using TPFinal.Modelo;

namespace TP_Final.Modelo
{
    internal class Fila
    {
        //ESTADOS POSIBLES SERVIDORES
        public const string estadoLibre = "Libre";
        public const string estadoOcupado = "Ocupado";
        public const string estadoDetenido = "Detenido";
        public const string estadoOcupadoEquipo1 = "Ocupado Lugar1";
        public const string estadoOcupadoEquipo2 = "Ocupado Lugar2";

        //Nombres de Eventos
        public const string eventoLlegadaTrabajo = "Llegada Trabajo";
        public const string eventoFinAtencionA = "Fin Atención A";
        public const string eventoDetencionAtencionA = "Detención Atención A";
        public const string eventoFinAtencionB = "Fin Atención B";
        public const string eventoDetencionAtencionB = "Detención Atención B";
        public const string eventoFinSecado = "Fin Secado";

        Taller taller;

        //Vector estado
        private string evento;
        private float reloj;

        //EVENTOS
        private float rndLlegadaTrabajo;
        private float tiempoEntreLlegadas;
        private float proximaLlegadaTrabajo;

        private float rndAtencionA;
        private float tiempoAtencionA;
        private float proximoFinAtencionA;

        private float rnd1AtencionB;
        private float rnd2AtencionB;
        private float tiempoAtencionB;
        private float proximoFinAtencionB;

        private float tiempoFinSecado;
        private float proximoFinSecado;

        //SERVIDORES
        private string estadoCentroA;
        private int indiceTrabajoCentroA;
        private string estadoCentroB;
        private int indiceTrabajoCentroB;
        private EquipoSecado[] equiposSecado; //5 equipos

        //COLAS
        private Queue<int> colaLlegadas;
        private Queue<int> colaCentroB; //Max. 3

        //ESTADISTICAS
        private int contadorTrabajosEnSistema;
        private int cantidadMaximaTrabajosEnSistema;
        private float tiempoACCentroADetenido;
        private int contadorTrabajosFinalizados;
        private float tiempoACTrabajosFinalizados;

        //OBJETOS TEMPORALES
        private List<Trabajo> trabajos;

        //Variables auxiliares
        private bool crearRNDsNormal;
        private int contadorTrabajosLlegados = 0;

        public string Evento { get => evento; set => evento = value; }
        public float Reloj { get => reloj; set => reloj = value; }
        public float RNDLlegadaTrabajo { get => rndLlegadaTrabajo; set => rndLlegadaTrabajo = value; }
        public float TiempoEntreLlegadas { get => tiempoEntreLlegadas; set => tiempoEntreLlegadas = value; }
        public float ProximaLlegadaTrabajo { get => proximaLlegadaTrabajo; set => proximaLlegadaTrabajo = value; }
        public float RNDAtencionA { get => rndAtencionA; set => rndAtencionA = value; }
        public float TiempoAtencionA { get => tiempoAtencionA; set => tiempoAtencionA = value; }
        public float ProximoFinAtencionA { get => proximoFinAtencionA; set => proximoFinAtencionA = value; }
        public float RND1AtencionB { get => rnd1AtencionB; set => rnd1AtencionB = value; }
        public float RND2AtencionB { get => rnd2AtencionB; set => rnd2AtencionB = value; }
        public float TiempoAtencionB { get => tiempoAtencionB; set => tiempoAtencionB = value; }
        public float ProximoFinAtencionB { get => proximoFinAtencionB; set => proximoFinAtencionB = value; }
        public float TiempoFinSecado { get => tiempoFinSecado; set => tiempoFinSecado = value; }
        public float ProximoFinSecado { get => proximoFinSecado; set => proximoFinSecado = value; }
        public string EstadoCentroA { get => estadoCentroA; set => estadoCentroA = value; }
        public string EstadoCentroB { get => estadoCentroB; set => estadoCentroB = value; }
        public Queue<int> ColaLlegadas { get => colaLlegadas; set => colaLlegadas = value; }
        public Queue<int> ColaCentroB { get => colaCentroB; set => colaCentroB = value; }
        public int ContadorTrabajosEnSistema { get => contadorTrabajosEnSistema; set => contadorTrabajosEnSistema = value; }
        public int CantidadMaximaTrabajosEnSistema { get => cantidadMaximaTrabajosEnSistema; set => cantidadMaximaTrabajosEnSistema = value; }
        public float TiempoACCentroADetenido { get => tiempoACCentroADetenido; set => tiempoACCentroADetenido = value; }
        public int ContadorTrabajosFinalizados { get => contadorTrabajosFinalizados; set => contadorTrabajosFinalizados = value; }
        public float TiempoACTrabajosFinalizados { get => tiempoACTrabajosFinalizados; set => tiempoACTrabajosFinalizados = value; }
        internal EquipoSecado[] EquiposSecado { get => equiposSecado; set => equiposSecado = value; }
        internal List<Trabajo> Trabajos { get => trabajos; set => trabajos = value; }
        public int IndiceTrabajoCentroA { get => indiceTrabajoCentroA; set => indiceTrabajoCentroA = value; }
        public int IndiceTrabajoCentroB { get => indiceTrabajoCentroB; set => indiceTrabajoCentroB = value; }
        public bool CrearRNDsNormal { get => crearRNDsNormal; set => crearRNDsNormal = value; }
        internal Taller Taller { get => taller; set => taller = value; }

        public Fila(float reloj, Taller taller)
        {
            Taller = taller;
            Reloj = reloj;
            estadoCentroA = estadoLibre;
            estadoCentroB = estadoLibre;
            ColaLlegadas = new Queue<int>();
            ColaCentroB = new Queue<int>();
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
            RNDLlegadaTrabajo = float.NaN;
            RNDAtencionA = float.NaN;
            RND1AtencionB = float.NaN;
            RND2AtencionB = float.NaN;
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
            filaClon.Trabajos = new List<Trabajo>();
            for (int i = 0; i < Trabajos.Count; i++)
            {
                Trabajo trabajoClon = new Trabajo(Trabajos[i].Estado, Trabajos[i].TiempoLlegada);
                filaClon.Trabajos.Add(trabajoClon);
            }
            return filaClon;
        }

        public float calcularProximoTiempo(Fila filaAnterior)
        {
            float proximaLlegada = float.MaxValue, proximoFinAtencionA = float.MaxValue, proximoFinAtencionB = float.MaxValue, proximoFinSecado = float.MaxValue;
            if (filaAnterior.ProximaLlegadaTrabajo != 0)
                proximaLlegada = ProximaLlegadaTrabajo;
            if (filaAnterior.ProximoFinAtencionA != 0)
                proximoFinAtencionA = ProximoFinAtencionA;
            if (filaAnterior.ProximoFinAtencionB != 0)
                proximoFinAtencionB = ProximoFinAtencionB;
            if (filaAnterior.tiempoMinimoEquipoSecado() != 0)
                proximoFinSecado = tiempoMinimoEquipoSecado();
            return Math.Min(proximaLlegada, Math.Min(proximoFinAtencionA, Math.Min(proximoFinAtencionB, proximoFinSecado)));
        }

        private float tiempoMinimoEquipoSecado()
        {
            float tiempoMin = float.MaxValue;
            float tiempoMenorEquipo;
            for (int i = 0; i < EquiposSecado.Length; i++)
            {
                if (EquiposSecado[i].Estado == estadoLibre)
                    continue;
                tiempoMenorEquipo = EquiposSecado[i].getTiempoFinSecadoMenor();
                if (tiempoMenorEquipo != 0 && tiempoMenorEquipo < tiempoMin)
                    tiempoMin = tiempoMenorEquipo;
            }
            return tiempoMin == float.MaxValue ? 0 : tiempoMin;
        }


        //---------------------------------------------------------------- EVENTOS

        //--------------------- Evento LLEGADA TRABAJO
        public void llegadaTrabajo()
        {
            //Setteo de Evento y Reloj
            Evento = eventoLlegadaTrabajo + " " + (contadorTrabajosLlegados+1).ToString();
            Reloj = proximaLlegadaTrabajo;

            //Calculo de la proxima llegada
            RNDLlegadaTrabajo = (float) (float) (float) Math.Truncate(1000 * Taller.GeneradorRNDLlegadaTrabajos.NextDouble()) / 1000;
            TiempoEntreLlegadas = calcularTiempoEntreLlegadas(RNDLlegadaTrabajo);
            ProximaLlegadaTrabajo = Reloj + TiempoEntreLlegadas;

            contadorTrabajosLlegados++;

            //Atiendo el trabajo en centro A
            if (estadoCentroA == estadoLibre)
            {
                estadoCentroA = estadoOcupado;
                indiceTrabajoCentroA = contadorTrabajosLlegados - 1;

                //Fin Atencion
                RNDAtencionA = (float) (float) Math.Truncate(1000 * Taller.GeneradorRNDAtencionA.NextDouble()) / 1000;
                TiempoAtencionA = calcularTiempoAtencionA(RNDAtencionA);
                proximoFinAtencionA = Reloj + TiempoAtencionA;

                //Creo el trabajo y lo agrego a la tabla según lo que se quiera observar
                Trabajo nuevoTrabajo = new Trabajo(Trabajo.estadoSiendoAtendidoA, reloj);
                Trabajos.Add(nuevoTrabajo);
            }
            else //El trabajo va a la colaLlegada
            {
                colaLlegadas.Enqueue(contadorTrabajosLlegados - 1);

                Trabajo nuevoTrabajo = new Trabajo(Trabajo.estadoEsperandoAtencionA, Reloj);
                Trabajos.Add(nuevoTrabajo);
            }
            //Estadisticas
            contadorTrabajosEnSistema++;
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
                estadoCentroB = estadoOcupado;
                Trabajos[indiceTrabajoCentroA].Estado = Trabajo.estadoSiendoAtendidoB;
                indiceTrabajoCentroB = indiceTrabajoCentroA;

                //Fin Atencion B
                calcularTiemposAtencionCentroB();
            }
            //Si el centro B NO esta libre, se fija si tiene lugar en la cola
            else if (ColaCentroB.Count < 3) //Si hay lugar en cola
            {
                colaCentroB.Enqueue(indiceTrabajoCentroA);
                Trabajos[indiceTrabajoCentroA].Estado = Trabajo.estadoEsperandoAtencionB;
            }
            //No hay lugar en cola --> detiene Atencion A
            else
            {
                estadoCentroA = estadoDetenido;
                Trabajos[indiceTrabajoCentroA].Estado = Trabajo.estadoDetenidoCentroA;
                proximoFinAtencionA = 0;
                return;
            }

            //Cómo sigue el CENTRO A
            //El Centro A chequea si atender otro trabajo o se libera
            definirEstadoCentroA();
        }


        //--------------------------- Evento FIN ATENCION B
        public void finAtencionB()
        {
            //Setteo de Evento y Reloj
            Evento = eventoFinAtencionB;
            Reloj = proximoFinAtencionB;

            //------ Cómo sigue el TRABAJO
            //Si hay equipo de secado libre
            int indiceEquipoSecadoLibre = getIndiceEquipoSecadoLibre();
            if (indiceEquipoSecadoLibre != -1)
            {
                //Ocupar lugar del equipo libre y calcular tiempos de secado
                ocuparEquipoSecado(indiceEquipoSecadoLibre, indiceTrabajoCentroB);
                Trabajos[indiceTrabajoCentroB].Estado = Trabajo.estadoSiendoAtendidoSecado;
            }
            //Si no hay equipo secado libre, detener atención B
            else
            {
                estadoCentroB = estadoDetenido;
                Trabajos[indiceTrabajoCentroB].Estado = Trabajo.estadoDetenidoCentroB;
                proximoFinAtencionB = 0;
                return;
            }

            //------ Cómo sigue el CENTRO B
            //Si hay trabajos en cola --> atenderlos
            if (ColaCentroB.Count > 0)
            {
                //Actualizo estados de Centro B y trabajo
                indiceTrabajoCentroB = ColaCentroB.Dequeue();
                Trabajos[indiceTrabajoCentroB].Estado = Trabajo.estadoSiendoAtendidoB;

                //Calcular tiempos de atencion de B
                calcularTiemposAtencionCentroB();

                //Chequeo si el centro A esta detenido
                if (estadoCentroA == estadoDetenido)
                {
                    //Paso el trabajo detenido en A, a la cola de B (se liberó un lugar)
                    Trabajos[indiceTrabajoCentroA].Estado = Trabajo.estadoEsperandoAtencionB;
                    colaCentroB.Enqueue(indiceTrabajoCentroA);

                    definirEstadoCentroA();
                }
            }
            //Si NO hay trabajos en cola --> liberar centro
            else
            {
                estadoCentroB = estadoLibre;
                indiceTrabajoCentroB = -1;
                proximoFinAtencionB = 0;
            }
        }

        private int getIndiceEquipoSecadoLibre()
        {
            //Retornar el equipo que esté libre en los 2 lugares
            for (int i = 0; i < EquiposSecado.Length; i++)
            {
                if (EquiposSecado[i].FinSecado1 == 0 && EquiposSecado[i].FinSecado2 == 0)
                    return i;
            }
            //Sino, retornar el equipo que tenga 1 lugar libre
            for (int i = 0; i < EquiposSecado.Length; i++)
            {
                if (EquiposSecado[i].FinSecado1 == 0 || EquiposSecado[i].FinSecado2 == 0)
                    return i;
            }
            //Si está todo ocupado, retornar -1
            return -1;
        }


        //-------------------------------- Evento FIN SECADO
        public void finSecado(float tiempoFinSecadoMinimo)
        {
            //Setteo de Evento y Reloj
            Evento = eventoFinSecado;
            Reloj = tiempoFinSecadoMinimo;

            int indiceEquipo = getIndiceEquipoSecadoTiempoMinimo(tiempoFinSecadoMinimo);
            int indiceTrabajo = -1;
            bool centroBDetenido = false;

            if (estadoCentroB == estadoDetenido)
                centroBDetenido = true;

            //SECADO DE BOX 1
            if (EquiposSecado[indiceEquipo].FinSecado1 == tiempoFinSecadoMinimo)
            {
                //Tomo el indice del trabajo
                indiceTrabajo = EquiposSecado[indiceEquipo].IndiceTrabajo1;
                Trabajos[indiceTrabajo].Estado = Trabajo.estadoDestruido;

                //Actualizo estado equipo segun si el centro B estaba detenido 
                if (centroBDetenido)
                {
                    EquiposSecado[indiceEquipo].IndiceTrabajo1 = indiceTrabajoCentroB;

                    if (EquiposSecado[indiceEquipo].FinSecado2 == 0)
                    {
                        EquiposSecado[indiceEquipo].Estado = estadoOcupadoEquipo1;
                        TiempoFinSecado = (float) taller.RungeKutta.integracionNumerica(Reloj, RungeKutta.unTrabajo);
                    }
                    else //Lugar 2 del equipo ocupado tambien
                    {
                        EquiposSecado[indiceEquipo].Estado = estadoOcupado;
                        TiempoFinSecado = (float) taller.RungeKutta.integracionNumerica(Reloj, RungeKutta.dosTrabajos);
                    }
                    EquiposSecado[indiceEquipo].FinSecado1 = Reloj + TiempoFinSecado;

                    //Actualizo estado del trabajo que estaba detenido --> siendo secado
                    Trabajos[indiceTrabajoCentroB].Estado = Trabajo.estadoSiendoAtendidoSecado;
                }
                else //Centro B no esta detenido --> se libera el equipo que terminó el secado
                {
                    EquiposSecado[indiceEquipo].FinSecado1 = 0;
                    if (EquiposSecado[indiceEquipo].FinSecado2 == 0)
                        EquiposSecado[indiceEquipo].Estado = estadoLibre;
                    else
                        EquiposSecado[indiceEquipo].Estado = estadoOcupadoEquipo2;
                }
            }
            //SECADO DE BOX 2
            else
            {
                //Tomo el indice del trabajo
                indiceTrabajo = EquiposSecado[indiceEquipo].IndiceTrabajo2;
                Trabajos[indiceTrabajo].Estado = Trabajo.estadoDestruido;

                if (centroBDetenido) 
                {
                    EquiposSecado[indiceEquipo].IndiceTrabajo2 = indiceTrabajoCentroB;

                    if (EquiposSecado[indiceEquipo].FinSecado1 == 0)
                    {
                        EquiposSecado[indiceEquipo].Estado = estadoOcupadoEquipo2;
                        TiempoFinSecado = (float) taller.RungeKutta.integracionNumerica(Reloj, RungeKutta.unTrabajo);
                    }
                    else //Lugar 1 ocupado tambien
                    { 
                        EquiposSecado[indiceEquipo].Estado = estadoOcupado;
                        TiempoFinSecado = (float) taller.RungeKutta.integracionNumerica(Reloj, RungeKutta.dosTrabajos);
                    }
                    EquiposSecado[indiceEquipo].FinSecado2 = Reloj + TiempoFinSecado;

                    //Actualizo estado del trabajo que estaba detenido --> siendo secado
                    Trabajos[indiceTrabajoCentroB].Estado = Trabajo.estadoSiendoAtendidoSecado;
                }
                else //Centro B no esta detenido --> se libera el equipo que terminó el secado
                {
                    EquiposSecado[indiceEquipo].FinSecado2 = 0;
                    if (EquiposSecado[indiceEquipo].FinSecado1 == 0)
                        EquiposSecado[indiceEquipo].Estado = estadoLibre;
                    else
                        EquiposSecado[indiceEquipo].Estado = estadoOcupadoEquipo1;
                }
            }
            
            //Chequeo si el centro B estaba detenido y ahora puede retomar su actividad
            if (centroBDetenido)
            {
                //Si tiene cola el centro B --> atender
                if (colaCentroB.Count > 0)
                {
                    estadoCentroB = estadoOcupado;
                    indiceTrabajoCentroB = colaCentroB.Dequeue();
                    Trabajos[indiceTrabajoCentroB].Estado = Trabajo.estadoSiendoAtendidoB;

                    calcularTiemposAtencionCentroB();

                    if(estadoCentroA == estadoDetenido)
                    {
                        //Paso el trabajo detenido en A, a la cola de B (se liberó un lugar)
                        Trabajos[indiceTrabajoCentroA].Estado = Trabajo.estadoEsperandoAtencionB;
                        colaCentroB.Enqueue(indiceTrabajoCentroA);

                        definirEstadoCentroA();
                    }
                }
                else
                {
                    estadoCentroB = estadoLibre;
                    indiceTrabajoCentroB = -1;
                    proximoFinAtencionB = 0;
                }
            }

            //Estadisticas
            contadorTrabajosEnSistema--;
            contadorTrabajosFinalizados++;
            tiempoACTrabajosFinalizados += (Reloj - Trabajos[indiceTrabajo].TiempoLlegada);
        }

        private int getIndiceEquipoSecadoTiempoMinimo(float tiempoFinSecadoMinimo)
        {
            for (int i = 0; i < EquiposSecado.Length; i++)
            {
                if (EquiposSecado[i].Estado == estadoLibre)
                    continue;
                if (EquiposSecado[i].FinSecado1 == tiempoFinSecadoMinimo || EquiposSecado[i].FinSecado2 == tiempoFinSecadoMinimo)
                    return i;
            }
            return -1;
        }

        public void setProximoFinSecado()
        {
            float tiempoMinimo = float.MaxValue;
            for (int i = 0; i < EquiposSecado.Length; i++)
            {
                if (EquiposSecado[i].Estado == estadoLibre)
                    continue;
                if (EquiposSecado[i].getTiempoFinSecadoMenor() < tiempoMinimo)
                    tiempoMinimo = EquiposSecado[i].getTiempoFinSecadoMenor();
            }
            if (tiempoMinimo != float.MaxValue)
                ProximoFinSecado = tiempoMinimo;
            else
                ProximoFinSecado = 0;
        }

        public int getCantidadTrabajosNoDestruidos()
        {
            for (int i = 0; i < Trabajos.Count; i++)
            {
                if (Trabajos[i].Estado != Trabajo.estadoDestruido)
                    return i;
            }
            return 0;
        }


        //----------------------------------------------------- OCUPACIONES DE SERVIDORES
        private void definirEstadoCentroA()
        {
            if (colaLlegadas.Count > 0)
            {
                ocuparCentroADesdeColaLlegada();
            }
            else //Liberar centro A
            {
                indiceTrabajoCentroA = -1;
                estadoCentroA = estadoLibre;
                proximoFinAtencionA = 0;
            }
        }

        private void ocuparCentroADesdeColaLlegada()
        {
            //Actualizo estados de Centro A y trabajo
            estadoCentroA = estadoOcupado;
            indiceTrabajoCentroA = colaLlegadas.Dequeue();
            Trabajos[indiceTrabajoCentroA].Estado = Trabajo.estadoSiendoAtendidoA;

            //Fin Atencion A
            RNDAtencionA = (float)Math.Truncate(1000 * Taller.GeneradorRNDAtencionA.NextDouble()) / 1000;
            tiempoAtencionA = calcularTiempoAtencionA(RNDAtencionA);
            proximoFinAtencionA = Reloj + tiempoAtencionA;
        }

        private void calcularTiemposAtencionCentroB()
        {
            //Tiempo Atencion Centro B
            float tiempoAtencionB = -1;
            while (tiempoAtencionB < 0)
            {
                if (CrearRNDsNormal) //Si los RNDs no se crearon, crearlos
                {
                    RND1AtencionB = (float)Math.Truncate(1000 * Taller.GeneradorRNDAtencionB.NextDouble()) / 1000;
                    RND2AtencionB = (float)Math.Truncate(1000 * Taller.GeneradorRNDAtencionB.NextDouble()) / 1000;
                    CrearRNDsNormal = false;
                }
                else //Si los RNDs se usaron una vez, usar los mismos y settear true para que la proxima vez se creen de nuevo
                    CrearRNDsNormal = true;
                tiempoAtencionB = calcularTiempoAtencionB(RND1AtencionB, RND2AtencionB, CrearRNDsNormal);
            }
            TiempoAtencionB = tiempoAtencionB;
            proximoFinAtencionB = Reloj + TiempoAtencionB;
        }

        private void ocuparEquipoSecado(int indiceEquipo, int indiceTrabajoASecar)
        {

            //Equipo con 2 lugares libres --> integrar con 1 trabajo
            if (EquiposSecado[indiceEquipo].FinSecado1 == 0 && EquiposSecado[indiceEquipo].FinSecado2 == 0)
            {
                EquiposSecado[indiceEquipo].Estado = estadoOcupadoEquipo1;
                TiempoFinSecado = (float)taller.RungeKutta.integracionNumerica(Reloj, RungeKutta.unTrabajo);
                EquiposSecado[indiceEquipo].FinSecado1 = Reloj + TiempoFinSecado;
                EquiposSecado[indiceEquipo].IndiceTrabajo1 = indiceTrabajoASecar;
            }

            //Equipo con 1 lugar libre --> integrar con 2 trabajos
            else
            {
                TiempoFinSecado = (float)taller.RungeKutta.integracionNumerica(Reloj, RungeKutta.dosTrabajos);
                EquiposSecado[indiceEquipo].Estado = estadoOcupado;

                //Lugar 1 del equipo libre
                if (EquiposSecado[indiceEquipo].FinSecado1 == 0)
                {
                    EquiposSecado[indiceEquipo].IndiceTrabajo1 = indiceTrabajoASecar;
                    EquiposSecado[indiceEquipo].FinSecado1 = Reloj + TiempoFinSecado;
                }
                //Lugar 2 del equipo libre
                else
                {
                    EquiposSecado[indiceEquipo].IndiceTrabajo2 = indiceTrabajoASecar;
                    EquiposSecado[indiceEquipo].FinSecado2 = Reloj + TiempoFinSecado;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------
        //Eventos asociadas a DISTRIBUCIONES
        private float calcularTiempoEntreLlegadas(float RND)
        {
            return -Taller.MediaLlegadas * (float)  Math.Log(1 - RND);
        }

        private float calcularTiempoAtencionA(float RND)
        {
            return Taller.LimiteInfAtencionA + RND * (Taller.LimiteSupAtencionA - Taller.LimiteInfAtencionA);
        }

        private float calcularTiempoAtencionB(float RND1, float RND2, bool segundoCalculo)
        {
            RND1 = RND1 != 0 ? RND1 : (float) 0.000001;
            if (!segundoCalculo)
            {
                return (float) (Math.Sqrt(-2 * Math.Log(RND1)) * Math.Cos(2 * Math.PI * RND2)) * Taller.DesvEstandarAtencionB + Taller.MediaAtencionB;

            }
            return (float) (Math.Sqrt(-2 * Math.Log(RND1)) * Math.Sin(2 * Math.PI * RND2)) * Taller.DesvEstandarAtencionB + Taller.MediaAtencionB;
        }

        public static List<String> getColumnas()
        {
            List<string> columnas = new List<string>(38);
            columnas.Add("Evento");
            columnas.Add("Reloj (min)");

            //EVENTOS
            columnas.Add("RND Llegadas entre trabajos");
            columnas.Add("Tiempo entre Llegadas de Trabajos");
            columnas.Add("Próxima Llegada de Trabajo"); //4

            columnas.Add("RND Atención Centro A");
            columnas.Add("Tiempo de Atención Centro A");
            columnas.Add("Próximo Fin de Atención Centro A"); //7

            columnas.Add("RND1 Atención Centro B");
            columnas.Add("RND2 Atención Centro B");
            columnas.Add("Tiempo de Atención Centro B");
            columnas.Add("Próximo Fin de Atención Centro B"); //11

            columnas.Add("Tiempo de Secado");
            columnas.Add("Próximo Fin de Secado"); //13

            //SERVIDORES
            columnas.Add("Estado Centro A");
            columnas.Add("Estado Centro B");
            for (int i = 0; i < 5; i++)
            {
                columnas.Add("Estado de Equipo" + (i + 1).ToString());
                columnas.Add("Fin Secado Equipo" + (i + 1).ToString() + " Lugar1");
                columnas.Add("Fin Secado Equipo" + (i + 1).ToString() + " Lugar2");
            }

            //COLAS
            columnas.Add("Cola de Llegadas");
            columnas.Add("Cola de Centro B (máx. 3)");

            //ESTADÍSTICAS
            columnas.Add("Cantidad de Trabajos en Sistema");
            columnas.Add("Cantidad Máxima de Trabajos en Sistema");
            columnas.Add("Tiempo AC de Centro A detenido");
            columnas.Add("Cantidad de Trabajos Finalizados");
            columnas.Add("Tiempo AC de Permanencia Trabajos Finalizados");

            //OBJETOS TEMPORALES
            columnas.Add("Trabajos en Sistema --> (N° trabajo)Estado - Minutos Llegada");
            return columnas;
        }
    }

    internal class EquipoSecado
    {
        private string estado;
        private int indiceTrabajo1;
        private float finSecado1;
        private int indiceTrabajo2;
        private float finSecado2;

        public string Estado { get => estado; set => estado = value; }
        public float FinSecado1 { get => finSecado1; set => finSecado1 = value; }
        public float FinSecado2 { get => finSecado2; set => finSecado2 = value; }
        public int IndiceTrabajo1 { get => indiceTrabajo1; set => indiceTrabajo1 = value; }
        public int IndiceTrabajo2 { get => indiceTrabajo2; set => indiceTrabajo2 = value; }

        public EquipoSecado()
        {
            Estado = Fila.estadoLibre;
            FinSecado1 = 0;
            FinSecado2 = 0;
        }

        public EquipoSecado(string estado, float finSecado1, float finSecado2)
        {
            Estado = estado;
            FinSecado1 = finSecado1;
            FinSecado2 = finSecado2;
        }

        public float getTiempoFinSecadoMenor()
        {
            if (FinSecado1 == 0)
                return finSecado2;
            else if (FinSecado2 == 0)
                return finSecado1;

            else if (FinSecado1 < FinSecado2)
                return finSecado1;
            return finSecado2;
        }
    }

    internal class Trabajo
    {
        private string estado;
        private float tiempoLlegada;
        public const string estadoEsperandoAtencionA = "EAA";
        public const string estadoSiendoAtendidoA = "SAA";
        public const string estadoDetenidoCentroA = "DA";
        public const string estadoEsperandoAtencionB = "EAB";
        public const string estadoSiendoAtendidoB = "SAB";
        public const string estadoDetenidoCentroB = "DB";
        public const string estadoSiendoAtendidoSecado = "SAS";
        public const string estadoDestruido = "X";

        public string Estado { get => estado; set => estado = value; }
        public float TiempoLlegada { get => tiempoLlegada; set => tiempoLlegada = value; }

        public Trabajo(string estado, float tiempoLlegada)
        {
            Estado = estado;
            TiempoLlegada = tiempoLlegada;
        }
    }
}
