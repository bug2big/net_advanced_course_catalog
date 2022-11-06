namespace CatalogService.Domain.Common
{
    public class BaseEntity
    {
        [Required()]
        public Guid Id { get; set; }
    }
}
