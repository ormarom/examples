using Books.Domain.AggregatedModel.AggragatedAutor;
using Books.Domain.AggregatedModel.AggragatedBooks;
using Books.Domain.SeedWork;
using Books.Infra.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Infra
{
    public class BookContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "booksService";

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync();

            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookEntityTypeConfiguration());
        }
    }
}
