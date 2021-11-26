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
    public partial class frmProducto : Form
    {
        int id = 0;
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            TodosProductos();
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarProducto();
            TodosProductos();
            LimpiarCampos();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            ModificarProducto();
            TodosProductos();
            LimpiarCampos();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            EliminarProducto();
            TodosProductos();
            LimpiarCampos();
        }

        private void btRegresar_Click(object sender, EventArgs e)
        {
            frmPrincipal ob = new frmPrincipal();
            ob.Show();
            this.Hide();
        }
        private void TodosProductos()
        {
            using(var context = new AplicationDbContext())
            {
                var productos = context.Producto.ToList();
                dgvProductos.DataSource = productos;
            }
        }
        private void RegistrarProducto()
        {
            using (var context = new AplicationDbContext())
            {
                var producto = new Producto();

                producto.Nombre = txtNombre.Text;
                producto.Marca = txtMarca.Text;
                producto.Cantidad = int.Parse(txtCantidad.Text);
                producto.PrecioCompra = int.Parse(txtPrecioCompra.Text);
                producto.PrecioVenta = int.Parse(txtPrecioVenta.Text);
                
                context.Producto.Add(producto);

                context.SaveChanges();


            }
        }
        private void ModificarProducto()
        {
            using (var context = new AplicationDbContext())
            {
                if(id != 0)
                {
                    var producto = context.Producto.First(x => x.Id == id);
                    if(producto!= null)
                    {
                        producto.Nombre = txtNombre.Text;
                        producto.Marca = txtMarca.Text;
                        producto.Cantidad = int.Parse(txtCantidad.Text);
                        producto.PrecioCompra = int.Parse(txtPrecioCompra.Text);
                        producto.PrecioVenta = int.Parse(txtPrecioVenta.Text);

                        context.SaveChanges();
                    }
                }
            }
        }
        private void EliminarProducto()
        {
            using (var context = new AplicationDbContext())
            {
                if (id != 0)
                {
                    var producto = context.Producto.First(x => x.Id == id);
                    if (producto!= null)
                    {
                        context.Remove(producto);
                        context.SaveChanges();
                    }
                }
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtMarca.Text = "";
            txtCantidad.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value.ToString());
            txtNombre.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            txtMarca.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            txtCantidad.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
            txtPrecioCompra.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();
            txtPrecioVenta.Text = dgvProductos.CurrentRow.Cells[5].Value.ToString();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
        private void BuscarProducto()
        {
            
            using (var context = new AplicationDbContext())
            {
                var producto = context.Producto.Where(x => x.Nombre.Contains(txtBuscar.Text)).ToList();
                dgvProductos.DataSource = producto;

            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            BuscarProducto();
            
        }
    }
}
