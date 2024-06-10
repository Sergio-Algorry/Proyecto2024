using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2024.BD.Data
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }

        public bool Activo { get; set; }



    }
}
