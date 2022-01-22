using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogHsynGcm.Models
{
    public class Categories
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public bool isAdminActive { get; set; } = true;

        [MaxLength(20)]
        public string Color { get; set; }

        public List<Blogs> Blogs { get; set; }
    }
}