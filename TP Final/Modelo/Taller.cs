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
            filaAnterior.RNDLlegadaTrabajo = generadorRNDLlegadaTrabajos.NextDouble();
            filaAnterior.TiempoEntreLlegadas = -mediaLlegadas * Math.Log(1 - filaAnterior.RNDLlegadaTrabajo);
            filaAnterior.ProximaLlegadaTrabajo = filaAnterior.TiempoEntreLlegadas;

            Fila fila = filaAnterior.copiarFila();
            //agregarFilaTabla(fila);


            //Variables auxiliares
            int contadorFilas = 0;
            double proximoTiempo;
            double promedioTiempoTrabajos = 0;

            //while (fila.Reloj < cantSimulacion)
            while (contadorFilas <= 2)
            {
                //Reiniciar RNDs y Tiempos en la nueva fila
                fila.RNDLlegadaTrabajo = 0;
                fila.TiempoEntreLlegadas = 0;
                fila.RNDAtencionA = 0;
                if (filaAnterior.CrearRNDsNormal)
                {
                    fila.RND1AtencionB = 0;
                    fila.RND2AtencionB = 0;
                }
                else
                {
                    fila.RND1AtencionB = filaAnterior.RND1AtencionB;
                    fila.RND2AtencionB = filaAnterior.RND2AtencionB;
                }
                fila.TiempoAtencionA = 0;
                fila.TiempoAtencionB = 0;
                fila.TiempoFinSecado = 0;

                proximoTiempo = fila.calcularProximoTiempo();

                // ---------------------------------------------------------- EVENTOS
                // ------------ Evento LLEGADA TRABAJO
                if(proximoTiempo == fila.ProximaLlegadaTrabajo)
                {
                    fila.llegadaTrabajo();
                }
                // ------------ Evento FIN ATENCION A
                else if(proximoTiempo == fila.ProximoFinAtencionA)
                {
                    fila.finAtencionA();
                }
                
                //----------------------------------------------------------- ESTADISTICAS
                //Cantidad maxima de Trabajos en Sistema
                if (filaAnterior.CantidadMaximaTrabajosEnSistema < fila.ContadorTrabajosEnSistema)
                    fila.CantidadMaximaTrabajosEnSistema = fila.ContadorTrabajosEnSistema;

                if (fila.Reloj < cantSimulacion && contadorFilas < cantidadFilasAMostrar)
                {
                    agregarFilaTabla(fila);
                    contadorFilas++;
                }
                else
                    break;
            }
            if (fila.ContadorTrabajosFinalizados != 0)
                promedioTiempoTrabajos = fila.TiempoACTrabajosFinalizados / fila.ContadorTrabajosFinalizados;
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

        private void agregarFilaTabla(Fila fila)
        {
            int tamañoFilaTabla = 38 + 2 * fila.Trabajos.Count;
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
            filaTabla[indice++] = fila.ColaLlegadas.ToString();
            filaTabla[indice++] = fila.ColaCentroB.ToString();
            filaTabla[indice++] = fila.ContadorTrabajosEnSistema.ToString();
            filaTabla[indice++] = fila.CantidadMaximaTrabajosEnSistema.ToString();
            filaTabla[indice++] = (Math.Truncate(1000 * fila.TiempoACCentroADetenido) / 1000).ToString();
            filaTabla[indice++] = fila.ContadorTrabajosFinalizados.ToString();
            filaTabla[indice++] = (Math.Truncate(1000 * fila.TiempoACTrabajosFinalizados) / 1000).ToString();
            for (int i = 0; i < fila.Trabajos.Count; i++)
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
