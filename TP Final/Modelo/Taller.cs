using System.Data;
using TPFinal.Modelo;

namespace TP_Final.Modelo
{
    class Taller
    {
        public DataTable tablaSimulacion;

        public void simulacion(double cantSimulacion, double minDesde, double filaDesde, double mediaLlegadas, double limiteInfAtencionA, double limiteSupAtencionA, double mediaAtencionB, double DesvEstAtencionB)
        {
            Random generadorRNDLlegadaTrabajos = new Random();
            Random generadorRNDAtencionA = new Random();
            Random generadorRNDAtencionB = new Random();

            RungeKutta rungeKutta = new RungeKutta();

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

            while (fila.Reloj < cantSimulacion)
            {
                //Reiniciar RNDs y Tiempos en la nueva fila
                fila.RNDLlegadaTrabajo = 0;
                fila.TiempoEntreLlegadas = 0;
                fila.RNDAtencionA = 0;
                fila.TiempoAtencionA = 0;
                fila.RND1AtencionB = 0;
                fila.RND2AtencionB = 0;
                fila.TiempoAtencionB = 0;
                fila.TiempoFinSecado = 0;

                proximoTiempo = fila.calcularProximoTiempo();

                // ---------------------------------------------------------- EVENTOS
                // ------------ Evento LLEGADA TRABAJO
                if(proximoTiempo == fila.ProximaLlegadaTrabajo)
                {
                    fila.llegadaTrabajo(generadorRNDLlegadaTrabajos, mediaLlegadas, generadorRNDAtencionA, limiteInfAtencionA, limiteSupAtencionA, tablaSimulacion);
                   
                }
                agregarFilaTabla(fila);
                break;
            }
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
            int tamañoFilaTabla = 38 + fila.Trabajos.Count;
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
