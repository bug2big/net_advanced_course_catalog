using CatalogService.Domain.Common;

namespace CatalogService.Domain.Entities
{
    public class Item : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? Image { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        [Required]
        public double Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }
    }
}
