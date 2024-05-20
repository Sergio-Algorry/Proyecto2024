using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2024.BD.Data.Entity
{
    [Index(nameof(Codigo), Name = "Titulo_UQ", IsUnique = true)]
    public class Titulo : EntityBase
    {
        [Required(ErrorMessage = "El código del título es obligatorio.")]
        [MaxLength(4, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre del título es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Nombre { get; set; }

        public List<Profesion> Profesiones { get; set; }

    }
}
