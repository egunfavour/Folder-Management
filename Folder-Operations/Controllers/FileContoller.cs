using Folder_Operations.@interface;
using Microsoft.AspNetCore.Mvc;

namespace Folder_Operations.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FileContoller : ControllerBase
    {
        public readonly IFileServices _fileServices;

        public FileContoller(IFileServices fileServices)
        {
            _fileServices = fileServices;
        }

        [HttpPost]
        [Route("create-files-by-folder-id")]
        public IActionResult CreateFilesByFolderName(string FolderName, string FileName)
        {
            if (FolderName != null)
            {
                var newFileName = _fileServices.CreateFilesByFolderName(FolderName, FileName);
                return Ok(newFileName);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("delete-files-by-folder-name")]
        public IActionResult DeleteFilesByFolderName(string filePath)
        {
            _fileServices.DeleteFiles(filePath);
            return Ok(filePath + "successfully deleted");
        }

        [HttpGet]
        [Route("get-all-files-by-folder-id")]
        public IActionResult GetAllFilesByFolderName()
        {
            return null;
        }

        [HttpGet]
        [Route("get-all-content-by-file-Id")]
        public IActionResult GetAllFileContentByFileName()
        {
            return null;
        }
        [HttpPost]
        [Route("update-file-content")]
        public IActionResult UpdateFileContent()
        {
            return null;
        }
        [HttpPatch]
        [Route("rename-file")]
        public IActionResult RenameFile()
        {
            return null;
        }
    }
}
