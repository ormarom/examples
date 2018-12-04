using Books.Domain.AggregatedModel.AggragatedPublisher;
using Books.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Books.API.Application.DomainEventHandlers.BookAdded
{
    public class BookAddedNeedToAssignPublisherDomainEventHandler : INotificationHandler<BookAddedDomainEvent>
    {
        IPublisherRepository _publisherRepository;
        public BookAddedNeedToAssignPublisherDomainEventHandler(IPublisherRepository publisherRepository) {
            _publisherRepository = publisherRepository;
        }
        public async Task Handle(BookAddedDomainEvent notification, CancellationToken cancellationToken)
        {
            var publisher = await _publisherRepository.GetPublisherByName(notification.PublisherName);
            if (publisher == null)
            {
                publisher = new Publisher(notification.PublisherName);
                _publisherRepository.Add(publisher);
            }
            publisher.AddBook(notification.Book);
        }
    }
}
