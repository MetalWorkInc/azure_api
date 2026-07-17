using CSharpPOC001.Domain.Weather;
using CSharpPOC001.Domain.Bookmarks;
using CSharpPOC001.Domain.Contable;
using CSharpPOC001.Domain.Partner;
using CSharpPOC001.Services;
using CSharpPOC001.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IService<WeatherForecast>, WeatherService>();
builder.Services.AddSingleton<IService<Bookmark>, BookmarkService>();
builder.Services.AddSingleton<IService<Transaction>, TransactionService>();
builder.Services.AddSingleton<IService<Partner>, PartnerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

public partial class Program { }
