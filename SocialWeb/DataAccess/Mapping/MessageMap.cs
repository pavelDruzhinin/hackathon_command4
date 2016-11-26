using SocialWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SocialWeb.DataAccess.Mapping
{
    public class MessageMap : EntityTypeConfiguration<Message>
    {
        public MessageMap()
        {
            ToTable("Messages");
            HasKey(x => x.Id);
            HasMany(x => x.)
        }
    }
}