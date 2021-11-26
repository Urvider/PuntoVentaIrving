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
    public partial class frmEmpleados : Form
    {
        public int id = 0;
        public frmEmpleados()
        {
            InitializeComponent();
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            AgregarEmpleado();
            TodosEmpleados();
            LimpiarCampos();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            TodosEmpleados();
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            BuscarEmpleado();
        }
        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells[0].Value.ToString());
            txtNombre.Text = dgvEmpleados.CurrentRow.Cells[1].Value.ToString();
            txtApellidoPaterno.Text = dgvEmpleados.CurrentRow.Cells[2].Value.ToString();
            txtApellidoMaterno.Text = dgvEmpleados.CurrentRow.Cells[3].Value.ToString();
            if (dgvEmpleados.CurrentRow.Cells[4].Value.ToString() == "Femenino")
            {
                rbFemenino.Checked = true;
            }
            else
            {
                rbMasculino.Checked = true;
            }
            dtpFechaNacimiento.Value = Convert.ToDateTime(dgvEmpleados.CurrentRow.Cells[5].Value.ToString());
            txtRFC.Text = dgvEmpleados.CurrentRow.Cells[6].Value.ToString();

        }
        private void btModificar_Click(object sender, EventArgs e)
        {
            using (var context = new AplicationDbContext())
            {
                if (id != 0)
                {
                    //Busqueda con un ORM
                    var empleado = context.Empleados.First(x => x.Id == id);
                    if (empleado != null)
                    {
                        empleado.Nombre = txtNombre.Text;
                        empleado.ApellidoPaterno = txtApellidoPaterno.Text;
                        empleado.ApellidoMaterno = txtApellidoMaterno.Text;
                        empleado.Sexo = rbFemenino.Checked ? "Femenino" : "Masuclino";
                        empleado.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                        empleado.RFC = txtRFC.Text;

                        context.SaveChanges();
                    }
                }
            }
            LimpiarCampos();
        }
        private void btEliminar_Click(object sender, EventArgs e)
        {
            using (var context = new AplicationDbContext())
            {
                if (id != 0)
                {
                    //Busqueda con un ORM
                    var empleado = context.Empleados.First(x => x.Id == id);
                    if (empleado != null)
                    {
                        context.Remove(empleado);
                        context.SaveChanges();
                    }
                }
            }
            LimpiarCampos();
        }



        private void TodosEmpleados()
        {
            using(var context = new AplicationDbContext())
            {
                var empleados = context.Empleados.ToList();
                dgvEmpleados.DataSource = empleados;
            }
        }
        private void BuscarEmpleado()
        {
            using (var context = new AplicationDbContext()) {
                var empleados = context.Empleados.Where(x => x.Nombre.Contains(txtNombre.Text)).ToList();
                dgvEmpleados.DataSource = empleados;
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtRFC.Text = "";

        }
        private void AgregarEmpleado() {
            using (var context = new AplicationDbContext())
            {
                //Paso 1 Crear el objeto
                var empleados1 = new Empleados();
                empleados1.Nombre = txtNombre.Text;
                empleados1.ApellidoPaterno = txtApellidoPaterno.Text;
                empleados1.ApellidoMaterno = txtApellidoMaterno.Text;
                empleados1.Sexo = rbFemenino.Checked ? "Femenino" : "Masculino";
                empleados1.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                empleados1.RFC = txtRFC.Text;
                //Paso 2: Notificamos a EFC que queremos agregar un empleado
                context.Empleados.Add(empleados1);
                //Paso 3: Guardamos los cambios
                context.SaveChanges();
            }
        }

        private void btRegresar_Click(object sender, EventArgs e)
        {
            frmPrincipal ob = new frmPrincipal();
            ob.Show();
            this.Hide();
        }
    }
}
