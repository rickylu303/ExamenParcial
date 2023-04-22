using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExamenPrimerParcial.Db;

public partial class DbA980ffServerlibraryContext : DbContext
{
    public DbA980ffServerlibraryContext()
    {
    }

    public DbA980ffServerlibraryContext(DbContextOptions<DbA980ffServerlibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autore> Autores { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Editoriale> Editoriales { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Valoracione> Valoraciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SQL5110.site4now.net;Initial Catalog=db_a980ff_serverlibrary;Persist Security Info=True;User ID=db_a980ff_serverlibrary_admin;Password=50l1d5n4k3;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autore>(entity =>
        {
            entity.HasKey(e => e.IdAutor).HasName("PK__Autores__5FC3872D2E7C3820");

            entity.Property(e => e.IdAutor)
                .ValueGeneratedNever()
                .HasColumnName("id_autor");
            entity.Property(e => e.FechaDefuncion)
                .HasColumnType("date")
                .HasColumnName("fecha_defuncion");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.NombreAutor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_autor");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__CD54BC5A7C627709");

            entity.Property(e => e.IdCategoria)
                .ValueGeneratedNever()
                .HasColumnName("id_categoria");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_categoria");
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.IdComentario).HasName("PK__Comentar__1BA6C6F49948BB66");

            entity.Property(e => e.IdComentario)
                .ValueGeneratedNever()
                .HasColumnName("id_comentario");
            entity.Property(e => e.FechaComentario)
                .HasColumnType("date")
                .HasColumnName("fecha_comentario");
            entity.Property(e => e.IdLibro).HasColumnName("id_libro");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.TextoComentario)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("texto_comentario");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK__Comentari__id_li__5535A963");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Comentari__id_us__5441852A");
        });

        modelBuilder.Entity<Editoriale>(entity =>
        {
            entity.HasKey(e => e.IdEditorial).HasName("PK__Editoria__10C1DD02DFEE4381");

            entity.Property(e => e.IdEditorial)
                .ValueGeneratedNever()
                .HasColumnName("id_editorial");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.NombreEditorial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_editorial");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__Libros__EC09C24EA695CA8D");

            entity.Property(e => e.IdLibro)
                .ValueGeneratedNever()
                .HasColumnName("id_libro");
            entity.Property(e => e.AnioPublicacion).HasColumnName("anio_publicacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdAutor).HasColumnName("id_autor");
            entity.Property(e => e.IdEditorial).HasColumnName("id_editorial");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdAutor)
                .HasConstraintName("FK__Libros__id_autor__4316F928");

            entity.HasOne(d => d.IdEditorialNavigation).WithMany(p => p.Libros)
                .HasForeignKey(d => d.IdEditorial)
                .HasConstraintName("FK__Libros__id_edito__440B1D61");

            entity.HasMany(d => d.IdCategoria).WithMany(p => p.IdLibros)
                .UsingEntity<Dictionary<string, object>>(
                    "LibrosCategoria",
                    r => r.HasOne<Categoria>().WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LibrosCat__id_ca__49C3F6B7"),
                    l => l.HasOne<Libro>().WithMany()
                        .HasForeignKey("IdLibro")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LibrosCat__id_li__48CFD27E"),
                    j =>
                    {
                        j.HasKey("IdLibro", "IdCategoria").HasName("PK__LibrosCa__50DC898B7ED29367");
                        j.ToTable("LibrosCategorias");
                        j.IndexerProperty<int>("IdLibro").HasColumnName("id_libro");
                        j.IndexerProperty<int>("IdCategoria").HasColumnName("id_categoria");
                    });
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__Prestamo__5E87BE274219EA2A");

            entity.Property(e => e.IdPrestamo)
                .ValueGeneratedNever()
                .HasColumnName("id_prestamo");
            entity.Property(e => e.FechaDevolucion)
                .HasColumnType("date")
                .HasColumnName("fecha_devolucion");
            entity.Property(e => e.FechaPrestamo)
                .HasColumnType("date")
                .HasColumnName("fecha_prestamo");
            entity.Property(e => e.IdLibro).HasColumnName("id_libro");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK__Prestamos__id_li__4D94879B");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Prestamos__id_us__4CA06362");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reservas__423CBE5DD04DE108");

            entity.Property(e => e.IdReserva)
                .ValueGeneratedNever()
                .HasColumnName("id_reserva");
            entity.Property(e => e.FechaReserva)
                .HasColumnType("date")
                .HasColumnName("fecha_reserva");
            entity.Property(e => e.IdLibro).HasColumnName("id_libro");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK__Reservas__id_lib__5165187F");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Reservas__id_usu__5070F446");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__6ABCB5E09FF8559E");

            entity.Property(e => e.IdRol)
                .ValueGeneratedNever()
                .HasColumnName("id_rol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__4E3E04ADEDC637FF");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("id_usuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_completo");

            entity.HasMany(d => d.IdRols).WithMany(p => p.IdUsuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuariosRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UsuariosR__id_ro__3C69FB99"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UsuariosR__id_us__3B75D760"),
                    j =>
                    {
                        j.HasKey("IdUsuario", "IdRol").HasName("PK__Usuarios__5895CFF3F997DF0E");
                        j.ToTable("UsuariosRoles");
                        j.IndexerProperty<int>("IdUsuario").HasColumnName("id_usuario");
                        j.IndexerProperty<int>("IdRol").HasColumnName("id_rol");
                    });
        });

        modelBuilder.Entity<Valoracione>(entity =>
        {
            entity.HasKey(e => e.IdValoracion).HasName("PK__Valoraci__1861B2490CD5054C");

            entity.Property(e => e.IdValoracion)
                .ValueGeneratedNever()
                .HasColumnName("id_valoracion");
            entity.Property(e => e.FechaValoracion)
                .HasColumnType("date")
                .HasColumnName("fecha_valoracion");
            entity.Property(e => e.IdLibro).HasColumnName("id_libro");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Puntuacion).HasColumnName("puntuacion");

            entity.HasOne(d => d.IdLibroNavigation).WithMany(p => p.Valoraciones)
                .HasForeignKey(d => d.IdLibro)
                .HasConstraintName("FK__Valoracio__id_li__59063A47");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Valoraciones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Valoracio__id_us__5812160E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
