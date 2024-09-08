using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.Views.Financiero
{
    public partial class frm_Financiero_Principal : Form
    {
        public frm_Financiero_Principal()
        {
            InitializeComponent();
        }

        private void frm_Financiero_Principal_Load(object sender, EventArgs e)
        {
            MessageBox.Show(ConfiguracionProyecto.usuario);

        }
    }
}
