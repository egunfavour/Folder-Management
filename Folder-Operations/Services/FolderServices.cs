using Folder_Operations.@interface;
using Microsoft.AspNetCore.Mvc;
using System.IO;
namespace Folder_Operations.Services
{
    public class FolderServices : IFolderServices
    {
        private static string rootPath = Directory.GetCurrentDirectory();
        private IHttpContextAccessor _httpContextAccessor;
        public FolderServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string CreateFolder(string name, string path)
        {
            try
            {
                if (path == null)
                {
                    var createdFolder = Directory.CreateDirectory(Path.Combine(rootPath, name));
                    var folderAddress = ((_httpContextAccessor.HttpContext.Request.IsHttps ? "https" : "http") + "://" + _httpContextAccessor.HttpContext.Request.Host + "/" + createdFolder.Name);
                    return createdFolder.FullName;
                }
                var folder = Directory.CreateDirectory(Path.Combine(rootPath, path, name));
                return folder.Name; 
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        public string CreateSubFoldersByName(string FolderName, string newFolderName)
        {
            try
            {

                var createdFolder = Directory.CreateDirectory(Path.Combine(rootPath, FolderName));
                var folderAddress = ((_httpContextAccessor.HttpContext.Request.IsHttps ? "https" : "http") + "://" + _httpContextAccessor.HttpContext.Request.Host + "/" + createdFolder.Name);
                var CreatedFolder = Directory.GetDirectories(rootPath, FolderName, SearchOption.AllDirectories).FirstOrDefault();
                if (FolderName == null)
                {
                    return "Folder name does not exist";
                }
                Directory.CreateDirectory(Path.Combine(CreatedFolder, newFolderName));
                return newFolderName;
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }

        }
        public string DeleteFolder(string FolderName, string FolderPath)
        {
            try
            {
                if (Directory.Exists(FolderPath))
                {
                    Directory.Delete(FolderPath);
                }
                return (FolderName + " folder Successfully deleted.");
            return "folder path does not exists";
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        public string DeleteSubFolderByName(string SubFolderName, string FolderPath)
        {
            try
            {
                string siteHost = (_httpContextAccessor.HttpContext.Request.IsHttps ? "https" : "http") + "://" + _httpContextAccessor.HttpContext.Request.Host;
                if (FolderPath == null) FolderPath = "";
                if (FolderPath.Contains(siteHost))
                {
                    int startIndex = siteHost.Length;
                    string newPath = FolderPath.Substring(startIndex);
                    FolderPath = rootPath + '/' + newPath;
                    Directory.Delete(Path.Combine(FolderPath, SubFolderName), true);
                    return (SubFolderName + " folder Successfully deleted.");
                }
                Directory.Delete(Path.Combine(rootPath, FolderPath, SubFolderName), true);
                return (SubFolderName + " folder Successfully deleted.");
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        public List<string> GetAllFolders()
        {
            var file = Directory.GetDirectories(rootPath);
            List<string> Folds = new();
            foreach (var i in file)
            {
                int startIndex = rootPath.Length;
                Folds.Add((_httpContextAccessor.HttpContext.Request.IsHttps ? "https" : "http") + "://" + _httpContextAccessor.HttpContext.Request.Host + i.Substring(startIndex));
            }
            return Folds;

        }
        public List<string> GetAllSubFoldersByFolderpath(string folderPath)
        {
            List<string> folders = new();
            var files = Directory.GetDirectories(folderPath);
            foreach (var folderName in files)
            {
                folders.Add(folderName);
            }
            return folders;
        }      
        public string RenameAllFolders(string FolderName, string FolderPath, string NewFolderName)
        {
            try
            {
                string siteHost = (_httpContextAccessor.HttpContext.Request.IsHttps ? "https" : "http") + "://" + _httpContextAccessor.HttpContext.Request.Host;
                if (FolderPath.Contains(siteHost))
                {
                    int startIndex = siteHost.Length;
                    string newPath = FolderPath.Substring(startIndex);
                    FolderPath = rootPath + '/' + newPath;
                }
                Directory.Move(Path.Combine(FolderPath, FolderName), Path.Combine(FolderPath, NewFolderName));
                return "Successfully Renamed";
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }

        
    }
}
