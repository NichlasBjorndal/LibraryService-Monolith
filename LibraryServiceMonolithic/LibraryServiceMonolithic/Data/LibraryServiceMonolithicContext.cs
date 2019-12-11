using System;
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
            
            var author1 = new Author
            {
                Id = 1,
                FirstName = "Edger Allan",
                LastName = "Poe"
            };

            var book1 = new Book
            {
                Id = 1,
                ISBN = "1234",
                Title = "Book A",
                AuthorId = 1
            };

            var author2 = new Author
            {
                Id = 2,
                FirstName = "Thomas",
                LastName = "Edison"
            };
            var book2 = new Book
            {
                Id = 2,
                ISBN = "1234",
                Title = "Book B",
                AuthorId = 2
            };

            var author3 = new Author
            {
                Id = 3,
                FirstName = "H.C",
                LastName = "Andersen"
            };

            var book3 = new Book
            {
                Id = 3,
                ISBN = "1234",
                Title = "Book Z",
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
              


            var user1 = new User
            {
                Id = 1,
                FirstName = "Nick",
                LastName = "Hansen",
                Email = "abc@gmail.com",
                Password = "thisIsAPW"
            };
            var user2 = new User
            {
                Id = 2,
                FirstName = "Marcus",
                LastName = "B",
                Email = "abc@gmail.com",
                Password = "c0mpl!c@t3dPw"
            };


            modelBuilder.Entity<User>().HasData(
                user1, user2
        );

            var loan1 = new Loan
            {
                Id = 1,
                UserId = 1,
                BookId = 1,
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                Active = true
            };

            var loan2 = new Loan
            {
                Id = 2,
                UserId = 1,
                BookId = 2,
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                Active = false
            };


            var loan3 = new Loan
            {
                Id = 3,
                UserId = 2,
                BookId = 3,
                StartDate = new DateTime(),
                EndDate = new DateTime(),
                Active = true
            };

            modelBuilder.Entity<Loan>().HasData(
             loan1, loan2, loan3
            );
        }

        public DbSet<LibraryServiceMonolithic.Models.Author> Author { get; set; }
    }

}
