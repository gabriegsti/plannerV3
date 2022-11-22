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

        public Documentos Buscar(int id)
        {
            return _contexto.Documentos.FirstOrDefault(x => x.Id_Documento == id);
        }

        public void Excluir(int id)
        {
            _contexto.Remove(_contexto.Documentos.FirstOrDefault(x => x.Id_Documento == id));
            _contexto.SaveChanges();
        }
    }
}
