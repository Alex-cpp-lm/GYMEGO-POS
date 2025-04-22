namespace ImpresionPOS58
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnInventario = new MaterialSkin.Controls.MaterialButton();
            btnContabilidad = new MaterialSkin.Controls.MaterialButton();
            btnMembresias = new MaterialSkin.Controls.MaterialButton();
            materialButton5 = new MaterialSkin.Controls.MaterialButton();
            lbltotal = new Label();
            txtBuscador = new MaterialSkin.Controls.MaterialTextBox();
            materialButton6 = new MaterialSkin.Controls.MaterialButton();
            flowLayoutPanel3 = new FlowLayoutPanel();
            timer1 = new System.Windows.Forms.Timer(components);
            materialSwitch1 = new MaterialSkin.Controls.MaterialSwitch();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.FromArgb(30, 30, 30);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(6, 81);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(505, 379);
            flowLayoutPanel1.TabIndex = 12;
            flowLayoutPanel1.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Location = new Point(6, 379);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(640, 100);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // btnInventario
            // 
            btnInventario.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnInventario.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnInventario.Depth = 0;
            btnInventario.HighEmphasis = true;
            btnInventario.Icon = null;
            btnInventario.Location = new Point(156, 14);
            btnInventario.Margin = new Padding(4, 6, 4, 6);
            btnInventario.MouseState = MaterialSkin.MouseState.HOVER;
            btnInventario.Name = "btnInventario";
            btnInventario.NoAccentTextColor = Color.Empty;
            btnInventario.Size = new Size(107, 36);
            btnInventario.TabIndex = 2;
            btnInventario.Text = "INVENTARIO";
            btnInventario.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnInventario.UseAccentColor = false;
            btnInventario.UseVisualStyleBackColor = true;
            btnInventario.Click += btnInventario_Click;
            // 
            // btnContabilidad
            // 
            btnContabilidad.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnContabilidad.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnContabilidad.Depth = 0;
            btnContabilidad.HighEmphasis = true;
            btnContabilidad.Icon = null;
            btnContabilidad.Location = new Point(319, 14);
            btnContabilidad.Margin = new Padding(4, 6, 4, 6);
            btnContabilidad.MouseState = MaterialSkin.MouseState.HOVER;
            btnContabilidad.Name = "btnContabilidad";
            btnContabilidad.NoAccentTextColor = Color.Empty;
            btnContabilidad.Size = new Size(125, 36);
            btnContabilidad.TabIndex = 3;
            btnContabilidad.Text = "CONTABILIDAD";
            btnContabilidad.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnContabilidad.UseAccentColor = false;
            btnContabilidad.UseVisualStyleBackColor = true;
            // 
            // btnMembresias
            // 
            btnMembresias.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMembresias.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMembresias.Depth = 0;
            btnMembresias.HighEmphasis = true;
            btnMembresias.Icon = null;
            btnMembresias.Location = new Point(7, 14);
            btnMembresias.Margin = new Padding(4, 6, 4, 6);
            btnMembresias.MouseState = MaterialSkin.MouseState.HOVER;
            btnMembresias.Name = "btnMembresias";
            btnMembresias.NoAccentTextColor = Color.Empty;
            btnMembresias.Size = new Size(114, 36);
            btnMembresias.TabIndex = 4;
            btnMembresias.Text = "MEMBRESIAS";
            btnMembresias.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnMembresias.UseAccentColor = false;
            btnMembresias.UseVisualStyleBackColor = true;
            btnMembresias.Click += btnMembresias_Click;
            // 
            // materialButton5
            // 
            materialButton5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton5.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton5.Depth = 0;
            materialButton5.HighEmphasis = true;
            materialButton5.Icon = null;
            materialButton5.Location = new Point(823, 421);
            materialButton5.Margin = new Padding(4, 6, 4, 6);
            materialButton5.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton5.Name = "materialButton5";
            materialButton5.NoAccentTextColor = Color.Empty;
            materialButton5.Size = new Size(139, 36);
            materialButton5.TabIndex = 5;
            materialButton5.Text = "REALIZAR VENTA";
            materialButton5.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton5.UseAccentColor = false;
            materialButton5.UseVisualStyleBackColor = true;
            materialButton5.Click += materialButton5_Click;
            // 
            // lbltotal
            // 
            lbltotal.BackColor = Color.Transparent;
            lbltotal.Font = new Font("Duldolar", 20.2499962F, FontStyle.Bold);
            lbltotal.ForeColor = SystemColors.Control;
            lbltotal.Location = new Point(-3, 20);
            lbltotal.Name = "lbltotal";
            lbltotal.Size = new Size(299, 45);
            lbltotal.TabIndex = 6;
            lbltotal.Text = "TOTAL: $10000.00";
            // 
            // txtBuscador
            // 
            txtBuscador.AnimateReadOnly = false;
            txtBuscador.BorderStyle = BorderStyle.None;
            txtBuscador.Depth = 0;
            txtBuscador.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBuscador.LeadingIcon = null;
            txtBuscador.Location = new Point(554, 81);
            txtBuscador.MaxLength = 50;
            txtBuscador.MouseState = MaterialSkin.MouseState.OUT;
            txtBuscador.Multiline = false;
            txtBuscador.Name = "txtBuscador";
            txtBuscador.Size = new Size(313, 50);
            txtBuscador.TabIndex = 7;
            txtBuscador.Text = "";
            txtBuscador.TrailingIcon = null;
            txtBuscador.TextChanged += txtBuscador_TextChanged;
            // 
            // materialButton6
            // 
            materialButton6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton6.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton6.Depth = 0;
            materialButton6.HighEmphasis = true;
            materialButton6.Icon = null;
            materialButton6.Location = new Point(874, 81);
            materialButton6.Margin = new Padding(4, 6, 4, 6);
            materialButton6.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton6.Name = "materialButton6";
            materialButton6.NoAccentTextColor = Color.Empty;
            materialButton6.Size = new Size(64, 36);
            materialButton6.TabIndex = 8;
            materialButton6.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton6.UseAccentColor = false;
            materialButton6.UseVisualStyleBackColor = true;
            materialButton6.Click += materialButton6_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoScroll = true;
            flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel3.Location = new Point(554, 134);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(384, 253);
            flowLayoutPanel3.TabIndex = 1;
            flowLayoutPanel3.WrapContents = false;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // materialSwitch1
            // 
            materialSwitch1.AutoSize = true;
            materialSwitch1.Depth = 0;
            materialSwitch1.Location = new Point(780, 466);
            materialSwitch1.Margin = new Padding(0);
            materialSwitch1.MouseLocation = new Point(-1, -1);
            materialSwitch1.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch1.Name = "materialSwitch1";
            materialSwitch1.Ripple = true;
            materialSwitch1.Size = new Size(58, 37);
            materialSwitch1.TabIndex = 9;
            materialSwitch1.UseVisualStyleBackColor = true;
            materialSwitch1.CheckedChanged += materialSwitch1_CheckedChanged;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(678, 475);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(73, 19);
            materialLabel1.TabIndex = 10;
            materialLabel1.Text = "EFECTIVO";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(869, 475);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(69, 19);
            materialLabel2.TabIndex = 11;
            materialLabel2.Text = "TARJETA";
            // 
            // panel1
            // 
            panel1.Controls.Add(lbltotal);
            panel1.Location = new Point(517, 397);
            panel1.Name = "panel1";
            panel1.Size = new Size(299, 75);
            panel1.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 519);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Controls.Add(materialSwitch1);
            Controls.Add(flowLayoutPanel3);
            Controls.Add(materialButton6);
            Controls.Add(txtBuscador);
            Controls.Add(materialButton5);
            Controls.Add(btnMembresias);
            Controls.Add(btnContabilidad);
            Controls.Add(btnInventario);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            Text = "MENU PRINCIPAL";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load_2;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private MaterialSkin.Controls.MaterialButton btnInventario;
        private MaterialSkin.Controls.MaterialButton btnContabilidad;
        private MaterialSkin.Controls.MaterialButton btnMembresias;
        private MaterialSkin.Controls.MaterialButton materialButton5;
        private Label lbltotal;
        private MaterialSkin.Controls.MaterialTextBox txtBuscador;
        private MaterialSkin.Controls.MaterialButton materialButton6;
        private FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Timer timer1;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.Timer buscadorTimer;
        private Panel panel1;
    }
}