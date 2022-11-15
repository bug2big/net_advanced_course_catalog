namespace CatalogService.Application.ApiModels
{
    public record ItemDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? Image { get; set; }

        public CategoryDto Category { get; set; } = null!;

        public double Price { get; set; }

        public int Amount { get; set; }
    }
}
