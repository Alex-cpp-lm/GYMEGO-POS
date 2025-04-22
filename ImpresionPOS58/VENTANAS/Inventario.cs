using ImpresionPOS58.DAOs;
using MaterialSkin;
using ImpresionPOS58.VENTANAS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpresionPOS58.VENTANAS
{
    public partial class Inventario : MaterialSkin.Controls.MaterialForm
    {
        public Inventario()
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
            buscadorTimer = new System.Windows.Forms.Timer();
            buscadorTimer.Interval = 500; // 500 MILISEGUNDOS ⏳
            buscadorTimer.Tick += BuscadorTimer_Tick;

        }
        private void BuscadorTimer_Tick(object sender, EventArgs e)
        {
            buscadorTimer.Stop(); // DETIENE EL TIMER DESPUÉS DE EJECUTAR
            if(materialTextBox1.Text=="")
            {
                CargarProductos();
            }
            else
            {
                BuscarProductos(materialTextBox1.Text.Trim()); // TU MÉTODO DE BÚSQUEDA 🔍
            }
            
        }

        private void CargarProductos()
        {
            var dao = new ProductoDAO();
            var listaProductos = dao.ObtenerTodos(); // AJUSTA ESTE MÉTODO SEGÚN TU LÓGICA

            flowLayoutPanel1.Controls.Clear();

            foreach (var producto in listaProductos)
            {
                var card = new VENTANAS.Producto2Card();
                card.CargarProducto(producto);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
        private void BuscarProductos(string texto)
        {
            var dao = new ProductoDAO();
            var lista = dao.BuscarPorNombreOCodigo(texto); // 🔍 CONSULTA PERSONALIZADA

            flowLayoutPanel1.Controls.Clear();

            foreach (var producto in lista)
            {
                var card = new Producto2Card();
                card.CargarProducto(producto);
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {
            buscadorTimer.Stop();  // DETIENE SI YA ESTABA CORRIENDO
            buscadorTimer.Start(); // INICIA EL TEMPORIZADOR
        }
    }
}
