﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryServiceMonolithic.Models;

namespace LibraryServiceMonolithic.Models
{
    public class LibraryServiceMonolithicContext : DbContext
    {
        public LibraryServiceMonolithicContext(DbContextOptions<LibraryServiceMonolithicContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<LibraryServiceMonolithic.Models.Book> Book { get; set; }

        public DbSet<LibraryServiceMonolithic.Models.User> User { get; set; }

        public DbSet<LibraryServiceMonolithic.Models.Loan> Loan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            var author1 = new
            {
                Id = 1,
                FirstName = "Thomas",
                LastName = "Edison"
            };

            var book1 = new 
            {
                Id = 1,
                ISBN = "1234",
                Title = "Book A",
                //Author = author1,
                AuthorId = 1
            };

            var author2 = new 
            {
                Id = 2,
                FirstName = "Thomas",
                LastName = "Edison"
            };
            var book2 = new 
            {
                Id = 2,
                ISBN = "1234",
                Title = "Book B",
                //Author = author2,
                AuthorId = 2
            };

            var author3 = new 
            {
                Id = 3,
                FirstName = "Thomas",
                LastName = "Edison"
            };

            var book3 = new 
            {
                Id = 3,
                ISBN = "1234",
                Title = "Book Z",
                //Author = author3,
                AuthorId = 3
            };

            modelBuilder.Entity<Author>().HasData(
                author1, author2, author3
            );

            modelBuilder.Entity<Book>(b =>
            {
                b.HasData(
                    book1, book2, book3
                );

            });
              


            var user1 = new 
            {
                Id = 1,
                FirstName = "Nick",
                LastName = "Hansen",
                Email = "abc@gmail.com"
            };
            var user2 = new 
            {
                Id = 2,
                FirstName = "Nick",
                LastName = "Hansen",
                Email = "abc@gmail.com"
            };


            modelBuilder.Entity<User>().HasData(
                user1, user2
        );

            var loan1 = new
            {
                Id = 1,
                //User = user1,
                UserId = 1,
                //Book = book1,
                BookId = 1,
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                Active = true
            };

            var loan2 = new 
            {
                Id = 2,
                //User = user1,
                UserId = 1,
                //Book = book2,
                BookId = 2,
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                Active = false
            };


            var loan3 = new 
            {
                Id = 3,
                //User = user2,
                UserId = 2,
                //Book = book3,
                BookId = 3,
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                Active = true
            };

            modelBuilder.Entity<Loan>().HasData(
             loan1, loan2, loan3
            );

        }
    }

}