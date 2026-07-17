using CSharpPOC001.Domain.Contable;
using CSharpPOC001.Services.Interfaces;

namespace CSharpPOC001.Services;

public class TransactionService : IService<Transaction>
{
    private readonly List<Transaction> _data = new();
    private int _nextId = 1;

    public Task<IEnumerable<Transaction>> GetAllAsync() => Task.FromResult(_data.AsEnumerable());
    public Task<Transaction?> GetByIdAsync(int id) => Task.FromResult(_data.FirstOrDefault(x => x.Id == id));
    public Task<Transaction> CreateAsync(Transaction entity) { entity.Id = _nextId++; entity.Date = DateTime.UtcNow; _data.Add(entity); return Task.FromResult(entity); }
    public Task<Transaction?> UpdateAsync(int id, Transaction entity) { var item = _data.FirstOrDefault(x => x.Id == id); if (item == null) return Task.FromResult<Transaction?>(null); item.Description = entity.Description; item.Amount = entity.Amount; item.Type = entity.Type; return Task.FromResult<Transaction?>(item); }
    public Task<bool> DeleteAsync(int id) { var item = _data.FirstOrDefault(x => x.Id == id); if (item == null) return Task.FromResult(false); _data.Remove(item); return Task.FromResult(true); }
}
