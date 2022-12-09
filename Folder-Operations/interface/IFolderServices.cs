namespace Folder_Operations.@interface
{
    public interface IFolderServices
    {
        string CreateFolder(string name, string path);
        string CreateSubFoldersById(string FolderName, string SubFolderName);
        string DeleteFolder(string FolderName, string FolderPath);
        string DeleteSubFolderById(string SubFolderName, string FolderPath);
        List<string> GetAllFolders();
        string GetAllSubFoldersByFolderName();
        string GetFoldersByName(string folderName);
        string RenameAllFolders(string FolderName, string FolderPath, string NewFolderName);
    }
}