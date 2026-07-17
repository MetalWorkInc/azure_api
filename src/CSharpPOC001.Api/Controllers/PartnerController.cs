using CSharpPOC001.Domain.Partner;
using CSharpPOC001.Services.Interfaces;

namespace CSharpPOC001.Api.Controllers;

public class PartnerController : BaseController<Partner>
{
    public PartnerController(IService<Partner> service) : base(service) { }
    protected override int GetId(Partner entity) => entity.Id;
}
