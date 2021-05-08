using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdditionBonusTask.Areas.Identity.Data;
using AdditionBonusTask.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdditionBonusTask.Data
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        public AuthDbContext() { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //One-to-many relationship between User and Post
            builder.Entity<ApplicationUser>()
                .HasMany<Post>(s => s.Posts)
                .WithOne(g => g.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //One-to-many relationship between Comment and Post
            builder.Entity<Post>()
                .HasMany<Comment>(s => s.Comments)
                .WithOne(g => g.Post)
                .HasForeignKey(s => s.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            //One-to-many relationship between Comment and User
            builder.Entity<ApplicationUser>()
                .HasMany<Comment>(s => s.Comments)
                .WithOne(g => g.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //One-to-many relationship between Friend and Person
            //builder.Entity<Person>()
            //    .HasMany<Friend>(s => s.Friends)
            //    .WithOne(g => g.Person)
            //    .HasForeignKey(s => s.PersonId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //One-to-one relationship between User and Person
            builder.Entity<Person>()
            .HasOne<ApplicationUser>(ad => ad.User)
            .WithOne(s => s.Persons)
            .HasForeignKey<Person>(ad => ad.FriendSenderId);

            //One-to-one relationship between User and Friends
            //builder.Entity<Friend>()
            //    .HasOne<ApplicationUser>(s => s.User)
            //    .WithOne(g => g.Friends)
            //    .HasForeignKey<Friend>(s => s.FriendReceiverId);

            //One-to-one relationship between User and Message
            builder.Entity<ApplicationUser>()
                .HasOne<Message>(s => s.Messages)
                .WithOne(g => g.User)
                .HasForeignKey<Message>(s => s.UserReceiverId);

            //One-to-one relationship between User and Dialog
            builder.Entity<ApplicationUser>()
            .HasOne<Dialog>(s => s.Dialogs)
            .WithOne(ad => ad.User)
            .HasForeignKey<Dialog>(ad => ad.UserSenderId);

            //One-to-many relationship between Dialog and Message
            builder.Entity<Dialog>()
               .HasMany<Message>(s => s.Messages)
               .WithOne(g => g.Dialog)
               .HasForeignKey(s => s.DialogId)
               .OnDelete(DeleteBehavior.Cascade);
        }


       public DbSet<Post> Posts { get; set; }
       public DbSet<Message> Messages { get; set; }
       public DbSet<Friend> Friends { get; set; }
       public DbSet<Comment> Comments { get; set; }
       public DbSet<Person> Persons{ get; set; }
       public DbSet<Dialog> Dialogs{ get; set; }

    }
}
