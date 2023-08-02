# Learning EF Core

## Nuget Packages

1. Microsoft.EntityFrameworkCore.SqlServer in DataAccess project
2. Microsoft.EntityFrameworkCore.Tools in DataAccess project
3. Microsoft.EntityFrameworkCore.Design in all UI projects

## Migration steps in EF Core

1. Create/Change Model
2. Add migration - ``Add-Migration <Migration_Name>``
3. Remove migration before updating the database - ``Remove-Migration``
4. Apply Migration - ``Update-Database``
5. Rollback to the specific migration - ``Update-Database <Migration_Name>`` 
6. Show all migration name and status - ``Get-Migration``
7. Delete database - ``Drop-Database``

## Data Annotations

- ``[Table("<changed_table_name>")]``
- ``[Column("<changed_column_name>")]``
- ``[Required]``
- ``[Key]``
- ``[MaxLength(<maximum_length_of_a_column>)]``
- ``[NotMapped]``
- ``[ForeignKey(<Foreign_table_property_name>)]``

## Relationships

### One to One

Child Table  (BookDetail)  
![BookDetail (Child to Book)](Screenshots/BookDetail%20(Child%20to%20Book).png)  
Parent Table (Book)  
![Book (Parent to BookDetail)](Screenshots/Book%20(Parent%20to%20BookDetail).png)   

### One to Many  

Child Table  (Book)  
![Book (Child to Publisher)](Screenshots/Book%20(Child%20to%20Publisher).png)  
Parent Table (Publisher)  
![Publisher (Parent to Book)](Screenshots/Publisher%20(Parent%20to%20Book).png)   

### Many to Many (Without mapping, .NET 5 to upper version)  

Book (Many to Many with Author)  
![Book (Many to Many with Author)](Screenshots/Book%20(Many%20to%20Many%20with%20Author)%201.PNG)  
Author (Many to Many with Book)  
![Author (Many to Many with Book)](Screenshots/Author%20(Many%20to%20Many%20with%20Book)%201.PNG)  

### Many to Many (With mannual mapping)  

AuthorBookMap class  
![AuthorBookMap](Screenshots/AuthorBookMap.png)  
AuthorBookMap Composit Key  
![AuthorBookMapCompositKey](Screenshots/AuthorBookMapCompositKey.PNG)  
Book (Many to Many with Author)  
![Book (Many to Many with Author)](Screenshots/Book%20(Many%20to%20Many%20with%20Author)%202.PNG)  
Author (Many to Many with Book)  
![Author (Many to Many with Book)](Screenshots/Author%20(Many%20to%20Many%20with%20Book)%202.PNG)    

### Fluent API  

- Table Name ``modelBuilder.Entity<Fluent_BookDetail>().ToTable("Fluent_BookDetails");``
- Primary Key ``modelBuilder.Entity<Fluent_Book>().HasKey(x => x.Book_Id);``
- Composit Primary Key ``modelBuilder.Entity<AuthorBookMap>().HasKey(x => new { x.Author_Id, x.Book_Id });``
- Required ``modelBuilder.Entity<Fluent_Book>().Property(x => x.ISBN).IsRequired();``
- Property Name Change in DB ``modelBuilder.Entity<Fluent_BookDetail>().Property(x => x.NumberOfChapters).HasColumnName("NoOfChapter");``
- Max Length ``modelBuilder.Entity<Fluent_Book>().Property(x => x.ISBN).HasMaxLength(50);``
- Not Mapped ``modelBuilder.Entity<Fluent_Book>().Ignore(x => x.PriceRange);``
- One to One relationship ``modelBuilder.Entity<Fluent_BookDetail>().HasOne(x => x.Book).WithOne(x => x.BookDetail).HasForeignKey<Fluent_BookDetail>(x => x.Book_Id);``
- One to Many relationship ``modelBuilder.Entity<Fluent_Book>().HasOne(x => x.Publisher).WithMany(x => x.Books).HasForeignKey(x => x.Publisher_Id);``
- Many to many relationship  
``modelBuilder.Entity<Fluent_AuthorBookMap>().HasOne(x => x.Book).WithMany(x => x.AuthorBookMap).HasForeignKey(x => x.Book_Id);``  
``modelBuilder.Entity<Fluent_AuthorBookMap>().HasOne(x => x.Author).WithMany(x => x.AuthorBookMap).HasForeignKey(x => x.Author_Id);``  