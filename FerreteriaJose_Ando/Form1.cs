using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using FerreteriaJose_Ando.Forms;

namespace FerreteriaJose_Ando
{
    public partial class Form1 : Form
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();
        public Form1()
        {
            InitializeComponent();
            CargarDatosInicio();
        }


        private void CargarDatosInicio()
        {
            MostrarProductos();
            MostrarVentasDelMes();
            MostrarStockBajo();
        }

        private void MostrarProductos()
        {
            var productos = db.Producto
                              .Select(p => new
                              {
                                  p.Id,
                                  p.Nombre,
                                  p.Precio,
                                  p.Stock,
                                  Categoria = p.Categoria.Nombre
                              })
                              .ToList();

            dgvProductos.DataSource = productos;
        }

        private void MostrarVentasDelMes()
        {
            DateTime inicioMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            var ventas = db.Venta
                           .Where(v => v.Fecha >= inicioMes)
                           .Select(v => new
                           {
                               v.Id,
                               v.Fecha,
                               v.Total,
                               Cliente = v.Cliente.Nombre
                           })
                           .ToList();

            dgvVentaMes.DataSource = ventas;
        }



        private void MostrarStockBajo()
            {
                var stockBajo = db.Producto
                                  .Include(p => p.Categoria) 
                                  .Where(p => p.Stock <= 5)
                                  .Select(p => new
                                  {
                                      p.Nombre,
                                      p.Stock,
                                      Categoria = p.Categoria != null ? p.Categoria.Nombre : "Sin categoría"
                                  })
                                  .ToList();

                dgvStockB.DataSource = stockBajo;
            }

    private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductosForm formulario = new ProductosForm();
            formulario.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Proveedores proveedoresForm = new Proveedores();
            proveedoresForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
