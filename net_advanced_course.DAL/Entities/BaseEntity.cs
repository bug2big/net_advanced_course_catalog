using System.ComponentModel.DataAnnotations;

namespace net_advanced_course.DAL.Entities
{
    public class BaseEntity
    {
        [Required()]
        public Guid Id { get; set; }
    }
}
