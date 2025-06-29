using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerreteriaJose_Ando.Forms
{
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private List<DetalleVenta> carrito = new List<DetalleVenta>();
        private FerreteriaDBEntities db = new FerreteriaDBEntities();
        private void Ventas_Load(object sender, EventArgs e)
        {
            cbxCliente.DataSource = db.Cliente.ToList();
            cbxCliente.DisplayMember = "Nombre";
            cbxCliente.ValueMember = "Id";

            dgvProdVen.DataSource = db.Producto
                .Select(p => new
                {
                    p.Id,
                    p.Nombre,
                    p.Precio,
                    p.Stock
                })
                .ToList();
        }
        private void MostrarCarrito()
        {
            var vista = carrito.Select(c => new
            {
                Producto = db.Producto.FirstOrDefault(p => p.Id == c.Id)?.Nombre,
                c.Cantidad,
                c.PrecioUnitario,
                Subtotal = c.Cantidad * c.PrecioUnitario
            }).ToList();

            dgvCarrito.DataSource = vista;

            lblTotal.Text = "Total: $" + vista.Sum(v => v.Subtotal).ToString("N0");
        }


        private void btnagregarventa_Click(object sender, EventArgs e)
        {
            if (dgvProdVen.CurrentRow != null && int.TryParse(txtCantidad.Text, out int cantidad))
            {
                int idProducto = Convert.ToInt32(dgvProdVen.CurrentRow.Cells["Id"].Value);
                var producto = db.Producto.Find(idProducto);

                if (producto != null && producto.Stock >= cantidad)
                {
                    var detalle = new DetalleVenta
                    {
                        Id = producto.Id,
                        Cantidad = cantidad,
                        PrecioUnitario = producto.Precio
                    };

                    carrito.Add(detalle);
                    MostrarCarrito();
                }
                else
                {
                    MessageBox.Show("Stock insuficiente.");
                }
            }
        }
    }
}
