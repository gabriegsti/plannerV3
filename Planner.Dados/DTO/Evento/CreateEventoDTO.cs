using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Dados.DTO
{
    public class CreateEventoDTO
    {
        [Required(ErrorMessage = "O campo titulo é obrigatório.")]
        public string? Titulo { get; set; }
        public DateTime? Data_Hora { get; set; }
        public int Id_Usuario { get; set; }
    }
}
