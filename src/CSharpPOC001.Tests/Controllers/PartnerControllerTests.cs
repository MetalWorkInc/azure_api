using CSharpPOC001.Api.Controllers;
using CSharpPOC001.Domain.Partner;
using CSharpPOC001.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CSharpPOC001.Tests.Controllers;

public class PartnerControllerTests
{
    private readonly Mock<IService<Partner>> _mockService;
    private readonly PartnerController _controller;

    public PartnerControllerTests()
    {
        _mockService = new Mock<IService<Partner>>();
        _controller = new PartnerController(_mockService.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsOkWithItems()
    {
        var items = new List<Partner> { new() { Id = 1, Name = "Test Partner" } };
        _mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(items);

        var result = await _controller.GetAll();

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returned = Assert.IsAssignableFrom<IEnumerable<Partner>>(okResult.Value);
        Assert.Single(returned);
    }

    [Fact]
    public async Task GetById_ExistingId_ReturnsOk()
    {
        var item = new Partner { Id = 1, Name = "Test Partner" };
        _mockService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(item);

        var result = await _controller.GetById(1);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsType<Partner>(okResult.Value);
    }

    [Fact]
    public async Task GetById_NonExistingId_ReturnsNotFound()
    {
        _mockService.Setup(s => s.GetByIdAsync(99)).ReturnsAsync((Partner?)null);

        var result = await _controller.GetById(99);

        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task Create_ReturnsCreatedAtAction()
    {
        var item = new Partner { Id = 1, Name = "Test Partner" };
        _mockService.Setup(s => s.CreateAsync(item)).ReturnsAsync(item);

        var result = await _controller.Create(item);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        Assert.IsType<Partner>(createdResult.Value);
    }

    [Fact]
    public async Task Delete_ExistingId_ReturnsNoContent()
    {
        _mockService.Setup(s => s.DeleteAsync(1)).ReturnsAsync(true);

        var result = await _controller.Delete(1);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Delete_NonExistingId_ReturnsNotFound()
    {
        _mockService.Setup(s => s.DeleteAsync(99)).ReturnsAsync(false);

        var result = await _controller.Delete(99);

        Assert.IsType<NotFoundResult>(result);
    }
}
