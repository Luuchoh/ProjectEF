using Microsoft.EntityFrameworkCore;
using projectEF.Models;

namespace projectEF;

public class TareasContext: DbContext
{
  public DbSet<Categoria> Categorias { get; set; }
  public DbSet<Tarea> Tareas { get; set; }
  public TareasContext (DbContextOptions<TareasContext> options): base(options) { }  

  protected override void OnModelCreating(ModelBuilder modelBuilder) 
  {
    List<Categoria> ListaCategoria = new List<Categoria>();
    ListaCategoria.Add(new Categoria() { CategoriaId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c657"), Nombre = "Activitidades Pendientes", Peso = 20});
    ListaCategoria.Add(new Categoria() { CategoriaId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c602"), Nombre = "Activitidades Personales", Peso = 50});
    modelBuilder.Entity<Categoria> ( categoria =>
    {
      categoria.ToTable("Categoria");
      categoria.HasKey(p => p.CategoriaId);
      categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
      categoria.Property(p => p.Descripcion).IsRequired(false).HasMaxLength(500);
      categoria.Property(p => p.Peso);
      categoria.HasData(ListaCategoria);
    });
    List<Tarea> ListaTarea = new List<Tarea>();
    ListaTarea.Add(new Tarea() {TareaId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c100"), 
                                  CategoriaId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c657"),
                                  PrioridadTarea = Prioridad.Media,
                                  Titulo = "Pago de servicios publicos",
                                  FechaCreacion = DateTime.Now});
    ListaTarea.Add(new Tarea() {TareaId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c101"), 
                                  CategoriaId = Guid.Parse("c4e0d0e7-5f06-48c7-9246-11fe12f2c602"),
                                  PrioridadTarea = Prioridad.Media,
                                  Titulo = "Terminar de ver peliculas",
                                  FechaCreacion = DateTime.Now}); 
    modelBuilder.Entity<Tarea> ( tarea =>
    {
      tarea.ToTable("Tarea");
      tarea.HasKey(p => p.TareaId);
      tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
      tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
      tarea.Property(p => p.Descripcion).IsRequired(false).HasMaxLength(500);
      tarea.Property(p => p.PrioridadTarea);
      tarea.Property(p => p.FechaCreacion);
      tarea.Ignore(p => p.Resumen);
      tarea.Property(p => p.Autor);
      tarea.HasData(ListaTarea);
    });
  }
}
