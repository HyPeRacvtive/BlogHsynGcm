using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogHsynGcm.Models
{
    public class SocialFeed
    {
        public int Id { get; set; }
        [AllowHtml]
        public string FaceBook { get; set; }
        [AllowHtml]
        public string Twitter { get; set; }
        [AllowHtml]
        public string Instagram { get; set; }
        [AllowHtml]
        public string Youtube { get; set; }
        [AllowHtml]
        public string LinkEdIn { get; set; }

    }
}