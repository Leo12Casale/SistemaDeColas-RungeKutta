using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final.Modelo
{
    internal class Fila
    {
        //ESTADOS POSIBLES SERVIDORES
        public const string estadoLibre = "Libre";
        public const string estadoOcupado = "Ocupado";
        public const string estadoDetenido = "Detenido";
        //ESTADOS POSIBLES TRABAJOS
        public const string estadoEsperandoAtencionA = "EAA";
        public const string estadoSiendoAtendidoA = "SAA";
        public const string estadoDetenidoCentroA = "DA";
        public const string estadoEsperandoAtencionB = "EAB";
        public const string estadoSiendoAtendidoB = "SAB";
        public const string estadoDetenidoCentroB = "DB";
        public const string estadoSiendoAtendidoSecado = "SAS";
        public const string estadoDestruido = "X";
        private int contadorTrabajosLlegados = 0;
        //Nombres de Eventos
        public const string eventoLlegadaTrabajo = "Llegada Trabajo";
        public const string eventoFinAtencionA = "Fin Atención A";
        public const string eventoDetencionAtencionA = "Detención Atención A";
        public const string eventoFinAtencionB = "Fin Atención B";
        public const string eventoDetencionAtencionB = "Detención Atención B";
        public const string eventoFinSecado = "Fin Secado";

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
        private int indiceTrabajoCentroA;
        private string estadoCentroB;
        private int indiceTrabajoCentroB;
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
        private List<Trabajo> trabajos;

        private bool crearRNDsNormal;

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
        internal EquipoSecado[] EquiposSecado { get => equiposSecado; set => equiposSecado = value; }
        internal List<Trabajo> Trabajos { get => trabajos; set => trabajos = value; }
        public int IndiceTrabajoCentroA { get => indiceTrabajoCentroA; set => indiceTrabajoCentroA = value; }
        public int IndiceTrabajoCentroB { get => indiceTrabajoCentroB; set => indiceTrabajoCentroB = value; }
        public bool CrearRNDsNormal { get => crearRNDsNormal; set => crearRNDsNormal = value; }

        public Fila(double reloj)
        {
            Reloj = reloj;
            estadoCentroA = estadoLibre;
            estadoCentroB = estadoLibre;
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
            Trabajos = new List<Trabajo>();
            indiceTrabajoCentroA = -1;
            CrearRNDsNormal = true;
        }

        public Fila copiarFila()
        {
            Fila filaClon = (Fila)this.MemberwiseClone();

            filaClon.equiposSecado = new EquipoSecado[equiposSecado.Length];
            for (int i = 0; i < equiposSecado.Length; i++)
            {
                EquipoSecado equipoClon = new EquipoSecado(equiposSecado[i].Estado, equiposSecado[i].FinSecado1, equiposSecado[i].FinSecado2);
                filaClon.equiposSecado[i] = equipoClon;
            }

            filaClon.Trabajos = new List<Trabajo>(Trabajos.Count);
            for (int i = 0; i < Trabajos.Count; i++)
            {
                Trabajo trabajoClon = new Trabajo(Trabajos[i].Estado, Trabajos[i].TiempoLlegada);
                filaClon.Trabajos[i] = trabajoClon;
            }

            return filaClon;
        }

        public double calcularProximoTiempo()
        {
            double proximaLlegada = double.MaxValue, proximoFinAtencionA = double.MaxValue, proximoFinAtencionB = double.MaxValue, proximoFinSecado = double.MaxValue;
            if (ProximaLlegadaTrabajo != 0)
                proximaLlegada = ProximaLlegadaTrabajo;
            if (ProximoFinAtencionA != 0)
                proximoFinAtencionA = ProximoFinAtencionA;
            if (ProximoFinAtencionB != 0)
                proximoFinAtencionB = ProximoFinAtencionB;
            if (tiempoMinimoEquipoSecado() != 0)
                proximoFinSecado = tiempoMinimoEquipoSecado();
            return Math.Min(proximaLlegada, Math.Min(proximoFinAtencionA, Math.Min(proximoFinAtencionB, proximoFinSecado)));
        }

        private double tiempoMinimoEquipoSecado()
        {
            double tiempoMin = double.MaxValue;
            double tiempoMenorEquipo;
            for (int i = 0; i < this.equiposSecado.Length; i++)
            {
                tiempoMenorEquipo = equiposSecado[i].getTiempoFinSecadoMenor();
                if (tiempoMenorEquipo < tiempoMin)
                    tiempoMin = tiempoMenorEquipo;
            }
            return tiempoMin;
        }



        //---------------------------------------------------------------- EVENTOS
        //--------------------- Evento LLEGADA TRABAJO
        public void llegadaTrabajo()
        {
            //Setteo de Evento y Reloj
            Evento = eventoLlegadaTrabajo;
            Reloj = proximaLlegadaTrabajo;

            //Calculo de la proxima llegada
            RNDLlegadaTrabajo = Taller.generadorRNDLlegadaTrabajos.NextDouble();
            TiempoEntreLlegadas = calcularTiempoEntreLlegadas(RNDLlegadaTrabajo);
            ProximaLlegadaTrabajo = Reloj + TiempoEntreLlegadas;

            contadorTrabajosLlegados++;

            //Atencion de A
            if (estadoCentroA == estadoLibre)
            {
                estadoCentroA = estadoOcupado;
                indiceTrabajoCentroA = contadorTrabajosEnSistema;
                RNDAtencionA = Taller.generadorRNDAtencionA.NextDouble();
                TiempoAtencionA = calcularTiempoAtencionA(RNDAtencionA);
                proximoFinAtencionA = Reloj + TiempoAtencionA;

                //Agrego el trabajo a la fila
                agregarTrabajoFila(estadoSiendoAtendidoA, Reloj);
            }
            else //El trabajo va a la colaLlegada
            {
                colaLlegadas++;
                agregarTrabajoFila(estadoEsperandoAtencionA, Reloj);
            }

            //Estadisticas
            contadorTrabajosEnSistema++;
        }

        private void agregarTrabajoFila(string estadoTrabajo, double reloj)
        {
            Trabajo nuevoTrabajo = new Trabajo(estadoTrabajo, reloj);
            Trabajos.Add(nuevoTrabajo);
            Taller.tablaSimulacion.Columns.Add("Estado Trabajo" + contadorTrabajosLlegados);
            Taller.tablaSimulacion.Columns.Add("Llegada Trabajo" + contadorTrabajosLlegados);
        }


        //--------------------------- Evento FIN ATENCION A
        public void finAtencionA()
        {
            //Setteo de Evento y Reloj
            Evento = eventoFinAtencionA;
            Reloj = proximoFinAtencionA;

            //Cómo sigue el TRABAJO
            //Si el centro B esta libre, pasa a atenderse ahi
            if (estadoCentroB == estadoLibre)
            {
                //Ocupar Centro B
                Trabajos[indiceTrabajoCentroA].Estado = estadoSiendoAtendidoB;
                estadoCentroB = estadoOcupado;
                indiceTrabajoCentroB = indiceTrabajoCentroA;

                //Tiempo Atencion Centro B
                //Si los RNDs no se crearon, crearlos
                if (CrearRNDsNormal) {
                    RND1AtencionB = Taller.generadorRNDAtencionB.NextDouble();
                    RND2AtencionB = Taller.generadorRNDAtencionB.NextDouble();
                    CrearRNDsNormal = false;
                }
                else 
                //Si los RNDs se usaron una vez, usar los mismos y settear true para que la proxima vez se creen de nuevo
                {
                    CrearRNDsNormal = true;
                }
                TiempoAtencionB = calcularTiempoAtencionB(RND1AtencionB, RND2AtencionB, CrearRNDsNormal);
                proximoFinAtencionB = Reloj + TiempoAtencionB;
            }

            //Si el centro B NO esta libre, se fija si tiene lugar en la cola
            else if(colaCentroB < 3) //Si hay lugar en cola
            {
                colaCentroB++;

            }
            //No hay lugar en cola --> detiene Atencion A
            else
            {

            }

            //Cómo sigue el CENTRO A
            //El Centro A chequea si atender otro trabajo o se libera
            if (colaLlegadas > 0)
            {
                int indiceTrabajoEsperandoAtencionA = getIndiceTrabajoEsperandoAtencionA();

                //Actualizo estados de Centro A y trabajo
                Trabajos[indiceTrabajoEsperandoAtencionA].Estado = estadoSiendoAtendidoA;
                estadoCentroA = estadoOcupado;
                indiceTrabajoCentroA = indiceTrabajoEsperandoAtencionA;

                colaLlegadas--;

                //Fin de Atencion A
                RNDAtencionA = Taller.generadorRNDAtencionA.NextDouble();
                TiempoAtencionA = calcularTiempoAtencionA(RNDAtencionA);
                proximoFinAtencionA = Reloj + TiempoAtencionA;
            }
            else
            {
                estadoCentroA = estadoLibre;
                indiceTrabajoCentroA = -1;
            }
        }

        private int getIndiceTrabajoEsperandoAtencionA()
        {
            for (int i = 0; i < Trabajos.Count; i++)
            {
                if (Trabajos[i].Estado == estadoEsperandoAtencionA)
                    return i;
            }
            return -1;
        }

        //----------------------------------------------------------------------------------------------------------------------------

        //Eventos asociadas a DISTRIBUCIONES
        private double calcularTiempoEntreLlegadas(double RND)
        {
            return -Taller.mediaLlegadas * Math.Log(1 - RND);
        }

        private double calcularTiempoAtencionA(double RND)
        {
            return Taller.limiteInfAtencionA + RND * (Taller.limiteSupAtencionA - Taller.limiteInfAtencionA);
        }

        private double calcularTiempoAtencionB(double RND1, double RND2, bool segundoCalculo)
        {
            if (!segundoCalculo)
            {
                return (Math.Sqrt(-2 * Math.Log(RND1)) * Math.Cos(2 * Math.PI * RND2)) * Taller.desvEstandarAtencionB + Taller.mediaAtencionB;
            }
            return (Math.Sqrt(-2 * Math.Log(RND1)) * Math.Sin(2 * Math.PI * RND2)) * Taller.desvEstandarAtencionB + Taller.mediaAtencionB;
        }

        public static List<String> getColumnas()
        {
            List<string> columnas = new List<string>(38);
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
            columnas.Add("Estado Equipo2");
            columnas.Add("Fin secado1 Equipo2");
            columnas.Add("Fin secado2 Equipo2");
            columnas.Add("Estado Equipo3");
            columnas.Add("Fin secado1 Equipo3");
            columnas.Add("Fin secado2 Equipo3");
            columnas.Add("Estado Equipo4");
            columnas.Add("Fin secado1 Equipo4");
            columnas.Add("Fin secado2 Equipo4");
            columnas.Add("Estado Equipo5");
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

            return columnas;
        }
    }

    internal class EquipoSecado
    {
        private string estado;
        private int indiceTrabajo1;
        private double finSecado1;
        private int indiceTrabajo2;
        private double finSecado2;

        public string Estado { get => estado; set => estado = value; }
        public double FinSecado1 { get => finSecado1; set => finSecado1 = value; }
        public double FinSecado2 { get => finSecado2; set => finSecado2 = value; }
        public int IndiceTrabajo1 { get => indiceTrabajo1; set => indiceTrabajo1 = value; }
        public int IndiceTrabajo2 { get => indiceTrabajo2; set => indiceTrabajo2 = value; }

        public EquipoSecado()
        {
            Estado = Fila.estadoLibre;
            FinSecado1 = 0;
            FinSecado2 = 0;
        }

        public EquipoSecado(string estado, double finSecado1, double finSecado2)
        {
            Estado = estado;
            FinSecado1 = finSecado1;
            FinSecado2 = finSecado2;
        }

        public double getTiempoFinSecadoMenor()
        {
            if (this.finSecado1 < this.finSecado2)
                return finSecado1;
            return finSecado2;
        }
    }

    internal class Trabajo
    {
        private string estado;
        private double tiempoLlegada;

        public string Estado { get => estado; set => estado = value; }
        public double TiempoLlegada { get => tiempoLlegada; set => tiempoLlegada = value; }

        public Trabajo(string estado, double tiempoLlegada)
        {
            Estado = estado;
            TiempoLlegada = tiempoLlegada;
        }
    }
}
