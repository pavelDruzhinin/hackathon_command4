﻿using SocialWeb.DataAccess.Mapping;
using SocialWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SocialWeb.DataAccess
{
    public class SocialWebContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Dialog> Dialogs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new DialogMap());
            base.OnModelCreating(modelBuilder);
        }
        public SocialWebContext() : base("DefaultConnection")
        {

        }
    }
}