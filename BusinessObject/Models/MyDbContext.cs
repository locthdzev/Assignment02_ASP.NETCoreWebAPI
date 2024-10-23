using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình quan hệ giữa Book và Publisher
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.pub_id);

            // Cấu hình quan hệ nhiều-nhiều giữa Book, Author thông qua BookAuthor
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.book_id, ba.author_id });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.book_id);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.author_id);

            // Cấu hình quan hệ giữa User và Role
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.role_id);

            // Cấu hình quan hệ giữa User và Publisher
            modelBuilder.Entity<User>()
                .HasOne(u => u.Publisher)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.pub_id);

            // Seed data cho các bảng
            modelBuilder.Entity<Role>().HasData(
                new Role { role_id = 1, role_desc = "Admin" },
                new Role { role_id = 2, role_desc = "User" }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { pub_id = 1, publisher_name = "O'Reilly Media", city = "Sebastopol", state = "CA", country = "USA" },
                new Publisher { pub_id = 2, publisher_name = "Packt Publishing", city = "Birmingham", state = "West Midlands", country = "UK" }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { author_id = 1, first_name = "John", last_name = "Doe", email_address = "john.doe@example.com", city = "New York", state = "NY", zip = "10001", phone = "123-456-7890", address = "123 Main St" },
                new Author { author_id = 2, first_name = "Jane", last_name = "Smith", email_address = "jane.smith@example.com", city = "Los Angeles", state = "CA", zip = "90001", phone = "098-765-4321", address = "456 Maple Ave" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { book_id = 1, title = "Learning EF Core", type = "Technical", pub_id = 1, price = 49.99m, advance = 5000m, royalty = 10m, ytd_sales = 500, notes = "Excellent resource", published_date = new DateTime(2022, 1, 1) },
                new Book { book_id = 2, title = "Mastering ASP.NET", type = "Technical", pub_id = 2, price = 59.99m, advance = 6000m, royalty = 12m, ytd_sales = 300, notes = "Highly recommended", published_date = new DateTime(2023, 5, 10) }
            );

            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor { author_id = 1, book_id = 1, author_order = 1, royality_percentage = 10m },
                new BookAuthor { author_id = 2, book_id = 2, author_order = 1, royality_percentage = 12m }
            );

            modelBuilder.Entity<User>().HasData(
                new User { user_id = 1, email_address = "admin@example.com", password = "password", source = "Internal", first_name = "Admin", middle_name = "", last_name = "User", role_id = 1, pub_id = 1, hire_date = DateTime.Now },
                new User { user_id = 2, email_address = "user@example.com", password = "password", source = "Internal", first_name = "Normal", middle_name = "", last_name = "User", role_id = 2, pub_id = 2, hire_date = DateTime.Now }
            );
        }
    }
}