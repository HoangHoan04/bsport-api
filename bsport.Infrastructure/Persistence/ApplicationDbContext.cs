using bsport.Domain.Entities;
using bsport.Domain.Entities.News;
using bsport.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace bsport.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // ==================== USER MANAGEMENT ====================
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<VerifyOtp> VerifyOtps { get; set; }
        public DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }

        // ==================== FILE MANAGEMENT ====================
        public DbSet<FileArchival> FileArchival { get; set; }

        // ==================== NEWS MANAGEMENT ====================
        // public DbSet<News> News { get; set; }
        // public DbSet<Blog> Blogs { get; set; }
        // public DbSet<Banner> Banners { get; set; }
        // public DbSet<Feedback> Feedbacks { get; set; }
        // public DbSet<FeedbackLike> FeedbackLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==================== USER CONFIGURATION ====================
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired();

                entity.Property(e => e.IsActive)
                    .HasDefaultValue(true);

                entity.Property(e => e.IsAdmin)
                    .HasDefaultValue(false);

                entity.Property(e => e.GoogleProviderId)
                    .HasMaxLength(255);

                entity.Property(e => e.FacebookProviderId)
                    .HasMaxLength(255);

                entity.Property(e => e.ZaloProviderId)
                    .HasMaxLength(255);

                entity.HasIndex(e => e.Username)
                    .IsUnique();

                // Relationships
                entity.HasMany(e => e.UserTokens)
                    .WithOne(ut => ut.User)
                    .HasForeignKey(ut => ut.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.VerifyOtps)
                    .WithOne(vo => vo.User)
                    .HasForeignKey(vo => vo.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ==================== CUSTOMER CONFIGURATION ====================
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20);

                entity.Property(e => e.IdCard)
                    .HasMaxLength(20);

                entity.Property(e => e.SocialLink)
                    .HasMaxLength(1000);

                entity.HasIndex(e => e.Code)
                    .IsUnique();

                entity.HasIndex(e => e.Email);

                // Relationships
                entity.HasMany(e => e.Files)
                    .WithOne(fa => fa.Customer)
                    .HasForeignKey(fa => fa.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ==================== EMPLOYEE CONFIGURATION ====================
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20);

                entity.Property(e => e.Address)
                    .HasMaxLength(500);

                entity.Property(e => e.IdentityNumber)
                    .HasMaxLength(20);

                entity.Property(e => e.Position)
                    .HasMaxLength(100);

                entity.Property(e => e.Department)
                    .HasMaxLength(100);

                entity.HasIndex(e => e.Code)
                    .IsUnique();

                // Relationships
                entity.HasMany(e => e.Schedules)
                    .WithOne(es => es.Employee)
                    .HasForeignKey(es => es.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.Files)
                    .WithOne(fa => fa.Employee)
                    .HasForeignKey(fa => fa.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ==================== USER TOKEN CONFIGURATION ====================
            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(1000);

                entity.Property(e => e.RefreshToken)
                    .HasMaxLength(1000);

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(50);

                entity.Property(e => e.ClientType)
                    .HasMaxLength(50);

                entity.Property(e => e.TokenId)
                    .HasMaxLength(255);

                entity.HasIndex(e => e.UserId);
            });

            // ==================== VERIFY OTP CONFIGURATION ====================
            modelBuilder.Entity<VerifyOtp>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Otp)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.OtpType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Receiver)
                    .HasMaxLength(255);

                entity.HasIndex(e => e.UserId);
            });

            // ==================== EMPLOYEE SCHEDULE CONFIGURATION ====================
            modelBuilder.Entity<EmployeeSchedule>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValue("SCHEDULED");

                entity.Property(e => e.Note)
                    .HasMaxLength(500);

                entity.HasIndex(e => e.EmployeeId);
                entity.HasIndex(e => e.WorkDate);
            });

            // ==================== FILE ARCHIVAL CONFIGURATION ====================
            modelBuilder.Entity<FileArchival>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FileUrl)
                    .HasMaxLength(1000);

                entity.Property(e => e.FileName)
                    .HasMaxLength(500);

                entity.Property(e => e.FileType)
                    .HasMaxLength(50);

                entity.HasIndex(e => e.CustomerId);
                entity.HasIndex(e => e.EmployeeId);
            });
        }
    }
}
