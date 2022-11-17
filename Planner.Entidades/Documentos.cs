using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Entidades
{
    public class Documentos
    {
        [Key]
        public int Id_Documento { get; set; }

        public string Titulo { get; set; }

        public List<byte[]>? documento { get; set; }

        public string ContentType { get; set; } 

        public int? Id_Usuario { get; set; }
    }
}
