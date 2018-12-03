using Books.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Domain.AggregatedModel.AggragatedBooks
{
    public class Book : Entity
    {
        public string Name { get; private set; }
        public Book(string name) {
            Name = name;
        }
    }
}
