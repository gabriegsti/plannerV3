using Planner.Dados.DTO.Anotacao;
using Planner.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Dados.Repositorios
{
    public class AnotacaoRepositorio
    {
        private readonly Contexto _contexto;
           
        public AnotacaoRepositorio(Contexto contexto)
        {
          _contexto = contexto;
        }

        public int Adicionar(Anotacao anotacao)
        {
            _contexto.Add(anotacao);
            return _contexto.SaveChanges();
        }

        public void Atualizar(Anotacao anotacao)
        {
            _contexto.Entry(anotacao).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public IEnumerable<Anotacao> Buscar()
        {
            return _contexto.Anotacao.AsEnumerable();
        }

        public Anotacao Buscar(int id )
        {
            return _contexto.Anotacao.FirstOrDefault(x => x.Id_Anotacao == id);
        }

        public void Excluir(int id)
        {
            _contexto.Remove(_contexto.Anotacao.FirstOrDefault(x => x.Id_Anotacao == id));
            _contexto.SaveChanges();
        }

        public void AtualizarAnotacao(UpdateAnotacaoDTO anotacaoDTO)
        {
            Anotacao anotacao = _contexto.Anotacao.FirstOrDefault(anotacao => anotacao.Id_Anotacao == anotacaoDTO.Id_Anotacao);
            anotacao.Titulo = anotacaoDTO.Titulo;
            anotacao.Campo_Texto = anotacaoDTO.Campo_Texto;
            anotacao.Link = anotacaoDTO.Link;

            _contexto.SaveChanges();
        }
    }
}
