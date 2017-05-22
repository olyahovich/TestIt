﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TestIT.Entities
{
    public class File : IEntityBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string NetworkPath { get; set; }
        public string Uri { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public User User { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public FileType FileType { get; set; }
        public int FileTypeId { get; set; }
    }
}
