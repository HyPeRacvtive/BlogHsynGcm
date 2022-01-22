using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogHsynGcm.Models
{
    public class Blogs
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [AllowHtml]
        public string Header { get; set; }
        [AllowHtml]
        public string BlogContent { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [MaxLength(20)]
        [Required]
        public string Image { get; set; }
        public int LikeCount { get; set; }
        public bool isSlider { get; set; }
        public bool isEditorschoice { get; set; }
        public bool isActive { get; set; }
        public bool isAdminActive { get; set; } = true;
        public int? WritersId { get; set; }
        public int? CategoriesId { get; set; }
        public Writers Writers { get; set; }
        public Categories Categories { get; set; }
        public List<Comments> Comments { get; set; }
    }
}