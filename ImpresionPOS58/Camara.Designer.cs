using MaterialSkin.Controls;

namespace ImpresionPOS58
{
    partial class Camara
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
            pictureBoxFoto = new PictureBox();
            btnCapturar = new MaterialButton();
            btnCargarDesdeArchivo = new MaterialButton();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxFoto
            // 
            pictureBoxFoto.Location = new Point(21, 67);
            pictureBoxFoto.Name = "pictureBoxFoto";
            pictureBoxFoto.Size = new Size(276, 257);
            pictureBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxFoto.TabIndex = 0;
            pictureBoxFoto.TabStop = false;
            // 
            // btnCapturar
            // 
            btnCapturar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCapturar.Density = MaterialButton.MaterialButtonDensity.Default;
            btnCapturar.Depth = 0;
            btnCapturar.HighEmphasis = true;
            btnCapturar.Icon = null;
            btnCapturar.Location = new Point(30, 329);
            btnCapturar.Margin = new Padding(4, 6, 4, 6);
            btnCapturar.MouseState = MaterialSkin.MouseState.HOVER;
            btnCapturar.Name = "btnCapturar";
            btnCapturar.NoAccentTextColor = Color.Empty;
            btnCapturar.Size = new Size(96, 36);
            btnCapturar.TabIndex = 2;
            btnCapturar.Text = "Capturar";
            btnCapturar.Type = MaterialButton.MaterialButtonType.Contained;
            btnCapturar.UseAccentColor = false;
            btnCapturar.UseVisualStyleBackColor = true;
            btnCapturar.Click += BtnCapturar_Click;
            // 
            // btnCargarDesdeArchivo
            // 
            btnCargarDesdeArchivo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCargarDesdeArchivo.Density = MaterialButton.MaterialButtonDensity.Default;
            btnCargarDesdeArchivo.Depth = 0;
            btnCargarDesdeArchivo.HighEmphasis = true;
            btnCargarDesdeArchivo.Icon = null;
            btnCargarDesdeArchivo.Location = new Point(196, 329);
            btnCargarDesdeArchivo.Margin = new Padding(4, 6, 4, 6);
            btnCargarDesdeArchivo.MouseState = MaterialSkin.MouseState.HOVER;
            btnCargarDesdeArchivo.Name = "btnCargarDesdeArchivo";
            btnCargarDesdeArchivo.NoAccentTextColor = Color.Empty;
            btnCargarDesdeArchivo.Size = new Size(77, 36);
            btnCargarDesdeArchivo.TabIndex = 3;
            btnCargarDesdeArchivo.Text = "Buscar";
            btnCargarDesdeArchivo.Type = MaterialButton.MaterialButtonType.Contained;
            btnCargarDesdeArchivo.UseAccentColor = false;
            btnCargarDesdeArchivo.UseVisualStyleBackColor = true;
            btnCargarDesdeArchivo.Click += BtnCargarDesdeArchivo_Click;
            // 
            // Camara
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 401);
            Controls.Add(btnCargarDesdeArchivo);
            Controls.Add(btnCapturar);
            Controls.Add(pictureBoxFoto);
            Name = "Camara";
            Text = "Seleccionar Imagen";
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxFoto;
        private MaterialButton btnCapturar;
        private MaterialButton btnCargarDesdeArchivo;
    }
}