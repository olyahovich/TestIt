using System;

namespace TestIT.Entities
{
    public class Action:IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
