using CodingWiki_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<AuthorBookMap> AuthorBookMaps { get; set; }

        public DbSet<Fluent_BookDetail> BookDetails_Fluent { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Athors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fluent_BookDetail>().ToTable("Fluent_BookDetails");
            modelBuilder.Entity<Fluent_BookDetail>().Property(x => x.NumberOfChapters).HasColumnName("NoOfChapter");
            modelBuilder.Entity<Fluent_BookDetail>().Property(x => x.NumberOfChapters).IsRequired();
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(x => x.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().HasOne(x => x.Book).WithOne(x => x.BookDetail)
                .HasForeignKey<Fluent_BookDetail>(x => x.Book_Id);

            modelBuilder.Entity<Fluent_Book>().HasKey(x => x.Book_Id);
            modelBuilder.Entity<Fluent_Book>().Property(x => x.ISBN).HasMaxLength(50);
            modelBuilder.Entity<Fluent_Book>().Property(x => x.ISBN).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Ignore(x => x.PriceRange);

            modelBuilder.Entity<Fluent_Author>().HasKey(x => x.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(x => x.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Fluent_Author>().Property(x => x.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(x => x.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(x => x.FullName);

            modelBuilder.Entity<Fluent_Author>().HasKey(x => x.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(x => x.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Fluent_Author>().Property(x => x.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(x => x.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(x => x.FullName);

            modelBuilder.Entity<Fluent_Publisher>().HasKey(x => x.Publisher_Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(x => x.Name).IsRequired();



            modelBuilder.Entity<AuthorBookMap>().HasKey(x => new { x.Author_Id, x.Book_Id });
            #region Other Code
            modelBuilder.Entity<Book>().Property(x => x.Price).HasPrecision(10, 5);

            var bookList = new List<Book>()
            {
                new Book(){BookId=1, Title="The Great Gatsby", ISBN="9780743273565", Price=15.99m, Publisher_Id = 1},
                new Book(){BookId=2, Title="To Kill a Mockingbird", ISBN="9780061120084", Price=12.50m, Publisher_Id = 2},
                new Book(){BookId=3, Title="Pride and Prejudice", ISBN="9780141439518", Price=9.99m, Publisher_Id = 3},
                new Book(){BookId=4, Title="1984", ISBN="9780451524935", Price=11.25m, Publisher_Id = 1},
                new Book(){BookId=5, Title="Harry Potter and the Sorcerer's Stone", ISBN="9780590353427", Price=19.95m, Publisher_Id = 2}
            };

            modelBuilder.Entity<Book>().HasData(bookList);


            var publisherList = new List<Publisher>()
            {
                new Publisher(){Publisher_Id=1, Name="John", Location="London"},
                new Publisher(){Publisher_Id=2, Name="Jimmy", Location="Paris"},
                new Publisher(){Publisher_Id=3, Name="Mark", Location="New York"}
            };

            modelBuilder.Entity<Publisher>().HasData(publisherList); 
            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-D0RU21U;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        }
    }
}
