using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class ProjectType:IEntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
