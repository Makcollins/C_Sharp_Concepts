using System;
using Microsoft.AspNetCore.Mvc;
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
    public void DeleteFile(string fileName)
    {
        if (File.Exists($"Uploads/{fileName}"))
            File.Delete($"Uploads/{fileName}");
    }

    public async Task<List<string>> Upload(List<IFormFile> files)
    {
        List<string> fileNames = new();
        foreach (var file in files)
        {
            string fileName = Path.GetRandomFileName() + DateTime.Now.ToString("yyyy_mm_dd_hh_mm_ss") + "_" + file.FileName;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            fileNames.Add(fileName);
        }
        return fileNames;
    }
}
