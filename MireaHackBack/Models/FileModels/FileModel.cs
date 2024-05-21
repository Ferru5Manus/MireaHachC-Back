using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileArchieveApi.Models.FileModels
{
    public class FileModel
    {
        public string fileName {get;set;}
        public string filePath {get;set;}
        public long? bytesVeight {get;set;}
        public string[] content {get;set;}
    }
}