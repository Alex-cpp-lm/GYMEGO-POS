using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpresionPOS58.OBJETOS
{
    public class VentaMembresia
    {
        public int IdVentasMembresia { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int ClienteId { get; set; }
        public int MembresiaId { get; set; }
        public int UsuarioId { get; set; }
    }

}
