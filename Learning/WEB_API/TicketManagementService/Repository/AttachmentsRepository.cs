using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketManagementService.Data;
using TicketManagementService.Repository;

namespace TicketManagementService;

public class AttachmentsRepository : IAttachmentsRepository
{
    private readonly TicketContext _context;

    public AttachmentsRepository(TicketContext context)
    {
        _context = context;
    }
    public async Task DeleteFile(string fileName)
    {
        //checks if the specified file exists and deletes if availlable from the The Directory
        if (File.Exists($"Uploads/{fileName}"))
            File.Delete($"Uploads/{fileName}");

        //checks for the filename in the database and deletes it if present
        var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.attachments.Contains(fileName));
        if (ticket != null)
        {
            ticket.attachments.Remove(fileName);
            await _context.SaveChangesAsync();
        }
    }

    //Allows multiple files uploading. takes any file
    //Takes a list of files then return their names/paths in a list.
    public async Task<List<string>> Upload(List<IFormFile> files)
    {
        List<string> fileNames = new();

        foreach (var file in files)
        {
            //generates and asign a unique to a file.
            string fileName = Path.GetRandomFileName() + DateTime.Now.ToString("Y_MM_dd_hh_mm_ss") + "_" + file.FileName;

            //sets the directory path where the file will be stored
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            //set the file path
            string filePath = Path.Combine(path, fileName);

            //Initializes a new instance of the FileStream class with a specific path and creation mode.
            //creates a new file in the specified path.
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                //reads the bytes from the provided file and writes them to the new created stream
                await file.CopyToAsync(stream);
            }
            fileNames.Add(fileName);
        }
        return fileNames;
    }
}
