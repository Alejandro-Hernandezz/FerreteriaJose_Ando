using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FerreteriaJose_Ando.Forms;

namespace FerreteriaJose_Ando.Forms
{
    public partial class ClienteForm : Form
    {
        public ClienteForm()
        {
            InitializeComponent();
            MostrarClientes();
        }
        private void MostrarClientes()
        {
            using (var db = new FerreteriaDBEntities())
            {
                var lista = db.Cliente
                    .Select(p => new
                    {
                        p.Id,
                        p.Nombre,
                        p.Telefono,
                        p.Email
                    })
                    .ToList();
                dgvClientes.DataSource = lista; // ← ESTO FALTABA
            }
        }
        private void LimpiarCampos()
        {
            txtId_Clientes.Clear();
            txtNombre_Clientes.Clear();
            txtTelefono_Clientes.Clear();
            txtEmail_Clientes.Clear();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {

        }

        private void dgvRowHeader_Clientes(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                txtId_Clientes.Text = fila.Cells[0].Value?.ToString() ?? "";
                txtNombre_Clientes.Text = fila.Cells[1].Value?.ToString() ?? "";
                txtEmail_Clientes.Text = fila.Cells[3].Value?.ToString() ?? "";
                txtTelefono_Clientes.Text = fila.Cells[2].Value?.ToString() ?? "";

            }
        }

        private void btnAgregar_Clientes_Click(object sender, EventArgs e)
        {
            using (var db = new FerreteriaDBEntities())
            {
                var nuevo = new FerreteriaJose_Ando.Cliente
                {
                    Nombre = txtNombre_Clientes.Text,
                    Telefono = txtTelefono_Clientes.Text,
                    Email = txtEmail_Clientes.Text,
                };

                db.Cliente.Add(nuevo);
                db.SaveChanges();
            }

            MostrarClientes();
            LimpiarCampos();

        }

        private void btnEliminar_Clientes_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId_Clientes.Text, out int id))
            {
                using (var db = new FerreteriaDBEntities())
                {
                    var Cliente = db.Cliente.FirstOrDefault(p => p.Id == id);
                    if (Cliente != null)
                    {
                        db.Cliente.Remove(Cliente);
                        db.SaveChanges();
                        MessageBox.Show("Cliente eliminado correctamente.");

                        MostrarClientes();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no encontrado.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un Cliente válido para eliminar.");
            }
        }

        private void btnModificar_Clientes_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId_Clientes.Text, out int id))
            {
                using (var db = new FerreteriaDBEntities())
                {
                    var Cliente = db.Cliente.FirstOrDefault(p => p.Id == id);
                    if (Cliente != null)
                    {
                        Cliente.Nombre = txtNombre_Clientes.Text;
                        Cliente.Telefono = txtTelefono_Clientes.Text;
                        Cliente.Email = txtEmail_Clientes.Text;

                        db.SaveChanges();
                        MessageBox.Show("Cliente modificado correctamente.");

                        MostrarClientes();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no encontrado.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un Cliente válido para modificar.");
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

