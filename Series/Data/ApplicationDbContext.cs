using Series.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Series.Data
{
    public class ApplicationDbContext : DbContext // Hereda de : Que pertenece al EntityFrameworkCore
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Dbset = representacion de cada tabla
        public virtual DbSet<Episodio> Episodio { get; set; }
        public virtual DbSet<Imagen> Imagen { get; set; }
        public virtual DbSet<Lista> Lista { get; set; }
        public virtual DbSet<Serie> Serie { get; set; }
        public virtual DbSet<Temporada> Temporada { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

    }
}
