using ImpresionPOS58.DAOs;
using ImpresionPOS58.OBJETOS;
using MaterialSkin;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ImpresionPOS58.VENTANAS
{
    public partial class AgregarCliente : MaterialSkin.Controls.MaterialForm
    {
        byte[] imagenBytes;
        bool metodoPago = false;
        Usuario user;
        public AgregarCliente(Usuario u)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK; // O LIGHT
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.LightBlue200,
                TextShade.WHITE
            );
            CargarComboMembresias();
            user = u;
            if (pictureBoxFoto.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBoxFoto.Image.Save(ms, pictureBoxFoto.Image.RawFormat); // 📸➡️💾
                    imagenBytes = ms.ToArray();
                }
            }

        }
        public byte[] RedimensionarImagen(byte[] imagenBytes, int maxWidth, int maxHeight)
        {
            using (var ms = new MemoryStream(imagenBytes))
            {
                var imagenOriginal = Image.FromStream(ms);

                // Calcular el nuevo tamaño basado en las restricciones máximas de ancho y alto
                var ratioX = (double)maxWidth / imagenOriginal.Width;
                var ratioY = (double)maxHeight / imagenOriginal.Height;
                var ratio = Math.Min(ratioX, ratioY);

                var nuevoAncho = (int)(imagenOriginal.Width * ratio);
                var nuevoAlto = (int)(imagenOriginal.Height * ratio);

                var imagenRedimensionada = new Bitmap(imagenOriginal, nuevoAncho, nuevoAlto);

                // Convertir la imagen redimensionada a byte[]
                using (var msRedimensionada = new MemoryStream())
                {
                    imagenRedimensionada.Save(msRedimensionada, ImageFormat.Jpeg);  // O el formato que prefieras
                    return msRedimensionada.ToArray();
                }
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario Camara
            Camara camaraForm = new Camara();

            // Mostrar el formulario Camara como un cuadro de diálogo
            DialogResult result = camaraForm.ShowDialog();

            // Depuración: Verificar si se cerró correctamente el formulario
            // Si se cerró correctamente, obtener la imagen capturada
            if (result == DialogResult.OK)
            {
                // Obtener la imagen capturada desde el formulario Camara
                imagenBytes = camaraForm.ObtenerImagenComoBytes();

                // Depuración: Verificar si la imagen no es nula
                if (imagenBytes != null)
                {

                    // Convertir los bytes de imagen en una imagen y mostrarla en el PictureBox
                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                    {
                        pictureBoxFoto.Image = Image.FromStream(ms);

                    }
                }
                else
                {
                    MessageBox.Show("No se obtuvo ninguna imagen.");
                }
            }
            else
            {
                MessageBox.Show("El formulario Camara no devolvió un resultado exitoso.");
            }
        }
        public byte[] ObtenerImagenComoBytes()
        {
            if (pictureBoxFoto.Image == null) return null;

            using (MemoryStream ms = new MemoryStream())
            {
                pictureBoxFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        private void CargarComboMembresias()
        {
            var dao = new MembresiaDAO();
            var membresias = dao.ObtenerTodas();

            materialComboBox1.DataSource = membresias;
            materialComboBox1.DisplayMember = "Display";        // 👈 MOSTRAMOS NOMBRE + PRECIO
            materialComboBox1.ValueMember = "idMembresia";      // 💾 VALOR QUE SE GUARDA INTERNAMENTE
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Cliente a = new Cliente();
            a.Nombre = materialTextBox1.Text;
            a.Apellidos = materialTextBox2.Text;
            a.Direccion = materialTextBox3.Text;
            a.Celular = materialTextBox4.Text;
            a.Correo = materialTextBox5.Text;
            a.Activo = true;
            a.Foto = RedimensionarImagen(imagenBytes,200,200);
            Membresia seleccionada = (Membresia)materialComboBox1.SelectedItem;
            int idMembresia = seleccionada.IdMembresia;
            ClienteDAO x = new ClienteDAO();
            a.IdCliente = x.Insertar(a);
            VentaMembresia v = new VentaMembresia();
            v.Total = seleccionada.Precio;
            v.Fecha = DateTime.Now;
            v.MembresiaId = idMembresia;
            v.ClienteId = a.IdCliente;
            v.UsuarioId = user.IdUsuario;
            VentaMembresiaDAO c = new VentaMembresiaDAO();
            v.IdVentasMembresia = c.Insertar(v);
            MessageBox.Show("VENTA REALIZADA");
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler((sender, e) => PrintReceipt(sender, e, v, seleccionada, a, 0));
            printDoc.PrinterSettings.PrinterName = "POS-58"; // Cambia el nombre de la impresora aquí
            printDoc.Print();
            this.Close();
        }
        private void PrintReceipt(object sender, PrintPageEventArgs e, VentaMembresia venta, Membresia membresia, Cliente cliente, decimal descuento)
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

            y = logoY + newHeight + 10; // Avanza el contador 'y' después de la imagen para el texto
            g.DrawString("Instagram: @ego_integral", fontxN, Brushes.Black, 0, y); y += 8;
            g.DrawString("Facebook: EGO Integral Fitness", fontxN, Brushes.Black, 0, y); y += 10;
            g.DrawString("--------------------------------", font, Brushes.Black, 0, y); y += 10;
            g.DrawString("CONCEPTO | CLIENTE  | PRECIO | ", fontN, Brushes.Black, 0, y); y += 10;
            g.DrawString("--------------------------------", font, Brushes.Black, 0, y); y += 10;
            // Definir el ancho máximo de 40 caracteres
            int maxWidth = 40;
            // Imprimir los productos

            string line = $"" + membresia.Nombre + "-" + cliente.Nombre + "-" + membresia.Precio;
            // Imprimir la línea de producto
            g.DrawString(line, fontN, Brushes.Black, 0, y);
            DateTime fechaActual = DateTime.Now;
            DateTime fechaCon30Dias = fechaActual.AddDays(30);

            g.DrawString("--------------------------------", font, Brushes.Black, 0, y); y += 10;
            g.DrawString($"TOTAL: ${membresia.Precio:F2}", font, Brushes.Black, 0, y); y += 10;
            g.DrawString($"RENOVACION EL ${fechaCon30Dias}", font, Brushes.Black, 0, y); y += 10;
            g.DrawString("--------------------------------", font, Brushes.Black, 0, y); y += 10;
            if (metodoPago) { g.DrawString($"COMPRA REALIZADA EN EFECTIVO", font, Brushes.Black, 0, y); y += 10; }
            else
            {
                g.DrawString($"COMPRA POR TRANFERENCIA", font, Brushes.Black, 0, y); y += 10;
                g.DrawString($"ALEXANDER - 1015", font, Brushes.Black, 0, y); y += 10;
            }
            g.DrawString("--------------------------------", font, Brushes.Black, 0, y); y += 10;
            // Finalizar el ticket
            g.DrawString("FECHA " + fechaActual, fontN, Brushes.Black, 0, y); y += 10;
            g.DrawString("SERVICIO POR: " + user.Username, fontN, Brushes.Black, 0, y); y += 10;
            g.DrawString("GRACIAS POR SU COMPRA <3", font, Brushes.Black, 0, y); y += 10;
            g.DrawString("QUEJAS Y SUGERENCIAS 445 108 2306", fontN, Brushes.Black, 0, y); y += 10;
            g.DrawString("¡¡ESTO NO CUENTA COMO FACTURA!!", fontN1, Brushes.Black, 0, y); y += 10;
            g.DrawString("FOLIO DE VENTA: " + venta.IdVentasMembresia, fontxN, Brushes.Black, 0, y); y += 8;



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

        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            metodoPago = materialSwitch1.Checked;
        }
    }
}
