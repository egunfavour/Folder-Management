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
        public string DeleteAllFilesByFolderName(string FolderName, string folderPath)
        {
            var files = Directory.GetFiles(rootPath, "*", SearchOption.TopDirectoryOnly);
            if(File.Exists(folderPath))
            {
                foreach (var file in files)
                {
                    File.Delete(file);
                    return "Deleted all files";
                }
            }
            return "path does not exist";
        }
        public string GetAllFilesByFolderName(string folderpath)
        {
            var files = Directory.GetFiles(rootPath, "*", SearchOption.TopDirectoryOnly);
            foreach (var fileName in files)
            {
                return fileName;
            }
            return "found";
        }
        public string GetAllFileContentByFilePath(string filepath)
        {
            DocumentCore documentContent = DocumentCore.Load(filepath);
            return documentContent.Content.ToString();

        }
        public string UpdateFileContent(string filepath, string newContent)
        {
            if (File.Exists(filepath))
            {
                File.ReadAllText(filepath);
            }
            File.WriteAllText(filepath, newContent);
            return newContent;

        }
        public string RenameFile(string filepath, string newfileName)
        {
            var newFilePath = Path.Combine(Path.GetDirectoryName(filepath), newfileName + Path.GetExtension(filepath));
            File.Move(filepath, newFilePath);
            return "";
        }
    }
}
