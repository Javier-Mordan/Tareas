using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modulo_Tareas.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string tarea { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string estatus { get; set; }
    }
}