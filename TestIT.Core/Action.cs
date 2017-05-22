using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class Action:IEntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
