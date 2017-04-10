using System.Collections.Generic;

namespace TestIT.Entities
{
    public class Permission:IEntityBase
    {
        public int Id { get; set; }
        public Object Object { get; set; }
        public int ObjectId { get; set; }
        public Action Action { get; set; }
        public int ActionId { get; set; }

        public Permission()
        {
            Objects = new List<Object>();
            Actions = new List<Action>();
        }

        public ICollection<Action> Actions { get; set; }

        public ICollection<Object> Objects { get; set; }
    }
}
