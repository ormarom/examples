using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App
{

    public class NewAuthorCommandHandler : IRequestHandler<NewAuthorCommand, bool>
    {
        IAuthorRepository _authorRepository;

        public NewAuthorCommandHandler(IAuthorRepository authorRepository) {
            _authorRepository = authorRepository;
        }

        public Task<bool> Handle(NewAuthorCommand request, CancellationToken cancellationToken)
        {
            var auther = new Domain.Author(request.Name);
            foreach (var book in request.Books)
            {
                auther.AddBook(book.Name);
            }
            _authorRepository.Add(auther);
            return _authorRepository.UnitOfWork.SaveChangesAsync();
        }
    }


    public class NewAuthorCommand : IRequest<bool>
    {
        public string Name { get; private set; }
        public IEnumerable<Book> Books { get; private set; }
        public NewAuthorCommand(string name, IEnumerable<Book> books) {
            Books = books;
        }
    }

    public class Book {
        public string Name { get; private set; }
        public Book(string name) { Name = name; }
    }

}
