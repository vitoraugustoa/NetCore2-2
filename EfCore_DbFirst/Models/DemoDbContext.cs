using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfCore_DbFirst.Models
{
    public partial class DemoDbContext : DbContext
    {
        public DemoDbContext()
        {
        }

        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alunos> Alunos { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Tiposocios> Tiposocios { get; set; }


        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         optionsBuilder.UseMySql("server=localhost;uid=root;pwd=root;database=EscolaDemo");
        //     }
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alunos>(entity =>
            {
                entity.ToTable("alunos");

                entity.HasIndex(e => e.TipoSocioId)
                    .HasName("IX_Alunos_TipoSocioId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Texto)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TipoSocioId).HasColumnType("int(11)");

                entity.HasOne(d => d.TipoSocio)
                    .WithMany(p => p.Alunos)
                    .HasForeignKey(d => d.TipoSocioId)
                    .HasConstraintName("FK_Alunos_TipoSocios_TipoSocioId");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasColumnType("varchar(95)");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<Tiposocios>(entity =>
            {
                entity.ToTable("tiposocios");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DuracaoEmMeses).HasColumnType("int(11)");

                entity.Property(e => e.TaxaDesconto).HasColumnType("int(11)");
            });
        }
    }
}
