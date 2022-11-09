using Microsoft.EntityFrameworkCore;
using Planner.Dados.DTO.Materia;
using Planner.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Dados.Repositorios
{
    public class MateriaRepositorio
    {
        private readonly Contexto _contexto;
           
        public MateriaRepositorio(Contexto contexto)
        {
          _contexto = contexto;
        }

        public int Adicionar(Materia materia)
        {
            _contexto.Add(materia);
            return _contexto.SaveChanges();
        }

        public void Atualizar(Materia materia)
        {
            _contexto.Entry(materia).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contexto.SaveChanges();
        }

        public IEnumerable<Materia> Buscar()
        {
            return _contexto.Materia.AsEnumerable();
        }

        public Materia Buscar(int id )
        {
            return _contexto.Materia.FirstOrDefault(x => x.Id_Materia == id);
        }

        public void Excluir(int id)
        {
            _contexto.Remove(_contexto.Materia.FirstOrDefault(x => x.Id_Materia == id));
            _contexto.SaveChanges();
        }

        public void AtualizarMateria(UpdateMateriaDTO materiaDto)
        {
            Materia materia = _contexto.Materia.FirstOrDefault(materia => materia.Id_Materia == materiaDto.Id_Materia);
            materia.Titulo = materiaDto.Titulo;
            materia.Email = materiaDto.Email;
            materia.Professor = materiaDto.Professor;
            materia.Data_Inicio = materiaDto.Data_Inicio;
            materia.Data_Fim = materiaDto.Data_Fim;

            _contexto.SaveChanges();
        }
    }
}
