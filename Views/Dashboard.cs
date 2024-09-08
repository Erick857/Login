using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login.Controllers;
using Login.Views.Acesos;
using Login.Views.Bodega;
using Login.Views.Financiero;
using Login.Views.Usuarios;

using Login.Views;
namespace Login.Views
{
    public partial class Dashboard : Form
    {

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            var roles = ConfiguracionProyecto.rol;
            var nombreusuairo = ConfiguracionProyecto.usuario;
            var diusaurios = ConfiguracionProyecto.IDusuario;

            MessageBox.Show("Rol actual: " + roles);

            if (roles == "Admin")
            {
                menu.Items.Add("Usuarios", default(Image), frm_Usuarios_click);
                menu.Items.Add("Bodega", default(Image), frm_Bodega_click);
                menu.Items.Add("Financiero", default(Image), frm_Financiero_click);
                menu.Items.Add("Accesos", default(Image), frm_Accesos_click);
            }
            else if (roles == "Guardia")
            {
                menu.Items.Add("Accesos", default(Image), frm_Accesos_click);
                menu.Items.Add("Usuarios", default(Image), frm_Usuariosmodificar_click);
            }
            else if (roles == "Financiero")
            {
                menu.Items.Add("Financiero", default(Image), frm_Financiero_click);
            }
            else if (roles == "Bodega")
            {
                menu.Items.Add("Bodega", default(Image), frm_Bodega_click);
            }
            else
            {
                menu.Items.Add("Salir", default(Image), frm_Salir_click);
            }
        }

        private void frm_Usuarios_click(object sender, EventArgs e)
        {
            frm_Usuarios _Usuarios = new frm_Usuarios();
            _Usuarios.ShowDialog();
        }

        private void frm_Usuariosmodificar_click(object sender, EventArgs e)
        {
            var modificarcontrasenia = new frm_Usuarios_Contrsenia();
            modificarcontrasenia.Show();
        }

        private void frm_Financiero_click(object sender, EventArgs e)
        {
            frm_Financiero_Principal _Financiero = new frm_Financiero_Principal();
            _Financiero.ShowDialog();
        }

        private void frm_Bodega_click(object sender, EventArgs e)
        {
            frm_Bodega_Principal _Bodega = new frm_Bodega_Principal();
            _Bodega.ShowDialog();
        }

        private void frm_Accesos_click(object sender, EventArgs e)
        {
            frm_Accesos_Principal _Accesos = new frm_Accesos_Principal();
            _Accesos.ShowDialog();
        }

        private void frm_Salir_click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
