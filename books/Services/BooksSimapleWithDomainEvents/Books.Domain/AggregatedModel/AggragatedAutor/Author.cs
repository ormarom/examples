using Books.Domain.AggregatedModel.AggragatedBooks;
using Books.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Domain.AggregatedModel.AggragatedAutor
{
    public class Author : Entity, IAggregateRoot
    {
        private List<Book> _books = new List<Book>();

        public IEnumerable<Book> Books => _books.AsReadOnly();

        public string Name { get; private set; }
        public Author(string name)
        {
            Name = name;
        }

        public void AddBook(string name, string publisherName) {
            _books.Add(new Book(name, publisherName));
        }
    }
}
