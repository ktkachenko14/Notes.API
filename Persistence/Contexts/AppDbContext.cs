using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Notes.API.Domain.Models;
using System;

namespace Notes.API.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<User>().Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(x => x.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(x => x.Login).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(x => x.Email).IsRequired();
            builder.Entity<User>().Property(x => x.Image).IsRequired();
            builder.Entity<User>().Property(x => x.Password).IsRequired();
            builder.Entity<User>().HasMany(x => x.UserRole).WithOne(x => x.User);
            builder.Entity<User>().HasMany(x => x.Notes).WithOne(x => x.User);
            builder.Entity<User>().HasAlternateKey(x => x.Login);
            
            builder.Entity<Note>().ToTable("Notes");
            builder.Entity<Note>().HasKey(x =>x.Id);
            builder.Entity<Note>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<Note>().Property(x => x.Title).IsRequired().HasMaxLength(30);
            builder.Entity<Note>().Property(x => x.Description).IsRequired();
            builder.Entity<Note>().Property(x => x.DateNote).IsRequired();
            builder.Entity<Note>().Property(x => x.Priority).IsRequired();


            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Role>().Property(x => x.Name).IsRequired();
            builder.Entity<Role>().HasAlternateKey(x => x.Name);
            builder.Entity<Role>().HasMany(x => x.UserRoles).WithOne(x => x.Role);


            builder.Entity<UserRole>().ToTable("UserRoles");
            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
        
            Role admin = new Role { Id = 1000, Name = "Admin" };
            Role user = new Role { Id = 2000, Name = "User" };


            User adm = new User{
                Id = 1,
                FirstName = "Karina",
                LastName = "Tkachenko",
                Login = "ktkachenko",
                Password = "KaRiNa12345",
                Email = "karinatkachenko9873@gmail.com",
                Image = "#"
            };

            User user1 = new User{
                Id = 2,
                FirstName = "Alina",
                LastName = "Kurinna",
                Login = "alina_",
                Password = "notes_alina_10",
                Email = "alina_kurinna7@gmail.com",
                Image = "#"
            };

                User user2 = new User{
                Id = 3,
                FirstName = "Yaroslav",
                LastName = "Dudnik",
                Login = "dudnik_y",
                Password = "ineednotes",
                Email = "yaroslav_dudnik0707@gmail.com",
                Image = "#"
            };

            UserRole ur1 = new UserRole { UserId = 1, RoleId = 1000 };
            UserRole ur2 = new UserRole { UserId = 2, RoleId = 2000};
            UserRole ur3 = new UserRole { UserId = 3, RoleId = 2000 };


            Note note1 = new Note{
                Id = 100,
                Title = "Deadlines June",
                Description = "Final Project, 4 practical works on the subject Decision Making System.",
                Priority = Priority.High,
                DateNote = DateTime.Now,
                UserId = 1
            };

            Note note2 = new Note{
                Id = 200,
                Title = "Supermarket list products",
                Description = "2 kilograms Apple, 1 Milk, 1 Bread, 3 Croissants.",
                Priority = Priority.Medium,
                DateNote = DateTime.Now,
                UserId = 2
            };

            Note note3 = new Note{
                Id = 201,
                Title = "Plans today",
                Description = "Morning run, breakfast, online-lecture, cook dinner, read a book.",
                Priority = Priority.Low,
                DateNote = DateTime.Now,
                UserId = 2
            };

            Note note4 = new Note{
                Id = 300,
                Title = "Call back a friend",
                Description = "Today, until 20:00",
                Priority = Priority.Medium,
                DateNote = DateTime.Now,
                UserId = 3
            };

            builder.Entity<User>().HasData(adm, user1,user2);
            builder.Entity<Role>().HasData(admin, user);
            builder.Entity<UserRole>().HasData(ur1, ur2,ur3);
            builder.Entity<Note>().HasData(note1,note2,note3,note4);
            
        }
    }
}