﻿using System.ComponentModel.DataAnnotations;

namespace Planner.Web.Models
{
    public class AnotacaoViewModel
    {
        public int Id_Anotacao { get; set; }
        [Required]
        public int Id_Aula { get; set; }
        [Required(ErrorMessage = "O campo titulo é obrigatório")]
        public string Titulo { get; set; }
        public string Campo_Texto { get; set; }

    }
}
