using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpresionPOS58.OBJETOS
{
    public class VentaProducto
    {
        public int IdVentas { get; set; }
        public string Fecha { get; set; }
        public decimal Total { get; set; }
        public int UsuarioId { get; set; }
    }

}
