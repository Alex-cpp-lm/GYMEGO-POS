using MaterialSkin.Controls;

namespace ImpresionPOS58.VENTANAS
{
    partial class AgregarCliente
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
            materialTextBox1 = new MaterialTextBox();
            materialTextBox2 = new MaterialTextBox();
            materialTextBox3 = new MaterialTextBox();
            materialTextBox4 = new MaterialTextBox();
            materialTextBox5 = new MaterialTextBox();
            pictureBoxFoto = new PictureBox();
            materialButton1 = new MaterialButton();
            materialComboBox1 = new MaterialComboBox();
            materialButton2 = new MaterialButton();
            materialSwitch1 = new MaterialSwitch();
            materialLabel1 = new MaterialLabel();
            materialLabel2 = new MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).BeginInit();
            SuspendLayout();
            // 
            // materialTextBox1
            // 
            materialTextBox1.AnimateReadOnly = false;
            materialTextBox1.BorderStyle = BorderStyle.None;
            materialTextBox1.Depth = 0;
            materialTextBox1.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox1.Hint = "NOMBRE";
            materialTextBox1.LeadingIcon = null;
            materialTextBox1.Location = new Point(38, 104);
            materialTextBox1.MaxLength = 50;
            materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox1.Multiline = false;
            materialTextBox1.Name = "materialTextBox1";
            materialTextBox1.Size = new Size(173, 50);
            materialTextBox1.TabIndex = 0;
            materialTextBox1.Text = "";
            materialTextBox1.TrailingIcon = null;
            // 
            // materialTextBox2
            // 
            materialTextBox2.AnimateReadOnly = false;
            materialTextBox2.BorderStyle = BorderStyle.None;
            materialTextBox2.Depth = 0;
            materialTextBox2.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox2.Hint = "APELLIDOS";
            materialTextBox2.LeadingIcon = null;
            materialTextBox2.Location = new Point(259, 104);
            materialTextBox2.MaxLength = 50;
            materialTextBox2.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox2.Multiline = false;
            materialTextBox2.Name = "materialTextBox2";
            materialTextBox2.Size = new Size(173, 50);
            materialTextBox2.TabIndex = 1;
            materialTextBox2.Text = "";
            materialTextBox2.TrailingIcon = null;
            // 
            // materialTextBox3
            // 
            materialTextBox3.AnimateReadOnly = false;
            materialTextBox3.BorderStyle = BorderStyle.None;
            materialTextBox3.Depth = 0;
            materialTextBox3.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox3.Hint = "DIRECCIÓN";
            materialTextBox3.LeadingIcon = null;
            materialTextBox3.Location = new Point(38, 195);
            materialTextBox3.MaxLength = 50;
            materialTextBox3.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox3.Multiline = false;
            materialTextBox3.Name = "materialTextBox3";
            materialTextBox3.Size = new Size(173, 50);
            materialTextBox3.TabIndex = 2;
            materialTextBox3.Text = "";
            materialTextBox3.TrailingIcon = null;
            // 
            // materialTextBox4
            // 
            materialTextBox4.AnimateReadOnly = false;
            materialTextBox4.BorderStyle = BorderStyle.None;
            materialTextBox4.Depth = 0;
            materialTextBox4.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox4.Hint = "NUMERO DE CELULAR";
            materialTextBox4.LeadingIcon = null;
            materialTextBox4.Location = new Point(259, 195);
            materialTextBox4.MaxLength = 50;
            materialTextBox4.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox4.Multiline = false;
            materialTextBox4.Name = "materialTextBox4";
            materialTextBox4.Size = new Size(173, 50);
            materialTextBox4.TabIndex = 3;
            materialTextBox4.Text = "";
            materialTextBox4.TrailingIcon = null;
            // 
            // materialTextBox5
            // 
            materialTextBox5.AnimateReadOnly = false;
            materialTextBox5.BorderStyle = BorderStyle.None;
            materialTextBox5.Depth = 0;
            materialTextBox5.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox5.Hint = "CORREO";
            materialTextBox5.LeadingIcon = null;
            materialTextBox5.Location = new Point(38, 287);
            materialTextBox5.MaxLength = 50;
            materialTextBox5.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox5.Multiline = false;
            materialTextBox5.Name = "materialTextBox5";
            materialTextBox5.Size = new Size(173, 50);
            materialTextBox5.TabIndex = 4;
            materialTextBox5.Text = "";
            materialTextBox5.TrailingIcon = null;
            // 
            // pictureBoxFoto
            // 
            pictureBoxFoto.Image = Properties.Resources.Captura_de_pantalla_2025_04_13_043149;
            pictureBoxFoto.Location = new Point(302, 253);
            pictureBoxFoto.Name = "pictureBoxFoto";
            pictureBoxFoto.Size = new Size(89, 84);
            pictureBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxFoto.TabIndex = 5;
            pictureBoxFoto.TabStop = false;
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(289, 346);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(120, 36);
            materialButton1.TabIndex = 6;
            materialButton1.Text = "CARGAR FOTO";
            materialButton1.Type = MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // materialComboBox1
            // 
            materialComboBox1.AutoResize = false;
            materialComboBox1.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox1.Depth = 0;
            materialComboBox1.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox1.DropDownHeight = 174;
            materialComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox1.DropDownWidth = 121;
            materialComboBox1.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox1.FormattingEnabled = true;
            materialComboBox1.Hint = "MEMBRESIA";
            materialComboBox1.IntegralHeight = false;
            materialComboBox1.ItemHeight = 43;
            materialComboBox1.Location = new Point(38, 405);
            materialComboBox1.MaxDropDownItems = 4;
            materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox1.Name = "materialComboBox1";
            materialComboBox1.Size = new Size(371, 49);
            materialComboBox1.StartIndex = 0;
            materialComboBox1.TabIndex = 7;
            // 
            // materialButton2
            // 
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(289, 475);
            materialButton2.Margin = new Padding(4, 6, 4, 6);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(88, 36);
            materialButton2.TabIndex = 8;
            materialButton2.Text = "AGREGAR";
            materialButton2.Type = MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            materialButton2.Click += materialButton2_Click;
            // 
            // materialSwitch1
            // 
            materialSwitch1.AutoSize = true;
            materialSwitch1.Depth = 0;
            materialSwitch1.Location = new Point(110, 474);
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
            materialLabel1.Location = new Point(23, 483);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(58, 19);
            materialLabel1.TabIndex = 10;
            materialLabel1.Text = "Efectivo";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(191, 483);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(51, 19);
            materialLabel2.TabIndex = 11;
            materialLabel2.Text = "Tarjeta";
            // 
            // AgregarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 556);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Controls.Add(materialSwitch1);
            Controls.Add(materialButton2);
            Controls.Add(materialComboBox1);
            Controls.Add(materialButton1);
            Controls.Add(pictureBoxFoto);
            Controls.Add(materialTextBox5);
            Controls.Add(materialTextBox4);
            Controls.Add(materialTextBox3);
            Controls.Add(materialTextBox2);
            Controls.Add(materialTextBox1);
            Name = "AgregarCliente";
            Text = "AgregarCliente";
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox materialTextBox1;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox2;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox3;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox4;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox5;
        private PictureBox pictureBoxFoto;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSwitch materialSwitch1;
        private MaterialLabel materialLabel1;
        private MaterialLabel materialLabel2;
    }
}