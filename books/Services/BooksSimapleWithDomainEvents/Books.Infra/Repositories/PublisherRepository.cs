using Books.Domain.AggregatedModel.AggragatedAutor;
using Books.Domain.AggregatedModel.AggragatedPublisher;
using Books.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infra.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BookContext _context;
        public PublisherRepository(BookContext context)
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

        public void Add(Publisher publisher)
        {
            _context.Publisher.Add(publisher);
        }

        public async Task<IEnumerable<Publisher>> GetAsync()
        {
            return await _context.Publisher.Include(p => p.Books).ToListAsync();
        }


        public async Task<Publisher> GetPublisherByName(string name)
        {
            return await _context.Publisher.FirstOrDefaultAsync(p => p.Name == name);
        }
    }
}
