using ImpresionPOS58.DAOs;
using ImpresionPOS58.OBJETOS;
using MaterialSkin;
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
    public partial class Membresias : MaterialSkin.Controls.MaterialForm
    {
        Usuario user;
        public Membresias(Usuario u)
        {
            InitializeComponent();
            if (u.RangoId == 3)
            {
                materialButton2.Enabled = false;
            }

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
            user = u;
            CargarClientes();

        }
        private void CargarClientes()
        {
            var dao = new ClienteDAO();
            var listaClientes = dao.ObtenerConMembresiaPorActividad(materialSwitch1.Checked);

            flowLayoutPanel1.Controls.Clear();

            foreach (var cliente in listaClientes)
            {
                var card = new ClienteCard(user); // AQUI USAMOS EL USERCONTROL
                card.CargarCliente(cliente);  // MÉTODO PERSONALIZADO PARA LLENAR LOS DATOS
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            AgregarCliente x = new AgregarCliente(user);
            x.Show();
        }

        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (!materialSwitch1.Checked)
            {
                materialSwitch1.Text = "SOLO USUARIOS INACTIVOS";
            }
            else
            {
                materialSwitch1.Text = "SOLO USUARIOS ACTIVOS";
            }
            CargarClientes();
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {
            string textoBuscado = materialTextBox1.Text;
            bool mostrarActivos = materialSwitch1.Checked;

            var dao = new ClienteDAO();
            var listaFiltrada = dao.ObtenerConMembresiaPorNombre(textoBuscado, mostrarActivos);

            flowLayoutPanel1.Controls.Clear();

            foreach (var cliente in listaFiltrada)
            {
                var card = new ClienteCard(user);
                card.CargarCliente(cliente);
                flowLayoutPanel1.Controls.Add(card);
            }
            if (materialTextBox1.Text == "")
            {
                flowLayoutPanel1.Controls.Clear();
                CargarClientes();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            CargarClientes();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            AgregarMembresia x = new AgregarMembresia();
            x.Show();
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            materialSwitch1.Checked = false;
            var dao = new ClienteDAO();
            var listaFiltrada = dao.ObtenerClientesInactivadosHoy();

            flowLayoutPanel1.Controls.Clear();

            foreach (var cliente in listaFiltrada)
            {
                var card = new ClienteCard(user);
                card.CargarCliente(cliente);
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            materialSwitch1.Checked = false;
            var dao = new ClienteDAO();
            var listaFiltrada = dao.ObtenerClientesInactivadosUltimos7Dias();

            flowLayoutPanel1.Controls.Clear();

            foreach (var cliente in listaFiltrada)
            {
                var card = new ClienteCard(user);
                card.CargarCliente(cliente);
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            materialSwitch1.Checked = false;
            var dao = new ClienteDAO();
            var listaFiltrada = dao.ObtenerClientesInactivadosUltimos30Dias();

            flowLayoutPanel1.Controls.Clear();

            foreach (var cliente in listaFiltrada)
            {
                var card = new ClienteCard(user);
                card.CargarCliente(cliente);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
    }
}


