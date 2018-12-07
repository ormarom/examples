using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.AggregatedModel.AggragatedPublisher
{
    public interface IPublisherRepository
    {
        void Add(Publisher publisher);
        Task<IEnumerable<Publisher>> GetAsync();
        Task<Publisher> GetPublisherByName(string name);
    }
}
