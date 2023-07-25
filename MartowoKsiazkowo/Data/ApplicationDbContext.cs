using MartowoKsiazkowo.Encje;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MartowoKsiazkowo.Data;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    
    public DbSet<User> User { get; set; }
    public DbSet<UserAddress> UserAddress { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookInfo> BookInfo { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<BookUser> BookUser { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<BookUser>()
        //     .HasKey(l => new {l.BookId, l.UserId});
        // base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().ToTable("User")
            .HasKey(a=> a.UserId);
        modelBuilder.Entity<UserAddress>().ToTable("UserAddress").HasKey(a => a.UserAddressId);
//        modelBuilder.Entity<Book>().ToTable("Book").HasKey(a=>a.BookId);
        modelBuilder.Entity<Book>().ToTable("Book").HasKey(a=>a.BookId);
        modelBuilder.Entity<BookInfo>().ToTable("BookInfo").HasKey(a=>a.BookInfoId);
        modelBuilder.Entity<Author>().ToTable("Author").HasKey(a => a.AuthorId);
        modelBuilder.Entity<BookUser>().ToTable("BookUser").HasKey(a=>a.BookUserId);
//        base.OnModelCreating(modelBuilder);

    }

}