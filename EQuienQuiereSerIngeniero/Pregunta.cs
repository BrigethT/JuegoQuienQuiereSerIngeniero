using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQuienQuiereSerIngeniero
{
    public class Pregunta
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Tema{ get;set; }
        public string Dificultad { get; set; }

        public Pregunta()
        {
            
        }

        public Pregunta(int id, string texto, string tema, string dificultad)
        {
            Id = id;
            Texto = texto;
            Tema = tema;
            Dificultad = dificultad;
        }
    }
}
