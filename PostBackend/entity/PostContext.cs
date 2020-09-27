using PostBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PostBackend.entity
{
    public class PostContext: DbContext
    {
        public PostContext() : base("PostContext")
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}