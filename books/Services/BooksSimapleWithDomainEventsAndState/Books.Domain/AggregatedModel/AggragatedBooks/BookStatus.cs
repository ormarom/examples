using Books.Domain.Exceptions;
using Books.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Domain.AggregatedModel.AggragatedBooks
{
    public class BookStatus
        : Enumeration
    {
        public static BookStatus Published = new BookStatus(1, nameof(Published).ToLowerInvariant());
        public static BookStatus InWriting = new BookStatus(2, nameof(InWriting).ToLowerInvariant());
        

        protected BookStatus()
        {
        }

        public BookStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<BookStatus> List() =>
            new[] { InWriting, Published };

        public static BookStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new BooksDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static BookStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new BooksDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
