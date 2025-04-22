using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpresionPOS58.OBJETOS
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public byte[] Foto { get; set; } // Imagen en formato binario
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; }

        public string NombreMembresia { get; set; }
        public DateTime FechaRenovacion { get; set; }
    }

}
