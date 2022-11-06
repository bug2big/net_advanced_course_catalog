using CatalogService.Application.Services.Items;
using CatalogService.Application.ApiModels;
using CatalogService.Application.Common.Exceptions;

namespace net_advanced_course.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _itemService.GetByIdAsync(id, cancellationToken));
        }
        catch (NotFoundException ex) 
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _itemService.GetAllAsync(cancellationToken);
        return Ok(categories);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateAsync(ItemDto itemDto, CancellationToken cancellationToken = default)
    {
        await _itemService.UpdateAsync(itemDto, cancellationToken);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(ItemDto itemDto, CancellationToken cancellationToken = default)
    {
        await _itemService.AddAsync(itemDto, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _itemService.DeleteAsync(id, cancellationToken);
        return Ok();
    }
}
