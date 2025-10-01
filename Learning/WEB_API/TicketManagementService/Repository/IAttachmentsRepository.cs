using System;

namespace TicketManagementService.Repository;

public interface IAttachmentsRepository
{
    Task<List<string>> Upload(List<IFormFile> files);
    void DeleteFile(string fileName);
}
