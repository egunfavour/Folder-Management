using Folder_Operations.@interface;
using Microsoft.AspNetCore.Mvc;

namespace Folder_Operations.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class FolderController : ControllerBase
    {
        public readonly IFolderServices _folderServices;
        public FolderController(IFolderServices folderServices)
        {
            _folderServices = folderServices;
        }
        [HttpPost]
        [Route("create-folder")]
        public  IActionResult CreateFolder(string name, string path)
        {
            var folder = _folderServices.CreateFolder(name, path);
            return Ok(folder);
        }
        [HttpPost]
        [Route("create-subfolder-by-id")]
        public IActionResult CreateSubFoldersById(string FolderName, string newFolderName)
        {
            var folder = _folderServices.CreateSubFoldersById(FolderName, newFolderName);
            return Ok(folder);

        }
        
        [HttpDelete]
        [Route("delete-folder")]
        public IActionResult DeleteFolder(string folderName, string folderPath)
        {
            var newFolderName = _folderServices.DeleteFolder(folderName, folderPath);
            return Ok(newFolderName);
        }
        [HttpPost]
        [Route("delete-sub-folders-by-Id")]
        public IActionResult DeleteSubFolderById(string subFolderName, string folderPath)
        {
            var newSubFolderName = _folderServices.DeleteSubFolderById(subFolderName, folderPath);
            return Ok(newSubFolderName);
        }
        
        [HttpGet]
        [Route("get-all-folders")]
        public IActionResult GetAllFolders()
        {
          var allFolders =  _folderServices.GetAllFolders();
            return Ok(allFolders);
        }
        [HttpGet]
        [Route("get-all-sub-folders-by-folder-name")]
        public IActionResult GetAllSubFoldersByFolderName(string folderPath)
        {
          var folders = _folderServices.GetAllSubFoldersByFolderName(folderPath);
           return Ok(folders);
        }
        [HttpGet]
        [Route("rename-folder")]
        public IActionResult RenameAllFolders(string FolderName, string FolderPath, string NewFolderName)
        {
            var Folder = _folderServices.RenameAllFolders(FolderName, FolderPath, NewFolderName);
            return Ok(Folder);
        }





    }
}
