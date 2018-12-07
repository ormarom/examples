using Books.Domain.AggregatedModel.AggragatedBooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Infra.EntityConfigurations
{
    class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books", BookContext.DEFAULT_SCHEMA);
            builder.HasKey(b => b.Id);
            builder.Ignore(b => b.DomainEvents);
            builder.Property(b => b.Name);
            builder.Property<int>("BookStatusId").IsRequired();
        }
    }
}
