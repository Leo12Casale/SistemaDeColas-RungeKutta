using System.Data;
using TPFinal.Modelo;

namespace TP_Final.Modelo
{
    class Taller
    {
        public static DataTable tablaSimulacion;
        public static Random generadorRNDLlegadaTrabajos = new Random();
        public static Random generadorRNDAtencionA = new Random();
        public static Random generadorRNDAtencionB = new Random();
        public static RungeKutta rungeKutta = new RungeKutta();
        public static double mediaLlegadas;
        public static double limiteInfAtencionA;
        public static double limiteSupAtencionA;
        public static double mediaAtencionB;
        public static double desvEstandarAtencionB;
        private Fila fila;

        internal Fila Fila { get => fila; set => fila = value; }

        public void simulacion(double cantSimulacion, double minDesde, double cantidadFilasAMostrar, double mediaLlegadas, double limiteInfAtencionA, double limiteSupAtencionA, double mediaAtencionB, double desvEstAtencionB)
        {
            Taller.mediaLlegadas = mediaLlegadas;
            Taller.limiteInfAtencionA = limiteInfAtencionA;
            Taller.limiteSupAtencionA = limiteSupAtencionA;
            Taller.mediaAtencionB = mediaAtencionB;
            Taller.desvEstandarAtencionB = desvEstAtencionB;

            generarTabla();

            //Fila inicial
            Fila filaAnterior = new Fila(0);
            filaAnterior.RNDLlegadaTrabajo = Math.Truncate(1000 * generadorRNDLlegadaTrabajos.NextDouble()) / 1000;
            filaAnterior.TiempoEntreLlegadas = -mediaLlegadas * Math.Log(1 - filaAnterior.RNDLlegadaTrabajo);
            filaAnterior.ProximaLlegadaTrabajo = filaAnterior.TiempoEntreLlegadas;

            Fila = filaAnterior.copiarFila();
            agregarFilaTabla(Fila, 0);


            //Variables auxiliares
            int contadorFilas = 0;
            double proximoTiempo;
            double promedioTiempoTrabajos = 0;
            int indiceTrabajosNoDestruidos = 0;
            bool indiceCalculado = false;

            while (fila.Reloj < cantSimulacion)
            {
                //Reiniciar RNDs y Tiempos en la nueva fila
                Fila.RNDLlegadaTrabajo = 0;
                Fila.TiempoEntreLlegadas = 0;
                Fila.RNDAtencionA = 0;
                if (filaAnterior.CrearRNDsNormal)
                {
                    Fila.RND1AtencionB = 0;
                    Fila.RND2AtencionB = 0;
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

                // ---------------------------------------------------------- EVENTOS
                // ------------ Evento LLEGADA TRABAJO
                if (proximoTiempo == Fila.ProximaLlegadaTrabajo)
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


                //----------------------------------------------------------- ESTADISTICAS
                //Cantidad maxima de Trabajos en Sistema
                if (filaAnterior.CantidadMaximaTrabajosEnSistema < Fila.ContadorTrabajosEnSistema)
                    Fila.CantidadMaximaTrabajosEnSistema = Fila.ContadorTrabajosEnSistema;

                if (Fila.Reloj > minDesde && Fila.Reloj < cantSimulacion && contadorFilas < cantidadFilasAMostrar)
                {
                    if (!indiceCalculado)
                    {
                        indiceTrabajosNoDestruidos = fila.getCantidadTrabajosNoDestruidos();
                        indiceCalculado = true;
                    }
                    fila.setProximoFinSecado();
                    agregarFilaTabla(Fila, indiceTrabajosNoDestruidos);
                    contadorFilas++;
                }
                else

                //Acumular tiempo de Centro A detenido
                if (filaAnterior.EstadoCentroA == Fila.estadoDetenido)
                {
                    Fila.TiempoACCentroADetenido += Fila.Reloj - filaAnterior.Reloj;
                }

                filaAnterior = Fila.copiarFila();
            }
            if (Fila.ContadorTrabajosFinalizados != 0)
                promedioTiempoTrabajos = Fila.TiempoACTrabajosFinalizados / Fila.ContadorTrabajosFinalizados;
        }

        private void generarTabla()
        {
            tablaSimulacion = new DataTable();
            List<string> columnas = Fila.getColumnas();
            for (int i = 0; i < columnas.Count; i++)
            {
                tablaSimulacion.Columns.Add(columnas[i]);
            }
        }

        private void agregarFilaTabla(Fila fila, int indiceTrabajosDesdeMostrar)
        {
            int tamañoFilaTabla = 38 + 2 * (fila.Trabajos.Count - indiceTrabajosDesdeMostrar);
            string[] filaTabla = new string[tamañoFilaTabla];
            int indice = 0;
            filaTabla[indice++] = fila.Evento;
            filaTabla[indice++] = (Math.Truncate(1000 * fila.Reloj) / 1000).ToString();
            filaTabla[indice++] = beautify(fila.RNDLlegadaTrabajo);
            filaTabla[indice++] = beautify(fila.TiempoEntreLlegadas);
            filaTabla[indice++] = beautify(fila.ProximaLlegadaTrabajo);
            filaTabla[indice++] = beautify(fila.RNDAtencionA);
            filaTabla[indice++] = beautify(fila.TiempoAtencionA);
            filaTabla[indice++] = beautify(fila.ProximoFinAtencionA);
            filaTabla[indice++] = beautify(fila.RND1AtencionB);
            filaTabla[indice++] = beautify(fila.RND2AtencionB);
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
            for (int i = indiceTrabajosDesdeMostrar; i < fila.Trabajos.Count; i++)
            {
                filaTabla[indice++] = fila.Trabajos[i].Estado;
                filaTabla[indice++] = beautify(fila.Trabajos[i].TiempoLlegada);
            }

            tablaSimulacion.Rows.Add(filaTabla);
        }

        private string beautify(double number)
        {
            if (number == 0) return "";
            else return (Math.Truncate(1000 * number) / 1000).ToString();
        }
    }
}
