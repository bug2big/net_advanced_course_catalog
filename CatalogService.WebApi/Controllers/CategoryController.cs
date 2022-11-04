using CatalogService.Application.Services.Categories;
using CatalogService.Application.ApiModels;

namespace CatalogService.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status200OK)]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken) 
    {
        return Ok(await _categoryService.GetByIdAsync(id, cancellationToken));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _categoryService.GetAllAsync(cancellationToken);
        return Ok(categories);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateAsync(CategoryDto categoryDto, CancellationToken cancellationToken = default)
    {
        await _categoryService.UpdateAsync(categoryDto, cancellationToken);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CategoryDto categoryDto, CancellationToken cancellationToken = default)
    {
        await _categoryService.AddAsync(categoryDto, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _categoryService.DeleteAsync(id, cancellationToken);
        return Ok();
    }
}