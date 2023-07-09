using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EQuienQuiereSerIngeniero;

namespace BLQuienQuiereSerIngeniero
{
    public class BLPartida
    {
        public List<Pregunta> Preguntas { get; set; } = new List<Pregunta>
        {
            #region Banco De Preguntas Faciles
            // Seteamos las preguntas en dificultad fácil
            new Pregunta(1,"¿Cómo se llama el documento de requerimientos que es dirigo al cliente? ","Analisis De Requerimientos","Facil"),
            new Pregunta(2,"¿Cómo se llama el documento de requerimientos que es dirigo al desarrollador?","Analisis De Requerimientos","Facil"),
            new Pregunta(3,"¿En qué lenguaje se encuentran los enunciados de los requerimientos del sistema?","Analisis De Requerimientos", "Facil"),
            new Pregunta(4,"¿En qué lenguaje se encuentran los enunciados de los requerimientos del usuario?","Analisis De Requerimientos","Facil"),
            new Pregunta(5,"¿Qué se enfoca en las condiciones técnicas y restricciones del sistema?","Analisis De Requerimientos","Facil"),
            new Pregunta(6,"¿Qué se enfoca en las necesidades y expectativas de los usuarios finales?","Analisis De Requerimientos","Facil"),
            new Pregunta(7,"¿Qué describe las funcionalidades específicas que el sistema debe realizar?","Analisis De Requerimientos","Facil"),
            new Pregunta(8,"¿Qué son esenciales para asegurar que el sistema sea confiable, seguro y eficiente? ","Analisis De Requerimientos","Facil"),
            new Pregunta(9,"¿En qué arquitectura el cliente solicita servicios al servidor?","Diseño","Facil"),
            new Pregunta(10,"¿En qué arquitectura se separa la lógica, la presentación y el control?","Diseño","Facil"),
            new Pregunta(11,"¿En qué arquitectura se separa la lógica, la presentación y el acceso a datos?","Diseño","Facil"),
            new Pregunta(12,"¿Cómo es la comunicación entre componentes en la Arquitectura Cliente-Servidor?","Diseño","Facil"),
            new Pregunta(13,"¿Cómo es la comunicación entre componentes en la Arquitectura MVC?","Diseño","Facil"),
            new Pregunta(14,"¿Cómo es la comunicación entre componentes en la Arquitectura en Capas?","Diseño","Facil"),
            new Pregunta(15,"¿Qué característica tienen en común las arquitecturas Cliente-Servidor y en Capas?","Diseño","Facil"),
            new Pregunta(16,"¿Qué característica tienen en común las arquitecturas MVC y en Capas?","Diseño","Facil"),
            new Pregunta(17,"¿Qué pilar de POO permite la creación de relaciones jerárquicas entre las clases?","Codificacion","Facil"),
            new Pregunta(18,"¿Qué pilar de POO permite simplificar y generalizar objetos, reutilizando código?","Codificacion","Facil"),
            new Pregunta(19,"¿Qué pilar de POO permite el ocultamiento de la información?","Codificacion","Facil"),
            new Pregunta(20,"¿Qué pilar de POO permite a un objeto presentar múltiples formas?","Codificacion","Facil"),
            new Pregunta(21,"¿Cúal es el compilador que convierte el código intermedio a código máquina?","Codificacion","Facil"),
            new Pregunta(22,"¿Cúal es el entorno de ejecución administrado que hace compilación Just-In-Time?","Codificacion","Facil"),
            new Pregunta(23,"¿Qué determina si dos objetos comparten la misma ubicación en memoria?","Codificacion","Facil"),
            new Pregunta(24,"¿Qué se utiliza para comparar igualdad de valores?","Codificacion","Facil"),
            new Pregunta(25,"¿Cómo se llama el proceso que se realiza con la intención de encontrar errores?","Pruebas","Facil"),
            new Pregunta(26,"¿Qué se provoca por la incorrecta interpretación de un método?","Pruebas","Facil"),
            new Pregunta(27,"¿Qué se provoca por un error de implementación?","Pruebas","Facil"),
            new Pregunta(28,"¿Qué se provoca al ejecutar el programa con un defecto?","Pruebas","Facil"),
            new Pregunta(29,"¿Qué pruebas estan basadas en las funcionalidas del sistema?","Pruebas","Facil"),
            new Pregunta(30,"¿Qué pruebas tienen en cuenta el comportamiento externo del software?","Pruebas","Facil"),
            new Pregunta(31,"¿Qué técnicas no se ejecutan en la aplicación?","Pruebas","Facil"),
            new Pregunta(32,"¿Qué técnicas son utilizadas para el diseño de los casos de prueba?","Pruebas","Facil"),
            new Pregunta(33,"¿Qué mantenimiento refiere a la corrección de errores encontrados en el software?","Mantenimiento","Facil"),
            new Pregunta(34,"¿Qué mantenimiento refiere a la modificación software para adaptarlo?","Mantenimiento","Facil"),
            new Pregunta(35,"¿Qué mantenimiento refiere a realizar mejores en el software?","Mantenimiento","Facil"),
            new Pregunta(36,"¿Qué mantenimiento refiere a prevenir posibles problemas futuros?","Mantenimiento","Facil"),
            new Pregunta(37,"¿Qué sistema permite gestionar y controlar los cambios realizados en el software?","Mantenimiento","Facil"),
            new Pregunta(38,"¿Qué se utiliza para gestionar y rastrear los errores?","Mantenimiento","Facil"),
            new Pregunta(39,"¿Qué sistema registra y clasifica las solicitudes de cambios del software?","Mantenimiento","Facil"),
            new Pregunta(40,"¿Cuál es el sistema de control de versiones más famoso?","Mantenimiento","Facil"),
            new Pregunta(41,"Primera Linea -> Primera Estrofa","EPN","Facil"),
            new Pregunta(42,"Segunda Linea -> Primera Estrofa","EPN","Facil"),
            new Pregunta(43,"Tercera Linea -> Primera Estrofa","EPN","Facil"),
            new Pregunta(44,"Cuarta Linea -> Primera Estrofa","EPN","Facil"),
            new Pregunta(45,"Primera Linea -> Segunda Estrofa","EPN","Facil"),
            new Pregunta(46,"Segunda Linea -> Segunda Estrofa","EPN","Facil"),
            new Pregunta(47,"Tercera Linea -> Segunda Estrofa","EPN","Facil"),
            new Pregunta(48,"Cuarta Linea -> Segunda Estrofa","EPN","Facil"),
            #endregion
        };      
        public List<Respuesta> Respuestas { get; set; } = new List<Respuesta> 
        {
            #region Banco De Respuestas Faciles
            new Respuesta(1,"Documento De Definición Funcional","Analisis De Requerimientos","Facil"),
            new Respuesta(2,"Documento De Especificación Funcional","Analisis De Requerimientos","Facil"),
            new Respuesta(3,"Lenguaje Técnico","Analisis De Requerimientos","Facil"),
            new Respuesta(4,"Lenguaje Natural","Analisis De Requerimientos","Facil"),
            new Respuesta(5,"Requerimientos Del Sistema","Analisis De Requerimientos","Facil"),
            new Respuesta(6,"Requerimientos Del Usuario","Analisis De Requerimientos","Facil"),
            new Respuesta(7,"Requerimientos Funcionales","Analisis De Requerimientos","Facil"),
            new Respuesta(8,"Requerimientos NO Funcionales","Analisis De Requerimientos","Facil"),
            new Respuesta(9,"Arquitectura Cliente - Servidor","Diseño","Facil"),
            new Respuesta(10,"Arquitectura Modelo Vista Controlador","Diseño","Facil"),
            new Respuesta(11,"Arquitectura En Capas","Diseño","Facil"),
            new Respuesta(12,"Comunicación A Través De La Red","Diseño","Facil"),
            new Respuesta(13,"Comunicación A Través De Eventos","Diseño","Facil"),
            new Respuesta(14,"Comunicación Jerárquica","Diseño","Facil"),
            new Respuesta(15,"Escalabilidad","Diseño","Facil"),
            new Respuesta(16,"Flexibilidad","Diseño","Facil"),
            new Respuesta(17,"Herencia","Codificacion","Facil"),
            new Respuesta(18,"Abstracción","Codificacion","Facil"),
            new Respuesta(19,"Encapsulamiento","Codificacion","Facil"),
            new Respuesta(20,"Polimorfismo","Codificacion","Facil"),
            new Respuesta(21,"JIT","Codificacion","Facil"),
            new Respuesta(22,"CLR","Codificacion","Facil"),
            new Respuesta(23,"Equals()","Codificacion","Facil"),
            new Respuesta(24,"'=='","Codificacion","Facil"),
            new Respuesta(25,"Testing","Pruebas","Facil"),
            new Respuesta(26,"Error","Pruebas","Facil"),
            new Respuesta(27,"Defecto","Pruebas","Facil"),
            new Respuesta(28,"Fallo","Pruebas","Facil"),
            new Respuesta(29,"Pruebas Funcionales","Pruebas","Facil"),
            new Respuesta(30,"Pruebas NO Funcionales","Pruebas","Facil"),
            new Respuesta(31,"Técnicas Estáticas","Pruebas","Facil"),
            new Respuesta(32,"Técnicas Dinámicas","Pruebas","Facil"),
            new Respuesta(33,"Correctivo","Mantenimiento","Facil"),
            new Respuesta(34,"Adaptativo","Mantenimiento","Facil"),
            new Respuesta(35,"Perfectivo","Mantenimiento","Facil"),
            new Respuesta(36,"Preventivo","Mantenimiento","Facil"),
            new Respuesta(37,"Sistema De Control De Versiones","Mantenimiento","Facil"),
            new Respuesta(38,"Bug Tracker","Mantenimiento","Facil"),
            new Respuesta(39,"Sistema De Control De Incidencias","Mantenimiento","Facil"),
            new Respuesta(40,"GIT","Mantenimiento","Facil"),
            new Respuesta(41,"Politécnica, sabia morada","EPN","Facil"),
            new Respuesta(42,"de palabras que no morirán,","EPN","Facil"),
            new Respuesta(43,"legendaria antorcha sagrada","EPN","Facil"),
            new Respuesta(44,"en la lucha de la libertad.","EPN","Facil"),
            new Respuesta(45,"Caminemos con el corazón,","EPN","Facil"),
            new Respuesta(46,"trascendente en nuestra labor.","EPN","Facil"),
            new Respuesta(47,"Politécnica, alma y razón,","EPN","Facil"),
            new Respuesta(48,"brote de luz y saber es tu amor.","EPN","Facil")
            #endregion
        };
        public Partida CrearPartida(string vTema, string vDificultad,Jugador vJugador)
        {
            Partida partidaNueva = new Partida();
            //Busco las preguntas del tema elegido
            List<Pregunta> preguntasXTema = Preguntas.Where(p => p.Tema == vTema && p.Dificultad == vDificultad).ToList();
            List<Respuesta> respuestasXTema = Respuestas.Where(r => r.Tema == vTema && r.Dificultad == vDificultad).ToList();
            // Genero la partida nueva
            partidaNueva.Id = 0;
            partidaNueva.Jugador = vJugador;
            partidaNueva.Puntaje = 0;
            partidaNueva.Dificultad = "facil";
            partidaNueva.Preguntas = preguntasXTema;
            partidaNueva.Respuestas = respuestasXTema;          
            return partidaNueva;
        }

        #region Mezcla Aleatoria y Algoritmo de Fisher-Yates
        public List<Pregunta> ReordenarPreguntas(List<Pregunta> preguntas)
        {
            List<Pregunta> PreguntasAleatorias = preguntas;
            Random random = new Random();
            int n = PreguntasAleatorias.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Pregunta pregunta = PreguntasAleatorias[k];
                PreguntasAleatorias[k] = PreguntasAleatorias[n];
                PreguntasAleatorias[n] = pregunta;
            }
            return PreguntasAleatorias;
        }

        public List<Respuesta> ReordenarRespuestas(List<Respuesta> respuestas)
        {
            List<Respuesta> RespuestasAleatorias = respuestas;
            Random random = new Random();
            int n = RespuestasAleatorias.Count;
            
            while (n > 1)
            {
                n--;
                int k = random.Next(n);
                Respuesta respuesta = RespuestasAleatorias[k];
                RespuestasAleatorias[k] = RespuestasAleatorias[n];
                RespuestasAleatorias[n] = respuesta;
            }
            return RespuestasAleatorias;
        }


        #endregion

        public Pregunta BuscarPreguntaXTexto(string vTexto)
        {
            Pregunta preguntaEncontrada = new Pregunta();

            foreach (Pregunta p in Preguntas)
            {
                if (p.Texto == vTexto)
                    preguntaEncontrada = p;
            }

            return preguntaEncontrada;       
        }

        public Respuesta BuscarRespuestaXTexto(string vTexto)
        {
            Respuesta respuestaEncontrada = new Respuesta();

            foreach(Respuesta r in Respuestas)
            {
                if (r.Texto == vTexto)
                    respuestaEncontrada = r;
            }
            return respuestaEncontrada;
        }

        public bool VerificarPreguntaRespuesta(string pregunta, string respuesta)
        {
            Pregunta preguntaMatch = BuscarPreguntaXTexto(pregunta);
            Respuesta respuestaMatch = BuscarRespuestaXTexto(respuesta);
            if (preguntaMatch.Id == respuestaMatch.Id)
            {
                return true;
            }
            return false;
        }

        public int AumentarAciertos(string vAciertos)
        {
            int result = Convert.ToInt32(vAciertos);
            result++;
            return result;
        }

        public int AumentarIntentos(string vIntentos)
        {
            int result = Convert.ToInt32(vIntentos);
            result++;
            return result;
        }

        public int AumentarPuntos(string vPuntos)
        {
            int result = Convert.ToInt32(vPuntos);
            result = result + 2;
            return result;
        }
    }
}
