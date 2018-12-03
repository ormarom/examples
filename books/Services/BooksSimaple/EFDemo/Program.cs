using Infra;
using Microsoft.EntityFrameworkCore;
using System;
using MediatR;
using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;

namespace EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var options = new DbContextOptionsBuilder<BooksDbContext>()
            //   .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
            //   .Options;

            //var context = new BooksDbContext(options);
            //var authorRepository = new AuthorRepository(context);

            //var author = new Author("Moshe");
            //author.AddBook("book1");
            //author.AddBook("book2");
            //authorRepository.Add(author);
            //authorRepository.UnitOfWork.SaveChangesAsync();
            //Console.ReadKey();
            //context = null;
            //authorRepository = null;
            //PrintAuthor();
            //Console.ReadKey();
        }


        static void PrintAuthor() {
            var options = new DbContextOptionsBuilder<BooksDbContext>()
               .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
               .Options;

            var context = new BooksDbContext(options);
            var authorRepository = new AuthorRepository(context);
            var authers = authorRepository.GetAsync().Result;
            foreach (var author in authers)
            {
                Console.WriteLine(author.Name);
                foreach (var book in author.Books)
                {
                    Console.WriteLine(book.Name);
                }

            }

        }
    }
}
