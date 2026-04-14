using KbsMobile.Core.Models;
using KbsMobile.Repositories;

namespace KbsMobile.Features.Records.Services;

public class RecordService(IRecordRepository repository) : IRecordService
{
    public async Task<IReadOnlyList<FieldRecord>> GetAsync(string? search = null)
    {
        var items = await repository.ListAsync();
        if (string.IsNullOrWhiteSpace(search)) return items;

        return items.Where(x => x.Title.Contains(search, StringComparison.OrdinalIgnoreCase)
                             || x.Description.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
    }

    public Task<FieldRecord?> GetByIdAsync(string id) => repository.FindAsync(id);
    public Task<FieldRecord> SaveAsync(FieldRecord record) => repository.UpsertAsync(record);
    public Task DeleteAsync(string id) => repository.RemoveAsync(id);
}
