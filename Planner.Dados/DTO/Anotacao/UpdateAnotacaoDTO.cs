using Planner.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Dados.DTO.Anotacao
{
    public class UpdateAnotacaoDTO
    {
        public int Id_Anotacao { get; set; }
        public int? AulaId { get; set; }
        public string Titulo { get; set; }
        public string? Campo_Texto { get; set; }
        public string? Link { get; set; }
    }
}
