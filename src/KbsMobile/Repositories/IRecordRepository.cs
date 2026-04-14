using KbsMobile.Core.Models;

namespace KbsMobile.Repositories;

public interface IRecordRepository
{
    Task<IReadOnlyList<FieldRecord>> ListAsync();
    Task<FieldRecord?> FindAsync(string id);
    Task<FieldRecord> UpsertAsync(FieldRecord record);
    Task RemoveAsync(string id);
}
