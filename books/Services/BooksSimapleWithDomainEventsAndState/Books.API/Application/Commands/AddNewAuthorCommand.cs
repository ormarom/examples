using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Application.Commands
{
    public class AddNewAuthorCommand : IRequest<bool>
    {
        public IEnumerable<Book> Books { get; private set; }
        public string Name { get; private set; }
        public AddNewAuthorCommand(string name, IEnumerable<Book> books) {
            Name = name;
            Books = books;
        }
    }

    public class Book {
        public string PublisherName { get; private set; }
        public string Name { get; private set; }
        public Book(string name, string publisherName) {
            Name = name;
            PublisherName = publisherName;
        }
    }
}
