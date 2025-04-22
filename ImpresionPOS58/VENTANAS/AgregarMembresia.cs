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
using ImpresionPOS58.OBJETOS;
using ImpresionPOS58.DAOs;

namespace ImpresionPOS58.VENTANAS
{
    public partial class AgregarMembresia : MaterialSkin.Controls.MaterialForm
    {
        public AgregarMembresia()
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
        

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if(materialTextBox1.Text!="" && materialMultiLineTextBox21.Text!="" )
            {
                Membresia a = new Membresia();
                a.Nombre = materialTextBox1.Text;
                a.Descripcion = materialMultiLineTextBox21.Text;
                a.Precio = materialSlider1.Value;
                MembresiaDAO x = new MembresiaDAO();
                x.Insertar(a);
                MessageBox.Show("AGREGADO CON EXITO");
                this.Close();
            }
        }
    }
}
