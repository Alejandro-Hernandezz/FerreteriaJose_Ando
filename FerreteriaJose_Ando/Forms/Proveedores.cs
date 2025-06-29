using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerreteriaJose_Ando
{
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
            MostrarProveedores();
        }


        private void MostrarProveedores()
        {
            using (var db = new FerreteriaDBEntities())
            {
                var lista = db.Proveedor
                    .Select(p => new
                    {
                        p.Id,
                        p.Nombre,
                        p.Telefono,
                        p.Direccion
                    })
                    .ToList();

                dgvProveedores.DataSource = lista; // ← ESTO FALTABA
            }

        }
        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
   

        

        private void Proveedores_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

         
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var db = new FerreteriaDBEntities())
            {
                var nuevo = new Proveedor
                {
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text
                };

                db.Proveedor.Add(nuevo);
                db.SaveChanges();
            }

            MostrarProveedores();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                using (var db = new FerreteriaDBEntities())
                {
                    var proveedor = db.Proveedor.FirstOrDefault(p => p.Id == id);
                    if (proveedor != null)
                    {
                        db.Proveedor.Remove(proveedor);
                        db.SaveChanges();
                        MessageBox.Show("Proveedor eliminado correctamente.");

                        MostrarProveedores();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Proveedor no encontrado.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor válido para eliminar.");
            }

        }

        private void dgvProveedores_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProveedores.Rows[e.RowIndex];

                txtId.Text = fila.Cells[0].Value?.ToString() ?? "";
                txtNombre.Text = fila.Cells[1].Value?.ToString() ?? "";
                txtTelefono.Text = fila.Cells[2].Value?.ToString() ?? "";
                txtDireccion.Text = fila.Cells[3].Value?.ToString() ?? "";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                using (var db = new FerreteriaDBEntities())
                {
                    var proveedor = db.Proveedor.FirstOrDefault(p => p.Id == id);
                    if (proveedor != null)
                    {
                        proveedor.Nombre = txtNombre.Text;
                        proveedor.Telefono = txtTelefono.Text;
                        proveedor.Direccion = txtDireccion.Text;

                        db.SaveChanges();
                        MessageBox.Show("Proveedor modificado correctamente.");

                        MostrarProveedores();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Proveedor no encontrado.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor válido para modificar.");
            }
        }
    }
}
