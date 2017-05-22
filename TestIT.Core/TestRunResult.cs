using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class TestRunResult:IEntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Result { get; set; }
    }
}
