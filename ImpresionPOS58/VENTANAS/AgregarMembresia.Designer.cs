
namespace ImpresionPOS58.VENTANAS
{
    partial class AgregarMembresia
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
            materialTextBox1 = new MaterialSkin.Controls.MaterialTextBox();
            materialMultiLineTextBox21 = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            materialSlider1 = new MaterialSkin.Controls.MaterialSlider();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            materialTextBox2 = new MaterialSkin.Controls.MaterialTextBox();
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
            materialTextBox1.Location = new Point(32, 101);
            materialTextBox1.MaxLength = 50;
            materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox1.Multiline = false;
            materialTextBox1.Name = "materialTextBox1";
            materialTextBox1.Size = new Size(297, 50);
            materialTextBox1.TabIndex = 1;
            materialTextBox1.Text = "";
            materialTextBox1.TrailingIcon = null;
            // 
            // materialMultiLineTextBox21
            // 
            materialMultiLineTextBox21.AnimateReadOnly = false;
            materialMultiLineTextBox21.BackgroundImageLayout = ImageLayout.None;
            materialMultiLineTextBox21.CharacterCasing = CharacterCasing.Normal;
            materialMultiLineTextBox21.Depth = 0;
            materialMultiLineTextBox21.HideSelection = true;
            materialMultiLineTextBox21.Hint = "DESCRIPCION";
            materialMultiLineTextBox21.Location = new Point(32, 171);
            materialMultiLineTextBox21.MaxLength = 32767;
            materialMultiLineTextBox21.MouseState = MaterialSkin.MouseState.OUT;
            materialMultiLineTextBox21.Name = "materialMultiLineTextBox21";
            materialMultiLineTextBox21.PasswordChar = '\0';
            materialMultiLineTextBox21.ReadOnly = false;
            materialMultiLineTextBox21.ScrollBars = ScrollBars.None;
            materialMultiLineTextBox21.SelectedText = "";
            materialMultiLineTextBox21.SelectionLength = 0;
            materialMultiLineTextBox21.SelectionStart = 0;
            materialMultiLineTextBox21.ShortcutsEnabled = true;
            materialMultiLineTextBox21.Size = new Size(297, 100);
            materialMultiLineTextBox21.TabIndex = 2;
            materialMultiLineTextBox21.TabStop = false;
            materialMultiLineTextBox21.TextAlign = HorizontalAlignment.Left;
            materialMultiLineTextBox21.UseSystemPasswordChar = false;
            // 
            // materialSlider1
            // 
            materialSlider1.Depth = 0;
            materialSlider1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialSlider1.Location = new Point(32, 297);
            materialSlider1.MouseState = MaterialSkin.MouseState.HOVER;
            materialSlider1.Name = "materialSlider1";
            materialSlider1.RangeMax = 1000;
            materialSlider1.Size = new Size(297, 40);
            materialSlider1.TabIndex = 3;
            materialSlider1.Text = "PRECIO $";
            materialSlider1.Value = 250;
            materialSlider1.onValueChanged += materialSlider1_onValueChanged;
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(241, 351);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(88, 36);
            materialButton1.TabIndex = 4;
            materialButton1.Text = "AGREGAR";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // materialTextBox2
            // 
            materialTextBox2.AnimateReadOnly = false;
            materialTextBox2.BorderStyle = BorderStyle.None;
            materialTextBox2.Depth = 0;
            materialTextBox2.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox2.Hint = "DURACION (EN DIAS)";
            materialTextBox2.LeadingIcon = null;
            materialTextBox2.Location = new Point(32, 351);
            materialTextBox2.MaxLength = 50;
            materialTextBox2.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox2.Multiline = false;
            materialTextBox2.Name = "materialTextBox2";
            materialTextBox2.Size = new Size(177, 50);
            materialTextBox2.TabIndex = 5;
            materialTextBox2.Text = "";
            materialTextBox2.TrailingIcon = null;
            // 
            // AgregarMembresia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 425);
            Controls.Add(materialTextBox2);
            Controls.Add(materialButton1);
            Controls.Add(materialSlider1);
            Controls.Add(materialMultiLineTextBox21);
            Controls.Add(materialTextBox1);
            Name = "AgregarMembresia";
            Text = "AGREGAR MEMBRESIA";
            ResumeLayout(false);
            PerformLayout();
        }

        private void materialSlider1_onValueChanged(object sender, int newValue)
        {
            int salto = 10;
            materialSlider1.Value = (materialSlider1.Value / salto) * salto;
        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox materialTextBox1;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 materialMultiLineTextBox21;
        private MaterialSkin.Controls.MaterialSlider materialSlider1;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox2;
    }
}