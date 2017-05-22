using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class ProjectStatus:IEntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Status { get; set; }
    }
}