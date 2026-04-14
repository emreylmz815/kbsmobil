using KbsMobile.Core.Models;

namespace KbsMobile.Repositories;

public class MockRecordRepository : IRecordRepository
{
    private readonly List<FieldRecord> _records =
    [
        new() { Title = "Rögar Taşkını", Category = "Altyapi", Description = "Mazgal tıkalı", Latitude = 41.014, Longitude = 28.978, IsUrgent = true },
        new() { Title = "Aydınlatma Arızası", Category = "Elektrik", Description = "Sokak lambası yanmıyor", Latitude = 41.008, Longitude = 28.965, IsUrgent = false }
    ];

    public Task<IReadOnlyList<FieldRecord>> ListAsync() => Task.FromResult<IReadOnlyList<FieldRecord>>(_records.OrderByDescending(x => x.IncidentDate).ToList());
    public Task<FieldRecord?> FindAsync(string id) => Task.FromResult(_records.FirstOrDefault(x => x.Id == id));

    public Task<FieldRecord> UpsertAsync(FieldRecord record)
    {
        var existing = _records.FirstOrDefault(x => x.Id == record.Id);
        if (existing is null) _records.Add(record);
        else
        {
            _records.Remove(existing);
            _records.Add(record);
        }

        return Task.FromResult(record);
    }

    public Task RemoveAsync(string id)
    {
        _records.RemoveAll(x => x.Id == id);
        return Task.CompletedTask;
    }
}
