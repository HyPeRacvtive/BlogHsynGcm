using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogHsynGcm.Models
{
    public class Settings
    {
        public int Id { get; set; }
        [AllowHtml]
        [MaxLength(20)]
        public string Logo { get; set; }
        public int LogoWidth { get; set; }
        public int LogoHeight { get; set; }
        public int VisitorCount { get; set; }
    }
}