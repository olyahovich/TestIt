using System;

namespace TestIT.Entities
{
    public interface IEntityBase
    {
        int Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
    }
}
