using System;
using Microsoft.AspNetCore.Http;

namespace TicketManager.Repository;

public interface IAttachmentsRepository
{
    Task<List<string>> Upload(List<IFormFile> files);
    Task DeleteFile(string fileName);
}
