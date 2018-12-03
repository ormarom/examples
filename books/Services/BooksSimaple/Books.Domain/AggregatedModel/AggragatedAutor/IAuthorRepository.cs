using Books.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.AggregatedModel.AggragatedAutor
{
    public interface IAuthorRepository : IRepository<Author>
    {
        void Add(Author author);
        Task<IEnumerable<Author>> GetAsync();
    }
}
