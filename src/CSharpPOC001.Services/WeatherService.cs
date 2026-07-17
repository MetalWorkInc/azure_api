using CSharpPOC001.Domain.Weather;
using CSharpPOC001.Services.Interfaces;

namespace CSharpPOC001.Services;

public class WeatherService : IService<WeatherForecast>
{
    private readonly List<WeatherForecast> _data = new();
    private int _nextId = 1;

    public WeatherService()
    {
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        for (int i = 1; i <= 5; i++)
        {
            _data.Add(new WeatherForecast
            {
                Id = _nextId++,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(i)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            });
        }
    }

    public Task<IEnumerable<WeatherForecast>> GetAllAsync() => Task.FromResult(_data.AsEnumerable());
    public Task<WeatherForecast?> GetByIdAsync(int id) => Task.FromResult(_data.FirstOrDefault(x => x.Id == id));
    public Task<WeatherForecast> CreateAsync(WeatherForecast entity) { entity.Id = _nextId++; _data.Add(entity); return Task.FromResult(entity); }
    public Task<WeatherForecast?> UpdateAsync(int id, WeatherForecast entity) { var item = _data.FirstOrDefault(x => x.Id == id); if (item == null) return Task.FromResult<WeatherForecast?>(null); item.TemperatureC = entity.TemperatureC; item.Summary = entity.Summary; item.Date = entity.Date; return Task.FromResult<WeatherForecast?>(item); }
    public Task<bool> DeleteAsync(int id) { var item = _data.FirstOrDefault(x => x.Id == id); if (item == null) return Task.FromResult(false); _data.Remove(item); return Task.FromResult(true); }
}
