using CatalogService.Application.ApiModels;
using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly IDbContextProvider<Category> _dbContextProvider;

    public CategoryService(
        IMapper mapper,
        IDbContextProvider<Category> dbContextProvider)
    {
        _dbContextProvider = dbContextProvider;
        _mapper = mapper;
    }

    public async Task<CategoryDto> GetByIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContextProvider
            .DbSet
            .FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Category), categoryId);
        }

        return _mapper.Map<CategoryDto>(entity);
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _dbContextProvider.DbSet.ToListAsync(cancellationToken);

        var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

        return categoryDtos;
    }

    public async Task UpdateAsync(CategoryDto categoryDto, CancellationToken cancellationToken = default)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _dbContextProvider.UpdateAsync(category, cancellationToken);
    }

    public async Task DeleteAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        var category = await _dbContextProvider.DbSet.FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);

        if (category == null) 
        {
            throw new NotFoundException(nameof(Category), categoryId);
        }

        await _dbContextProvider.DeleteAsync(category, cancellationToken);
    }

    public async Task AddAsync(CategoryDto categoryDto, CancellationToken cancellationToken = default)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _dbContextProvider.AddAsync(category, cancellationToken);
    }
}

