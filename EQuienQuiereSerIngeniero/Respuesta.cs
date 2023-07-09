using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQuienQuiereSerIngeniero
{
    public class Respuesta
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Tema { get; set; }
        public string Dificultad { get; set; }

        public Respuesta()
        {
            
        }

        public Respuesta(int id, string texto, string tema, string dificultad)
        {
            Id = id;
            Texto = texto;
            Tema = tema;
            Dificultad = dificultad;
        }
    }
}
