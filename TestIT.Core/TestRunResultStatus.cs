using System;
using System.Collections.Generic;
using System.Text;

namespace TestIT.Entities
{
    public class TestRunResultStatus:IEntityBase
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
