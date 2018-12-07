using Books.Domain.AggregatedModel.AggragatedAutor;
using Books.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infra.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookContext _context;
        public AuthorRepository(BookContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
        }

        public async Task<IEnumerable<Author>> GetAsync()
        {
            return await _context.Authors.Include(a => a.Books).ToListAsync();
        }
    }
}
