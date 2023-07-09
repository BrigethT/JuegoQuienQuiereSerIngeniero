using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQuienQuiereSerIngeniero
{
    public class Partida
    {
  
        public int Id { get; set; }
        public Jugador Jugador { get; set; }
        public int Puntaje { get; set; }
        public string Dificultad { get; set; }
        public List<Pregunta> Preguntas { get; set; }
        public List<Respuesta> Respuestas { get; set; }
        public Partida()
        {
            
        }
        public Partida(int id, Jugador jugador, int puntaje,string dificultad, List<Pregunta> preguntas, List<Respuesta> respuestas)
        {
            Id = id;
            Jugador = jugador;
            Puntaje = puntaje;
            Dificultad = dificultad;
            Preguntas = preguntas;
            Respuestas = respuestas;
        }


    }
}
