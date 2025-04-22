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
using System.Security.Cryptography;
using MaterialSkin;

namespace ImpresionPOS58
{
    public partial class Login : MaterialSkin.Controls.MaterialForm
    {
        // VARIABLES PARA EL EFECTO DE HOVER EN btnCerrar
        private Size tamañoOriginal;
        private bool mouseEncima = false;
        private UsuarioDAO usuarioDAO = new UsuarioDAO(); // ASEGÚRATE QUE EL DAO ESTÉ BIEN IMPORTADO


        public Login()
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
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void btnCerrar_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            if (!mouseEncima)
            {
                tamañoOriginal = btnCerrar.Size;
                btnCerrar.Size = new Size((int)(tamañoOriginal.Width * 1.1), (int)(tamañoOriginal.Height * 1.1));
                mouseEncima = true;
            }
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            if (mouseEncima)
            {
                btnCerrar.Size = tamañoOriginal;
                mouseEncima = false;
            }
        }
        public static string EncriptarSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte b in hash)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("INGRESA USUARIO Y CONTRASEÑA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Usuario user = usuarioDAO.ObtenerPorCredenciales(usuario, EncriptarSHA256(contraseña));

            if (user != null)
            {
                //MessageBox.Show($"BIENVENIDO {user.Username} 🎉", "ACCESO CONCEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // ABRE TU FORM PRINCIPAL AQUÍ
                // por ejemplo: new MenuPrincipal(user).Show(); this.Hide();
                new Form1(user).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("USUARIO O CONTRASEÑA INCORRECTOS 🚫", "ACCESO DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MostrarDialogoContraseña();
        }
        private void MostrarDialogoContraseña()
        {
            // FORMULARIO PERSONALIZADO
            Form dialogo = new Form();
            dialogo.Width = 300;
            dialogo.Height = 180;
            dialogo.FormBorderStyle = FormBorderStyle.FixedDialog;
            dialogo.StartPosition = FormStartPosition.CenterScreen;
            dialogo.ControlBox = false;

            // ETIQUETA CON TEXTO DE INSTRUCCIÓN
            Label etiqueta = new Label();
            etiqueta.Text = "INGRESA LA PALABRA SECRETA 🔐🦖";
            etiqueta.AutoSize = true;
            etiqueta.Location = new Point(50, 20);
            dialogo.Controls.Add(etiqueta);

            // CAJA DE TEXTO PARA CONTRASEÑA
            TextBox cajaContraseña = new TextBox();
            cajaContraseña.PasswordChar = '*';
            cajaContraseña.Width = 200;
            cajaContraseña.Location = new Point(40, 50);
            dialogo.Controls.Add(cajaContraseña);

            // BOTÓN VALIDAR
            Button botonAceptar = new Button();
            botonAceptar.Text = "VALIDAR ✅";
            botonAceptar.Width = 100;
            botonAceptar.Location = new Point(90, 90);
            botonAceptar.Click += (sender, e) =>
            {
                string contraseñaIngresada = cajaContraseña.Text;
                if (contraseñaIngresada == "DINOSAURIO69")
                {
                    RegistroUsuario a = new RegistroUsuario();
                    a.Show();
                    dialogo.Close();
                }
                else
                {
                    dialogo.Close();
                }
            };
            dialogo.Controls.Add(botonAceptar);
            dialogo.ShowDialog();
        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
