using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btEmpleados_Click(object sender, EventArgs e)
        {
            frmEmpleados ob = new frmEmpleados();
            ob.Show();
            this.Hide();
        }

        private void btClientes_Click(object sender, EventArgs e)
        {
            frmClientes ob1 = new frmClientes();
            ob1.Show();
            this.Hide();
        }

        private void btProducto_Click(object sender, EventArgs e)
        {
            frmProducto ob = new frmProducto();
            ob.Show();
            this.Hide();
        }
    }
}
