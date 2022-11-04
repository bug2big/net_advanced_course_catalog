namespace CatalogService.Application.ApiModels
{
    public record CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Image { get; set; }

        public Guid? ParentCategoryId { get; set; }
    }
}
