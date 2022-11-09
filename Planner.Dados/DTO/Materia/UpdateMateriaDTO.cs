using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Dados.DTO.Materia
{
    public class UpdateMateriaDTO
    {
        public int Id_Materia { get; set; }
        public int? Id_Usuario { get; set; }
        public string Titulo { get; set; }
        public string? Email { get; set; }
        public string? Professor { get; set; }
        public DateTime? Data_Inicio { get; set; }
        public DateTime? Data_Fim { get; set; }
    }
}
