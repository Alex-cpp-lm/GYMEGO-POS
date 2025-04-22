namespace ImpresionPOS58.VENTANAS
{
    partial class Producto2Card
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            picFoto = new PictureBox();
            lblNombre = new Label();
            lblDescripcion = new Label();
            lblPrecio = new Label();
            lblCantidad = new Label();
            lblPrecioReal = new Label();
            btnModificar = new Button();
            label1 = new Label();
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
            lblNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombre.Location = new Point(120, 10);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(200, 23);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "NOMBRE";
            // 
            // lblDescripcion
            // 
            lblDescripcion.Font = new Font("Segoe UI", 9F);
            lblDescripcion.Location = new Point(120, 35);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(200, 40);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "DESCRIPCION";
            // 
            // lblPrecio
            // 
            lblPrecio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrecio.ForeColor = Color.Green;
            lblPrecio.Location = new Point(120, 75);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(100, 20);
            lblPrecio.TabIndex = 3;
            lblPrecio.Text = "$0.00";
            // 
            // lblCantidad
            // 
            lblCantidad.Font = new Font("Segoe UI", 8F);
            lblCantidad.ForeColor = Color.White;
            lblCantidad.Location = new Point(120, 95);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(200, 20);
            lblCantidad.TabIndex = 4;
            lblCantidad.Text = "CANTIDAD";
            // 
            // lblPrecioReal
            // 
            lblPrecioReal.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblPrecioReal.ForeColor = Color.DarkRed;
            lblPrecioReal.Location = new Point(226, 75);
            lblPrecioReal.Name = "lblPrecioReal";
            lblPrecioReal.Size = new Size(100, 20);
            lblPrecioReal.TabIndex = 5;
            lblPrecioReal.Text = "REAL: $0.00";
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.RoyalBlue;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnModificar.Location = new Point(314, 98);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(90, 23);
            btnModificar.TabIndex = 6;
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(120, 115);
            label1.Name = "label1";
            label1.Size = new Size(200, 23);
            label1.TabIndex = 7;
            label1.Text = "NOMBRE";
            // 
            // Producto2Card
            // 
            BackColor = Color.Black;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(label1);
            Controls.Add(btnModificar);
            Controls.Add(lblPrecioReal);
            Controls.Add(lblCantidad);
            Controls.Add(lblPrecio);
            Controls.Add(lblDescripcion);
            Controls.Add(lblNombre);
            Controls.Add(picFoto);
            Name = "Producto2Card";
            Size = new Size(418, 148);
            ((System.ComponentModel.ISupportInitialize)picFoto).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblPrecioReal;
        private System.Windows.Forms.Button btnModificar;
        private Label label1;
    }
}
