using ImpresionPOS58.OBJETOS;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ImpresionPOS58
{
    public partial class pos : Form
    {
        public pos(Usuario user)
        {
            InitializeComponent();
            btnEfectivo.Enabled = false;
            btnTarjeta.Enabled = true;

        }
        bool metodoPago = true;
        private void btnTarjeta_Click(object sender, EventArgs e)
        {
            metodoPago = false;
            btnEfectivo.Enabled = true;
            btnTarjeta.Enabled = false;
            txtMetodo.Text = "EL PAGO SE HARÁ CON TARJETA";
        }
        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            metodoPago = true;
            txtMetodo.Text = "EL PAGO SE HARÁ EN EFECTIVO";
            btnEfectivo.Enabled = false;
            btnTarjeta.Enabled = true;

        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Crear algunos productos de ejemplo
            List<Producto> productos = new List<Producto>{
          new Producto { IdProducto = 1, Nombre = "INSCRIPCION", Descripcion = "PRIMERA VEZ QUE SE AGREGA", Precio = 0.0m, Cantidad = 1 },
        new Producto { IdProducto = 2, Nombre = "MENSUALIDAD", Descripcion = "MENSUALIDAD DE GYM", Precio = 450.00m, Cantidad = 1 },
              new Producto { IdProducto = 1, Nombre = "AGUA 600ML", Descripcion = "PRIMERA VEZ QUE SE AGREGA", Precio = 15.0m, Cantidad = 2 },
              new Producto { IdProducto = 1, Nombre = "PROTEINA", Descripcion = "PRIMERA VEZ QUE SE AGREGA", Precio = 40.0m, Cantidad = 1 }};

            decimal descuento = 0.00m;  // Ejemplo de descuento

            // Configura el documento de impresión
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler((sender, e) => PrintReceipt(sender, e, productos, descuento, 1324532));
            printDoc.PrinterSettings.PrinterName = "POS-58"; // Cambia el nombre de la impresora aquí

            try
            {
                // Imprime el documento
                printDoc.Print();
                MessageBox.Show("IMPRESIÓN EXITOSA ✅", "¡Listo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL IMPRIMIR: " + ex.Message, "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintReceipt(object sender, PrintPageEventArgs e, List<Producto> productos, decimal descuento, int folio)
        {
            // Configura la fuente para la impresión
            Graphics g = e.Graphics;
            Font font = new Font("Consolas", 8);
            Font fontxN = new Font("Consolas", 5);
            Font fontN = new Font("Consolas", 6);
            Font fontN1 = new Font("Consolas", 7);
            float y = 0;

            // Cargar y procesar la imagen para convertirla en blanco y negro (1 bit)
            Image logo = Image.FromFile("graficos/logo 1bit.png"); // Cargar imagen
            logo = ConvertToBlackAndWhite(logo); // Convertir a blanco y negro

            // Redimensionar la imagen (por ejemplo, reducirla a la mitad de su tamaño original)
            int newWidth = logo.Width / 2;  // Redimensionar a la mitad del tamaño original (ajusta el valor según sea necesario)
            int newHeight = logo.Height / 2; // Redimensionar a la mitad del tamaño original (ajusta el valor según sea necesario)

            // Obtener las dimensiones de la página de impresión
            float x = (e.PageBounds.Width - newWidth) / 2;  // Centrar en el eje X
            float logoY = y + 8; // Ubicación de la imagen en el eje Y (después del título)

            // Dibujar la imagen redimensionada y centrada en el ticket
            g.DrawImage(logo, x, logoY, newWidth, newHeight);  // Especifica el tamaño redimensionado aquí

            g.DrawString("FOLIO DE VENTA: " + folio, fontxN, Brushes.Black, 0, y); y += 8;
            y = logoY + newHeight + 10; // Avanza el contador 'y' después de la imagen para el texto
            g.DrawString("Instagram: @ego_integral", fontxN, Brushes.Black, 0, y); y += 8;
            g.DrawString("Facebook: EGO Integral Fitness", fontxN, Brushes.Black, 0, y); y += 10;
            g.DrawString("--------------------------------", font, Brushes.Black, 0, y); y += 10;
            g.DrawString("CONCEPTO | CANTIDAD  | PRECIO | TOTAL", fontN, Brushes.Black, 0, y); y += 10;
            g.DrawString("--------------------------------", font, Brushes.Black, 0, y); y += 10;
            // Definir el ancho máximo de 40 caracteres
            int maxWidth = 40;
            // Imprimir los productos
            decimal total = 0;
            int cantProd = 1;
            foreach (var producto in productos)
            {
                decimal subTotal = producto.Precio * producto.Cantidad;
                total += subTotal;
                // Crear la cadena de texto sin espacios adicionales
                string nombre = producto.Nombre;
                string cantidad = producto.Cantidad.ToString();
                string precio = producto.Precio.ToString("F2");
                string totalStr = subTotal.ToString("F2");
                // Obtener la longitud total de la cadena sin espacios
                int totalLength = nombre.Length + cantidad.Length + precio.Length + totalStr.Length;
                // Si la longitud total supera los 40 caracteres, agregar el ID del producto
                if (totalLength >= maxWidth)
                {
                    nombre = "ID: " + producto.IdProducto; // Añadir el ID al principio
                    totalLength = nombre.Length + cantidad.Length + precio.Length + totalStr.Length;
                }
                // Calcular el espacio restante y dividirlo entre 3 (para la separación entre campos)
                int spacePerColumn = (maxWidth - totalLength) / 3; // Espacios entre nombre, cantidad, precio y total
                // Construir la línea con los espacios calculados
                string espacios = "";
                for (int i = 0; i < spacePerColumn - 2; i++) { espacios += " "; }
                string line = $"" + cantProd + "-" + nombre + espacios + " " + cantidad + espacios + "$" + precio + espacios + "$" + totalStr;
                // Imprimir la línea de producto
                g.DrawString(line, fontN, Brushes.Black, 0, y);
                y += 10;
                cantProd++;
            }
            // Mostrar el descuento
            decimal totalConDescuento = total - descuento;
            g.DrawString("--------------------------------", font, Brushes.Black, 0, y); y += 10;
            g.DrawString($"TOTAL: ${total:F2}", font, Brushes.Black, 0, y); y += 10;
            g.DrawString($"DESCUENTO: -${descuento:F2}", font, Brushes.Black, 0, y); y += 10;
            g.DrawString($"TOTAL CON DESCUENTO: ${totalConDescuento:F2}", font, Brushes.Black, 0, y); y += 10;
            g.DrawString("--------------------------------", font, Brushes.Black, 0, y); y += 10;
            if (metodoPago) { g.DrawString($"COMPRA REALIZADA EN EFECTIVO", font, Brushes.Black, 0, y); y += 10; }
            else
            {
                g.DrawString($"COMPRA POR TRANFERENCIA", font, Brushes.Black, 0, y); y += 10;
                g.DrawString($"ALEXANDER - 1015", font, Brushes.Black, 0, y); y += 10;
            }
            g.DrawString("--------------------------------", font, Brushes.Black, 0, y); y += 10;
            // Finalizar el ticket
            g.DrawString("FECHA " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), fontN, Brushes.Black, 0, y); y += 10;
            g.DrawString("SERVICIO POR: ALEX (CAJERO)", fontN, Brushes.Black, 0, y); y += 10;
            g.DrawString("GRACIAS POR SU COMPRA <3", font, Brushes.Black, 0, y); y += 10;
            g.DrawString("QUEJAS Y SUGERENCIAS 445 108 2306", fontN, Brushes.Black, 0, y); y += 10;
            g.DrawString("¡¡ESTO NO CUENTA COMO FACTURA!!", fontN1, Brushes.Black, 0, y); y += 10;
        }
        private Image ConvertToBlackAndWhite(Image originalImage)
        {
            // Crear un objeto Bitmap con la imagen original
            Bitmap bmp = new Bitmap(originalImage);

            // Recorrer cada píxel de la imagen
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    // Obtener el color del píxel
                    Color pixelColor = bmp.GetPixel(x, y);

                    // Calcular el brillo del píxel (promediando los valores de los componentes RGB)
                    int brightness = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);

                    // Si el brillo es mayor que 128, hacer el píxel blanco, sino negro
                    Color newColor = brightness > 128 ? Color.White : Color.Black;

                    // Establecer el nuevo color en el píxel
                    bmp.SetPixel(x, y, newColor);
                }
            }

            return bmp;
        }

        private void pos_Load(object sender, EventArgs e)
        {

        }

        private void btnImprimir_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnImprimir_Click(sender, e);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Eso carnal");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
