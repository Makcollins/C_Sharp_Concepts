using System;
using System.Threading.Tasks;


namespace TicketManagementService.Data;

public class UploadHandler
{
    public static async Task<List<string>> Upload(List<IFormFile> files)
    {
        // string extension = Path.GetExtension(file.FileName);
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
