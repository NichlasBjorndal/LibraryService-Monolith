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
            var loopCount100Mb = 15000;

            var authors = new List<Author>();

            for (int i = 1; i < loopCount100Mb; i++)
            {
                var author1 = new Author
                {
                    Id = i,
                    FirstName = "Edger Allan",
                    LastName = "Poe"
                };


                authors.Add(author1);
            }

            var books = new List<Book>();

            for (int i = 1; i < loopCount100Mb; i++)
            {
                var book1 = new Book
                {
                    Id = i,
                    ISBN = "1234",
                    Title = "Book A",
                    AuthorId = 1
                };

                books.Add(book1);
            }

            modelBuilder.Entity<Author>().HasData(
                authors
            );


            modelBuilder.Entity<Book>(b =>
            {
                b.HasData(
                    books
                );

            });

            var users = new List<User>();

            for (int i = 1; i < loopCount100Mb; i++)
            {

                var user1 = new User
                {
                    Id = i,
                    FirstName = "Nick",
                    LastName = "Hansen",
                    Email = "abc@gmail.com",
                    Password = "thisIsAPW"
                };

                users.Add(user1);
            }


            modelBuilder.Entity<User>().HasData(
                users
        );


            var loans = new List<Loan>();

            for (int i = 1; i < loopCount100Mb; i++)
            {

                var loan1 = new Loan
                {
                    Id = i,
                    UserId = 1,
                    BookId = 1,
                    StartDate = new DateTime(),
                    EndDate = new DateTime(),
                    Active = true
                };

                loans.Add(loan1);
            }
  

            modelBuilder.Entity<Loan>().HasData(
             loans
            );


            var orders = new List<Order>();

            for (int i = 1; i < loopCount100Mb; i++)
            {
                var order1 = new Order
                {
                    Id = i,
                    OrderTime = default,
                    IsCompleted = false,
                    BookId = 1,
                };

                orders.Add(order1);
            }


            modelBuilder.Entity<Order>().HasData(
                orders
            );

        }

        public DbSet<LibraryServiceMonolithic.Models.Author> Author { get; set; }

        public DbSet<LibraryServiceMonolithic.Models.Order> Order { get; set; }

        public DbSet<LibraryServiceMonolithic.Models.PhysicalBook> PhysicalBook { get; set; }
    }

}
