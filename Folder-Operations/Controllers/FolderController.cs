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
        public IActionResult DeleteFolder()
        {
            return null;
        }
        [HttpPost]
        [Route("delete-sub-folders-by-Id")]
        public IActionResult DeleteSubFolderById()
        {
            return null;
        }
        [HttpPost]
        [Route("delete-files-By-Folder-Id")]
        public IActionResult DeleteFilesByFolderId()
        {
            return null;
        }
        [HttpGet]
        [Route("get-all-folders")]
        public IActionResult GetAllFolders()
        {
            return null;
        }
        [HttpGet]
        [Route("get-all-sub-folders-by-folder-Id")]
        public IActionResult GetAllSubFoldersByFolderId()
        {
            return null;
        }
       


    }
}
