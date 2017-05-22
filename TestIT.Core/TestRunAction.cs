using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class TestRunAction:IEntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Action { get; set; }
    }
}
