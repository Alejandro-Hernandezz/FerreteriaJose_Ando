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
    public partial class VentasForm : Form
    {
        private List<DetalleVenta> carrito = new List<DetalleVenta>();
        public VentasForm()
        {
            InitializeComponent();
            CargarClientes();
            CargarProductos();
            MostrarCarrito();

        }
        private void CargarClientes()
        {
            using (var db = new FerreteriaDBEntities())
            {
                var clientes = db.Cliente.ToList();
                cbxCliente.DataSource = clientes;
                cbxCliente.DisplayMember = "Nombre";
                cbxCliente.ValueMember = "Id";
            }
        }
        private void CargarProductos()
        {
            using (var db = new FerreteriaDBEntities())
            {
                var productos = db.Producto.Where(p => p.Stock > 0).ToList();
                cbxProducto.DataSource = productos;
                cbxProducto.DisplayMember = "Nombre";
                cbxProducto.ValueMember = "Id";
            }
        }
        private void MostrarCarrito()
        {
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = carrito.Select(c => new
            {
                Producto = new FerreteriaDBEntities().Producto.FirstOrDefault(p => p.Id == c.Id).Nombre,
                c.Cantidad,
                c.PrecioUnitario,
                Subtotal = c.Cantidad * c.PrecioUnitario
            }).ToList();

            lblTotal.Text = "Total: $" + carrito.Sum(c => c.Cantidad * c.PrecioUnitario).ToString("N0");
        }
        private void VentasForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cbxProducto.SelectedItem is Producto producto)
            {
                int cantidad = (int)nudCantidad.Value;

                if (cantidad > producto.Stock)
                {
                    MessageBox.Show("No hay suficiente stock.");
                    return;
                }

                carrito.Add(new DetalleVenta
                {
                    Id = producto.Id,
                    Cantidad = cantidad,
                    PrecioUnitario = producto.Precio
                });

                MostrarCarrito();
            }
        }

        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            if (cbxCliente.SelectedItem is Cliente cliente && carrito.Count > 0)
            {
                using (var db = new FerreteriaDBEntities())
                {
                    // Crear y guardar la venta
                    var nuevaVenta = new Venta
                    {
                        Fecha = DateTime.Now,
                        Total = carrito.Sum(x => x.Cantidad * x.PrecioUnitario),
                        // Asumiendo que la relación con Cliente se hace por navegación o clave foránea "IdCliente" interna
                    };

                    // Asociar cliente (esto depende de tu modelo)
                    db.Cliente.Attach(cliente); // Asegura que el cliente esté referenciado
                    nuevaVenta.Cliente = cliente;

                    db.Venta.Add(nuevaVenta);
                    db.SaveChanges(); // Esto genera el Id de la venta

                    foreach (var item in carrito)
                    {
                        // Buscar producto original en la base de datos
                        var producto = db.Producto.FirstOrDefault(p => p.Id == item.Id);

                        if (producto != null)
                        {
                            // Crear nuevo detalle con los datos requeridos
                            var detalle = new DetalleVenta
                            {
                                Id = 0, // Este será autogenerado
                                Venta = nuevaVenta,
                                Producto = producto,
                                Cantidad = item.Cantidad,
                                PrecioUnitario = item.PrecioUnitario
                            };

                            db.DetalleVenta.Add(detalle);

                            // Descontar stock
                            producto.Stock -= item.Cantidad;
                        }
                    }

                    db.SaveChanges(); // Guarda detalles y stock actualizado
                }

                MessageBox.Show("Venta realizada con éxito.");
                carrito.Clear();
                MostrarCarrito();
                CargarProductos();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente y al menos un producto.");
            }
        }
    }
} 
