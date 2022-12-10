using Folder_Operations.@interface;
using Microsoft.AspNetCore.Mvc;

namespace Folder_Operations.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FileController : ControllerBase
    {
        public readonly IFileServices _fileServices;

        public FileController(IFileServices fileServices)
        {
            _fileServices = fileServices;
        }

        [HttpPost]
        [Route("create-files-by-folder-Name")]
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
        [HttpDelete]
        [Route("delete-all-files-By-Folder-Name")]
        public IActionResult DeleteAllFilesByFolderName(string folderName, string folderPath )
        {
            var fileNames = _fileServices.DeleteAllFilesByFolderName(folderName, folderPath);
            return Ok(fileNames);
        }

        [HttpGet]
        [Route("get-all-files-by-folder-Name")]
        public IActionResult GetAllFilesByFolderName(string folderName)
        {
            var files = _fileServices.GetAllFilesByFolderName(folderName);
            return Ok(files);
        }

        [HttpGet]
        [Route("get-all-content-by-file-Name")]
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
