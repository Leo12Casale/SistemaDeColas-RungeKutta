using Sistemas_de_Colas.Modelo;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TP_Final.Modelo;

namespace Sistemas_de_Colas.Presentacion
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
            if (nud_cant_minutos_simulacion.Value == 0)
            {
                MessageBox.Show("La cantidad de simulaciones a generar debe ser mayor a 0.", "Generación de Simulación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (nud_mostrar_desde_minutos.Value > nud_cant_minutos_simulacion.Value)
            {
                MessageBox.Show("El día a partir del cual mostrar debe ser menor a la cantidad de días de simulación.", "Generación de Simulación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (nud_tiempo_medio_llegadas.Value == 0)
            {
                MessageBox.Show("El tiempo medio entre llegadas de camiones debe ser mayor a 0.", "Generación de Simulación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (nud_tiempo_limite_inf_atencionA.Value == 0)
            {
                MessageBox.Show("El tiempo medio de mantenimiento debe ser mayor a 0.", "Generación de Simulación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (nud_media_atencionB.Value == 0)
            {
                MessageBox.Show("El tiempo medio de lavado debe ser mayor a 0.", "Generación de Simulación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                nud_tiempo_medio_llegadas.Enabled = true;
                nud_tiempo_limite_inf_atencionA.Enabled = true;
                nud_media_atencionB.Enabled = true;


                btn_generar.Enabled = true;
                btn_restablecer.Enabled = false;
                gb_metricas.Visible = false;
                
                dgv_simulacion.Columns.Clear();

                tab_RK_1trabajo.Show();
                tab_RK_2trabajos.Show();
                dgv_rk_instante_bloqueo.Columns.Clear();
                dgv_rk_bloqueo_llegadas.Columns.Clear();
            }
            else
            {
                nud_cant_minutos_simulacion.Enabled = false;
                nud_mostrar_desde_minutos.Enabled = false;
                nud_mostrar_desde_filas.Enabled = false;
                nud_tiempo_medio_llegadas.Enabled = false;
                nud_tiempo_limite_inf_atencionA.Enabled = false;
                nud_media_atencionB.Enabled = false;

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
                taller.simulacion((double)nud_cant_minutos_simulacion.Value, (int)nud_mostrar_desde_minutos.Value, (int)nud_mostrar_desde_filas.Value, (int)nud_tiempo_medio_llegadas.Value, (double)nud_tiempo_limite_inf_atencionA.Value, (double)nud_tiempo_limite_sup_atencionA.Value, (double)nud_media_atencionB.Value, (double)nud_DE_atencionB.Value);
                var tabla = taller.tablaM;
                var columnas = taller.getColumnas();
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
    }
}
