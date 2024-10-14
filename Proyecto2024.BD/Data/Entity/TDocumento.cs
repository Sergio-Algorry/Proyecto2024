using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2024.BD.Data.Entity
{
    /// <summary>
    /// Entity de la tabla TDocumentos
    /// </summary>
    [Index(nameof(Codigo), Name = "TDocumento_UQ", IsUnique = true)]
    public class TDocumento : EntityBase
    {
        /// <summary>
        /// Codigo del tipo de documento
        /// </summary>
        [Required(ErrorMessage = "El código del tipo de documento es obligatorio.")]
        [MaxLength(4, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Codigo { get; set; }

        /// <summary>
        /// nombre del tipo de documento
        /// </summary>
        [Required(ErrorMessage = "El nombre del tipo de documento es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Nombre { get; set; }

        public List<Persona> Personas { get; set; } = new List<Persona>();
    }
}
