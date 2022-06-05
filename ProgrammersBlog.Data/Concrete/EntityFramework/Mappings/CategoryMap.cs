using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired(true);
            builder.Property(c => c.Name).HasMaxLength(70);
            builder.Property(c => c.Description).HasMaxLength(500);

            builder.Property(c => c.CreatedByName).IsRequired(true);
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired(true);
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired(true);
            builder.Property(c => c.ModifiedDate).IsRequired(true);
            builder.Property(c => c.IsActive).IsRequired(true);
            builder.Property(c => c.IsDeleted).IsRequired(true);
            builder.Property(c => c.Note).HasMaxLength(500);

            builder.ToTable("Categories");

            builder.HasData(
                 new Category
                 {
                     Id = 1,
                     Name = "C#",
                     Description = "Latest Information on C# Programming Language",
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreate",
                     CreatedDate = DateTime.Now,
                     ModifiedByName = "InitialCreate",
                     ModifiedDate = DateTime.Now,
                     Note = "C# Blog Category",
                 },
                 new Category
                 {
                     Id = 2,
                     Name = "C++",
                     Description = "Latest Information on C++ Programming Language",
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreate",
                     CreatedDate = DateTime.Now,
                     ModifiedByName = "InitialCreate",
                     ModifiedDate = DateTime.Now,
                     Note = "C++ Blog Category",
                 },

                 new Category
                 {
                     Id = 3,
                     Name = "JavaScript",
                     Description = "Latest Information on JavaScript Programming Language",
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreate",
                     CreatedDate = DateTime.Now,
                     ModifiedByName = "InitialCreate",
                     ModifiedDate = DateTime.Now,
                     Note = "JavaScript Blog Category",
                 },
                 new Category
                 {
                     Id = 4,
                     Name = "Typescript",
                     Description = "Latest Information on TypeScript Programming Language",
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreate",
                     CreatedDate = DateTime.Now,
                     ModifiedByName = "InitialCreate",
                     ModifiedDate = DateTime.Now,
                     Note = "Typescript Blog Category",
                 }
                 ,
                 new Category
                 {
                     Id = 5,
                     Name = "Java",
                     Description = "Latest Information on Java Programming Language",
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreate",
                     CreatedDate = DateTime.Now,
                     ModifiedByName = "InitialCreate",
                     ModifiedDate = DateTime.Now,
                     Note = "Java Blog Category",
                 }
                 ,
                 new Category
                 {
                     Id = 6,
                     Name = "Python",
                     Description = "Latest Information on Python Programming Language",
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreate",
                     CreatedDate = DateTime.Now,
                     ModifiedByName = "InitialCreate",
                     ModifiedDate = DateTime.Now,
                     Note = "Python Blog Category",
                 }
                 ,
                 new Category
                 {
                     Id = 7,
                     Name = "Php",
                     Description = "Latest Information on Php Programming Language",
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreate",
                     CreatedDate = DateTime.Now,
                     ModifiedByName = "InitialCreate",
                     ModifiedDate = DateTime.Now,
                     Note = "Php Blog Category",
                 }
                 ,
                 new Category
                 {
                     Id = 8,
                     Name = "Kotlin",
                     Description = "Latest Information on Kotlin Programming Language",
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreate",
                     CreatedDate = DateTime.Now,
                     ModifiedByName = "InitialCreate",
                     ModifiedDate = DateTime.Now,
                     Note = "Kotlin Blog Category",
                 }
                 ,
                 new Category
                 {
                     Id = 9,
                     Name = "Swift",
                     Description = "Latest Information on Swift Programming Language",
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreate",
                     CreatedDate = DateTime.Now,
                     ModifiedByName = "InitialCreate",
                     ModifiedDate = DateTime.Now,
                     Note = "Swift Blog Category",
                 }
                 ,
                 new Category
                 {
                     Id = 10,
                     Name = "Ruby",
                     Description = "Latest Information on Ruby Programming Language",
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreate",
                     CreatedDate = DateTime.Now,
                     ModifiedByName = "InitialCreate",
                     ModifiedDate = DateTime.Now,
                     Note = "Ruby Blog Category",
                 }
             );
        }
    }
}
