using Microsoft.AspNetCore.Identity;
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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Picture).IsRequired(true);
            builder.Property(u => u.Picture).HasMaxLength(250);

            // Social Media Links
            builder.Property(u => u.YoutubeLink).HasMaxLength(250);
            builder.Property(u => u.TwitterLink).HasMaxLength(250);
            builder.Property(u => u.InstagramLink).HasMaxLength(250);
            builder.Property(u => u.FacebookLink).HasMaxLength(250);
            builder.Property(u => u.LinkedInLink).HasMaxLength(250);
            builder.Property(u => u.GitHubLink).HasMaxLength(250);
            builder.Property(u => u.WebsiteLink).HasMaxLength(250);
            // About
            builder.Property(u => u.FirstName).HasMaxLength(30);
            builder.Property(u => u.LastName).HasMaxLength(30);
            builder.Property(u => u.About).HasMaxLength(1000);

            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("Users");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(50);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(50);
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(100);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            var adminUser = new User
            {
                Id = 1,
                UserName = "mahdiguliyev",
                NormalizedUserName = "MAHDIGULIYEV",
                Email = "mahdiguliyev@gmail.com",
                NormalizedEmail = "MAHDIGULIYEV@GMAIL.COM",
                PhoneNumber = "+905555555555",
                Picture = "/userImages/defaultUser.png",
                FirstName = "Mahdi",
                LastName = "Guliyev",
                About = "Admin User of ProgrammersBlog",
                TwitterLink = "https://twitter.com/mahdiguliyev",
                InstagramLink = "https://instagram.com/mahdiguliyev",
                YoutubeLink = "https://youtube.com/mahdiguliyev",
                GitHubLink = "https://github.com/mahdiguliyev",
                LinkedInLink = "https://linkedin.com/mahdiguliyev",
                WebsiteLink = "https://programmersblog.com/",
                FacebookLink = "https://facebook.com/mahdiguliyev",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            adminUser.PasswordHash = CreatePasswordHash(adminUser, "Mehdi135");
            var editorUser = new User
            {
                Id = 2,
                UserName = "guliyevsadiq",
                NormalizedUserName = "GULIYEVSADIQ",
                Email = "guliyevsadiq@gmail.com",
                NormalizedEmail = "GULIYEVSADIQ@GMAIL.COM",
                PhoneNumber = "+905555555555",
                Picture = "/userImages/defaultUser.png",
                FirstName = "Sadiq",
                LastName = "Guliyev",
                About = "Editor User of ProgrammersBlog",
                TwitterLink = "https://twitter.com/guliyevsadiq",
                InstagramLink = "https://instagram.com/guliyevsadiq",
                YoutubeLink = "https://youtube.com/guliyevsadiq",
                GitHubLink = "https://github.com/guliyevsadiq",
                LinkedInLink = "https://linkedin.com/guliyevsadiq",
                WebsiteLink = "https://programmersblog.com/",
                FacebookLink = "https://facebook.com/guliyevsadiq",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            editorUser.PasswordHash = CreatePasswordHash(editorUser, "Sadiq135");

            builder.HasData(adminUser, editorUser);
        }
        
        private string CreatePasswordHash(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
