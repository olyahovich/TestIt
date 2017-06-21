using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestIT.Entities;


namespace TestIT.Web.ViewModels.Default
{
   public class ProjectViewModel
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProjectTypeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime CompletedOn { get; set; }
        public string UserId { get; set; }
        public string ModifiedBy { get; set; }
        public string CompletedBy { get; set; }
        public int ProjectStatusId { get; set; }

        internal bool IsModelValid()
        {
            throw new NotImplementedException();
        }

    }
}
