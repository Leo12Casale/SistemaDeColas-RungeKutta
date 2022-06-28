using TP_Final.Modelo;

namespace TPFinal.Presentacion
{
    public partial class frm_principal : Form
    {

        public frm_principal()
        {
            InitializeComponent();          
        }

        private void frm_principal_Load(object sender, EventArgs e)
        {
            btn_restablecer.Enabled = false;
            gb_metricas.Visible = false;
        }
        
        private bool validarParametros()
        {
            if (nud_mostrar_desde_minutos.Value > nud_cant_minutos_simulacion.Value)
            {
                MessageBox.Show("El minuto a partir del cual mostrar debe ser menor a la cantidad de minutos de simulación.", "Generación de Simulación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(nud_tiempo_limite_sup_atencionA.Value < nud_tiempo_limite_inf_atencionA.Value)
            {
                MessageBox.Show("El tiempo límite superior de Atención del Centro A debe ser mayor al límite inferior del mismo.", "Generación de Simulación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        
        private void activarParametros(bool activar)
        {
            if (activar)
            {
                nud_cant_minutos_simulacion.Enabled = true;
                nud_mostrar_desde_minutos.Enabled = true;
                nud_mostrar_desde_filas.Enabled = true;
                //Distribuciones eventos
                nud_tiempo_medio_llegadas.Enabled = true;
                nud_tiempo_limite_inf_atencionA.Enabled = true;
                nud_tiempo_limite_sup_atencionA.Enabled = true;
                nud_media_atencionB.Enabled = true;
                nud_DE_atencionB.Enabled = true;


                btn_generar.Enabled = true;
                btn_restablecer.Enabled = false;
                gb_metricas.Visible = false;
                
                dgv_simulacion.Columns.Clear();

                tab_RK_1trabajo.Show();
                tab_RK_2trabajos.Show();
                dgv_rk_1trabajo.Columns.Clear();
                dgv_rk_2trabajos.Columns.Clear();
            }
            else
            {
                nud_cant_minutos_simulacion.Enabled = false;
                nud_mostrar_desde_minutos.Enabled = false;
                nud_mostrar_desde_filas.Enabled = false;
                nud_tiempo_medio_llegadas.Enabled = false;
                nud_tiempo_limite_inf_atencionA.Enabled = false;
                nud_tiempo_limite_sup_atencionA.Enabled = false;
                nud_media_atencionB.Enabled = false;
                nud_DE_atencionB.Enabled = false;

                btn_generar.Enabled = false;
                btn_restablecer.Enabled = true;
                gb_metricas.Visible = true;
            }
        }

        private void numActive(object sender, EventArgs e)
        {
            NumericUpDown clickedNumeric = (NumericUpDown)sender;
            clickedNumeric.Select(0, clickedNumeric.Text.Length);
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            if (validarParametros())
            {
                activarParametros(false);
                Taller taller = new Taller();
                taller.simulacion((double)nud_cant_minutos_simulacion.Value, (double)nud_mostrar_desde_minutos.Value, (double)nud_mostrar_desde_filas.Value, (double)nud_tiempo_medio_llegadas.Value, (double)nud_tiempo_limite_inf_atencionA.Value, (double)nud_tiempo_limite_sup_atencionA.Value, (double)nud_media_atencionB.Value, (double)nud_DE_atencionB.Value);
                var tabla = taller.tablaM;
                var columnas = getColumnas();
                this.dgv_simulacion.ColumnCount = tabla[0].Length;
                for (int i = 0; i < columnas.Count(); i++)
                {
                    dgv_simulacion.Columns[i].Name = columnas[i];
                }
                this.dgv_simulacion.Columns[dgv_simulacion.ColumnCount - 1].Width = 1000;
                for (int r = 0; r < tabla.Length; r++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgv_simulacion);
                    if (tabla[r][1] == null)
                        continue;
                    for (int c = 0; c < tabla[r].Length; c++)
                    {
                        row.Cells[c].Value = tabla[r][c];
                    }

                    this.dgv_simulacion.Rows.Add(row);
                }

                foreach (DataGridViewColumn dgvc in dgv_simulacion.Columns)
                {
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dgv_simulacion.Columns[dgv_simulacion.Columns.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                //lbl_cant_maxima_trabajos_value.Text = (Math.Truncate(1000 * taller.fila.CantidadMaxColaLavado) / 1000).ToString();
                //lbl_tiempo_parada_centroA_value.Text = (Math.Truncate(10000 * taller.fila.maximoTiempoOciosoLavadores()) / 100).ToString() + "%";
                //lbl_tiempo_prom_trabajo_value.Text = (Math.Truncate(1000000 * taller.fila.TiempoAtencionMinimoMecanicos) / 1000000).ToString();

                ////carga de las tablas RK
                //dgv_rk_instante_bloqueo.DataSource = taller.rungeKuttaInstanteBloqueo.tabla;
                //dgv_rk_bloqueo_llegadas.DataSource = taller.rungeKuttaBloqueoCliente.tabla;
            }
        }

        private void btn_restablecer_Click(object sender, EventArgs e)
        {
            activarParametros(true);
        }

        private List<String> getColumnas()
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
}
