
namespace ImpresionPOS58
{
    partial class pos
    {
        /// <summary>
        /// Variable de diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar cualquier recurso que esté en uso.
        /// </summary>
        /// <param name="disposing">Indica si los recursos administrados deben eliminarse; de lo contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el diseño de Windows Forms.
        /// No se debe modificar el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            btnImprimir = new Button();
            btnEfectivo = new Button();
            pnlVender = new Panel();
            txtInfo1 = new Label();
            txtMetodo = new Label();
            btnTarjeta = new Button();
            txtBuscador = new TextBox();
            imgBuscador = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            textBox1 = new TextBox();
            pnlVender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgBuscador).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = SystemColors.MenuHighlight;
            btnImprimir.Cursor = Cursors.Hand;
            btnImprimir.FlatStyle = FlatStyle.Popup;
            btnImprimir.Font = new Font("NFL Minnesota Vikings", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImprimir.Location = new Point(41, 139);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(275, 74);
            btnImprimir.TabIndex = 0;
            btnImprimir.Text = "VENDER (F1)";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            btnImprimir.KeyUp += btnImprimir_KeyUp;
            // 
            // btnEfectivo
            // 
            btnEfectivo.Cursor = Cursors.Hand;
            btnEfectivo.Font = new Font("Acherus Grotesque Black", 11.9999981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnEfectivo.ForeColor = SystemColors.WindowText;
            btnEfectivo.Location = new Point(41, 72);
            btnEfectivo.Name = "btnEfectivo";
            btnEfectivo.Size = new Size(122, 61);
            btnEfectivo.TabIndex = 1;
            btnEfectivo.Text = "EFECTIVO";
            btnEfectivo.UseVisualStyleBackColor = true;
            btnEfectivo.Click += btnEfectivo_Click;
            // 
            // pnlVender
            // 
            pnlVender.BackColor = Color.FromArgb(208, 235, 254);
            pnlVender.BorderStyle = BorderStyle.FixedSingle;
            pnlVender.Controls.Add(txtInfo1);
            pnlVender.Controls.Add(txtMetodo);
            pnlVender.Controls.Add(btnTarjeta);
            pnlVender.Controls.Add(btnImprimir);
            pnlVender.Controls.Add(btnEfectivo);
            pnlVender.Location = new Point(1506, 791);
            pnlVender.Name = "pnlVender";
            pnlVender.Size = new Size(367, 233);
            pnlVender.TabIndex = 3;
            // 
            // txtInfo1
            // 
            txtInfo1.AutoSize = true;
            txtInfo1.Font = new Font("Acherus Grotesque Black", 8.999998F, FontStyle.Bold | FontStyle.Italic);
            txtInfo1.ForeColor = SystemColors.GrayText;
            txtInfo1.Location = new Point(74, 46);
            txtInfo1.Name = "txtInfo1";
            txtInfo1.Size = new Size(204, 20);
            txtInfo1.TabIndex = 5;
            txtInfo1.Text = "PUEDES ELEGIR OTRO METODO";
            // 
            // txtMetodo
            // 
            txtMetodo.AutoSize = true;
            txtMetodo.Font = new Font("Acherus Grotesque Black", 11.9999981F, FontStyle.Bold | FontStyle.Italic);
            txtMetodo.Location = new Point(41, 21);
            txtMetodo.Name = "txtMetodo";
            txtMetodo.Size = new Size(267, 25);
            txtMetodo.TabIndex = 4;
            txtMetodo.Text = "EL PAGO SE HARÁ EN EFECTIVO";
            // 
            // btnTarjeta
            // 
            btnTarjeta.Cursor = Cursors.Hand;
            btnTarjeta.Font = new Font("Acherus Grotesque Black", 11.9999981F, FontStyle.Bold | FontStyle.Italic);
            btnTarjeta.ForeColor = SystemColors.WindowText;
            btnTarjeta.Location = new Point(194, 72);
            btnTarjeta.Name = "btnTarjeta";
            btnTarjeta.Size = new Size(122, 61);
            btnTarjeta.TabIndex = 4;
            btnTarjeta.Text = "TARJETA";
            btnTarjeta.UseVisualStyleBackColor = true;
            btnTarjeta.Click += btnTarjeta_Click;
            // 
            // txtBuscador
            // 
            txtBuscador.Font = new Font("Acherus Grotesque Black", 11.9999981F, FontStyle.Bold | FontStyle.Italic);
            txtBuscador.Location = new Point(1529, 319);
            txtBuscador.Name = "txtBuscador";
            txtBuscador.Size = new Size(280, 42);
            txtBuscador.TabIndex = 4;
            txtBuscador.KeyUp += textBox1_KeyUp;
            // 
            // imgBuscador
            // 
            imgBuscador.Image = Properties.Resources.buscar;
            imgBuscador.Location = new Point(1805, 319);
            imgBuscador.Name = "imgBuscador";
            imgBuscador.Size = new Size(50, 42);
            imgBuscador.SizeMode = PictureBoxSizeMode.StretchImage;
            imgBuscador.TabIndex = 5;
            imgBuscador.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(pictureBox5);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(1529, 128);
            panel1.Name = "panel1";
            panel1.Size = new Size(328, 178);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Location = new Point(700, 11);
            panel2.Name = "panel2";
            panel2.Size = new Size(328, 178);
            panel2.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Highlight;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(pictureBox4);
            panel3.Location = new Point(-842, -66);
            panel3.Name = "panel3";
            panel3.Size = new Size(2012, 74);
            panel3.TabIndex = 10;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.cerrar;
            pictureBox3.Location = new Point(1807, 8);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(50, 56);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.salir;
            pictureBox4.Location = new Point(1741, 15);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(35, 41);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 7;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.buscar;
            pictureBox5.Location = new Point(976, 202);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(50, 42);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 9;
            pictureBox5.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Acherus Grotesque Black", 11.9999981F, FontStyle.Bold | FontStyle.Italic);
            textBox1.Location = new Point(700, 202);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(280, 42);
            textBox1.TabIndex = 8;
            // 
            // pos
            // 
            AutoSize = true;
            ClientSize = new Size(1386, 788);
            Controls.Add(panel1);
            Controls.Add(imgBuscador);
            Controls.Add(txtBuscador);
            Controls.Add(pnlVender);
            FormBorderStyle = FormBorderStyle.None;
            Name = "pos";
            Text = "TERMINAL";
            WindowState = FormWindowState.Maximized;
            Load += pos_Load;
            pnlVender.ResumeLayout(false);
            pnlVender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgBuscador).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private Button btnEfectivo;
        private Panel pnlVender;
        private Button btnTarjeta;
        private Label txtMetodo;
        private Label txtInfo1;
        private TextBox txtBuscador;
        private PictureBox imgBuscador;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private TextBox textBox1;
    }
}
