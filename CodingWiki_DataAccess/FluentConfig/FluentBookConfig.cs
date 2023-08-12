using CodingWiki_Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            modelBuilder.HasKey(x => x.Book_Id);
            modelBuilder.Property(x => x.ISBN).HasMaxLength(50);
            modelBuilder.Property(x => x.ISBN).IsRequired();
            modelBuilder.Property(x => x.Title).IsRequired();
            modelBuilder.Property(x => x.Price).IsRequired();
            modelBuilder.Ignore(x => x.PriceRange);
            modelBuilder.HasOne(x => x.Publisher).WithMany(x => x.Books)
                .HasForeignKey(x => x.Publisher_Id);
        }
    }
}
