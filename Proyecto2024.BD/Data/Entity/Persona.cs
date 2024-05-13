using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2024.BD.Data.Entity
{
    public class Persona : EntityBase
    {
        public string NumDoc { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
