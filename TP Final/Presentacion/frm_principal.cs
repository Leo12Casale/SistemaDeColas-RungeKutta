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
            if (nud_tiempo_limite_sup_atencionA.Value < nud_tiempo_limite_inf_atencionA.Value)
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
                //Simulacion
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

                //Limpieza tablas
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

                dgv_simulacion.DataSource = Taller.tablaSimulacion;

                foreach (DataGridViewColumn dgvc in dgv_simulacion.Columns)
                {
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

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
    }
}
