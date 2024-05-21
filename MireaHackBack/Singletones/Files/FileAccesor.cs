using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FileArchieveApi.Exceptions.FileExceptions;
using FileArchieveApi.Models.FileModels;
using Microsoft.AspNetCore.Mvc;
using MireaHackBack.Exceptions.FileExceptions;

namespace FileArchieveApi.Singletones.Files
{
    public class FileAccesor
    {       
        public void RemoveProject(string directoryPath)
        {
            try
            {
                Directory.Delete(directoryPath,true);
            }
            catch(Exception ex)
            {
                throw new RemoveDirectoryException(ex.Message);
            }
        }
        public void ModifyFiles(List<FileModel> fileModels)
        {
            try
            {
                foreach(var file in fileModels)
                {
                    File.WriteAllText(file.filePath, string.Join("\n", file.content));
                }
            }
            catch(Exception ex)
            {
                throw new ModifyFileException(ex.Message);
            }
        }
        public void RemoveFile(string filePath)
        {
            try
            {
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                throw new RemoveFileException(ex.Message);
            }
        }
        public FileModel CreateFile(string content, string filePath)
        {
            try
            {
                File.WriteAllText(filePath, content);

                var fileModel = new FileModel
                {
                    fileName = Path.GetFileName(filePath),
                    filePath = filePath,
                    bytesVeight = File.ReadAllBytes(filePath).Length,
                    content = File.ReadAllLines(filePath)
                };
                return fileModel;

            }
            catch(Exception ex)
            {
                throw new CreateFileException(ex.Message);
            }
        }
        
        public List<FileModel> GetFiles(string path)
        {
            try
            {
                List<FileModel> files = new List<FileModel>();
                string folderPath = "/root/TestFiles";
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
                fileList.Add(new FileModel(){ bytesVeight = file.Length, fileName = file.Name, filePath = file.FullName, content = System.IO.File.ReadAllLines(file.FullName)});
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
                string folderPath = "/root/";
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