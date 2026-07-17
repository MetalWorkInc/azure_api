using Microsoft.AspNetCore.Mvc;

namespace CSharpPOC001.Api.Controllers;

[ApiController]
[Route("app/[controller]")]
public abstract class BaseController<T> : ControllerBase where T : class
{
    protected readonly Services.Interfaces.IService<T> _service;

    protected BaseController(Services.Interfaces.IService<T> service)
    {
        _service = service;
    }

    [HttpGet]
    public virtual async Task<ActionResult<IEnumerable<T>>> GetAll()
    {
        var items = await _service.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<T>> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public virtual async Task<ActionResult<T>> Create([FromBody] T entity)
    {
        var created = await _service.CreateAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = GetId(created) }, created);
    }

    [HttpPut("{id}")]
    public virtual async Task<ActionResult<T>> Update(int id, [FromBody] T entity)
    {
        var updated = await _service.UpdateAsync(id, entity);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }

    protected abstract int GetId(T entity);
}
