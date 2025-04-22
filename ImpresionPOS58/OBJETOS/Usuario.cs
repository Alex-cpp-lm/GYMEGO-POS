using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpresionPOS58.OBJETOS
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public byte[] Foto { get; set; } // Imagen en formato binario
        public string Username { get; set; }
        public string Password { get; set; } // MANTENIDO COMO TEXT
        public string NombreCompleto { get; set; }
        public int RangoId { get; set; }
        public string Celular { get; set; }
        public string CorreoElectronico { get; set; }
        public string Domicilio { get; set; }
    }

}
