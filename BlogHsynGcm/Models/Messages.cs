using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogHsynGcm.Models
{
    public class Messages
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string NameSurname { get; set; }
        [MaxLength(11)]
        public string Phone { get; set; }
        [MaxLength(30)]
        public string Mail { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool isRead { get; set; }
        [MaxLength(30)]
        public string Subject { get; set; }
        public string ipAdress { get; set; }
        public string Message { get; set; }
    }
}