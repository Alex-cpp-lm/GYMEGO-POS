namespace ImpresionPOS58.VENTANAS
{
    partial class ClienteCard
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblActivo;
        private System.Windows.Forms.Label lblMembresia;
        private System.Windows.Forms.Label lblFechaRenovacion;
        private void InitializeComponent()
        {
            picFoto = new PictureBox();
            lblNombre = new Label();
            lblDireccion = new Label();
            lblCelular = new Label();
            lblCorreo = new Label();
            lblActivo = new Label();
            lblMembresia = new Label();
            lblFechaRenovacion = new Label();
            btnRenovar = new MaterialSkin.Controls.MaterialButton();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)picFoto).BeginInit();
            SuspendLayout();
            // 
            // picFoto
            // 
            picFoto.Location = new Point(10, 10);
            picFoto.Name = "picFoto";
            picFoto.Size = new Size(100, 100);
            picFoto.SizeMode = PictureBoxSizeMode.Zoom;
            picFoto.TabIndex = 0;
            picFoto.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(120, 10);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(300, 20);
            lblNombre.TabIndex = 1;
            // 
            // lblDireccion
            // 
            lblDireccion.Location = new Point(120, 35);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(300, 20);
            lblDireccion.TabIndex = 2;
            // 
            // lblCelular
            // 
            lblCelular.Location = new Point(120, 60);
            lblCelular.Name = "lblCelular";
            lblCelular.Size = new Size(300, 20);
            lblCelular.TabIndex = 3;
            // 
            // lblCorreo
            // 
            lblCorreo.Location = new Point(120, 85);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(371, 20);
            lblCorreo.TabIndex = 4;
            // 
            // lblActivo
            // 
            lblActivo.Location = new Point(120, 110);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(300, 20);
            lblActivo.TabIndex = 5;
            // 
            // lblMembresia
            // 
            lblMembresia.Location = new Point(120, 135);
            lblMembresia.Name = "lblMembresia";
            lblMembresia.Size = new Size(300, 20);
            lblMembresia.TabIndex = 6;
            // 
            // lblFechaRenovacion
            // 
            lblFechaRenovacion.Location = new Point(120, 160);
            lblFechaRenovacion.Name = "lblFechaRenovacion";
            lblFechaRenovacion.Size = new Size(300, 20);
            lblFechaRenovacion.TabIndex = 7;
            // 
            // btnRenovar
            // 
            btnRenovar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRenovar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRenovar.Depth = 0;
            btnRenovar.HighEmphasis = true;
            btnRenovar.Icon = null;
            btnRenovar.Location = new Point(455, 49);
            btnRenovar.Margin = new Padding(4, 6, 4, 6);
            btnRenovar.MouseState = MaterialSkin.MouseState.HOVER;
            btnRenovar.Name = "btnRenovar";
            btnRenovar.NoAccentTextColor = Color.Empty;
            btnRenovar.Size = new Size(88, 36);
            btnRenovar.TabIndex = 8;
            btnRenovar.Text = "Renovar";
            btnRenovar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRenovar.UseAccentColor = false;
            btnRenovar.UseVisualStyleBackColor = true;
            btnRenovar.Click += btnRenovar_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(455, 110);
            button1.Name = "button1";
            button1.Size = new Size(88, 45);
            button1.TabIndex = 9;
            button1.Text = "DESACTIVAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ClienteCard
            // 
            Controls.Add(button1);
            Controls.Add(btnRenovar);
            Controls.Add(picFoto);
            Controls.Add(lblNombre);
            Controls.Add(lblDireccion);
            Controls.Add(lblCelular);
            Controls.Add(lblCorreo);
            Controls.Add(lblActivo);
            Controls.Add(lblMembresia);
            Controls.Add(lblFechaRenovacion);
            Name = "ClienteCard";
            Size = new Size(562, 200);
            ((System.ComponentModel.ISupportInitialize)picFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnRenovar;
        private Button button1;
    }
}
