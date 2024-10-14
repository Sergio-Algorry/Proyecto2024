using Microsoft.EntityFrameworkCore;
using Proyecto2024.BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2024.BD.Data
{
    public class Context : DbContext
    {
        
        public DbSet<Simbolo> Simbolos { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Persona> Personas { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Profesion> Profesiones { get; set; }
        public DbSet<TDocumento> TDocumentos { get; set; }
        public DbSet<Titulo> Titulos { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var cascadeFKs = modelBuilder.Model.G­etEntityTypes()
                                          .SelectMany(t => t.GetForeignKeys())
                                          .Where(fk => !fk.IsOwnership
                                                       && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
