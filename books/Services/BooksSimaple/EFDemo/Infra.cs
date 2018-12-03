using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infra
{
    public class BooksDbContext : DbContext, IUnitOfWork
    {
        public static string Schema = "booksService";
        public BooksDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync();
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        }
    }

    public class AuthorRepository : IAuthorRepository
    {
        private BooksDbContext _context;
        public AuthorRepository(BooksDbContext context)
        {
            _context = context;
        }
        public void Add(Author author)
        {
            _context.Authors.Add(author);
        }
        public async Task<IEnumerable<Author>> GetAsync()
        {
            return await _context.Authors.Include(a => a.Books).ToListAsync();

        }
        public IUnitOfWork UnitOfWork { get { return _context; } }

    }

    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books", BooksDbContext.Schema);
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name);
        }
    }

    class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("authors", BooksDbContext.Schema);
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name);
            var navigation = builder.Metadata.FindNavigation(nameof(Author.Books));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
