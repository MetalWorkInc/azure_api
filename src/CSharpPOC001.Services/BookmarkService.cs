using CSharpPOC001.Domain.Bookmarks;
using CSharpPOC001.Services.Interfaces;

namespace CSharpPOC001.Services;

public class BookmarkService : IService<Bookmark>
{
    private readonly List<Bookmark> _data = new();
    private int _nextId = 1;

    public Task<IEnumerable<Bookmark>> GetAllAsync() => Task.FromResult(_data.AsEnumerable());
    public Task<Bookmark?> GetByIdAsync(int id) => Task.FromResult(_data.FirstOrDefault(x => x.Id == id));
    public Task<Bookmark> CreateAsync(Bookmark entity) { entity.Id = _nextId++; entity.CreatedAt = DateTime.UtcNow; _data.Add(entity); return Task.FromResult(entity); }
    public Task<Bookmark?> UpdateAsync(int id, Bookmark entity) { var item = _data.FirstOrDefault(x => x.Id == id); if (item == null) return Task.FromResult<Bookmark?>(null); item.Title = entity.Title; item.Url = entity.Url; item.Description = entity.Description; return Task.FromResult<Bookmark?>(item); }
    public Task<bool> DeleteAsync(int id) { var item = _data.FirstOrDefault(x => x.Id == id); if (item == null) return Task.FromResult(false); _data.Remove(item); return Task.FromResult(true); }
}
