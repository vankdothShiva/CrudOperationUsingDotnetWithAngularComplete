using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication3.Model
{
    public class DbContext_Login : DbContext
    {
        public DbContext_Login(DbContextOptions<DbContext_Login> options) : base(options)
        {
        }
        public DbSet<Login> Logins { get; set; }
        public DbSet<SignUp> SignUp { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SignUp>().ToTable("UserSignUps");
            modelBuilder.Entity<Login>().ToTable("Logins");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SignUp>()
                .HasOne(s => s.Login)
                .WithOne(l => l.UserSignUp)
                .HasForeignKey<Login>(l => l.UserSignUpId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
    }
