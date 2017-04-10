using System;
using System.Collections.Generic;
using System.Text;

namespace TestIT.Entities
{
    public class UserAssignment:IEntityBase
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
