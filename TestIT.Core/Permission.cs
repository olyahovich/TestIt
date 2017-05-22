using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class Permission:IEntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public Object Object { get; set; }
        public int ObjectId { get; set; }
        public Action Action { get; set; }
        public int ActionId { get; set; }
    }
}
