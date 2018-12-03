using Books.Domain.AggregatedModel.AggragatedAutor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Books.API.Application.Commands
{
    public class AddNewAuthorCommandHandler : IRequestHandler<AddNewAuthorCommand, bool>
    {
        IAuthorRepository _authorRepository;

        public AddNewAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Task<bool> Handle(AddNewAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author(request.Name);
            foreach (var book in request.Books)
            {
                author.AddBook(book.Name);
            }
            _authorRepository.Add(author);
            return _authorRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
