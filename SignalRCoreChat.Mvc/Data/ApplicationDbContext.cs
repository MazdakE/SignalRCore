using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalRCoreChat.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRCoreChat.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<ChatUser>
    {
        // Out DbContext holds a reference to ChatUser, and a ChatUser 
        // has one or many messages. That's why the DbSet comes in.
        public DbSet<Message> Messages { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
