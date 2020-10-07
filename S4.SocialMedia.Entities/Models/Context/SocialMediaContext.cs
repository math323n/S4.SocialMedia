using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using S4.SocialMedia.Entities.Models;

namespace S4.SocialMedia.Entities.Models.Context
{
    public partial class SocialMediaContext : DbContext
    {
        public SocialMediaContext()
        {
        }

        public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TrollSpaceDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.PkCommentId);

                entity.Property(e => e.PkCommentId)
                    .HasColumnName("PK_CommentId")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkPostId).HasColumnName("FK_PostId");

                entity.Property(e => e.FkUserId).HasColumnName("FK_UserId");

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(1024);

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("Update_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.FkPost)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.FkPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Post");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PkPostId);

                entity.Property(e => e.PkPostId).HasColumnName("PK_PostId");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(255);

                entity.Property(e => e.FkUserId)
                .   IsRequired()
                    .HasColumnName("Fk_UserId")
                    .HasMaxLength(450);

                entity.Property(e => e.Image)
                    .HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("Update_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.PkUserId);

                entity.Property(e => e.PkUserId).HasColumnName("PK_UserId");

                entity.Property(e => e.Birthdate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Facebook).HasMaxLength(1024);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Google).HasMaxLength(1024);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.Twitter).HasMaxLength(1024);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
