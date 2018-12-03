using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
    public class Entity
    {
        private int _id;

        public virtual int Id { get => _id; private set => _id = value; }
    }

    public interface IAggregateRoot { }

    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }

    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }

    public interface IAuthorRepository : IRepository<Author>
    {
        void Add(Author author);
        Task<IEnumerable<Author>> GetAsync();
    }

    public class Book : Entity
    {
        public string Name { get; private set; }
        public Book(string name)
        {
            Name = name;
        }
    }

    public class Author : Entity, IAggregateRoot
    {
        private List<Book> _books = new List<Book>();
        public IEnumerable<Book> Books => _books.AsReadOnly();
        public string Name { get; private set; }
        public Author(string name)
        {
            Name = name;
        }

        public void AddBook(string name)
        {
            _books.Add(new Book(name));
        }
    }
}
