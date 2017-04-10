using System;
using System.Collections.Generic;
using System.Text;

namespace TestIT.Entities
{
    public class ProjectType:IEntityBase
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
