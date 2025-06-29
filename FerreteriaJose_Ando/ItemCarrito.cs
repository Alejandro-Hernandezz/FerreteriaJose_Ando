using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaJose_Ando
{
    internal class ItemCarrito
    {
        public int IdProducto { get; set; }  // ← Este es el ID que debes usar
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
