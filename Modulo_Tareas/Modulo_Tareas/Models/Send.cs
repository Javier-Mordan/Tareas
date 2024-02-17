using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modulo_Tareas.Models
{
    public class Send
    {
        public Send() { }
        Tarea tarea1;
        Tarea tarea2;
        public bool Guardar()
        {
            tarea2 = new Tarea
            {
                Id = 2,
                tarea = "Cocinar",
                Description = "Realizar almuerso",
                CreatedDate = DateTime.Now,
                estatus = "Hecho",
            };

            tarea1 = new Tarea
            {
                Id = tarea2.Id,
                tarea = tarea2.tarea,
                Description = tarea2.Description,
                CreatedDate = tarea2.CreatedDate,
                estatus = tarea2.estatus,
            };

            if(tarea2 == tarea1)
            {
                return true;
            }
            return true;
            

        }

        public string st()
        {
            return "w";
        }
    }
}