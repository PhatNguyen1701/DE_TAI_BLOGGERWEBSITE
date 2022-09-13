using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Blog.DAL.Models
{
    public partial class BloggerWebsiteContext : DbContext
    {
        public BloggerWebsiteContext()
        {
        }

        public BloggerWebsiteContext(DbContextOptions<BloggerWebsiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<SubReview> SubReviews { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BloggerWebsite;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.PostId)
                    .ValueGeneratedNever()
                    .HasColumnName("PostID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Images).HasMaxLength(50);

                entity.Property(e => e.PostStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Post__CategoryID__2B3F6F97");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Post__CategoryID__2A4B4B5E");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__Review__C3B4DFAAEB72EE83");

                entity.ToTable("Review");

                entity.Property(e => e.CommentId)
                    .ValueGeneratedNever()
                    .HasColumnName("CommentID");

                entity.Property(e => e.Content).HasMaxLength(100);

                entity.Property(e => e.CreateAt).HasMaxLength(20);

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__Review__PostID__2E1BDC42");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Review__UserID__2F10007B");
            });

            modelBuilder.Entity<SubReview>(entity =>
            {
                entity.HasKey(e => e.SubCommentId)
                    .HasName("PK__SubRevie__3D24901F8D1A5D50");

                entity.ToTable("SubReview");

                entity.Property(e => e.SubCommentId)
                    .ValueGeneratedNever()
                    .HasColumnName("SubCommentID");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.SubReviews)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK__SubReview__Comme__31EC6D26");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
