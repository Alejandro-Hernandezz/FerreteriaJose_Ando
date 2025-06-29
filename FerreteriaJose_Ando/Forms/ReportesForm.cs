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
    public partial class ReportesForm : Form
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();
        public ReportesForm()
        {
            InitializeComponent();
            cbxReportes.Items.AddRange(new string[]
           {
                "Ventas del Mes",
                "Productos con Bajo Stock",
                "Top Productos Más Vendidos",
                "Clientes con Más Compras",
                "Productos Sin Ventas"
           });
            cbxReportes.SelectedIndex = 0;
            MostrarReporte();
        }

        private void MostrarReporte()
        {
            string seleccion = cbxReportes.SelectedItem?.ToString();

            switch (seleccion)
            {
                case "Ventas del Mes":
                    MostrarVentasDelMes();
                    break;

                case "Productos con Bajo Stock":
                    MostrarStockBajo();
                    break;

                case "Top Productos Más Vendidos":
                    MostrarTopProductos();
                    break;

                case "Clientes con Más Compras":
                    MostrarTopClientes();
                    break;

                case "Productos Sin Ventas":
                    MostrarProductosSinVentas();
                    break;


                default:
                    dgvReporte.DataSource = null;
                    break;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarReporte();
        }

        private void MostrarVentasDelMes()
        {
            var inicioMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            var ventas = db.Venta
                .Where(v => v.Fecha >= inicioMes)
                .Select(v => new
                {
                    v.Id,
                    Cliente = v.Cliente.Nombre,
                    v.Fecha,
                    v.Total
                }).ToList();

            dgvReporte.DataSource = ventas;
        }

        private void MostrarStockBajo()
        {
            var productos = db.Producto
                .Where(p => p.Stock <= 5)
                .Select(p => new
                {
                    p.Id,
                    p.Nombre,
                    p.Stock,
                    Categoria = p.Categoria.Nombre
                }).ToList();

            dgvReporte.DataSource = productos;
        }

        private void MostrarTopProductos()
        {
            var top = db.DetalleVenta
                .GroupBy(d => d.Producto.Nombre)
                .Select(g => new
                {
                    Producto = g.Key,
                    CantidadVendida = g.Sum(d => d.Cantidad)
                })
                .OrderByDescending(x => x.CantidadVendida)
                .Take(10)
                .ToList();

            dgvReporte.DataSource = top;
        }

        private void MostrarTopClientes()
        {
            var clientes = db.Venta
                .GroupBy(v => v.Cliente.Nombre)
                .Select(g => new
                {
                    Cliente = g.Key,
                    TotalCompras = g.Sum(v => v.Total),
                    CantidadVentas = g.Count()
                })
                .OrderByDescending(x => x.TotalCompras)
                .Take(10)
                .ToList();

            dgvReporte.DataSource = clientes;
        }

        private void MostrarProductosSinVentas()
        {
            var vendidos = db.DetalleVenta.Select(d => d.Producto.Id).Distinct();

            var sinVentas = db.Producto
                .Where(p => !vendidos.Contains(p.Id))
                .Select(p => new
                {
                    p.Id,
                    p.Nombre,
                    p.Stock
                }).ToList();

            dgvReporte.DataSource = sinVentas;
        }

       
    
        private void ReportesForm_Load(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
