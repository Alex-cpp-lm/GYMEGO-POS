using ImpresionPOS58.DAOs;
using ImpresionPOS58.OBJETOS;
using MaterialSkin;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpresionPOS58.VENTANAS
{
    public partial class RenovarCliente : MaterialSkin.Controls.MaterialForm
    {
        bool metodoPago = false;
        Cliente cliente;
        Usuario usuario;
        public RenovarCliente(Cliente cliente, Usuario usuario)
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
            this.cliente = cliente;
            this.usuario = usuario;
            CargarDatos();

        }
        public void CargarDatos()
        {
            if (cliente.Foto != null)
            {
                using (var ms = new MemoryStream(cliente.Foto))
                {
                    picFoto.Image = Image.FromStream(ms);
                }
            }
            cliente.FechaRenovacion = cliente.FechaRenovacion.AddDays(30);
            label1.Text = $"{cliente.Nombre} {cliente.Apellidos}\n" + $"DIRECCION 🏠 {cliente.Direccion}\n"
                + $"CELULAR 📱 {cliente.Celular}\n" + $"CORREO 📧 {cliente.Correo}\n" +
                $"Te atiende: {usuario.NombreCompleto}";
        }
        private void CargarComboMembresias()
        {
            var dao = new MembresiaDAO();
            var membresias = dao.ObtenerTodas();

            materialComboBox1.DataSource = membresias;
            materialComboBox1.DisplayMember = "Display";        // 👈 MOSTRAMOS NOMBRE + PRECIO
            materialComboBox1.ValueMember = "idMembresia";      // 💾 VALOR QUE SE GUARDA INTERNAMENTE
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Membresia seleccionada = (Membresia)materialComboBox1.SelectedItem;
            int idMembresia = seleccionada.IdMembresia;
            VentaMembresia v = new VentaMembresia();
            v.Total = seleccionada.Precio;
            v.Fecha = DateTime.Now;
            v.MembresiaId = idMembresia;
            v.ClienteId = cliente.IdCliente;
            v.UsuarioId = usuario.IdUsuario;
            VentaMembresiaDAO c = new VentaMembresiaDAO();
            v.IdVentasMembresia = c.Insertar(v);
            MessageBox.Show("VENTA REALIZADA");
            ClienteDAO x = new ClienteDAO();
            x.Activar(cliente.IdCliente);
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler((sender, e) => PrintReceipt(sender, e, v, seleccionada, cliente, 0));
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
            g.DrawString("SERVICIO POR: " + usuario.Username, fontN, Brushes.Black, 0, y); y += 10;
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
