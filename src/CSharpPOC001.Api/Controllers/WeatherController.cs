using CSharpPOC001.Domain.Weather;
using CSharpPOC001.Services.Interfaces;

namespace CSharpPOC001.Api.Controllers;

public class WeatherController : BaseController<WeatherForecast>
{
    public WeatherController(IService<WeatherForecast> service) : base(service) { }
    protected override int GetId(WeatherForecast entity) => entity.Id;
}
