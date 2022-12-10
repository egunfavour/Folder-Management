using Folder_Operations.@interface;
using SautinSoft.Document;
using System.IO;

namespace Folder_Operations.Services
{
    public class FileServices : IFileServices
    {
        private static string rootPath = Directory.GetCurrentDirectory();
        private IHttpContextAccessor _httpContextAccessor;

        public FileServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string CreateFilesByFolderName(string FolderName, string FileName)
        {
            var createdFolder = Directory.GetDirectories(rootPath, FolderName, SearchOption.AllDirectories).FirstOrDefault();;
            var folderAddress = ((_httpContextAccessor.HttpContext.Request.IsHttps ? "https" : "http") + "://" + _httpContextAccessor.HttpContext.Request.Host + "/" + createdFolder);
            var filepath = Path.Combine(createdFolder, FileName);
            File.Create(filepath);
            return filepath;
        }
        public string DeleteFiles(string filepath)
        {
            if (File.Exists(filepath))
    
                File.Delete(filepath);
            return "sucessfully deleted";
        }
        public string DeleteAllFilesByFolderName(/* FolderName,*/ string folderPath)
        {
            if(Directory.Exists(folderPath))
            {
                var files = Directory.GetFiles(folderPath);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
                return $"All files in {folderPath} deleted!";
            }
            return "Folder path does not exist!";
        }
        public List<string> GetAllFilesByFolderName(string folderpath)
        {
            List<string> fileList = new List<string>();
            var files = Directory.GetFiles(folderpath);
            foreach (var fileName in files)
            {
                fileList.Add(fileName);
            }
            return fileList;
            //return "found";
        }
        public string GetAllFileContentByFilePath(string filepath)
        {
            DocumentCore documentContent = DocumentCore.Load(filepath);
            var content = documentContent.Content.ToString();
            return content;

        }
        //updates txt files.
        public string UpdateFileContent(string filepath, string newContent)
        {
            if (File.Exists(filepath))
            {
                File.WriteAllText(filepath, newContent);
                string content = File.ReadAllText(filepath);
                return content;
            }
            return "File does not exist!";

        }
        public string RenameFile(string filepath, string newfileName)
        {
            var newFilePath = Path.Combine(Path.GetDirectoryName(filepath), newfileName + Path.GetExtension(filepath));
            File.Move(filepath, newFilePath);
            return "";
        }
    }
}
