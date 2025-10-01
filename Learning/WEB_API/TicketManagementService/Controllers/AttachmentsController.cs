using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using TicketManagementService.Repository;

namespace TicketManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly IAttachmentsRepository _attachments;

        public AttachmentsController(IAttachmentsRepository attachments)
        {
            _attachments = attachments;
        }

        [HttpPost]
        public async Task<ActionResult> UploadAttachments(List<IFormFile> files)
        {
            return Ok(await _attachments.Upload(files));
        }

        [HttpDelete]
        public ActionResult DeleteAttachment(string fileName)
        {
            try
            {
                _attachments.DeleteFile(fileName);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Server Error!" });
            }
        }

        [HttpGet]
        [Route("download/{fileName}")]
        public async Task<ActionResult> DownloadFile(string fileName)
        {
            //return the full path of the file (Uploads/fileName.ext)
            //all files are store in the "Uploads" folder.
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);

            // FileExtensionContentTypeProvider class Provides a mapping between file extensions and MIME types.
            // MIME stands for Multi-purpose Internet Mail Extensions. 
            // MIME types form a standard way of classifying file types on the Internet.

            FileExtensionContentTypeProvider provider = new ();

            // The method TryGetContentType(String, String) takes a path, and returns a string (mime type)
            if (!provider.TryGetContentType(filePath, out string? contentType))
            {
                // "application/octet-stream" allows transfer of raw binary data. 
                // It is used when Conte type / MIME type is unknown
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);

            return File(bytes, contentType, Path.GetFileName(filePath));
        }
        
    }
}
