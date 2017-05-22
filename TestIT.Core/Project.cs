using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class Project : IEntityBase
    {
        public Project()
        {
            TestRuns = new List<TestRun>();
            UserAssignments = new List<UserAssignment>();
        }

        public ICollection<UserAssignment> UserAssignments { get; set; }
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ProjectType ProjectType { get; set; }
        public int ProjectTypeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime CompletedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public int CompletedBy { get; set; }
        public User User { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public int ProjectStatusId { get; set; }
        public ICollection<TestRun> TestRuns { get; set; }
    }
}
