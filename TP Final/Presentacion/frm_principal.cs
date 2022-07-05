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
            gb_ec_dif_1trabajo.Visible = false;
            gb_ec_dif_2trabajos.Visible = false;
        }

        private bool validarParametros()
        {
            if (nud_mostrar_desde_minutos.Value > nud_cant_minutos_simulacion.Value)
            {
                MessageBox.Show("El minuto a partir del cual mostrar, debe ser menor a la cantidad de minutos de simulación.", "Generación de Simulación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (nud_tiempo_limite_sup_atencionA.Value < nud_tiempo_limite_inf_atencionA.Value)
            {
                MessageBox.Show("El tiempo límite superior de Atención del Centro A, debe ser mayor al límite inferior del mismo.", "Generación de Simulación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (nud_cant_max_trabajos.Value > nud_cant_minutos_simulacion.Value)
            {
                MessageBox.Show("El minuto a partir del cual mostrar la cantidad máxima de trabajos, debe ser menor a la cantidad de minutos de simulación.", "Generación de Simulación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void restablecerParametros(bool restablecer)
        {
            //Simulacion
            nud_cant_minutos_simulacion.Enabled = restablecer;
            nud_mostrar_desde_minutos.Enabled = restablecer;
            nud_mostrar_cantidad_filas.Enabled = restablecer;
            //Distribuciones eventos
            nud_tiempo_medio_llegadas.Enabled = restablecer;
            nud_tiempo_limite_inf_atencionA.Enabled = restablecer;
            nud_tiempo_limite_sup_atencionA.Enabled = restablecer;
            nud_media_atencionB.Enabled = restablecer;
            nud_DE_atencionB.Enabled = restablecer;
            nud_cant_max_trabajos.Enabled = restablecer;
            //RK
            nud_indice_mojado.Enabled = restablecer;
            nud_indice_seco.Enabled = restablecer;
            nud_paso_integracion.Enabled = restablecer;

            btn_generar.Enabled = restablecer;
            btn_restablecer.Enabled = !restablecer;
            gb_metricas.Visible = !restablecer;

            if (restablecer)
            {
                //Ocultar lbls de RK
                gb_ec_dif_1trabajo.Visible = false;
                gb_ec_dif_2trabajos.Visible = false;

                //Limpieza tablas
                dgv_simulacion.Columns.Clear();
                tab_RK_1trabajo.Show();
                tab_RK_2trabajos.Show();
                dgv_rk_1trabajo.Columns.Clear();
                dgv_rk_2trabajos.Columns.Clear();
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
                restablecerParametros(false);
                try
                {
                    Taller taller = new Taller((float)nud_indice_mojado.Value, (float)nud_indice_seco.Value, (float) nud_paso_integracion.Value);
                    taller.simulacion((int)nud_cant_minutos_simulacion.Value, (float)nud_mostrar_desde_minutos.Value, (int)nud_mostrar_cantidad_filas.Value, (int)nud_cant_max_trabajos.Value, (float)nud_tiempo_medio_llegadas.Value, (float)nud_tiempo_limite_inf_atencionA.Value, (float)nud_tiempo_limite_sup_atencionA.Value, (float)nud_media_atencionB.Value, (float)nud_DE_atencionB.Value);

                    dgv_simulacion.DataSource = taller.TablaSimulacion;

                    //Propiedades de la tabla principal
                    setPropiedadesTablaSimulacion();

                    //Carga de datos solicitados en consigna
                    cargarMetricas(taller);

                    //Carga y setteo de estilos de las tablas Runge Kutta
                    setPropiedadesTablasRK(taller);

                    //Carga y setteo de labels de integracion de Runge Kutta
                    setLabelsRK(taller);
                }
                catch
                {
                    restablecerParametros(true);
                    MessageBox.Show("Ha ocurrido un error durante la Simulación.\nPor favor intente nuevamente.", "Generación de Simulación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_restablecer_Click(object sender, EventArgs e)
        {
            restablecerParametros(true);
            nud_cant_minutos_simulacion.Value = 150;
            nud_mostrar_desde_minutos.Value = 0;
            nud_mostrar_cantidad_filas.Value = 400;
            nud_cant_max_trabajos.Value = 50;

            nud_tiempo_medio_llegadas.Value = 12;
            nud_tiempo_limite_inf_atencionA.Value = 1;
            nud_tiempo_limite_sup_atencionA.Value = 10;
            nud_media_atencionB.Value = 8;
            nud_DE_atencionB.Value = 5;

            nud_indice_mojado.Value = 100;
            nud_indice_seco.Value = 1;
            nud_paso_integracion.Value = 1;
        }

        private void setPropiedadesTablaSimulacion()
        {
            dgv_simulacion.Columns[0].Frozen = true;
            dgv_simulacion.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_simulacion.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_simulacion.Columns[1].Frozen = true;
            dgv_simulacion.Columns[1].Width = 65;

            dgv_simulacion.Columns[dgv_simulacion.Columns.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_simulacion.Columns[dgv_simulacion.Columns.Count - 1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_simulacion.Columns[dgv_simulacion.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            foreach (DataGridViewColumn dgvc in dgv_simulacion.Columns)
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void setPropiedadesTablasRK(Taller taller)
        {
            tab_RK_1trabajo.Show();
            if (taller.RungeKutta.Tabla1Trabajo != null)
            {
                gb_ec_dif_1trabajo.Visible = true;
                dgv_rk_1trabajo.DataSource = taller.RungeKutta.Tabla1Trabajo;
                dgv_rk_1trabajo.Rows[dgv_rk_1trabajo.Rows.Count - 1].Cells[0].Style.BackColor = Color.IndianRed;
                dgv_rk_1trabajo.Rows[dgv_rk_1trabajo.Rows.Count - 1].Cells[1].Style.BackColor = Color.IndianRed;
            }

            tab_RK_2trabajos.Show();
            if (taller.RungeKutta.Tabla2Trabajos != null)
            {
                gb_ec_dif_2trabajos.Visible = true;
                dgv_rk_2trabajos.DataSource = taller.RungeKutta.Tabla2Trabajos;
                dgv_rk_2trabajos.Rows[dgv_rk_2trabajos.Rows.Count - 1].Cells[0].Style.BackColor = Color.IndianRed;
                dgv_rk_2trabajos.Rows[dgv_rk_2trabajos.Rows.Count - 1].Cells[1].Style.BackColor = Color.IndianRed;
            }
        }

        private void setLabelsRK(Taller taller)
        {
            lbl_condicion_inicial_ec_dif_1trabajo.Text = "Condición Inicial: M(0) = " + nud_indice_mojado.Value.ToString();
            lbl_condicion_final_ec_dif_1trabajo.Text = "Condición Final: M < " + nud_indice_seco.Value.ToString();
            lbl_resultado_RK_1trabajo.Text = "Resultado (M < " + nud_indice_seco.Value.ToString() + "): " + (Math.Truncate(100 * taller.RungeKutta.TiempoSecado1Trabajo) / 100).ToString() + " mins.";
            lbl_condicion_inicial_ec_dif_2trabajos.Text = "Condición Inicial: M(0) = " + nud_indice_mojado.Value.ToString();
            lbl_condicion_final_ec_dif_2trabajos.Text = "Condición Final: M < " + nud_indice_seco.Value.ToString();
            lbl_resultado_RK_2trabajos.Text = "Resultado (M < " + nud_indice_seco.Value.ToString() + "): " + (Math.Truncate(100 * taller.RungeKutta.TiempoSecado2Trabajos) / 100).ToString() + " mins.";
        }

        private void cargarMetricas(Taller taller)
        {
            lbl_cant_maxima_trabajos_value.Text = taller.Fila.CantidadMaximaTrabajosEnSistema.ToString();
            lbl_cant_max_trabajos_min.Text = "Cant. máx. de trabajos en el Sistema (min. " + nud_cant_max_trabajos.Value.ToString() + "):";
            lbl_cant_max_trabajos_min_value.Text = taller.CantidadMaxTrabajosMinuto.ToString();
            lbl_tiempo_parada_centroA_value.Text = (Math.Truncate(1000 * taller.Fila.TiempoACCentroADetenido) / 1000).ToString() + " min.";
            if (taller.Fila.ContadorTrabajosFinalizados == 0)
                lbl_tiempo_prom_trabajo_value.Text = "-";
            else
                lbl_tiempo_prom_trabajo_value.Text = (Math.Truncate(1000 * (taller.Fila.TiempoACTrabajosFinalizados / taller.Fila.ContadorTrabajosFinalizados)) / 1000).ToString() + " min.";
        }
    }
}
