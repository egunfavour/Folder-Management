using SautinSoft.Document;

namespace Folder_Operations.Services
{
    public class FileServices : IFileServices
    {
        private static string rootPath = Directory.GetCurrentDirectory();
        public string CreateFilesByFolderName(string FolderName, string FileName)
        {
            var filepath = Path.Combine(rootPath, FolderName, FileName);
            File.Create(filepath);
            return filepath;
        }
        public string DeleteFiles(string filepath)
        {
            if (File.Exists(filepath))
                File.Delete(filepath);
            return "sucessfully deleted";
        }
        public string GetAllFilesByFolderName(string folderName)
        {
            var files = Directory.GetFiles(rootPath, "*", SearchOption.TopDirectoryOnly);
            return "";
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
            System.IO.File.Move(filepath, newFilePath);
            return "";
        }
    }
}
