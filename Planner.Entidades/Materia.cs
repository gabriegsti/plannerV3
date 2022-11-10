using System;
using System.ComponentModel.DataAnnotations;

namespace Planner.Entidades
{
    public class Materia
    {
        [Key]
        [Required]
        public int Id_Materia { get; set; }
        public int? Id_Usuario { get; set; }
        [MaxLength(100)]
        public string Titulo { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(100)]
        public string? Professor { get; set; }
        public DateTime? Data_Inicio { get; set; }
        public DateTime? Data_Fim { get; set; }
    }
}
