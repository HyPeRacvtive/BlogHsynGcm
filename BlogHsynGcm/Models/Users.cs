using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogHsynGcm.Models
{
    public class Users
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string NameSurName { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
        [MaxLength(30)]
        public string Mail { get; set; }
        [MaxLength(20)]
        public string Image { get; set; }
        public string ipAdress { get; set; }

        public List<Blogs> Blogs { get; set; }
        public List<Comments> Comments { get; set; }
    }
}