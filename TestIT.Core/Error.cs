using System;
using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class Error : IEntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
