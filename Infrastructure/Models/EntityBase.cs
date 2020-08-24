using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
