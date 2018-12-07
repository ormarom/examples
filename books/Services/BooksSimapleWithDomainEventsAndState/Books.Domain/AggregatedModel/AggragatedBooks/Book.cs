using Books.Domain.Events;
using Books.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Domain.AggregatedModel.AggragatedBooks
{
    public class Book : Entity
    {
        private int _bookStatusId;
        public BookStatus BookStatus { get; private set; }

        public string Name { get; private set; }

        private Book() { }

        public Book(string name, string publisherName) {
            Name = name;
            if (!string.IsNullOrEmpty(publisherName)) {
                AddDomainEvent(new AssignBookToPublisherDomainEvent(this, publisherName));
                _bookStatusId = BookStatus.Published.Id;
            }
            else
            {
                _bookStatusId = BookStatus.InWriting.Id;
            }
        }

        public void PublishBook(string publisherName) {
            if (_bookStatusId != BookStatus.Published.Id) {
                AddDomainEvent(new AssignBookToPublisherDomainEvent(this, publisherName));
                _bookStatusId = BookStatus.Published.Id;
            }
        }
    }
}
