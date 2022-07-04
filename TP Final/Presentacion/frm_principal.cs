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
            if(nud_indice_mojado.Value < nud_indice_seco.Value)
            {
                MessageBox.Show("El índice inicial de Mojado (M) del Trabajo, debe ser mayor al índice final de Mojado (M).", "Generación de Simulación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void restablecerParametros(bool restablecer)
        {
            if (restablecer)
            {
                //Simulacion
                nud_cant_minutos_simulacion.Enabled = true;
                nud_mostrar_desde_minutos.Enabled = true;
                nud_mostrar_cantidad_filas.Enabled = true;
                //Distribuciones eventos
                nud_tiempo_medio_llegadas.Enabled = true;
                nud_tiempo_limite_inf_atencionA.Enabled = true;
                nud_tiempo_limite_sup_atencionA.Enabled = true;
                nud_media_atencionB.Enabled = true;
                nud_DE_atencionB.Enabled = true;
                nud_cant_max_trabajos.Enabled = true;
                nud_indice_mojado.Enabled = true;
                nud_indice_seco.Enabled = true;
                nud_paso_integracion.Enabled = true;

                btn_generar.Enabled = true;
                btn_restablecer.Enabled = false;
                gb_metricas.Visible = false;
                gb_ec_dif_1trabajo.Visible = false;
                gb_ec_dif_2trabajos.Visible = false;

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
                nud_mostrar_cantidad_filas.Enabled = false;
                nud_tiempo_medio_llegadas.Enabled = false;
                nud_tiempo_limite_inf_atencionA.Enabled = false;
                nud_tiempo_limite_sup_atencionA.Enabled = false;
                nud_media_atencionB.Enabled = false;
                nud_DE_atencionB.Enabled = false;
                nud_cant_max_trabajos.Enabled = false;
                nud_indice_mojado.Enabled = false;
                nud_indice_seco.Enabled = false;
                nud_paso_integracion.Enabled = false;

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
                restablecerParametros(false);
                try
                {
                    Taller taller = new Taller((float)nud_indice_mojado.Value, (float)nud_indice_seco.Value, (float) nud_paso_integracion.Value);
                    taller.simulacion((int)nud_cant_minutos_simulacion.Value, (float)nud_mostrar_desde_minutos.Value, (int)nud_mostrar_cantidad_filas.Value, (int)nud_cant_max_trabajos.Value, (float)nud_tiempo_medio_llegadas.Value, (float)nud_tiempo_limite_inf_atencionA.Value, (float)nud_tiempo_limite_sup_atencionA.Value, (float)nud_media_atencionB.Value, (float)nud_DE_atencionB.Value);

                    dgv_simulacion.DataSource = taller.TablaSimulacion;

                    //Propiedades de la tabla principal
                    setPropiedadesTabla(dgv_simulacion);

                    //Carga de datos solicitados en consigna
                    cargarMetricas(taller);

                    //Carga y setteo de estilos de las tablas RK
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

                    lbl_condicion_inicial_ec_dif_1trabajo.Text = "Condición Inicial: M(0) = " + nud_indice_mojado.Value.ToString();
                    lbl_condicion_final_ec_dif_1trabajo.Text = "Condición Final: M < " + nud_indice_seco.Value.ToString();
                    lbl_resultado_RK_1trabajo.Text = "Resultado (M < " + nud_indice_seco.Value.ToString() + "): " + (Math.Truncate(1000 * taller.RungeKutta.TiempoSecado1Trabajo) / 1000).ToString() + " mins.";
                    lbl_condicion_inicial_ec_dif_2trabajos.Text = "Condición Inicial: M(0) = " + nud_indice_mojado.Value.ToString();
                    lbl_condicion_final_ec_dif_2trabajos.Text = "Condición Final: M < " + nud_indice_seco.Value.ToString();
                    lbl_resultado_RK_2trabajos.Text = "Resultado (M < " + nud_indice_seco.Value.ToString() + "): " + (Math.Truncate(1000 * taller.RungeKutta.TiempoSecado2Trabajos) / 1000).ToString() + " mins.";
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

        private void setPropiedadesTabla(DataGridView dataGridView)
        {
            dgv_simulacion.Columns[0].Frozen = true;
            dgv_simulacion.Columns[0].Width = 110;
            dgv_simulacion.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_simulacion.Columns[1].Frozen = true;
            dgv_simulacion.Columns[1].Width = 65;
            dgv_simulacion.Columns[dgv_simulacion.Columns.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_simulacion.Columns[dgv_simulacion.Columns.Count - 1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_simulacion.Columns[dgv_simulacion.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            foreach (DataGridViewColumn dgvc in dgv_simulacion.Columns)
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
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
