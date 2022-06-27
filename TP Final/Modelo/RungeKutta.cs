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

        public const String proximoBloqueo = "proximo_bloqueo";
        public const String finBloqueoLlegada = "bloqueo_llegada";
        public const String finBloqueoServidor = "bloqueo_servidor";

        public DataTable tabla;

        public RungeKutta(string tipo)
        {
            this.tipo = tipo;
            this.h = 0.1;
        }

        public double integracionNumerica(double reloj, double rndB = 1, double tiempoA = 1) //rndB es opcional (solo se usa para instante_bloqueo)
        {
            Fila fila = new Fila();

            //Instante inicial t0
            fila.Tiempo = 0;
            fila.VarDependiente = Math.Truncate(1000 * reloj) / 1000; //A, L o S dependiendo qué ecuación dif. se use

            if (tabla == null)
                tabla = crearTabla();

            tabla.Rows.Add("Reloj:" + Math.Truncate(1000 * reloj) / 1000);
            switch (this.tipo)
            {
                case proximoBloqueo:
                    fila.VarDependiente = Math.Truncate(1000 * tiempoA) / 1000;
                    while (true)
                    {
                        fila.K1 = Math.Truncate(1000 * ecuacionDiferencialInstanteBloqueo(fila.VarDependiente, rndB)) / 1000;
                        fila.K2 = Math.Truncate(1000 * ecuacionDiferencialInstanteBloqueo(fila.VarDependiente + h / 2 * fila.K1, rndB)) / 1000;
                        fila.K3 = Math.Truncate(1000 * ecuacionDiferencialInstanteBloqueo(fila.VarDependiente + h / 2 * fila.K2, rndB)) / 1000;
                        fila.K4 = Math.Truncate(1000 * ecuacionDiferencialInstanteBloqueo(fila.VarDependiente + h * fila.K3, rndB)) / 1000;
                        fila.TiempoSiguiente = Math.Truncate(1000 * (fila.Tiempo + h)) / 1000;
                        fila.VarDependienteSiguiente = Math.Truncate(1000 * (fila.VarDependiente + (h / 6) * (fila.K1 + 2 * fila.K2 + 2 * fila.K3 + fila.K4))) / 1000;

                        agregarFilaTabla(fila, proximoBloqueo);

                        if (fila.VarDependiente >= 2 * reloj)
                        {
                            tabla.Rows.Add();
                            return fila.Tiempo * 9;
                        }

                        //Para fila siguiente
                        fila.Tiempo = fila.TiempoSiguiente;
                        fila.VarDependiente = fila.VarDependienteSiguiente;
                    }

                case finBloqueoLlegada: 
                    double varDependienteAnterior = 0;
                    while (true)
                    {
                        fila.K1 = Math.Truncate(1000 * ecuacionDiferencialBloqueoLlegada(fila.Tiempo, fila.VarDependiente)) / 1000;
                        fila.K2 = Math.Truncate(1000 * ecuacionDiferencialBloqueoLlegada(fila.Tiempo + h / 2, fila.VarDependiente + h / 2 * fila.K1)) / 1000;
                        fila.K3 = Math.Truncate(1000 * ecuacionDiferencialBloqueoLlegada(fila.Tiempo + h / 2, fila.VarDependiente + h / 2 * fila.K2)) / 1000;
                        fila.K4 = Math.Truncate(1000 * ecuacionDiferencialBloqueoLlegada(fila.Tiempo + h, fila.VarDependiente + h * fila.K3)) / 1000;
                        fila.TiempoSiguiente = Math.Truncate(1000 * (fila.Tiempo + h)) / 1000;
                        fila.VarDependienteSiguiente = Math.Truncate(1000 * (fila.VarDependiente + (h / 6) * (fila.K1 + 2 * fila.K2 + 2 * fila.K3 + fila.K4))) / 1000;

                        agregarFilaTabla(fila, finBloqueoLlegada);

                        if (Math.Abs(varDependienteAnterior - fila.VarDependiente) < 1)
                        {
                            tabla.Rows.Add();
                            return fila.Tiempo * 5;
                        }

                        //Para fila siguiente
                        varDependienteAnterior = fila.VarDependiente;
                        fila.Tiempo = fila.TiempoSiguiente;
                        fila.VarDependiente = fila.VarDependienteSiguiente;
                    }

                case finBloqueoServidor: 
                    while (true)
                    {
                        fila.K1 = Math.Truncate(1000 * ecuacionDiferencialBloqueoServidores(fila.Tiempo, fila.VarDependiente)) / 1000;
                        fila.K2 = Math.Truncate(1000 * ecuacionDiferencialBloqueoServidores(fila.Tiempo + h / 2, fila.VarDependiente + h / 2 * fila.K1)) / 1000;
                        fila.K3 = Math.Truncate(1000 * ecuacionDiferencialBloqueoServidores(fila.Tiempo + h / 2, fila.VarDependiente + h / 2 * fila.K2)) / 1000;
                        fila.K4 = Math.Truncate(1000 * ecuacionDiferencialBloqueoServidores(fila.Tiempo + h, fila.VarDependiente + h * fila.K3)) / 1000;
                        fila.TiempoSiguiente = Math.Truncate(1000 * (fila.Tiempo + h)) / 1000;
                        fila.VarDependienteSiguiente = Math.Truncate(1000 * (fila.VarDependiente + (h / 6) * (fila.K1 + 2 * fila.K2 + 2 * fila.K3 + fila.K4))) / 1000;

                        agregarFilaTabla(fila, finBloqueoServidor);

                        if (fila.VarDependiente >= 1.35 * reloj)
                        {
                            tabla.Rows.Add();
                            return fila.Tiempo * 2;
                        }

                        //Para fila siguiente
                        fila.Tiempo = fila.TiempoSiguiente;
                        fila.VarDependiente = fila.VarDependienteSiguiente;
                    }
                default:
                    return 0;
            }
        }

        public double ecuacionDiferencialInstanteBloqueo(double varDependiente, double rndB)
        {
            return rndB * varDependiente;
        }

        public double ecuacionDiferencialBloqueoLlegada(double tiempo, double varDependiente)
        {
            return -((varDependiente / 0.8) * Math.Pow(tiempo, 2)) - varDependiente;
        }

        public double ecuacionDiferencialBloqueoServidores(double tiempo, double varDependiente)
        {
            return (0.2 * varDependiente) + 3 - tiempo;
        }

        private DataTable crearTabla()
        {
            DataTable tabla = new DataTable();
            string colVarDependiente = "";
            string colVarDependienteSiguiente = "";
            switch (this.tipo)
            {
                case proximoBloqueo:
                    colVarDependiente = "A";
                    colVarDependienteSiguiente = "A(t+i)";
                    break;
                case finBloqueoLlegada:
                    colVarDependiente = "L";
                    colVarDependienteSiguiente = "L(t+i)";
                    break;
                case finBloqueoServidor:
                    colVarDependiente = "S";
                    colVarDependienteSiguiente = "S(t+i)";
                    break;
                default:
                    break;
            }
            string[] columnas = new string[] { "t", colVarDependiente, "K1", "K2", "K3", "K4", "t(i+1)", colVarDependienteSiguiente };
            for (int i = 0; i < columnas.Length; i++)
            {
                tabla.Columns.Add(columnas[i]);
            }
            return tabla;
        }

        private void agregarFilaTabla(Fila fila, string tipo)
        { 
            this.tabla.Rows.Add(fila.Tiempo, fila.VarDependiente, fila.K1, fila.K2, fila.K3, fila.K4, fila.TiempoSiguiente, fila.VarDependienteSiguiente);
        }

        internal class Fila
        {
            private double tiempo;
            private double varDependiente;
            private double k1;
            private double k2;
            private double k3;
            private double k4;
            private double tiempoSiguiente;
            private double varDependienteSiguiente;

            public double Tiempo { get => tiempo; set => tiempo = value; }
            public double VarDependiente { get => varDependiente; set => varDependiente = value; }
            public double K1 { get => k1; set => k1 = value; }
            public double K2 { get => k2; set => k2 = value; }
            public double K3 { get => k3; set => k3 = value; }
            public double K4 { get => k4; set => k4 = value; }
            public double TiempoSiguiente { get => tiempoSiguiente; set => tiempoSiguiente = value; }
            public double VarDependienteSiguiente { get => varDependienteSiguiente; set => varDependienteSiguiente = value; }
        }
    }
}
