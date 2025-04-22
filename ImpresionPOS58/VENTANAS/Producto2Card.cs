using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ImpresionPOS58.OBJETOS;

namespace ImpresionPOS58.VENTANAS
{
    public partial class Producto2Card : UserControl
    {
        private Producto _producto;

        public event EventHandler ProductoModificado;

        public Producto2Card()
        {
            InitializeComponent();
        }

        public void CargarProducto(Producto producto)
        {
            _producto = producto;

            lblNombre.Text = producto.Nombre;
            lblDescripcion.Text = producto.Descripcion;
            lblPrecio.Text = $"${producto.Precio:F2}";
            lblCantidad.Text = $"CANTIDAD DISPONIBLE {producto.Cantidad}";
            lblPrecioReal.Text = $"REAL ${producto.precioReal:F2}";
            label1.Text = $"CODIGO: {producto.codigo}" ;

            if (producto.Foto != null)
            {
                using (MemoryStream ms = new MemoryStream(producto.Foto))
                {
                    picFoto.Image = Image.FromStream(ms);
                }
            }
            else
            {
                picFoto.Image = null;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // AQUÍ LANZAS EL EVENTO O PUEDES ABRIR UN FORMULARIO DE EDICIÓN
            ProductoModificado?.Invoke(this, EventArgs.Empty);
        }

        public Producto ObtenerProducto()
        {
            return _producto;
        }
    }
}
