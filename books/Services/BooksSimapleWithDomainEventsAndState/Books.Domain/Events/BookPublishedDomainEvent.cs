using Books.Domain.AggregatedModel.AggragatedBooks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Domain.Events
{
    public class AssignBookToPublisherDomainEvent : INotification
    {
        public Book Book { get; private set; }
        public string PublisherName { get; private set; }
        public AssignBookToPublisherDomainEvent(Book book, string publisherName) {
            Book = book;
            PublisherName = publisherName;
        }
    }
}
