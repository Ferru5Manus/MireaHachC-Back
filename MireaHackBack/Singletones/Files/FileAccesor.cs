using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FileArchieveApi.Exceptions.FileExceptions;
using FileArchieveApi.Models.FileModels;
using Microsoft.AspNetCore.Mvc;

namespace FileArchieveApi.Singletones.Files
{
    public class FileAccesor
    {       
        public List<FileModel> GetFiles()
        {
            try
            {
                List<FileModel> files = new List<FileModel>();
                string folderPath = "/root/Pr5_1/Praktika5Api";
                DirectoryInfo di = new DirectoryInfo(folderPath);
                ProcessDirectory(di,files);

                return files;
            }
            catch (Exception ex)
            {
                throw new LoadFilesException(ex.Message);
            }
        }
        private void ProcessDirectory(DirectoryInfo directory, List<FileModel> fileList)
        {
           
            foreach (FileInfo file in directory.GetFiles())
            {
                fileList.Add(new FileModel(){ bytesVeight = file.Length, fileName = file.Name, filePath = file.FullName});
            }
            /*
            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {
                ProcessDirectory(subDirectory, fileList);
            }
            */
        }
        public List<RequiredFileModel> GetRequiredFiles(List<string> fileNames)
        {
            try
            {
                List<RequiredFileModel> requiredFiles = new List<RequiredFileModel>();
                string folderPath = "/root/Pr5_1/Praktika5Api";
                DirectoryInfo di = new DirectoryInfo(folderPath);
                List<FileInfo> filesInfo = di.GetFiles().ToList<FileInfo>();

                foreach (string filename in fileNames)
                {
                    requiredFiles.Add(new RequiredFileModel()
                    {
                        fileInfo = filesInfo.Find(x=>x.Name == filename),
                        data = System.IO.File.ReadAllBytes(filesInfo.Find(x=>x.Name == filename).FullName)
                    });
                }
                return requiredFiles;
            }
            catch(Exception ex)
            {
                throw new GetRequiredFilesException(ex.Message);
            }
        } 
    }
}