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
    public partial class ProductosForm : Form
    {
        public ProductosForm()
        {
            InitializeComponent();
            mostrarProductos();
            mostrar_Prov_Cat();
            Tb_Id.Enabled = false; // deshabilitamos el campo ID para evitar cambios
        }
        private void mostrarProductos()
        {
            using (FerreteriaDBEntities db = new FerreteriaDBEntities())
            {
                var query = from p in db.Producto
                            select new
                            {
                                ID = p.Id,
                                Nombre = p.Nombre,
                                Categoria = p.Categoria.Nombre,
                                Proveedor = p.Proveedor.Nombre,
                                Precio = p.Precio,
                                Stock = p.Stock
                            };
                Dgw_Producto.DataSource = query.ToList();
                Dgw_Producto.Refresh();
            }

        }
        private void Limpiar()
        {
            Tb_Id.Text = string.Empty;
            Tb_Nom.Text = string.Empty;
            Cb_Cat.SelectedIndex = -1;
            Cb_Prov.SelectedIndex = -1;
            Tb_Pre.Text = string.Empty;
            Nud_Sto.Text = string.Empty;
        }

        private void mostrar_Prov_Cat()
        {
            using (FerreteriaDBEntities db = new FerreteriaDBEntities())
            {
                Cb_Cat.DataSource = db.Categoria.ToList();
                Cb_Cat.DisplayMember = "Nombre";
                Cb_Cat.ValueMember = "Id";
                Cb_Cat.SelectedIndex = -1;
                Cb_Prov.DataSource = db.Proveedor.ToList();
                Cb_Prov.DisplayMember = "Nombre";
                Cb_Prov.ValueMember = "Id";
                Cb_Prov.SelectedIndex = -1;
            }
        }

        private void Btn_agregar_Click(object sender, EventArgs e)
        {
            if (Tb_Nom.Text.Trim() != "" && Tb_Pre.Text.Trim() != "" && Cb_Cat.SelectedIndex != -1 && Cb_Prov.SelectedIndex != -1 && Nud_Sto.Value > -1)
            {
                Producto p = new Producto();
                //p.Id = int.Parse(Tb_Id.Text.Trim());
                p.Nombre = Tb_Nom.Text.Trim();
                p.CategoriaId = int.Parse(Cb_Cat.SelectedValue.ToString());
                p.ProveedorId = int.Parse(Cb_Prov.SelectedValue.ToString()); 
                p.Precio = decimal.Parse(Tb_Pre.Text.Trim());
                p.Stock = int.Parse(Nud_Sto.Value.ToString());

                using (FerreteriaDBEntities db = new FerreteriaDBEntities())
                {
                    db.Producto.Add(p);
                    db.SaveChanges();
                    mostrarProductos();
                    Limpiar();
                }
            }
        }

        private void Dgw_Producto_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow fila = Dgw_Producto.Rows[e.RowIndex]; // obtenemos la fila seleccionada            
            Tb_Id.Text = fila.Cells[0].Value.ToString();
            Tb_Nom.Text = fila.Cells[1].Value.ToString();
            Cb_Cat.Text = fila.Cells[2].Value.ToString();
            Cb_Prov.Text = fila.Cells[3].Value.ToString();
            Tb_Pre.Text = fila.Cells[4].Value.ToString();
            Nud_Sto.Value = int.Parse(fila.Cells[5].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Tb_Nom.Text.Trim() != "" && Tb_Pre.Text.Trim() != "" && Cb_Cat.SelectedIndex != -1 && Cb_Prov.SelectedIndex != -1 && Nud_Sto.Value > -1)
            {
                using (var db = new FerreteriaDBEntities())
                {
                    var p = db.Producto.Find(int.Parse(Tb_Id.Text.Trim()));
                    if (p != null)
                    {
                        p.Nombre = Tb_Nom.Text.Trim();
                        p.CategoriaId = int.Parse(Cb_Cat.SelectedValue.ToString()); // Explicit conversion to int
                        p.ProveedorId = int.Parse(Cb_Prov.SelectedValue.ToString()); // Explicit conversion to int
                        p.Precio = decimal.Parse(Tb_Pre.Text.Trim());
                        p.Stock = int.Parse(Nud_Sto.Value.ToString());
                        db.SaveChanges();
                        mostrarProductos();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado.");
                    }
                }
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (Tb_Nom.Text.Trim() != "" && Tb_Pre.Text.Trim() != "" && Cb_Cat.SelectedIndex != -1 && Cb_Prov.SelectedIndex != -1 && Nud_Sto.Value > -1)
            {
                using (var db = new FerreteriaDBEntities())
                {
                    var p = db.Producto.Find(int.Parse(Tb_Id.Text.Trim()));
                    if (p != null)
                    {
                        db.Producto.Remove(p);
                        db.SaveChanges();
                        mostrarProductos();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado.");
                    }

                }
            }
        }
    }
}
