using Books.Domain.Events;
using Books.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Domain.AggregatedModel.AggragatedBooks
{
    public class Book : Entity
    {
        public string Name { get; private set; }

        private Book() { }

        public Book(string name, string publisherName) {
            Name = name;
            AddDomainEvent(new BookAddedDomainEvent(this, publisherName));
        }
    }
}
