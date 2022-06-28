using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistemas_de_Colas.Modelo
{
    class RungeKutta
    {
        private string tipo;
        private double h;

        public const String unTrabajo = "1 trabajo";
        public const String dosTrabajos = "2 trabajos";

        public DataTable tabla;

        public RungeKutta(string tipo)
        {
            this.h = 0.01;
        }

        public double integracionNumerica(double reloj, string tipo) //rndB es opcional (solo se usa para instante_bloqueo)
        {
            Fila fila = new Fila();

            //Instante inicial M(0)=100
            fila.Tiempo = 0;
            fila.IndiceSecado = 100;

            if (tabla == null)
                tabla = crearTabla();

            tabla.Rows.Add("Reloj:" + truncar(1000 * reloj) / 1000);
            switch (tipo)
            {
                case unTrabajo:
                    while (true)
                    {
                        fila.K1 = truncar(1000 * ecuacionDiferencialUnTrabajo(fila.Tiempo, fila.IndiceSecado));
                        fila.K2 = truncar(1000 * ecuacionDiferencialUnTrabajo(fila.Tiempo + h/2, fila.IndiceSecado + h/(2*fila.K1)));
                        fila.K3 = truncar(1000 * ecuacionDiferencialUnTrabajo(fila.Tiempo + h/2, fila.IndiceSecado + h/(2*fila.K2)));
                        fila.K4 = truncar(1000 * ecuacionDiferencialUnTrabajo(fila.Tiempo + h, fila.IndiceSecado + h*fila.K3));
                        fila.TiempoSiguiente = truncar(1000 * (fila.Tiempo + h));
                        fila.IndiceSecadoSiguiente = truncar(1000 * (fila.IndiceSecado + (h/6) * (fila.K1 + 2*fila.K2 + 2*fila.K3 + fila.K4)));

                        agregarFilaTabla(fila);

                        if (fila.IndiceSecado <  1)
                        {
                            tabla.Rows.Add();
                            return fila.Tiempo;
                        }

                        //Para fila siguiente
                        fila.Tiempo = fila.TiempoSiguiente;
                        fila.IndiceSecado = fila.IndiceSecadoSiguiente;
                    }

                case dosTrabajos: 
                    while (true)
                    {
                        fila.K1 = truncar(ecuacionDiferencialDosTrabajos(fila.Tiempo, fila.IndiceSecado));
                        fila.K2 = truncar(1000 * ecuacionDiferencialDosTrabajos(fila.Tiempo + h/2, fila.IndiceSecado + h/(2*fila.K1)));
                        fila.K3 = truncar(1000 * ecuacionDiferencialDosTrabajos(fila.Tiempo + h/2, fila.IndiceSecado + h/(2*fila.K2)));
                        fila.K4 = truncar(1000 * ecuacionDiferencialDosTrabajos(fila.Tiempo + h, fila.IndiceSecado + h*fila.K3));
                        fila.TiempoSiguiente = truncar(1000 * (fila.Tiempo + h));
                        fila.IndiceSecadoSiguiente = truncar(1000 * (fila.IndiceSecado + (h/6) * (fila.K1 + 2 * fila.K2 + 2 * fila.K3 + fila.K4)));

                        agregarFilaTabla(fila);

                        if (fila.IndiceSecado < 1)
                        {
                            tabla.Rows.Add();
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
            return Math.Truncate(1000 * numero) / 1000;
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

        private void agregarFilaTabla(Fila fila)
        { 
            this.tabla.Rows.Add(fila.Tiempo, fila.IndiceSecado, fila.K1, fila.K2, fila.K3, fila.K4, fila.TiempoSiguiente, fila.IndiceSecadoSiguiente);
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
