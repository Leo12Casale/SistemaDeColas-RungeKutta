using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistemas_de_Colas.Presentacion;

namespace Sistemas_de_Colas.Presentacion
{
    public partial class frm_splash_screen : Form
    {
        public frm_splash_screen()
        {
            InitializeComponent();
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_principal frp = new frm_principal();
            frp.ShowDialog();
            this.Close();
        }
    }
}
