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
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_BookDetails");
            modelBuilder.Property(x => x.NumberOfChapters).HasColumnName("NoOfChapter");
            modelBuilder.Property(x => x.NumberOfChapters).IsRequired();
            modelBuilder.HasKey(x => x.BookDetail_Id);
            modelBuilder.HasOne(x => x.Book).WithOne(x => x.BookDetail)
                .HasForeignKey<Fluent_BookDetail>(x => x.Book_Id);
        }
    }
}
