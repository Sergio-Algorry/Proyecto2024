using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2024.BD.Data.Entity
{
    public class Simbolo : EntityBase
    {
        public string Codigo { get; set; }   //BYMA
        public string NombreSimbolo { get; set; }
        public string Moneda { get; set; }   //$

        public int? SimboloRelacionadoId { get; set; }    //NULL
        public Simbolo? SimboloRelacionado { get; set; }


    }
}
