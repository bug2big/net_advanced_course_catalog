using CatalogService.Application.ApiModels;
using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Services.Items;

public class ItemService : IItemService
{
    private readonly IDbContextProvider<Item> _dbContextProvider;
    private readonly IMapper _mapper;

    public ItemService(
        IDbContextProvider<Item> dbContextProvider,
        IMapper mapper)
    {
        _dbContextProvider = dbContextProvider;
        _mapper = mapper;
    }

    public async Task<ItemDto> GetByIdAsync(Guid itemId, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContextProvider
            .DbSet
            .FirstOrDefaultAsync(i => i.Id == itemId, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Item), itemId);
        }

        return _mapper.Map<ItemDto>(entity);
    }

    public async Task<IEnumerable<ItemDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var items = await _dbContextProvider.DbSet.ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ItemDto>>(items);
    }

    public async Task UpdateAsync(ItemDto itemDto, CancellationToken cancellationToken = default)
    {
        var item = _mapper.Map<Item>(itemDto);
        await _dbContextProvider.UpdateAsync(item, cancellationToken);
    }

    public async Task DeleteAsync(Guid itemId, CancellationToken cancellationToken = default)
    {
        var item = await _dbContextProvider.DbSet.FirstOrDefaultAsync(c => c.Id == itemId, cancellationToken);

        if (item == null)
        {
            throw new NotFoundException(nameof(Category), itemId);
        }

        await _dbContextProvider.DeleteAsync(item, cancellationToken);
    }

    public async Task AddAsync(ItemDto itemDto, CancellationToken cancellationToken = default)
    {
        var item = _mapper.Map<Item>(itemDto);
        await _dbContextProvider.AddAsync(item, cancellationToken);
    }
}
