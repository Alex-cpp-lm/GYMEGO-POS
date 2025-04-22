using ImpresionPOS58.DAOs;
using ImpresionPOS58.OBJETOS;
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
    public partial class ClienteCard : UserControl
    {
        Cliente client;
        Usuario usuario;
        public ClienteCard(Usuario u)
        {
            InitializeComponent();
            usuario = u;
        }

        public void CargarCliente(Cliente cliente)
        {
            client = cliente;
            lblNombre.Text = $"{cliente.Nombre} {cliente.Apellidos}";
            lblDireccion.Text = $"DIRECCION 🏠 {cliente.Direccion}";
            cliente.FechaRenovacion = cliente.FechaRenovacion.AddDays(30);
            lblCelular.Text = $"CELULAR 📱 {cliente.Celular}";
            lblCorreo.Text = $"CORREO 📧 {cliente.Correo}";
            lblActivo.Text = cliente.Activo ? "ESTADO ✅ ACTIVO" : "ESTADO ❌ INACTIVO";
            if (!cliente.Activo)
            {
                button1.Visible = false;
                lblActivo.ForeColor = Color.Red;
            }
            lblMembresia.Text = $"MEMBRESIA 💳 {cliente.NombreMembresia}";
            lblFechaRenovacion.Text = $"RENOVACION ⏳ {cliente.FechaRenovacion:dd/MM/yyyy}";

            if (cliente.Foto != null)
            {
                using (var ms = new MemoryStream(cliente.Foto))
                {
                    picFoto.Image = Image.FromStream(ms);
                }
            }
        }

        private void btnRenovar_Click(object sender, EventArgs e)
        {
            RenovarCliente x = new RenovarCliente(client,usuario);
            x.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            clienteDAO.Desactivar(client.IdCliente);
            MessageBox.Show("Cliente desactivado");
        }
    }

}
