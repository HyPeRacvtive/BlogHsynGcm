using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogHsynGcm.Models
{
    public class Comments
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string Comment { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string ipAdres { get; set; }
        public bool isActive { get; set; } = false;
        public bool isRead { get; set; } = false;
        public int? UsersId { get; set; }
        public int? BlogId { get; set; }
        public Users User { get; set; }
        public Blogs Blog { get; set; }
    }
}