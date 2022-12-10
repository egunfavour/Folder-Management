namespace Folder_Operations.@interface
{
    public interface IFolderServices
    {
        string CreateFolder(string name, string path);
        string CreateSubFoldersByName(string FolderName, string newFolderName);
        string DeleteFolder(string FolderName, string FolderPath);
        string DeleteSubFolderByName(string SubFolderName, string FolderPath);
        List<string> GetAllFolders();
        List<string> GetAllSubFoldersByFolderpath(string folderPath);
        string RenameAllFolders(string FolderName, string FolderPath, string NewFolderName);
    }
}