namespace Folder_Operations.@interface
{
    public interface IFileServices
    {
        string CreateFilesByFolderName(string FolderName, string FileName);
        string DeleteFiles(string filepath);
        string GetAllFileContentByFilePath(string filepath);
        List<string> GetAllFilesByFolderPath(string folderName);
        string RenameFile(string filepath, string newfileName);
        string UpdateFileContent(string filepath, string newContent);
        string DeleteAllFilesByFolderName(/*string FolderName,*/ string folderPath);
    }
}