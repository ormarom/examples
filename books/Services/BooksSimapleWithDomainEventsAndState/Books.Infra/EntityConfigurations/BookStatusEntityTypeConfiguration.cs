using Books.Domain.AggregatedModel.AggragatedAutor;
using Books.Domain.AggregatedModel.AggragatedBooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Infra.EntityConfigurations
{
    class BookStatusEntityTypeConfiguration
         : IEntityTypeConfiguration<BookStatus>
    {
        public void Configure(EntityTypeBuilder<BookStatus> orderStatusConfiguration)
        {
            orderStatusConfiguration.ToTable("bookstatus", BookContext.DEFAULT_SCHEMA);

            orderStatusConfiguration.HasKey(o => o.Id);

            orderStatusConfiguration.Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            orderStatusConfiguration.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
