﻿using SocialWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SocialWeb.DataAccess.Mapping
{
    public class DialogMap : EntityTypeConfiguration<Dialog>
    {
        public DialogMap()
        {
            ToTable("Dialogs");
            HasKey(x => x.Id);
            //HasMany(x => x.Messages);
            //HasRequired(x => x.Users);
        }
    }
}