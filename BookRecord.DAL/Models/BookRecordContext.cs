using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookRecord.DAL.Models;

public partial class BookRecordContext : DbContext
{
    public BookRecordContext()
    {
    }

    public BookRecordContext(DbContextOptions<BookRecordContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-I0OTQSJ\\SQLEXPRESS;Database=BookRecord; User Id=UserBookRecord; Password=123456; Encrypt=Yes; TrustServerCertificate=Yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.AutorId).HasName("PK__Autor__F58AE909004AFFB6");

            entity.ToTable("Autor");

            entity.Property(e => e.AutorId)
                .ValueGeneratedNever()
                .HasColumnName("AutorID");
            entity.Property(e => e.CiudadProcedencia).HasMaxLength(50);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.NombreCompleto).HasMaxLength(100);
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.LibroId).HasName("PK__Libro__35A1EC8D5B6EC611");

            entity.ToTable("Libro");

            entity.Property(e => e.LibroId)
                .ValueGeneratedNever()
                .HasColumnName("LibroID");
            entity.Property(e => e.AutorId).HasColumnName("AutorID");
            entity.Property(e => e.Genero).HasMaxLength(50);
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.Autor).WithMany(p => p.Libros)
                .HasForeignKey(d => d.AutorId)
                .HasConstraintName("FK__Libro__AutorID__35BCFE0A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
