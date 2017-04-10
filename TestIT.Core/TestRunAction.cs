using System;
using System.Collections.Generic;
using System.Text;

namespace TestIT.Entities
{
    public class TestRunAction:IEntityBase
    {
        public int Id { get; set; }
        public string Action { get; set; }
    }
}
