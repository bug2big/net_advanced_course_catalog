using System.ComponentModel.DataAnnotations;

namespace net_advanced_course.DAL.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public string? Image { get; set; }

        public Guid? ParentCategoryId { get; set; }

        public Category? ParentCategory { get; set; }
    }
}
