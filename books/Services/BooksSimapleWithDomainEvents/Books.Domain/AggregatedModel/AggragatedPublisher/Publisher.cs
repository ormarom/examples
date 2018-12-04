using Books.Domain.AggregatedModel.AggragatedBooks;
using Books.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Domain.AggregatedModel.AggragatedPublisher
{
    public class Publisher : Entity, IAggregateRoot
    {
        private List<Book> _books = new List<Book>();
        public IEnumerable<Book> Books => _books.AsReadOnly();
        public string Name { get; private set; }
        public Publisher(string name)
        {
            Name = name;
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }
    }
}
