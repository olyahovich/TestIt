using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class Object:IEntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
