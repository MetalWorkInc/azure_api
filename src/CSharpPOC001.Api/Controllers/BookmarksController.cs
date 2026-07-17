using CSharpPOC001.Domain.Bookmarks;
using CSharpPOC001.Services.Interfaces;

namespace CSharpPOC001.Api.Controllers;

public class BookmarksController : BaseController<Bookmark>
{
    public BookmarksController(IService<Bookmark> service) : base(service) { }
    protected override int GetId(Bookmark entity) => entity.Id;
}
