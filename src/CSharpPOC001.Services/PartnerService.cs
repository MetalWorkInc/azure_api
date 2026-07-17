using CSharpPOC001.Domain.Partner;
using CSharpPOC001.Services.Interfaces;

namespace CSharpPOC001.Services;

public class PartnerService : IService<Partner>
{
    private readonly List<Partner> _data = new();
    private int _nextId = 1;

    public Task<IEnumerable<Partner>> GetAllAsync() => Task.FromResult(_data.AsEnumerable());
    public Task<Partner?> GetByIdAsync(int id) => Task.FromResult(_data.FirstOrDefault(x => x.Id == id));
    public Task<Partner> CreateAsync(Partner entity) { entity.Id = _nextId++; entity.CreatedAt = DateTime.UtcNow; _data.Add(entity); return Task.FromResult(entity); }
    public Task<Partner?> UpdateAsync(int id, Partner entity) { var item = _data.FirstOrDefault(x => x.Id == id); if (item == null) return Task.FromResult<Partner?>(null); item.Name = entity.Name; item.Email = entity.Email; item.Phone = entity.Phone; return Task.FromResult<Partner?>(item); }
    public Task<bool> DeleteAsync(int id) { var item = _data.FirstOrDefault(x => x.Id == id); if (item == null) return Task.FromResult(false); _data.Remove(item); return Task.FromResult(true); }
}
