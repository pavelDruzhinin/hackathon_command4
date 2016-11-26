using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialWeb.Models
{
    public class UserMessage
    {
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public int MessageId { get; set; }
    }
}