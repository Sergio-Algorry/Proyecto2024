using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2024.BD.Data.Entity
{
    [Index(nameof(ProfesionId), nameof(EspecialidadId), Name = "Matricula_UQ", IsUnique = true)]
    public class Matricula : EntityBase
    {
        [Required(ErrorMessage = "La Profesion es obligatoria.")]
        public int ProfesionId { get; set; }
        public Profesion Profesion { get; set; }

        [Required(ErrorMessage = "L Especialidad es obligatoria.")]
        public int EspecialidadId { get; set; }
        public Especialidad Especialidad { get; set; }

        [Required(ErrorMessage = "El Número de matrícula es obligatorio.")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Numero { get; set; }
    }
}
