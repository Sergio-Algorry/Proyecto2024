using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2024.BD.Data.Entity
{
    [Index(nameof(Codigo), Name = "Especialidad_UQ", IsUnique = true)]
    public class Especialidad : EntityBase
    {
        [Required(ErrorMessage = "El código de la especialidad es obligatorio.")]
        [MaxLength(4, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre de la especialidad es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Nombre { get; set; }

        public int TituloId { get; set; }
        public Titulo Titulo { get; set; }

        public List<Matricula> Matriculas { get; set; } = new List<Matricula>();

    }
}
