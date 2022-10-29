using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Dados.DTO.Evento
{
    public class UpdateEventoDTO
    {
        [Required]
        public int id_Evento { get; set; }
        public string Titulo { get; set; }
        public DateTime? Data_Hora { get; set; }
    }
}
