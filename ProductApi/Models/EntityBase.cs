using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
