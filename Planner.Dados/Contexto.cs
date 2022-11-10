using Microsoft.EntityFrameworkCore;
using Planner.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Dados
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            
        }

        public DbSet<Evento> Evento { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Anotacao> Anotacao { get; set; }
        public DbSet<Documentos> Documentos { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
