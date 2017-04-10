using System;
using System.Collections.Generic;
using System.Text;

namespace TestIT.Entities
{
    public class TestRunFile:IEntityBase
    {
        public int Id { get; set; }
        public File File { get; set; }
        public int FileId { get; set; }
    }
}
