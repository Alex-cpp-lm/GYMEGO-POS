using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ImpresionPOS58.DAOs;
using ImpresionPOS58.OBJETOS;
using ImpresionPOS58.VENTANAS;
using MaterialSkin;

namespace ImpresionPOS58
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        bool metodoPago = false;
        public int ids = 1;
        public Usuario user;
        public ProductoDAO p = new ProductoDAO();
        public Form1(Usuario userA)
        {
            InitializeComponent();
            user = userA;
            this.Load += Form1_Load;
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
            buscadorTimer = new System.Windows.Forms.Timer();
            buscadorTimer.Interval = 500; // 500 MILISEGUNDOS ⏳
            buscadorTimer.Tick += BuscadorTimer_Tick;

            if (user.RangoId == 3)
            {
                btnContabilidad.Enabled = false;
                btnInventario.Enabled = false;
            }
            else if (user.RangoId == 2)
            {
                btnContabilidad.Enabled = false;
            }
            lbltotal.BackColor = Color.Transparent;
            lbltotal.Font = new Font("Duldolar", 20.2499962F, FontStyle.Bold);
            lbltotal.ForeColor = SystemColors.Control;
            lbltotal.Location = new Point(-3, 20);
            lbltotal.Name = "lbltotal";
            lbltotal.Size = new Size(299, 45);
            lbltotal.TabIndex = 6;
            lbltotal.Text = "TOTAL: $10000.00";


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // AJUSTAR ESTILO DEL PANEL
            List<Producto> lista = p.ObtenerTodos(); // BUSQUEDA EN BD 🔍

            foreach (var prod in lista)
            {
                Producto1Card card1 = new Producto1Card(prod);
                card1.OnAgregar += (productoSeleccionado) =>
                {
                    if (productoSeleccionado.Cantidad <= 0)
                    {
                        MessageBox.Show("NO HAY EXISTENCIAS");
                    }
                    else
                    {
                        bool verificar = false;
                        foreach (var card in flowLayoutPanel1.Controls.OfType<ProductoCard>())
                        {
                            Producto producto = card.Producto;
                            if (productoSeleccionado.IdProducto == producto.IdProducto)
                            {
                                verificar = true;
                                card.IncrementarCantidad();
                                break;
                            }
                        }
                        if (!verificar)
                        {
                            // VERIFICAR QUE NO HAYA SIDO AGREGADO
                            GenerarProductoCard(productoSeleccionado);
                            actualizarTotal();
                        }
                    }
                };
                flowLayoutPanel3.Controls.Add(card1);
            }


        }

        private void GenerarProductoCard(Producto producto)
        {
            var card = new ProductoCard(producto);
            card.OnEliminar += (prod) =>
            {
                flowLayoutPanel1.Controls.Remove(card);
                actualizarTotal();
            };
            flowLayoutPanel1.Controls.Add(card);
            actualizarTotal();
        }


        private List<Producto> ObtenerProductosDelTicket()
        {
            List<Producto> productosEnTicket = new List<Producto>();

            foreach (var card in flowLayoutPanel1.Controls.OfType<ProductoCard>())
            {
                Producto producto = card.Producto;

                // ACTUALIZAMOS LA CANTIDAD EN TICKET
                producto.CantidadEnTicket = card.ObtenerCantidadEnTicket();

                // AGREGAMOS EL PRODUCTO A LA LISTA
                productosEnTicket.Add(producto);
            }

            return productosEnTicket;
        }
        public void ImprimirTicket()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler((sender, e) => PrintReceipt(sender, e, ObtenerProductosDelTicket(), 0));
            printDoc.PrinterSettings.PrinterName = "POS-58"; // Cambia el nombre de la impresora aquí
            try
            {
                try
                {
                    printDoc.Print();
                    MessageBox.Show("IMPRESIÓN EXITOSA ✅", "¡Listo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("ERROR AL IMPRIMIR");
                }
                try
                {
                    ProductoDAO x = new ProductoDAO();
                    x.DescontarInventarioPorVenta(ObtenerProductosDelTicket());
                }
                catch
                {
                    MessageBox.Show("ERROR AL DESCONTAR INVENTARIO");
                }
                try
                {
                    DetallesVentasProductoDAO z = new DetallesVentasProductoDAO();
                    z.InsertarDetallesDeVenta(ObtenerProductosDelTicket(), ids);

                }
                catch
                {
                    MessageBox.Show("ERROR AL AGREGAR DETALLES DE VENTA");
                }

            }
            catch
            {
                MessageBox.Show("OCURRIO UN ERROR AL HACER LA VENTA");
            }
            Form1 nuevoForm = new Form1(user); // CREA UNO NUEVO
            nuevoForm.Show();              // LO MUESTRA
            this.Close();

        }

        private void PrintReceipt(object sender, PrintPageEventArgs e, List<Producto> productos, decimal descuento)
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
            g.DrawString("CONCEPTO | CANTIDAD  | PRECIO | TOTAL", fontN, Brushes.Black, 0, y); y += 10;
            g.DrawString("--------------------------------", font, Brushes.Black, 0, y); y += 10;
            // Definir el ancho máximo de 40 caracteres
            int maxWidth = 40;
            // Imprimir los productos
            decimal total1 = 0;
            int cantProd = 1;
            foreach (var producto in productos)
            {
                decimal subTotal = producto.Precio * producto.Cantidad;
                total1 += subTotal;
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
            decimal total = 0;
            foreach (var card in flowLayoutPanel1.Controls.OfType<ProductoCard>())
            {
                Producto producto = card.Producto;

                producto.CantidadEnTicket = card.ObtenerCantidadEnTicket();
                total = total + (producto.Precio * producto.CantidadEnTicket);
            }
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
            g.DrawString("SERVICIO POR: " + user.Username, fontN, Brushes.Black, 0, y); y += 10;
            g.DrawString("GRACIAS POR SU COMPRA <3", font, Brushes.Black, 0, y); y += 10;
            g.DrawString("QUEJAS Y SUGERENCIAS 445 108 2306", fontN, Brushes.Black, 0, y); y += 10;
            g.DrawString("¡¡ESTO NO CUENTA COMO FACTURA!!", fontN1, Brushes.Black, 0, y); y += 10;
            VentaProducto s = new VentaProducto();
            s.Total = total;
            s.Fecha = DateTime.Now.ToString("dd/MM/yyyy");
            s.UsuarioId = user.IdUsuario;
            try
            {
                VentaProductoDAO a = new VentaProductoDAO();
                ids = a.InsertarYObtenerId(s);
            }
            catch
            {
                MessageBox.Show("ERROR AL REGISTRAR VENTA");
            }
            g.DrawString("FOLIO DE VENTA: " + ids, fontxN, Brushes.Black, 0, y); y += 8;



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
        private void BuscadorTimer_Tick(object sender, EventArgs e)
        {
            buscadorTimer.Stop(); // DETIENE EL TIMER DESPUÉS DE EJECUTAR
            if (txtBuscador.Text == "")
            {
                List<Producto> lista = p.ObtenerTodos(); // BUSQUEDA EN BD 🔍

                foreach (var prod in lista)
                {
                    Producto1Card card1 = new Producto1Card(prod);
                    card1.OnAgregar += (productoSeleccionado) =>
                    {
                        if (productoSeleccionado.Cantidad <= 0)
                        {
                            MessageBox.Show("NO HAY EXISTENCIAS");
                        }
                        else
                        {
                            bool verificar = false;
                            foreach (var card in flowLayoutPanel1.Controls.OfType<ProductoCard>())
                            {
                                Producto producto = card.Producto;
                                if (productoSeleccionado.IdProducto == producto.IdProducto)
                                {
                                    verificar = true;
                                    card.IncrementarCantidad();
                                    break;
                                }
                            }
                            if (!verificar)
                            {
                                // VERIFICAR QUE NO HAYA SIDO AGREGADO
                                GenerarProductoCard(productoSeleccionado);
                                actualizarTotal();
                            }
                        }
                    };
                    flowLayoutPanel3.Controls.Add(card1);
                }
            }
            else
            {
                buscarProductos(txtBuscador.Text.Trim()); // TU MÉTODO DE BÚSQUEDA 🔍
            }

        }

        private async void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            buscadorTimer.Stop();  // DETIENE SI YA ESTABA CORRIENDO
            buscadorTimer.Start(); // INICIA EL TEMPORIZADOR
        }
        public void buscarProductos(string texto)
        {
            flowLayoutPanel3.Controls.Clear(); // LIMPIA LOS RESULTADOS ANTERIORES 🧹


            if (!string.IsNullOrEmpty(texto))
            {
                // Esperamos 500ms para evitar que la búsqueda se realice con cada tecla

                List<Producto> lista = p.BuscarPorNombreOCodigo(texto); // BUSQUEDA EN BD 🔍

                foreach (var prod in lista)
                {
                    Producto1Card card1 = new Producto1Card(prod);
                    card1.OnAgregar += (productoSeleccionado) =>
                    {
                        if (productoSeleccionado.Cantidad <= 0)
                        {
                            MessageBox.Show("NO HAY EXISTENCIAS");
                        }
                        else
                        {
                            bool verificar = false;
                            foreach (var card in flowLayoutPanel1.Controls.OfType<ProductoCard>())
                            {
                                Producto producto = card.Producto;
                                if (productoSeleccionado.IdProducto == producto.IdProducto)
                                {
                                    verificar = true;
                                    card.IncrementarCantidad();
                                    break;
                                }
                            }
                            if (!verificar)
                            {
                                // VERIFICAR QUE NO HAYA SIDO AGREGADO
                                GenerarProductoCard(productoSeleccionado);
                                actualizarTotal();
                            }
                        }
                    };
                    flowLayoutPanel3.Controls.Add(card1);
                }
            }
        }

        public void actualizarTotal()
        {
            decimal total = 0;
            foreach (var card in flowLayoutPanel1.Controls.OfType<ProductoCard>())
            {
                Producto producto = card.Producto;

                producto.CantidadEnTicket = card.ObtenerCantidadEnTicket();
                total = total + (producto.Precio * producto.CantidadEnTicket);
            }
            lbltotal.Text = "TOTAL: $" + total.ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            actualizarTotal();
        }

        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            metodoPago = materialSwitch1.Checked;
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            ImprimirTicket();
        }
        public static void InsertarProductosFalsos()
        {
            ProductoDAO dao = new ProductoDAO();

            for (int i = 1; i <= 100; i++)
            {
                Producto producto = new Producto
                {
                    IdProducto = i,
                    Nombre = $"PRODUCTO PRUEBA {i}",
                    Descripcion = $"DESCRIPCION DEL PRODUCTO {i}",
                    Precio = Math.Round(10 + (decimal)(i * 0.75), 2),
                    Cantidad = 100,
                    CantidadEnTicket = 0,
                    codigo = $"COD{i:0000}",
                    Foto = ObtenerImagenDummyComoBytes()
                };

                dao.Insertar(producto);
            }
            MessageBox.Show("agregados");
        }

        private static byte[] ObtenerImagenDummyComoBytes()
        {
            // CREA UNA IMAGEN DE COLOR ALEATORIO PARA SIMULAR LA FOTO 🎨📸
            Bitmap bmp = new Bitmap(100, 100);
            Random rnd = new Random();
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            }

            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            InsertarProductosFalsos();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            Membresias s = new Membresias(user);
            s.Show();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario x = new Inventario(); x.Show();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit(); // ESTO CIERRA TODO 💥
        }

        private void Form1_Load_2(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit(); // ESTO CIERRA TODO 💥
        }
    }
}
