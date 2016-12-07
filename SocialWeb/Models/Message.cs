using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialWeb.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DialogId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string Text { get; set; }

        //public Dialog Dialog { get; set; }
        //public User user { get; set; }
    }
}