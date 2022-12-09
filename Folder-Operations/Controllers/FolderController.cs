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
        public IActionResult CreateSubFoldersById(string FolderName, string SubFolderName)
        {
            var folder = _folderServices.CreateSubFoldersById(FolderName,SubFolderName);
            return Ok(folder);

        }
        
        [HttpPost]
        [Route("delete-folder")]
        public IActionResult DeleteFolder(string folderName, string folderPath)
        {
            var newFolderName = _folderServices.DeleteFolder(folderName, folderPath);
            return Ok(newFolderName + "successfully deleted");
        }
        [HttpPost]
        [Route("delete-sub-folders-by-Id")]
        public IActionResult DeleteSubFolderById(string subFolderName, string folderPath)
        {
            var newSubFolderName = _folderServices.DeleteSubFolderById(subFolderName, folderPath);
            return Ok(newSubFolderName + "sucessfully deleted");
        }
        
        [HttpGet]
        [Route("get-all-folders")]
        public IActionResult GetAllFolders()
        {
            return null;
        }
        [HttpGet]
        [Route("get-all-sub-folders-by-folder-Id")]
        public IActionResult GetAllSubFoldersByFolderName(string folderPath)
        {
          var folders = _folderServices.GetAllSubFoldersByFolderName(folderPath);
           return Ok(folders);
        }
       


    }
}
