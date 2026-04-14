using KbsMobile.Core.Models;

namespace KbsMobile.Features.Records.Services;

public interface IRecordService
{
    Task<IReadOnlyList<FieldRecord>> GetAsync(string? search = null);
    Task<FieldRecord?> GetByIdAsync(string id);
    Task<FieldRecord> SaveAsync(FieldRecord record);
    Task DeleteAsync(string id);
}
