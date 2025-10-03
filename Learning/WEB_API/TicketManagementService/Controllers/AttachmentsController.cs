using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using TicketManagementService.Data;
using TicketManagementService.Repository;

namespace TicketManagementService.Controllers
{
    [Route("api/tickets/[controller]")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly IAttachmentsRepository _attachments;
        private readonly TicketContext _context;

        public AttachmentsController(IAttachmentsRepository attachments, TicketContext context)
        {
            _attachments = attachments;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> UploadAttachments(List<IFormFile> files)
            => Ok(await _attachments.Upload(files));
        

        [HttpDelete]
        public async Task<ActionResult> DeleteAttachment(string fileName)
        {
            try
            {
                await _attachments.DeleteFile(fileName);

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

            //Check if the file is missing. If missing terminate the process and return "File Not found"
            if (!System.IO.File.Exists(filePath))
                return NotFound("File Not found");

            //If the file is available continue with the below operations
            try
            {
                // FileExtensionContentTypeProvider class Provides a mapping between file extensions and MIME types.
                // MIME stands for Multi-purpose Internet Mail Extensions. 
                // MIME types form a standard way of classifying file types on the Internet.
                FileExtensionContentTypeProvider provider = new();

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
            catch (Exception)
            {
                return StatusCode(500, new { error = "Internal Server error;" });
            }
        }

    }
}
