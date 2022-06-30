using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Modelo
{
    class RungeKutta
    {
        private double h;

        public const String unTrabajo = "1 trabajo";
        public const String dosTrabajos = "2 trabajos";
        private double tiempoSecado1Trabajo;
        private double tiempoSecado2Trabajos;

        private DataTable tabla1Trabajo;
        private DataTable tabla2Trabajos;

        public DataTable Tabla1Trabajo { get => tabla1Trabajo; set => tabla1Trabajo = value; }
        public DataTable Tabla2Trabajos { get => tabla2Trabajos; set => tabla2Trabajos = value; }

        public RungeKutta()
        {
            this.h = 1;
        }

        public double integracionNumerica(double reloj, string tipo) 
        {
            if (tipo == unTrabajo && tiempoSecado1Trabajo.Equals(null))
                return tiempoSecado1Trabajo;
            if (tipo == dosTrabajos && tiempoSecado2Trabajos.Equals(null))
                return tiempoSecado2Trabajos;
            Fila fila = new Fila();

            //Instante inicial M(0)=100
            fila.Tiempo = 0;
            fila.IndiceSecado = 100;

            switch (tipo)
            {
                case unTrabajo:
                    if (Tabla1Trabajo == null)
                        Tabla1Trabajo = crearTabla();
                    Tabla1Trabajo.Rows.Add("Reloj:" + truncar(1000 * reloj) / 1000);
                    while (true)
                    {
                        fila.K1 = ecuacionDiferencialUnTrabajo(fila.Tiempo, fila.IndiceSecado);
                        fila.K2 = ecuacionDiferencialUnTrabajo(fila.Tiempo + h/2, fila.IndiceSecado + h/2*fila.K1);
                        fila.K3 = ecuacionDiferencialUnTrabajo(fila.Tiempo + h/2, fila.IndiceSecado + h/2*fila.K2);
                        fila.K4 = ecuacionDiferencialUnTrabajo(fila.Tiempo + h, fila.IndiceSecado + h*fila.K3);
                        fila.TiempoSiguiente = (fila.Tiempo + h);
                        fila.IndiceSecadoSiguiente = (fila.IndiceSecado + (h/6) * (fila.K1 + 2*fila.K2 + 2*fila.K3 + fila.K4));

                        agregarFilaTabla(fila, Tabla1Trabajo);

                        if (fila.IndiceSecado <  1)
                        {
                            Tabla1Trabajo.Rows.Add();
                            tiempoSecado1Trabajo = fila.Tiempo;
                            return fila.Tiempo;
                        }

                        //Para fila siguiente
                        fila.Tiempo = fila.TiempoSiguiente;
                        fila.IndiceSecado = fila.IndiceSecadoSiguiente;
                    }

                case dosTrabajos:
                    if (Tabla2Trabajos == null)
                        Tabla2Trabajos = crearTabla();
                    Tabla2Trabajos.Rows.Add("Reloj:" + truncar(1000 * reloj) / 1000);
                    while (true)
                    {
                        fila.K1 = ecuacionDiferencialDosTrabajos(fila.Tiempo, fila.IndiceSecado);
                        fila.K2 = ecuacionDiferencialDosTrabajos(fila.Tiempo + h/2, fila.IndiceSecado + h/2*fila.K1);
                        fila.K3 = ecuacionDiferencialDosTrabajos(fila.Tiempo + h/2, fila.IndiceSecado + h/2*fila.K2);
                        fila.K4 = ecuacionDiferencialDosTrabajos(fila.Tiempo + h, fila.IndiceSecado + h*fila.K3);
                        fila.TiempoSiguiente = (fila.Tiempo + h);
                        fila.IndiceSecadoSiguiente = (fila.IndiceSecado + (h/6) * (fila.K1 + 2 * fila.K2 + 2 * fila.K3 + fila.K4));

                        agregarFilaTabla(fila, Tabla2Trabajos);

                        if (fila.IndiceSecado < 1)
                        {
                            Tabla2Trabajos.Rows.Add();
                            tiempoSecado2Trabajos = fila.Tiempo;
                            return fila.Tiempo;
                        }

                        //Para fila siguiente
                        fila.Tiempo = fila.TiempoSiguiente;
                        fila.IndiceSecado = fila.IndiceSecadoSiguiente;
                    }
                default:
                    return 0;
            }
        }

        public double ecuacionDiferencialUnTrabajo(double tiempo, double indiceSecado)
        {
            return -0.05 * indiceSecado -0.0001 * tiempo;
        }

        public double ecuacionDiferencialDosTrabajos(double tiempo, double indiceSecado)
        {
            return -0.05 * indiceSecado + 0.04 - 0.0001 * tiempo;
        }

        private double truncar(double numero)
        {
            return Math.Truncate(10000 * numero) / 10000;
        }

        private DataTable crearTabla()
        {
            DataTable tabla = new DataTable();
            string[] columnas = new string[] { "t", "M", "K1", "K2", "K3", "K4", "t(i+1)", "M(t+i)"};
            for (int i = 0; i < columnas.Length; i++)
            {
                tabla.Columns.Add(columnas[i]);
            }
            return tabla;
        }

        private void agregarFilaTabla(Fila fila, DataTable tabla)
        { 
            tabla.Rows.Add(truncar(fila.Tiempo), truncar(fila.IndiceSecado), truncar(fila.K1), truncar(fila.K2), truncar(fila.K3), truncar(fila.K4), truncar(fila.TiempoSiguiente), truncar(fila.IndiceSecadoSiguiente));
        }

        internal class Fila
        {
            private double tiempo;
            private double indiceSecado;
            private double k1;
            private double k2;
            private double k3;
            private double k4;
            private double tiempoSiguiente;
            private double indiceSecadoSiguiente;

            public double Tiempo { get => tiempo; set => tiempo = value; }
            public double IndiceSecado { get => indiceSecado; set => indiceSecado = value; }
            public double K1 { get => k1; set => k1 = value; }
            public double K2 { get => k2; set => k2 = value; }
            public double K3 { get => k3; set => k3 = value; }
            public double K4 { get => k4; set => k4 = value; }
            public double TiempoSiguiente { get => tiempoSiguiente; set => tiempoSiguiente = value; }
            public double IndiceSecadoSiguiente { get => indiceSecadoSiguiente; set => indiceSecadoSiguiente = value; }
        }
    }
}
