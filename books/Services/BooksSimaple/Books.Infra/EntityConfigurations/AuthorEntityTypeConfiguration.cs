using Books.Domain.AggregatedModel.AggragatedAutor;
using Books.Domain.AggregatedModel.AggragatedBooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Infra.EntityConfigurations
{
    class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("authors", BookContext.DEFAULT_SCHEMA);
            builder.HasKey(b => b.Id);
            builder.Ignore(b => b.DomainEvents);
            builder.Property(b => b.Name);

            var navigation = builder.Metadata.FindNavigation(nameof(Author.Books));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
