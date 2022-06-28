using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final.Modelo
{
    internal class Fila
    {
        //ESTADOS POSIBLES
        public const string estadoLibre = "Libre";
        public const string estadoOcupado = "Ocupado";
        public const string estadoDetenido = "Detenido";

        //Vector estado
        private string evento;
        private double reloj;

        //EVENTOS
        private double rndLlegadaTrabajo;
        private double tiempoEntreLlegadas;
        private double proximaLlegadaTrabajo;

        private double rndAtencionA;
        private double tiempoAtencionA;
        private double proximoFinAtencionA;

        private double rnd1AtencionB;
        private double rnd2AtencionB;
        private double tiempoAtencionB;
        private double proximoFinAtencionB;

        private double tiempoFinSecado;
        private double proximoFinSecado;

        //SERVIDORES
        private string estadoCentroA;
        private string estadoCentroB;
        private EquipoSecado[] equiposSecado; //5 equipos

        //COLAS
        private int colaLlegadas;
        private int colaCentroB; //Max. 3

        //ESTADISTICAS
        private int contadorTrabajosEnSistema;
        private int cantidadMaximaTrabajosEnSistema;
        private double tiempoACCentroADetenido;
        private int contadorTrabajosFinalizados;
        private double tiempoACTrabajosFinalizados;

        //OBJETOS TEMPORALES
        //TODO: ver como manejarlo
        private string trabajos;

        public string Evento { get => evento; set => evento = value; }
        public double Reloj { get => reloj; set => reloj = value; }
        public double RNDLlegadaTrabajo { get => rndLlegadaTrabajo; set => rndLlegadaTrabajo = value; }
        public double TiempoEntreLlegadas { get => tiempoEntreLlegadas; set => tiempoEntreLlegadas = value; }
        public double ProximaLlegadaTrabajo { get => proximaLlegadaTrabajo; set => proximaLlegadaTrabajo = value; }
        public double RNDAtencionA { get => rndAtencionA; set => rndAtencionA = value; }
        public double TiempoAtencionA { get => tiempoAtencionA; set => tiempoAtencionA = value; }
        public double ProximoFinAtencionA { get => proximoFinAtencionA; set => proximoFinAtencionA = value; }
        public double RND1AtencionB { get => rnd1AtencionB; set => rnd1AtencionB = value; }
        public double RND2AtencionB { get => rnd2AtencionB; set => rnd2AtencionB = value; }
        public double TiempoAtencionB { get => tiempoAtencionB; set => tiempoAtencionB = value; }
        public double ProximoFinAtencionB { get => proximoFinAtencionB; set => proximoFinAtencionB = value; }
        public double TiempoFinSecado { get => tiempoFinSecado; set => tiempoFinSecado = value; }
        public double ProximoFinSecado { get => proximoFinSecado; set => proximoFinSecado = value; }
        public string EstadoCentroA { get => estadoCentroA; set => estadoCentroA = value; }
        public string EstadoCentroB { get => estadoCentroB; set => estadoCentroB = value; }
        public int ColaLlegadas { get => colaLlegadas; set => colaLlegadas = value; }
        public int ColaCentroB { get => colaCentroB; set => colaCentroB = value; }
        public int ContadorTrabajosEnSistema { get => contadorTrabajosEnSistema; set => contadorTrabajosEnSistema = value; }
        public int CantidadMaximaTrabajosEnSistema { get => cantidadMaximaTrabajosEnSistema; set => cantidadMaximaTrabajosEnSistema = value; }
        public double TiempoACCentroADetenido { get => tiempoACCentroADetenido; set => tiempoACCentroADetenido = value; }
        public int ContadorTrabajosFinalizados { get => contadorTrabajosFinalizados; set => contadorTrabajosFinalizados = value; }
        public double TiempoACTrabajosFinalizados { get => tiempoACTrabajosFinalizados; set => tiempoACTrabajosFinalizados = value; }
        public string Trabajos { get => trabajos; set => trabajos = value; }
        internal EquipoSecado[] EquiposSecado { get => equiposSecado; set => equiposSecado = value; }

        public Fila()
        {
            ColaLlegadas = 0;
            ColaCentroB = 0;
            ContadorTrabajosEnSistema = 0;
            CantidadMaximaTrabajosEnSistema = 0;
            TiempoACCentroADetenido = 0;
            ContadorTrabajosFinalizados = 0;
            TiempoACTrabajosFinalizados = 0;
            EquiposSecado = new EquipoSecado[5];
            for (int i = 0; i < 5; i++)
            {
                EquiposSecado[i] = new EquipoSecado();
            }
        }

        public List<String> getColumnas()
        {
            List<string> columnas = new List<string>(67);
            columnas.Add("Evento");
            columnas.Add("Reloj (min)");

            //EVENTOS
            columnas.Add("RND Llegadas entre trabajos");
            columnas.Add("Tiempo entre llegadas trabajo");
            columnas.Add("Próxima Llegada Trabajo");

            columnas.Add("RND Atención Centro A");
            columnas.Add("Tiempo Atención Centro A");
            columnas.Add("Próximo Fin Atención A");

            columnas.Add("RND1 Atención Centro B");
            columnas.Add("RND2 Atención Centro B");
            columnas.Add("Tiempo Atención Centro B");
            columnas.Add("Próximo Fin Atención B");

            columnas.Add("Tiempo Fin Secado");
            columnas.Add("Próximo Fin Secado");

            //SERVIDORES
            columnas.Add("Estado Centro A");
            columnas.Add("Estado Centro B");
            columnas.Add("Estado Equipo1");
            columnas.Add("Fin secado1 Equipo1");
            columnas.Add("Fin secado2 Equipo1");
            columnas.Add("Fin secado1 Equipo2");
            columnas.Add("Fin secado2 Equipo2");
            columnas.Add("Fin secado1 Equipo3");
            columnas.Add("Fin secado2 Equipo3");
            columnas.Add("Fin secado1 Equipo4");
            columnas.Add("Fin secado2 Equipo4");
            columnas.Add("Fin secado1 Equipo5");
            columnas.Add("Fin secado2 Equipo5");

            //COLAS
            columnas.Add("Cola de Llegadas");
            columnas.Add("Cola de Centro B");

            //ESTADÍSTICAS
            columnas.Add("Contador de trabajos en sistema");
            columnas.Add("Cant. Máx de trabajos en sistema");
            columnas.Add("Tiempo AC Centro A detenido");
            columnas.Add("Contador trabajos finalizados");
            columnas.Add("Tiempo AC trabajos finalizados");

            //OBJETOS TEMPORALES
            //TODO: ver como agg
            columnas.Add("Trabajos");

            return columnas;
        }
    }

    internal class EquipoSecado
    {
        private string estado;
        private double finSecado1;
        private double finSecado2;

        public string Estado { get => estado; set => estado = value; }
        public double FinSecado1 { get => finSecado1; set => finSecado1 = value; }
        public double FinSecado2 { get => finSecado2; set => finSecado2 = value; }

        public EquipoSecado()
        {
            Estado = 
        }
    }
}
