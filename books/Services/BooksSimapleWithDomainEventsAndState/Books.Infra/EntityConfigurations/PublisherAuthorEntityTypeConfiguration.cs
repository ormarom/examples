using Books.Domain.AggregatedModel.AggragatedAutor;
using Books.Domain.AggregatedModel.AggragatedBooks;
using Books.Domain.AggregatedModel.AggragatedPublisher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Infra.EntityConfigurations
{
    class PublisherEntityTypeConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable("publishers", BookContext.DEFAULT_SCHEMA);
            builder.HasKey(b => b.Id);
            builder.Ignore(b => b.DomainEvents);
            builder.Property(b => b.Name);

            var navigation = builder.Metadata.FindNavigation(nameof(Publisher.Books));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
