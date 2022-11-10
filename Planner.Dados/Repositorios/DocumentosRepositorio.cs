using Planner.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Dados.Repositorios
{
    public class DocumentosRepositorio
    {
        private readonly Contexto _contexto;
        public DocumentosRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public int Adicionar(Documentos documentos)
        {
            _contexto.Add(documentos);
            return _contexto.SaveChanges();
        }

        public IEnumerable<Documentos> Buscar()
        {
            return _contexto.Documentos.AsEnumerable();
        }
    }
}
