using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialWeb.Models
{
    public class Dialog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Message> Messages { get; set; }
        public List<User> Users { get; set; }
    }
}