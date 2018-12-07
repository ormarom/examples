using Books.Domain.AggregatedModel.AggragatedAutor;
using Books.Domain.AggregatedModel.AggragatedBooks;
using Books.Domain.AggregatedModel.AggragatedPublisher;
using Books.Domain.SeedWork;
using Books.Infra.EntityConfigurations;
using MediatR;
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
        private readonly IMediator _mediator;

        public const string DEFAULT_SCHEMA = "booksService";

        public DbSet<Book> Books { get; set; }
        public DbSet<BookStatus> BookStatus { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publisher { get; set; }

        public BookContext(DbContextOptions<BookContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);
            var result = await base.SaveChangesAsync();

            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookStatusEntityTypeConfiguration());
            
        }
    }
}
