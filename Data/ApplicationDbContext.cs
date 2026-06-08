using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tarea4.Models;

namespace Tarea4.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<PropietarioModel> Propietarios { get; set; }
        public DbSet<MarcaModel> Marcas { get; set; }
        public DbSet<VehiculoModel> Vehiculos { get; set; }
        public DbSet<MatriculaModel> Matriculas { get; set; }
        public DbSet<RevisionTecnicaModel> RevisionesTecnicas { get; set; }
    }
}
