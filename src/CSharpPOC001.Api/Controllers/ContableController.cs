using CSharpPOC001.Domain.Contable;
using CSharpPOC001.Services.Interfaces;

namespace CSharpPOC001.Api.Controllers;

public class ContableController : BaseController<Transaction>
{
    public ContableController(IService<Transaction> service) : base(service) { }
    protected override int GetId(Transaction entity) => entity.Id;
}
