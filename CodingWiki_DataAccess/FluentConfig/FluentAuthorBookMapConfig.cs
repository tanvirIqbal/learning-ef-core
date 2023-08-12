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
    public class FluentAuthorBookMapConfig : IEntityTypeConfiguration<Fluent_AuthorBookMap>
    {
        public void Configure(EntityTypeBuilder<Fluent_AuthorBookMap> modelBuilder)
        {
            modelBuilder.HasKey(x => new { x.Author_Id, x.Book_Id });
            modelBuilder.HasOne(x => x.Book).WithMany(x => x.AuthorBookMap).HasForeignKey(x => x.Book_Id);
            modelBuilder.HasOne(x => x.Author).WithMany(x => x.AuthorBookMap).HasForeignKey(x => x.Author_Id);
        }
    }
}
