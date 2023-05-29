using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessObject.Models
{
    public partial class Online_LearningContext : DbContext
    {
        public Online_LearningContext()
        {
        }

        public Online_LearningContext(DbContextOptions<Online_LearningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Certificate> Certificates { get; set; } = null!;
        public virtual DbSet<Chapter> Chapters { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =103.184.112.242,1433; database=Online_Learning;uid=HieuDD;pwd=123456789;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasMany(d => d.Courses)
                    .WithMany(p => p.Accounts)
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountCourse",
                        l => l.HasOne<Course>().WithMany().HasForeignKey("CourseId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Account_Course_Course"),
                        r => r.HasOne<Account>().WithMany().HasForeignKey("AccountId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Account_Course_Account"),
                        j =>
                        {
                            j.HasKey("AccountId", "CourseId");

                            j.ToTable("Account_Course");
                        });

                entity.HasMany(d => d.Lessons)
                    .WithMany(p => p.Accounts)
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountLesson",
                        l => l.HasOne<Lesson>().WithMany().HasForeignKey("LessonId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Account_Lesson_Lesson"),
                        r => r.HasOne<Account>().WithMany().HasForeignKey("AccountId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Account_Lesson_Account"),
                        j =>
                        {
                            j.HasKey("AccountId", "LessonId");

                            j.ToTable("Account_Lesson");
                        });

                entity.HasMany(d => d.Permissions)
                    .WithMany(p => p.Accounts)
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountPermisson",
                        l => l.HasOne<Permission>().WithMany().HasForeignKey("PermissionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Account_Permisson_Permission"),
                        r => r.HasOne<Account>().WithMany().HasForeignKey("AccountId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Account_Permisson_Account"),
                        j =>
                        {
                            j.HasKey("AccountId", "PermissionId");

                            j.ToTable("Account_Permisson");
                        });
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Blog_Account");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.InverseParentCategory)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .HasConstraintName("FK_Category_Category");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificate");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Certificate_Account");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Certificate_Course");
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.ToTable("Chapter");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Chapters)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Chapter_Course");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Comment_Account");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK_Comment_Blog");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Comment_Course");

                entity.HasOne(d => d.Rely)
                    .WithMany(p => p.InverseRely)
                    .HasForeignKey(d => d.RelyId)
                    .HasConstraintName("FK_Comment_Comment");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasMany(d => d.Categories)
                    .WithMany(p => p.Courses)
                    .UsingEntity<Dictionary<string, object>>(
                        "CourseCategory",
                        l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Course_Category_Category"),
                        r => r.HasOne<Course>().WithMany().HasForeignKey("CourseId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Course_Category_Course"),
                        j =>
                        {
                            j.HasKey("CourseId", "CategoryId");

                            j.ToTable("Course_Category");
                        });
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lesson");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Chapter)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.ChapterId)
                    .HasConstraintName("FK_Lesson_Chapter");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.CourseId });

                entity.ToTable("OrderDetail");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Course");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Order");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RefreshToken");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Expires).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
