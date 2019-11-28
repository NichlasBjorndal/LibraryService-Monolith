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

        public DbSet<LibraryServiceMonolithic.Models.Book> Book { get; set; }

        public DbSet<LibraryServiceMonolithic.Models.User> User { get; set; }

        public DbSet<LibraryServiceMonolithic.Models.Loan> Loan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            var author1 = new Author
            {
                Id = 1,
                FirstName = "Thomas",
                LastName = "Edison"
            };

            var book1 = new Book
            {
                Id = 1,
                ISBN = "1234",
                Title = "Book A",
                Author = author1
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
                Title = "Book A",
                Author = author2
            };

            var author3 = new Author
            {
                Id = 3,
                FirstName = "Thomas",
                LastName = "Edison"
            };

            var book3 = new Book
            {
                Id = 3,
                ISBN = "1234",
                Title = "Book A",
                Author = author3
            };

            //modelBuilder.Entity<Author>().HasData(
            //    author1, author2, author2
            //);

            modelBuilder.Entity<Book>(b =>
            {
                b.HasData(
                    book1, book2, book3
                );

                b.OwnsOne(a => a.Author).HasData(
                    author1, author2, author2
                );
            });
              


            var user1 = new User
            {
                Id = 1,
                FirstName = "Nick",
                LastName = "Hansen",
                Email = "abc@gmail.com"
            };
            var user2 = new User
            {
                Id = 2,
                FirstName = "Nick",
                LastName = "Hansen",
                Email = "abc@gmail.com"
            };


            modelBuilder.Entity<User>().HasData(
                user1, user2
        );

            var loan1 = new Loan
            {
                Id = 1,
                User = user1,
                Book = book1,
                StartDate = default,
                EndDate = default,
                Active = true
            };

            var loan2 = new Loan
            {
                Id = 2,
                User = user1,
                Book = book2,
                StartDate = default,
                EndDate = default,
                Active = false
            };


            var loan3 = new Loan
            {
                Id = 3,
                User = user2,
                Book = book3,
                StartDate = default,
                EndDate = default,
                Active = true
            };

            modelBuilder.Entity<Loan>().HasData(
             loan1, loan2, loan3
            );


            //    modelBuilder.Entity<Book>().HasData(
            //        new Book
            //        {
            //            Id = 1,
            //            ISBN = "1234",
            //            Title = "Book A",
            //            Author = new Author
            //            {
            //                Id = 1,
            //                FirstName = "Thomas",
            //                LastName = "Edison"
            //            }
            //        },

            //        new Book
            //        {
            //            Id = 2,
            //            ISBN = "1234",
            //            Title = "Book A",
            //            Author = new Author
            //            {
            //                Id = 2,
            //                FirstName = "Thomas",
            //                LastName = "Edison"
            //            }
            //        },

            //        new Book
            //        {
            //            Id = 3,
            //            ISBN = "1234",
            //            Title = "Book A",
            //            Author = new Author
            //            {
            //                Id = 3,
            //                FirstName = "Thomas",
            //                LastName = "Edison"
            //            }
            //        }
            //    );



            //    modelBuilder.Entity<User>().HasData(
            //         new User
            //         {
            //             Id = 1,
            //             FirstName = "Nick",
            //             LastName = "Hansen",
            //             Email = "abc@gmail.com"
            //         },
            //         new User
            //         {
            //             Id = 2,
            //             FirstName = "Nick",
            //             LastName = "Hansen",
            //             Email = "abc@gmail.com"
            //         }
            //);

            //modelBuilder.Entity<Loan>().HasData(
            //   new Loan
            //{
            //    Id = 1,
            //    User = user,
            //    Book = book,
            //    StartDate = default,
            //    EndDate = default,
            //    Active = true
            //},

            // new Loan
            //{
            //    Id = 2,
            //    User = user,
            //    Book = book2,
            //    StartDate = default,
            //    EndDate = default,
            //    Active = false
            //},



            // new Loan
            //    {
            //        Id = 3,
            //        User = user2,
            //        Book = book3,
            //        StartDate = default,
            //        EndDate = default,
            //        Active = true
            //    };
            //);

        }
    }

}
