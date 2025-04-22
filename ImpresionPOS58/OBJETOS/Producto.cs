using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpresionPOS58.OBJETOS
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public byte[] Foto { get; set; }  // Imagen en formato binario
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int CantidadEnTicket { get; set; } // esto solo en momento de venta
        public string codigo {  get; set; }
        public decimal precioReal { get; set; } // Precio que costó adquirirlo a la empresa

    }
}
