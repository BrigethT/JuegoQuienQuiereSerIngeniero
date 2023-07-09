using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQuienQuiereSerIngeniero
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }

        public Jugador()
        {
                
        }
        public Jugador(int id,string nombre, string password)
        {
            Id = id;
            Nombre = nombre;
            Password = password;
        }

       
        
    }
}
