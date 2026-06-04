using EIN.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Centrodecomputo.data.DataContext
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions <BaseContext> options):base(options) { }
  
    public DbSet<AlumnoEntity> Alumnos { get; set; }

        public DbSet<GeneracionEntity> Generaciones { get; set; }
    
    public DbSet<GrupoEntity> Grupo { get; set; }
    }
}
