using System.Data;
using System.Text;
using TPFinal.Modelo;

namespace TP_Final.Modelo
{
    class Taller
    {
        private DataTable tablaSimulacion;
        private Fila fila;
        private Random generadorRNDLlegadaTrabajos;
        private Random generadorRNDAtencionA;
        private Random generadorRNDAtencionB;
        private RungeKutta rungeKutta = new RungeKutta();
        private float mediaLlegadas;
        private float limiteInfAtencionA;
        private float limiteSupAtencionA;
        private float mediaAtencionB;
        private float desvEstandarAtencionB;
        private int cantidadMaxTrabajosMinuto;

        public DataTable TablaSimulacion { get => tablaSimulacion; set => tablaSimulacion = value; }
        internal Fila Fila { get => fila; set => fila = value; }
        public Random GeneradorRNDLlegadaTrabajos { get => generadorRNDLlegadaTrabajos; set => generadorRNDLlegadaTrabajos = value; }
        public Random GeneradorRNDAtencionA { get => generadorRNDAtencionA; set => generadorRNDAtencionA = value; }
        public Random GeneradorRNDAtencionB { get => generadorRNDAtencionB; set => generadorRNDAtencionB = value; }
        internal RungeKutta RungeKutta { get => rungeKutta; set => rungeKutta = value; }
        public float MediaLlegadas { get => mediaLlegadas; set => mediaLlegadas = value; }
        public float LimiteInfAtencionA { get => limiteInfAtencionA; set => limiteInfAtencionA = value; }
        public float LimiteSupAtencionA { get => limiteSupAtencionA; set => limiteSupAtencionA = value; }
        public float MediaAtencionB { get => mediaAtencionB; set => mediaAtencionB = value; }
        public float DesvEstandarAtencionB { get => desvEstandarAtencionB; set => desvEstandarAtencionB = value; }
        public int CantidadMaxTrabajosMinuto { get => cantidadMaxTrabajosMinuto; set => cantidadMaxTrabajosMinuto = value; }

        public Taller()
        {
            RungeKutta = new RungeKutta();
            GeneradorRNDLlegadaTrabajos = new Random();
            GeneradorRNDAtencionA = new Random();
            GeneradorRNDAtencionB = new Random();
        }

        public void simulacion(int cantSimulacion, float minDesde, int cantidadFilasAMostrar, int minutoCantMaxTrabajos, float mediaLlegadas, float limiteInfAtencionA, float limiteSupAtencionA, float mediaAtencionB, float desvEstAtencionB)
        {
            MediaLlegadas = mediaLlegadas;
            LimiteInfAtencionA = limiteInfAtencionA;
            LimiteSupAtencionA = limiteSupAtencionA;
            MediaAtencionB = mediaAtencionB;
            DesvEstandarAtencionB = desvEstAtencionB;

            generarTabla();

            //Fila inicial
            Fila filaAnterior = new Fila(0, this);
            filaAnterior.Evento = "Inicio Simulación";
            filaAnterior.RNDLlegadaTrabajo = (float) Math.Truncate(1000 * GeneradorRNDLlegadaTrabajos.NextDouble()) / 1000;
            filaAnterior.TiempoEntreLlegadas = -mediaLlegadas * (float) Math.Log(1 - filaAnterior.RNDLlegadaTrabajo);
            filaAnterior.ProximaLlegadaTrabajo = filaAnterior.TiempoEntreLlegadas;

            Fila = filaAnterior.copiarFila();
            agregarFilaTabla(Fila);


            //Variables auxiliares
            int contadorFilas = 0;
            float proximoTiempo;
            float promedioTiempoTrabajos = 0;
            bool cantidadMaxTrabajosSeteado = false;

            while (Fila.Reloj < cantSimulacion)
            {
                //Reiniciar RNDs y Tiempos en la nueva fila
                Fila.RNDLlegadaTrabajo = float.NaN;
                Fila.TiempoEntreLlegadas = 0;
                Fila.RNDAtencionA = float.NaN;
                if (filaAnterior.CrearRNDsNormal)
                {
                    Fila.RND1AtencionB = float.NaN;
                    Fila.RND2AtencionB = float.NaN;
                }
                else
                {
                    Fila.RND1AtencionB = filaAnterior.RND1AtencionB;
                    Fila.RND2AtencionB = filaAnterior.RND2AtencionB;
                }
                Fila.TiempoAtencionA = 0;
                Fila.TiempoAtencionB = 0;
                Fila.TiempoFinSecado = 0;


                proximoTiempo = Fila.calcularProximoTiempo(filaAnterior);

                //Cantidad maxima de trabajos en el minuto indicado por el usuario
                if (!cantidadMaxTrabajosSeteado && proximoTiempo > minutoCantMaxTrabajos)
                {
                    CantidadMaxTrabajosMinuto = filaAnterior.CantidadMaximaTrabajosEnSistema;
                    cantidadMaxTrabajosSeteado = true;
                }

                // ---------------------------------------------------------- EVENTOS
                // ------------ Evento LLEGADA TRABAJO
                if (proximoTiempo > cantSimulacion) //Agego la ultima fila y termino la simulacion
                {
                    crearFilaFinSimulacion(filaAnterior, cantSimulacion);
                    agregarFilaTabla(filaAnterior);
                    break;
                }
                else if (proximoTiempo == Fila.ProximaLlegadaTrabajo)
                {
                    Fila.llegadaTrabajo();
                }
                // ------------ Evento FIN ATENCION A
                else if (proximoTiempo == Fila.ProximoFinAtencionA)
                {
                    Fila.finAtencionA();
                }
                // ------------ Evento FIN ATENCION B
                else if (proximoTiempo == Fila.ProximoFinAtencionB)
                {
                    Fila.finAtencionB();
                }
                else if (proximoTiempo == Fila.ProximoFinSecado)
                {
                    Fila.finSecado(Fila.ProximoFinSecado);
                }

                Fila.setProximoFinSecado();

                //------- ESTADISTICAS
                //Cantidad maxima de Trabajos en Sistema
                if (filaAnterior.CantidadMaximaTrabajosEnSistema < Fila.ContadorTrabajosEnSistema)
                    Fila.CantidadMaximaTrabajosEnSistema = Fila.ContadorTrabajosEnSistema;
                //Acumular tiempo de Centro A detenido
                if (filaAnterior.EstadoCentroA == Fila.estadoDetenido)
                    Fila.TiempoACCentroADetenido += Fila.Reloj - filaAnterior.Reloj;


                //AGREGAR FILA A TABLA
                if (Fila.Reloj > minDesde && Fila.Reloj < cantSimulacion && contadorFilas < cantidadFilasAMostrar)
                {
                    agregarFilaTabla(Fila);
                    contadorFilas++;
                }

                filaAnterior = Fila.copiarFila();
            }

            if (Fila.ContadorTrabajosFinalizados != 0)
                promedioTiempoTrabajos = Fila.TiempoACTrabajosFinalizados / Fila.ContadorTrabajosFinalizados;
        }

        private void generarTabla()
        {
            TablaSimulacion = new DataTable();
            List<string> columnas = Fila.getColumnas();
            for (int i = 0; i < columnas.Count; i++)
                TablaSimulacion.Columns.Add(columnas[i]);
        }

        private void agregarFilaTabla(Fila fila)
        {
            int indiceTrabajosNoDestruidos = 0;
            for (int i = 0; i < fila.Trabajos.Count; i++)
            {
                if (fila.Trabajos[i].Estado != Trabajo.estadoDestruido)
                {
                    indiceTrabajosNoDestruidos = i;
                    break;
                }
            }
            int tamañoFilaTabla = 39;
            string[] filaTabla = new string[tamañoFilaTabla];
            int indice = 0;
            filaTabla[indice++] = fila.Evento;
            filaTabla[indice++] = (Math.Truncate(1000 * fila.Reloj) / 1000).ToString();
            filaTabla[indice++] = beautifyRND(fila.RNDLlegadaTrabajo);
            filaTabla[indice++] = beautify(fila.TiempoEntreLlegadas);
            filaTabla[indice++] = beautify(fila.ProximaLlegadaTrabajo);
            filaTabla[indice++] = beautifyRND(fila.RNDAtencionA);
            filaTabla[indice++] = beautify(fila.TiempoAtencionA);
            filaTabla[indice++] = beautify(fila.ProximoFinAtencionA);
            filaTabla[indice++] = beautifyRND(fila.RND1AtencionB);
            filaTabla[indice++] = beautifyRND(fila.RND2AtencionB);
            filaTabla[indice++] = beautify(fila.TiempoAtencionB);
            filaTabla[indice++] = beautify(fila.ProximoFinAtencionB);
            filaTabla[indice++] = beautify(fila.TiempoFinSecado);
            filaTabla[indice++] = beautify(fila.ProximoFinSecado);
            filaTabla[indice++] = fila.EstadoCentroA;
            filaTabla[indice++] = fila.EstadoCentroB;
            for (int i = 0; i < fila.EquiposSecado.Length; i++)
            {
                filaTabla[indice++] = fila.EquiposSecado[i].Estado;
                filaTabla[indice++] = beautify(fila.EquiposSecado[i].FinSecado1);
                filaTabla[indice++] = beautify(fila.EquiposSecado[i].FinSecado2);
            }
            filaTabla[indice++] = fila.ColaLlegadas.Count.ToString();
            filaTabla[indice++] = fila.ColaCentroB.Count.ToString();
            filaTabla[indice++] = fila.ContadorTrabajosEnSistema.ToString();
            filaTabla[indice++] = fila.CantidadMaximaTrabajosEnSistema.ToString();
            filaTabla[indice++] = (Math.Truncate(1000 * fila.TiempoACCentroADetenido) / 1000).ToString();
            filaTabla[indice++] = fila.ContadorTrabajosFinalizados.ToString();
            filaTabla[indice++] = (Math.Truncate(1000 * fila.TiempoACTrabajosFinalizados) / 1000).ToString();
            StringBuilder stringTrabajos = new StringBuilder("");
            if (fila.Trabajos.Count > 0) 
            {
                for (int i = indiceTrabajosNoDestruidos; i < fila.Trabajos.Count; i++)
                {
                    if (fila.Trabajos[i].Estado == Trabajo.estadoDestruido)
                        continue;
                    stringTrabajos.Append("(" + (i + 1).ToString() + ")" + fila.Trabajos[i].Estado + "-" + beautify(fila.Trabajos[i].TiempoLlegada).ToString() + "    ");
                }
            }
            filaTabla[indice] = stringTrabajos.ToString();

            TablaSimulacion.Rows.Add(filaTabla);
        }

        private string beautify(float number)
        { 
            if (number == 0) 
                return "";
            return (Math.Truncate(1000 * number) / 1000).ToString();
        }
        
        private string beautifyRND(float number)
        {
            if (number.Equals(float.NaN))
                return "";
            return (Math.Truncate(1000 * number) / 1000).ToString();
        }

        private void crearFilaFinSimulacion(Fila ultimaFila, float cantSimulacion)
        {
            ultimaFila.Reloj = cantSimulacion;
            ultimaFila.Evento = "Fin Simulación";
            ultimaFila.RNDLlegadaTrabajo = float.NaN;
            ultimaFila.RNDAtencionA = float.NaN;
            ultimaFila.RND1AtencionB = float.NaN;
            ultimaFila.RND2AtencionB = float.NaN;
            ultimaFila.TiempoEntreLlegadas = 0;
            ultimaFila.TiempoAtencionA = 0;
            ultimaFila.TiempoAtencionB = 0;
            ultimaFila.TiempoFinSecado = 0;
        }
    }
}
