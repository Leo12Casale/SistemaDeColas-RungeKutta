
namespace Sistemas_de_Colas.Presentacion
{
    partial class frm_principal
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.Windows.Forms.NumericUpDown nud_tiempo_limite_sup_atencionA;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_principal));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_simulacion = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gb_metricas = new System.Windows.Forms.GroupBox();
            this.lbl_tiempo_prom_trabajo_value = new System.Windows.Forms.Label();
            this.lbl_tiempo_prom_trabajo = new System.Windows.Forms.Label();
            this.lbl_tiempo_parada_centroA_value = new System.Windows.Forms.Label();
            this.lbl_tiempo_parada_centroA = new System.Windows.Forms.Label();
            this.lbl_cant_maxima_trabajos_value = new System.Windows.Forms.Label();
            this.lbl_cant_maxima_trabajos = new System.Windows.Forms.Label();
            this.gb_parametros = new System.Windows.Forms.GroupBox();
            this.lbl_distribucion_eventos = new System.Windows.Forms.Label();
            this.nud_DE_atencionB = new System.Windows.Forms.NumericUpDown();
            this.lbl_DE_atencionB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_mostrar_desde_filas = new System.Windows.Forms.NumericUpDown();
            this.lbl_mostrar_desde_filas = new System.Windows.Forms.Label();
            this.nud_mostrar_desde_minutos = new System.Windows.Forms.NumericUpDown();
            this.lbl_mostrar_desde_minutos = new System.Windows.Forms.Label();
            this.nud_media_atencionB = new System.Windows.Forms.NumericUpDown();
            this.nud_cant_minutos_simulacion = new System.Windows.Forms.NumericUpDown();
            this.lbl_limite_inf_tiempo_atencionA = new System.Windows.Forms.Label();
            this.nud_tiempo_medio_llegadas = new System.Windows.Forms.NumericUpDown();
            this.lbl_media_atencionB = new System.Windows.Forms.Label();
            this.lbl_tiempo_medio_llegadas = new System.Windows.Forms.Label();
            this.lbl_cant_minutos_simulacion = new System.Windows.Forms.Label();
            this.nud_tiempo_limite_inf_atencionA = new System.Windows.Forms.NumericUpDown();
            this.btn_generar = new System.Windows.Forms.Button();
            this.btn_restablecer = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv_simulacion = new System.Windows.Forms.DataGridView();
            this.tab_RK_1trabajo = new System.Windows.Forms.TabPage();
            this.dgv_rk_instante_bloqueo = new System.Windows.Forms.DataGridView();
            this.tab_RK_2trabajos = new System.Windows.Forms.TabPage();
            this.dgv_rk_bloqueo_llegadas = new System.Windows.Forms.DataGridView();
            nud_tiempo_limite_sup_atencionA = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(nud_tiempo_limite_sup_atencionA)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tab_simulacion.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gb_metricas.SuspendLayout();
            this.gb_parametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DE_atencionB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_mostrar_desde_filas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_mostrar_desde_minutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_media_atencionB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cant_minutos_simulacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_tiempo_medio_llegadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_tiempo_limite_inf_atencionA)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_simulacion)).BeginInit();
            this.tab_RK_1trabajo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rk_instante_bloqueo)).BeginInit();
            this.tab_RK_2trabajos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rk_bloqueo_llegadas)).BeginInit();
            this.SuspendLayout();
            // 
            // nud_tiempo_limite_sup_atencionA
            // 
            nud_tiempo_limite_sup_atencionA.DecimalPlaces = 2;
            nud_tiempo_limite_sup_atencionA.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            nud_tiempo_limite_sup_atencionA.Location = new System.Drawing.Point(244, 257);
            nud_tiempo_limite_sup_atencionA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            nud_tiempo_limite_sup_atencionA.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            nud_tiempo_limite_sup_atencionA.Name = "nud_tiempo_limite_sup_atencionA";
            nud_tiempo_limite_sup_atencionA.Size = new System.Drawing.Size(88, 23);
            nud_tiempo_limite_sup_atencionA.TabIndex = 63;
            nud_tiempo_limite_sup_atencionA.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_simulacion);
            this.tabControl1.Controls.Add(this.tab_RK_1trabajo);
            this.tabControl1.Controls.Add(this.tab_RK_2trabajos);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1446, 885);
            this.tabControl1.TabIndex = 3;
            // 
            // tab_simulacion
            // 
            this.tab_simulacion.Controls.Add(this.tableLayoutPanel1);
            this.tab_simulacion.Location = new System.Drawing.Point(4, 24);
            this.tab_simulacion.Name = "tab_simulacion";
            this.tab_simulacion.Padding = new System.Windows.Forms.Padding(3);
            this.tab_simulacion.Size = new System.Drawing.Size(1438, 857);
            this.tab_simulacion.TabIndex = 0;
            this.tab_simulacion.Text = "Simulación";
            this.tab_simulacion.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 385F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1432, 851);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gb_metricas);
            this.panel2.Controls.Add(this.gb_parametros);
            this.panel2.Controls.Add(this.btn_generar);
            this.panel2.Controls.Add(this.btn_restablecer);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 820);
            this.panel2.TabIndex = 63;
            // 
            // gb_metricas
            // 
            this.gb_metricas.Controls.Add(this.lbl_tiempo_prom_trabajo_value);
            this.gb_metricas.Controls.Add(this.lbl_tiempo_prom_trabajo);
            this.gb_metricas.Controls.Add(this.lbl_tiempo_parada_centroA_value);
            this.gb_metricas.Controls.Add(this.lbl_tiempo_parada_centroA);
            this.gb_metricas.Controls.Add(this.lbl_cant_maxima_trabajos_value);
            this.gb_metricas.Controls.Add(this.lbl_cant_maxima_trabajos);
            this.gb_metricas.Location = new System.Drawing.Point(7, 451);
            this.gb_metricas.Margin = new System.Windows.Forms.Padding(4);
            this.gb_metricas.Name = "gb_metricas";
            this.gb_metricas.Padding = new System.Windows.Forms.Padding(4);
            this.gb_metricas.Size = new System.Drawing.Size(365, 229);
            this.gb_metricas.TabIndex = 63;
            this.gb_metricas.TabStop = false;
            this.gb_metricas.Text = "Métricas";
            // 
            // lbl_tiempo_prom_trabajo_value
            // 
            this.lbl_tiempo_prom_trabajo_value.AutoSize = true;
            this.lbl_tiempo_prom_trabajo_value.Location = new System.Drawing.Point(301, 117);
            this.lbl_tiempo_prom_trabajo_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_tiempo_prom_trabajo_value.Name = "lbl_tiempo_prom_trabajo_value";
            this.lbl_tiempo_prom_trabajo_value.Size = new System.Drawing.Size(13, 15);
            this.lbl_tiempo_prom_trabajo_value.TabIndex = 13;
            this.lbl_tiempo_prom_trabajo_value.Text = "0";
            // 
            // lbl_tiempo_prom_trabajo
            // 
            this.lbl_tiempo_prom_trabajo.AutoSize = true;
            this.lbl_tiempo_prom_trabajo.Location = new System.Drawing.Point(60, 117);
            this.lbl_tiempo_prom_trabajo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_tiempo_prom_trabajo.Name = "lbl_tiempo_prom_trabajo";
            this.lbl_tiempo_prom_trabajo.Size = new System.Drawing.Size(226, 15);
            this.lbl_tiempo_prom_trabajo.TabIndex = 12;
            this.lbl_tiempo_prom_trabajo.Text = "Tiempo promedio de terminar un trabajo:";
            // 
            // lbl_tiempo_parada_centroA_value
            // 
            this.lbl_tiempo_parada_centroA_value.AutoSize = true;
            this.lbl_tiempo_parada_centroA_value.Location = new System.Drawing.Point(301, 74);
            this.lbl_tiempo_parada_centroA_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_tiempo_parada_centroA_value.Name = "lbl_tiempo_parada_centroA_value";
            this.lbl_tiempo_parada_centroA_value.Size = new System.Drawing.Size(13, 15);
            this.lbl_tiempo_parada_centroA_value.TabIndex = 11;
            this.lbl_tiempo_parada_centroA_value.Text = "0";
            // 
            // lbl_tiempo_parada_centroA
            // 
            this.lbl_tiempo_parada_centroA.AutoSize = true;
            this.lbl_tiempo_parada_centroA.Location = new System.Drawing.Point(21, 74);
            this.lbl_tiempo_parada_centroA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_tiempo_parada_centroA.Name = "lbl_tiempo_parada_centroA";
            this.lbl_tiempo_parada_centroA.Size = new System.Drawing.Size(265, 15);
            this.lbl_tiempo_parada_centroA.TabIndex = 10;
            this.lbl_tiempo_parada_centroA.Text = "Tiempo de parada del centro A por falta de lugar:";
            // 
            // lbl_cant_maxima_trabajos_value
            // 
            this.lbl_cant_maxima_trabajos_value.AutoSize = true;
            this.lbl_cant_maxima_trabajos_value.Location = new System.Drawing.Point(301, 36);
            this.lbl_cant_maxima_trabajos_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cant_maxima_trabajos_value.Name = "lbl_cant_maxima_trabajos_value";
            this.lbl_cant_maxima_trabajos_value.Size = new System.Drawing.Size(13, 15);
            this.lbl_cant_maxima_trabajos_value.TabIndex = 9;
            this.lbl_cant_maxima_trabajos_value.Text = "0";
            // 
            // lbl_cant_maxima_trabajos
            // 
            this.lbl_cant_maxima_trabajos.AutoSize = true;
            this.lbl_cant_maxima_trabajos.Location = new System.Drawing.Point(62, 36);
            this.lbl_cant_maxima_trabajos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cant_maxima_trabajos.Name = "lbl_cant_maxima_trabajos";
            this.lbl_cant_maxima_trabajos.Size = new System.Drawing.Size(224, 15);
            this.lbl_cant_maxima_trabajos.TabIndex = 8;
            this.lbl_cant_maxima_trabajos.Text = "Cantidad máxima de trabajos en sistema:";
            // 
            // gb_parametros
            // 
            this.gb_parametros.Controls.Add(this.lbl_distribucion_eventos);
            this.gb_parametros.Controls.Add(this.nud_DE_atencionB);
            this.gb_parametros.Controls.Add(this.lbl_DE_atencionB);
            this.gb_parametros.Controls.Add(this.label1);
            this.gb_parametros.Controls.Add(nud_tiempo_limite_sup_atencionA);
            this.gb_parametros.Controls.Add(this.nud_mostrar_desde_filas);
            this.gb_parametros.Controls.Add(this.lbl_mostrar_desde_filas);
            this.gb_parametros.Controls.Add(this.nud_mostrar_desde_minutos);
            this.gb_parametros.Controls.Add(this.lbl_mostrar_desde_minutos);
            this.gb_parametros.Controls.Add(this.nud_media_atencionB);
            this.gb_parametros.Controls.Add(this.nud_cant_minutos_simulacion);
            this.gb_parametros.Controls.Add(this.lbl_limite_inf_tiempo_atencionA);
            this.gb_parametros.Controls.Add(this.nud_tiempo_medio_llegadas);
            this.gb_parametros.Controls.Add(this.lbl_media_atencionB);
            this.gb_parametros.Controls.Add(this.lbl_tiempo_medio_llegadas);
            this.gb_parametros.Controls.Add(this.lbl_cant_minutos_simulacion);
            this.gb_parametros.Controls.Add(this.nud_tiempo_limite_inf_atencionA);
            this.gb_parametros.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gb_parametros.Location = new System.Drawing.Point(7, 9);
            this.gb_parametros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_parametros.Name = "gb_parametros";
            this.gb_parametros.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_parametros.Size = new System.Drawing.Size(365, 368);
            this.gb_parametros.TabIndex = 0;
            this.gb_parametros.TabStop = false;
            this.gb_parametros.Text = "Parámetros";
            // 
            // lbl_distribucion_eventos
            // 
            this.lbl_distribucion_eventos.AutoSize = true;
            this.lbl_distribucion_eventos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_distribucion_eventos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_distribucion_eventos.Location = new System.Drawing.Point(0, 144);
            this.lbl_distribucion_eventos.Name = "lbl_distribucion_eventos";
            this.lbl_distribucion_eventos.Size = new System.Drawing.Size(166, 19);
            this.lbl_distribucion_eventos.TabIndex = 67;
            this.lbl_distribucion_eventos.Text = "Distribuciones de Eventos";
            // 
            // nud_DE_atencionB
            // 
            this.nud_DE_atencionB.DecimalPlaces = 2;
            this.nud_DE_atencionB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_DE_atencionB.Location = new System.Drawing.Point(245, 333);
            this.nud_DE_atencionB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nud_DE_atencionB.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nud_DE_atencionB.Name = "nud_DE_atencionB";
            this.nud_DE_atencionB.Size = new System.Drawing.Size(88, 23);
            this.nud_DE_atencionB.TabIndex = 65;
            this.nud_DE_atencionB.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lbl_DE_atencionB
            // 
            this.lbl_DE_atencionB.AutoSize = true;
            this.lbl_DE_atencionB.Location = new System.Drawing.Point(12, 335);
            this.lbl_DE_atencionB.Name = "lbl_DE_atencionB";
            this.lbl_DE_atencionB.Size = new System.Drawing.Size(216, 15);
            this.lbl_DE_atencionB.TabIndex = 66;
            this.lbl_DE_atencionB.Text = "Desv. Estándar de atención B (minutos):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 15);
            this.label1.TabIndex = 64;
            this.label1.Text = "Límite superior atención A (minutos):";
            // 
            // nud_mostrar_desde_filas
            // 
            this.nud_mostrar_desde_filas.Location = new System.Drawing.Point(244, 116);
            this.nud_mostrar_desde_filas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nud_mostrar_desde_filas.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_mostrar_desde_filas.Name = "nud_mostrar_desde_filas";
            this.nud_mostrar_desde_filas.Size = new System.Drawing.Size(88, 23);
            this.nud_mostrar_desde_filas.TabIndex = 2;
            this.nud_mostrar_desde_filas.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nud_mostrar_desde_filas.Click += new System.EventHandler(this.numActive);
            this.nud_mostrar_desde_filas.Enter += new System.EventHandler(this.numActive);
            // 
            // lbl_mostrar_desde_filas
            // 
            this.lbl_mostrar_desde_filas.AutoSize = true;
            this.lbl_mostrar_desde_filas.Location = new System.Drawing.Point(145, 116);
            this.lbl_mostrar_desde_filas.Name = "lbl_mostrar_desde_filas";
            this.lbl_mostrar_desde_filas.Size = new System.Drawing.Size(83, 15);
            this.lbl_mostrar_desde_filas.TabIndex = 62;
            this.lbl_mostrar_desde_filas.Text = "Mostrar (filas):";
            this.lbl_mostrar_desde_filas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nud_mostrar_desde_minutos
            // 
            this.nud_mostrar_desde_minutos.Location = new System.Drawing.Point(244, 75);
            this.nud_mostrar_desde_minutos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nud_mostrar_desde_minutos.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.nud_mostrar_desde_minutos.Name = "nud_mostrar_desde_minutos";
            this.nud_mostrar_desde_minutos.Size = new System.Drawing.Size(88, 23);
            this.nud_mostrar_desde_minutos.TabIndex = 1;
            this.nud_mostrar_desde_minutos.Click += new System.EventHandler(this.numActive);
            this.nud_mostrar_desde_minutos.Enter += new System.EventHandler(this.numActive);
            // 
            // lbl_mostrar_desde_minutos
            // 
            this.lbl_mostrar_desde_minutos.AutoSize = true;
            this.lbl_mostrar_desde_minutos.Location = new System.Drawing.Point(89, 75);
            this.lbl_mostrar_desde_minutos.Name = "lbl_mostrar_desde_minutos";
            this.lbl_mostrar_desde_minutos.Size = new System.Drawing.Size(139, 15);
            this.lbl_mostrar_desde_minutos.TabIndex = 60;
            this.lbl_mostrar_desde_minutos.Text = "Mostrar desde el minuto:";
            this.lbl_mostrar_desde_minutos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nud_media_atencionB
            // 
            this.nud_media_atencionB.DecimalPlaces = 2;
            this.nud_media_atencionB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_media_atencionB.Location = new System.Drawing.Point(244, 293);
            this.nud_media_atencionB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nud_media_atencionB.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nud_media_atencionB.Name = "nud_media_atencionB";
            this.nud_media_atencionB.Size = new System.Drawing.Size(88, 23);
            this.nud_media_atencionB.TabIndex = 5;
            this.nud_media_atencionB.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nud_media_atencionB.Click += new System.EventHandler(this.numActive);
            this.nud_media_atencionB.Enter += new System.EventHandler(this.numActive);
            // 
            // nud_cant_minutos_simulacion
            // 
            this.nud_cant_minutos_simulacion.Location = new System.Drawing.Point(244, 34);
            this.nud_cant_minutos_simulacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nud_cant_minutos_simulacion.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.nud_cant_minutos_simulacion.Name = "nud_cant_minutos_simulacion";
            this.nud_cant_minutos_simulacion.Size = new System.Drawing.Size(88, 23);
            this.nud_cant_minutos_simulacion.TabIndex = 0;
            this.nud_cant_minutos_simulacion.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_cant_minutos_simulacion.Click += new System.EventHandler(this.numActive);
            this.nud_cant_minutos_simulacion.Enter += new System.EventHandler(this.numActive);
            // 
            // lbl_limite_inf_tiempo_atencionA
            // 
            this.lbl_limite_inf_tiempo_atencionA.AutoSize = true;
            this.lbl_limite_inf_tiempo_atencionA.Location = new System.Drawing.Point(9, 219);
            this.lbl_limite_inf_tiempo_atencionA.Name = "lbl_limite_inf_tiempo_atencionA";
            this.lbl_limite_inf_tiempo_atencionA.Size = new System.Drawing.Size(219, 15);
            this.lbl_limite_inf_tiempo_atencionA.TabIndex = 51;
            this.lbl_limite_inf_tiempo_atencionA.Text = "Límite inf. tiempo atención A (minutos):";
            // 
            // nud_tiempo_medio_llegadas
            // 
            this.nud_tiempo_medio_llegadas.DecimalPlaces = 2;
            this.nud_tiempo_medio_llegadas.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_tiempo_medio_llegadas.Location = new System.Drawing.Point(244, 176);
            this.nud_tiempo_medio_llegadas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nud_tiempo_medio_llegadas.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nud_tiempo_medio_llegadas.Name = "nud_tiempo_medio_llegadas";
            this.nud_tiempo_medio_llegadas.Size = new System.Drawing.Size(88, 23);
            this.nud_tiempo_medio_llegadas.TabIndex = 3;
            this.nud_tiempo_medio_llegadas.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nud_tiempo_medio_llegadas.Click += new System.EventHandler(this.numActive);
            this.nud_tiempo_medio_llegadas.Enter += new System.EventHandler(this.numActive);
            // 
            // lbl_media_atencionB
            // 
            this.lbl_media_atencionB.AutoSize = true;
            this.lbl_media_atencionB.Location = new System.Drawing.Point(54, 295);
            this.lbl_media_atencionB.Name = "lbl_media_atencionB";
            this.lbl_media_atencionB.Size = new System.Drawing.Size(173, 15);
            this.lbl_media_atencionB.TabIndex = 52;
            this.lbl_media_atencionB.Text = "Media de atención B (minutos):";
            // 
            // lbl_tiempo_medio_llegadas
            // 
            this.lbl_tiempo_medio_llegadas.AutoSize = true;
            this.lbl_tiempo_medio_llegadas.Location = new System.Drawing.Point(10, 178);
            this.lbl_tiempo_medio_llegadas.Name = "lbl_tiempo_medio_llegadas";
            this.lbl_tiempo_medio_llegadas.Size = new System.Drawing.Size(218, 15);
            this.lbl_tiempo_medio_llegadas.TabIndex = 50;
            this.lbl_tiempo_medio_llegadas.Text = "Tiempo medio entre llegadas (minutos):";
            this.lbl_tiempo_medio_llegadas.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_cant_minutos_simulacion
            // 
            this.lbl_cant_minutos_simulacion.AutoSize = true;
            this.lbl_cant_minutos_simulacion.Location = new System.Drawing.Point(30, 34);
            this.lbl_cant_minutos_simulacion.Name = "lbl_cant_minutos_simulacion";
            this.lbl_cant_minutos_simulacion.Size = new System.Drawing.Size(198, 15);
            this.lbl_cant_minutos_simulacion.TabIndex = 53;
            this.lbl_cant_minutos_simulacion.Text = "Cantidad de minutos de simulación:";
            // 
            // nud_tiempo_limite_inf_atencionA
            // 
            this.nud_tiempo_limite_inf_atencionA.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.nud_tiempo_limite_inf_atencionA.DecimalPlaces = 2;
            this.nud_tiempo_limite_inf_atencionA.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_tiempo_limite_inf_atencionA.Location = new System.Drawing.Point(244, 217);
            this.nud_tiempo_limite_inf_atencionA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nud_tiempo_limite_inf_atencionA.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_tiempo_limite_inf_atencionA.Name = "nud_tiempo_limite_inf_atencionA";
            this.nud_tiempo_limite_inf_atencionA.Size = new System.Drawing.Size(88, 23);
            this.nud_tiempo_limite_inf_atencionA.TabIndex = 4;
            this.nud_tiempo_limite_inf_atencionA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_tiempo_limite_inf_atencionA.Click += new System.EventHandler(this.numActive);
            this.nud_tiempo_limite_inf_atencionA.Enter += new System.EventHandler(this.numActive);
            // 
            // btn_generar
            // 
            this.btn_generar.Location = new System.Drawing.Point(193, 392);
            this.btn_generar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(178, 50);
            this.btn_generar.TabIndex = 0;
            this.btn_generar.Text = "Generar Simulación";
            this.btn_generar.UseVisualStyleBackColor = true;
            this.btn_generar.Click += new System.EventHandler(this.btn_generar_Click);
            // 
            // btn_restablecer
            // 
            this.btn_restablecer.Location = new System.Drawing.Point(7, 392);
            this.btn_restablecer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_restablecer.Name = "btn_restablecer";
            this.btn_restablecer.Size = new System.Drawing.Size(178, 50);
            this.btn_restablecer.TabIndex = 1;
            this.btn_restablecer.Text = "Restablecer";
            this.btn_restablecer.UseVisualStyleBackColor = true;
            this.btn_restablecer.Click += new System.EventHandler(this.btn_restablecer_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.dgv_simulacion);
            this.panel4.Location = new System.Drawing.Point(388, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1041, 847);
            this.panel4.TabIndex = 67;
            // 
            // dgv_simulacion
            // 
            this.dgv_simulacion.AllowUserToAddRows = false;
            this.dgv_simulacion.AllowUserToDeleteRows = false;
            this.dgv_simulacion.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_simulacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_simulacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_simulacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_simulacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_simulacion.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_simulacion.Location = new System.Drawing.Point(6, 18);
            this.dgv_simulacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_simulacion.Name = "dgv_simulacion";
            this.dgv_simulacion.ReadOnly = true;
            this.dgv_simulacion.RowHeadersVisible = false;
            this.dgv_simulacion.RowHeadersWidth = 51;
            this.dgv_simulacion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_simulacion.RowTemplate.Height = 24;
            this.dgv_simulacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_simulacion.Size = new System.Drawing.Size(1032, 823);
            this.dgv_simulacion.TabIndex = 62;
            // 
            // tab_RK_1trabajo
            // 
            this.tab_RK_1trabajo.Controls.Add(this.dgv_rk_instante_bloqueo);
            this.tab_RK_1trabajo.Location = new System.Drawing.Point(4, 24);
            this.tab_RK_1trabajo.Name = "tab_RK_1trabajo";
            this.tab_RK_1trabajo.Padding = new System.Windows.Forms.Padding(3);
            this.tab_RK_1trabajo.Size = new System.Drawing.Size(1438, 857);
            this.tab_RK_1trabajo.TabIndex = 1;
            this.tab_RK_1trabajo.Text = "RK - Un trabajo";
            this.tab_RK_1trabajo.UseVisualStyleBackColor = true;
            // 
            // dgv_rk_instante_bloqueo
            // 
            this.dgv_rk_instante_bloqueo.AllowUserToAddRows = false;
            this.dgv_rk_instante_bloqueo.AllowUserToDeleteRows = false;
            this.dgv_rk_instante_bloqueo.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_rk_instante_bloqueo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_rk_instante_bloqueo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_rk_instante_bloqueo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_rk_instante_bloqueo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_rk_instante_bloqueo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_rk_instante_bloqueo.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_rk_instante_bloqueo.Location = new System.Drawing.Point(202, 17);
            this.dgv_rk_instante_bloqueo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_rk_instante_bloqueo.Name = "dgv_rk_instante_bloqueo";
            this.dgv_rk_instante_bloqueo.ReadOnly = true;
            this.dgv_rk_instante_bloqueo.RowHeadersVisible = false;
            this.dgv_rk_instante_bloqueo.RowHeadersWidth = 51;
            this.dgv_rk_instante_bloqueo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_rk_instante_bloqueo.RowTemplate.Height = 24;
            this.dgv_rk_instante_bloqueo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_rk_instante_bloqueo.Size = new System.Drawing.Size(1034, 824);
            this.dgv_rk_instante_bloqueo.TabIndex = 63;
            // 
            // tab_RK_2trabajos
            // 
            this.tab_RK_2trabajos.Controls.Add(this.dgv_rk_bloqueo_llegadas);
            this.tab_RK_2trabajos.Location = new System.Drawing.Point(4, 24);
            this.tab_RK_2trabajos.Name = "tab_RK_2trabajos";
            this.tab_RK_2trabajos.Size = new System.Drawing.Size(1438, 857);
            this.tab_RK_2trabajos.TabIndex = 2;
            this.tab_RK_2trabajos.Text = "RK - Dos trabajos";
            this.tab_RK_2trabajos.UseVisualStyleBackColor = true;
            // 
            // dgv_rk_bloqueo_llegadas
            // 
            this.dgv_rk_bloqueo_llegadas.AllowUserToAddRows = false;
            this.dgv_rk_bloqueo_llegadas.AllowUserToDeleteRows = false;
            this.dgv_rk_bloqueo_llegadas.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_rk_bloqueo_llegadas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_rk_bloqueo_llegadas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_rk_bloqueo_llegadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_rk_bloqueo_llegadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_rk_bloqueo_llegadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_rk_bloqueo_llegadas.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_rk_bloqueo_llegadas.Location = new System.Drawing.Point(202, 17);
            this.dgv_rk_bloqueo_llegadas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_rk_bloqueo_llegadas.Name = "dgv_rk_bloqueo_llegadas";
            this.dgv_rk_bloqueo_llegadas.ReadOnly = true;
            this.dgv_rk_bloqueo_llegadas.RowHeadersVisible = false;
            this.dgv_rk_bloqueo_llegadas.RowHeadersWidth = 51;
            this.dgv_rk_bloqueo_llegadas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_rk_bloqueo_llegadas.RowTemplate.Height = 24;
            this.dgv_rk_bloqueo_llegadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_rk_bloqueo_llegadas.Size = new System.Drawing.Size(1034, 824);
            this.dgv_rk_bloqueo_llegadas.TabIndex = 64;
            // 
            // frm_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1446, 885);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_principal";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trabajo Práctico Final";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_principal_Load);
            ((System.ComponentModel.ISupportInitialize)(nud_tiempo_limite_sup_atencionA)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tab_simulacion.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gb_metricas.ResumeLayout(false);
            this.gb_metricas.PerformLayout();
            this.gb_parametros.ResumeLayout(false);
            this.gb_parametros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DE_atencionB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_mostrar_desde_filas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_mostrar_desde_minutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_media_atencionB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cant_minutos_simulacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_tiempo_medio_llegadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_tiempo_limite_inf_atencionA)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_simulacion)).EndInit();
            this.tab_RK_1trabajo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rk_instante_bloqueo)).EndInit();
            this.tab_RK_2trabajos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rk_bloqueo_llegadas)).EndInit();
            this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_simulacion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gb_metricas;
        private System.Windows.Forms.Label lbl_tiempo_prom_trabajo_value;
        private System.Windows.Forms.Label lbl_tiempo_prom_trabajo;
        private System.Windows.Forms.Label lbl_tiempo_parada_centroA_value;
        private System.Windows.Forms.Label lbl_tiempo_parada_centroA;
        private System.Windows.Forms.Label lbl_cant_maxima_trabajos_value;
        private System.Windows.Forms.Label lbl_cant_maxima_trabajos;
        private System.Windows.Forms.GroupBox gb_parametros;
        private System.Windows.Forms.NumericUpDown nud_mostrar_desde_minutos;
        private System.Windows.Forms.Label lbl_mostrar_desde_minutos;
        private System.Windows.Forms.NumericUpDown nud_media_atencionB;
        private System.Windows.Forms.NumericUpDown nud_cant_minutos_simulacion;
        private System.Windows.Forms.Label lbl_limite_inf_tiempo_atencionA;
        private System.Windows.Forms.NumericUpDown nud_tiempo_medio_llegadas;
        private System.Windows.Forms.Label lbl_media_atencionB;
        private System.Windows.Forms.Label lbl_tiempo_medio_llegadas;
        private System.Windows.Forms.Label lbl_cant_minutos_simulacion;
        private System.Windows.Forms.NumericUpDown nud_tiempo_limite_inf_atencionA;
        private System.Windows.Forms.Button btn_generar;
        private System.Windows.Forms.Button btn_restablecer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgv_simulacion;
        private System.Windows.Forms.TabPage tab_RK_1trabajo;
        private System.Windows.Forms.TabPage tab_RK_2trabajos;
        private System.Windows.Forms.DataGridView dgv_rk_instante_bloqueo;
        private System.Windows.Forms.DataGridView dgv_rk_bloqueo_llegadas;
        private System.Windows.Forms.NumericUpDown nud_mostrar_desde_filas;
        private System.Windows.Forms.Label lbl_mostrar_desde_filas;
        private Label label1;
        private NumericUpDown nud_tiempo_limite_sup_atencionA;
        private Label lbl_distribucion_eventos;
        private NumericUpDown nud_DE_atencionB;
        private Label lbl_DE_atencionB;
    }
}