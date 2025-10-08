using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TicketManager.Data;

namespace TicketManager.Repository;

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
    public async Task<List<string>> Upload(List<IFormFile> newfiles)
    {
        List<string> fileNames = new();
        var newfilesNames = newfiles.Select(x => x.FileName).Distinct().ToList();

        List<IFormFile> files = new();

        foreach (var fileName in newfilesNames)
        {
            files.Add(newfiles.FirstOrDefault(x => x.FileName == fileName)!);
        }

        foreach (var file in files)
        {
            string fileNameOnly = Path.GetFileNameWithoutExtension(file.FileName);
            string fileExtension = Path.GetExtension(file.FileName);
            //generates and asign a unique name to a file.
            string fileName = fileNameOnly + "_" + Path.GetRandomFileName() + "_" + DateTime.Now.ToString("Y_MM_dd_hh_mm_ss") + fileExtension;


            //create directory if exists
            if (!Directory.Exists("Uploads"))
                Directory.CreateDirectory("Uploads");

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
