using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpresionPOS58.OBJETOS
{
    public class Membresia
    {
        public int IdMembresia { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Display => $"{Nombre} - ${Precio:N2}"; // 👈 NOMBRE Y PRECIO FORMATEADO

        public override string ToString()
        {
            return Display;
        }
    }

}
