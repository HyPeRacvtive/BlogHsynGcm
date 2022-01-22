using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogHsynGcm.Models
{
    public class Writers
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string NameSurname { get; set; }
        [MaxLength(20)]
        public string UserName { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
        [MaxLength(30)]
        public string Mail { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
        [AllowHtml]
        public string About { get; set; }
        [MaxLength(40)]
        public string AboutHeader { get; set; }
        public string ShortAbout { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string Image { get; set; }
        public List<Blogs> Blog { get; set; }
        
    }
}