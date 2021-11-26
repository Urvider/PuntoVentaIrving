using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2
{
    public partial class frmClientes : Form
    {
        public int id = 0;
        public frmClientes()
        {
            InitializeComponent();
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            AgregarClientes();
            TodosClientes();
            LimpiarCampos();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            ModificarCliente();
            TodosClientes();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            EliminarCliente();
            LimpiarCampos();
        }
        private void btRegresar_Click(object sender, EventArgs e)
        {
            frmPrincipal ob = new frmPrincipal();
            ob.Show();
            this.Hide();
        }
        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value.ToString());
            txtNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            txtApellidoPaterno.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
            txtApellidoMaterno.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
            if (dgvClientes.CurrentRow.Cells[4].Value.ToString() == "Femenino")
            {
                rbFemenino.Checked = true;
            }
            else
            {
                rbMasculino.Checked = true;
            }
            dtpFechaNacimiento.Value = Convert.ToDateTime(dgvClientes.CurrentRow.Cells[5].Value.ToString());
            txtRFC.Text = dgvClientes.CurrentRow.Cells[6].Value.ToString();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            TodosClientes();
        }
        private void TodosClientes()
        {
            using (var context = new AplicationDbContext())
            {
                var clientes = context.Clientes.ToList();
                dgvClientes.DataSource = clientes;
            }
        }
        private void AgregarClientes()
        {
            using (var context = new AplicationDbContext())
            {
                var clientes = new Clientes();
                clientes.Nombre = txtNombre.Text;
                clientes.ApellidoPaterno = txtApellidoPaterno.Text;
                clientes.ApellidoMaterno = txtApellidoMaterno.Text;
                clientes.Sexo = rbFemenino.Checked ? "Femenino" : "Masculino";
                clientes.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                clientes.RFC = txtRFC.Text;

                //Notificamos a EFC el agregar un cliente
                context.Clientes.Add(clientes);
                context.SaveChanges();
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtRFC.Text = "";

        }
        private void BuscarCliente()
        {
            using (var context = new AplicationDbContext())
            {
                var cliente = context.Clientes.Where(x => x.Nombre.Contains(txtNombre.Text)).ToList();
                dgvClientes.DataSource = cliente;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            BuscarCliente();
        }
        private void ModificarCliente()
        {
            using (var context = new AplicationDbContext())
            {
                if (id != 0)
                {
                    //Busqueda con un ORM
                    var cliente = context.Clientes.First(x => x.Id == id);
                    if (cliente != null)
                    {
                        cliente.Nombre = txtNombre.Text;
                        cliente.ApellidoPaterno = txtApellidoPaterno.Text;
                        cliente.ApellidoMaterno = txtApellidoMaterno.Text;
                        cliente.Sexo = rbFemenino.Checked ? "Femenino" : "Masuclino";
                        cliente.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                        cliente.RFC = txtRFC.Text;

                        context.SaveChanges();
                    }
                }
            }
            LimpiarCampos();

        }
        private void EliminarCliente()
        {
            using (var context = new AplicationDbContext())
            {
                if (id != 0)
                {
                    //Busqueda con un ORM
                    var cliente = context.Clientes.First(x => x.Id == id);
                    if (cliente != null)
                    {
                        context.Remove(cliente);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void lbNombre_Click(object sender, EventArgs e)
        {

        }

        private void lbApellidoPaterno_Click(object sender, EventArgs e)
        {

        }

        private void txtApellidoPaterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbApellidoMaterno_Click(object sender, EventArgs e)
        {

        }

        private void txtApellidoMaterno_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
