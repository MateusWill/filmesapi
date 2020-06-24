using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace filmesapi.Models
{
    public partial class APIDBContext : DbContext
    {
        public APIDBContext()
        {
        }

        public APIDBContext(DbContextOptions<APIDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAtor> TbAtor { get; set; }
        public virtual DbSet<TbAtorFilme> TbAtorFilme { get; set; }
        public virtual DbSet<TbDiretor> TbDiretor { get; set; }
        public virtual DbSet<TbFilme> TbFilme { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user id=root;password=123456;database=APIDB", x => x.ServerVersion("8.0.20-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAtor>(entity =>
            {
                entity.HasKey(e => e.IdAtor)
                    .HasName("PRIMARY");

                entity.Property(e => e.NmAtor)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbAtorFilme>(entity =>
            {
                entity.HasKey(e => e.IdAtorFilme)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdAtor)
                    .HasName("id_ator");

                entity.HasIndex(e => e.IdFilme)
                    .HasName("id_filme");

                entity.Property(e => e.DsPersonagem)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdAtorNavigation)
                    .WithMany(p => p.TbAtorFilme)
                    .HasForeignKey(d => d.IdAtor)
                    .HasConstraintName("tb_ator_filme_ibfk_2");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.TbAtorFilme)
                    .HasForeignKey(d => d.IdFilme)
                    .HasConstraintName("tb_ator_filme_ibfk_1");
            });

            modelBuilder.Entity<TbDiretor>(entity =>
            {
                entity.HasKey(e => e.IdDiretor)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdFilme)
                    .HasName("id_filme");

                entity.Property(e => e.NmDiretor)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.TbDiretor)
                    .HasForeignKey(d => d.IdFilme)
                    .HasConstraintName("tb_diretor_ibfk_1");
            });

            modelBuilder.Entity<TbFilme>(entity =>
            {
                entity.HasKey(e => e.IdFilme)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsGenero)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmFilme)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
