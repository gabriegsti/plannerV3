using System.ComponentModel.DataAnnotations;

namespace Planner.Entidades
{
    public class Anotacao
    {
        [Key]
        public int Id_Anotacao { get; set; }
        public int? Id_Usuario { get; set; }
        public string? Titulo { get; set; }
        [MaxLength(500)]
        public string? Campo_Texto { get; set; }
        public string? Link { get; set; }

    }
}
