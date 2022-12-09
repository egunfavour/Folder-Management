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
        [HttpPost]
        [Route("delete-files-By-Folder-Id")]
        public IActionResult DeleteAllFilesByFolderId()
        {
           
            return null;
        }

        [HttpGet]
        [Route("get-all-files-by-folder-id")]
        public IActionResult GetAllFilesByFolderName(string folderName)
        {
            var files = _fileServices.GetAllFilesByFolderName(folderName);
            return Ok(files);
        }

        [HttpGet]
        [Route("get-all-content-by-file-Id")]
        public IActionResult GetAllFileContentByFileName(string filepath)
        {
            var fileContent = _fileServices.GetAllFileContentByFilePath(filepath);
            return Ok(fileContent);
        }
        [HttpPost]
        [Route("update-file-content")]
        public IActionResult UpdateFileContent(string Filepath, string newContent)
        {
            var updatedContent = _fileServices.UpdateFileContent(Filepath, newContent);
            return Ok(updatedContent);
        }
        [HttpPatch]
        [Route("rename-file")]
        public IActionResult RenameFile(string filepath, string newfileName)
        {
            var newName = _fileServices.RenameFile(filepath, newfileName);
            return Ok(newName);
        }
    }
}
