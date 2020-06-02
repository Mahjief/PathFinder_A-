namespace PathFinder
{
    partial class AsignarTipo
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
            this.btn_camino = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_pared = new System.Windows.Forms.Button();
            this.btn_inicio = new System.Windows.Forms.Button();
            this.btn_fin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_camino
            // 
            this.btn_camino.Location = new System.Drawing.Point(28, 28);
            this.btn_camino.Name = "btn_camino";
            this.btn_camino.Size = new System.Drawing.Size(50, 50);
            this.btn_camino.TabIndex = 0;
            this.btn_camino.Tag = "camino";
            this.btn_camino.Text = "Camino";
            this.btn_camino.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(84, 115);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_pared
            // 
            this.btn_pared.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_pared.Location = new System.Drawing.Point(84, 28);
            this.btn_pared.Name = "btn_pared";
            this.btn_pared.Size = new System.Drawing.Size(50, 50);
            this.btn_pared.TabIndex = 4;
            this.btn_pared.Tag = "pared";
            this.btn_pared.Text = "Pared";
            this.btn_pared.UseVisualStyleBackColor = false;
            // 
            // btn_inicio
            // 
            this.btn_inicio.BackColor = System.Drawing.Color.Blue;
            this.btn_inicio.Location = new System.Drawing.Point(140, 28);
            this.btn_inicio.Name = "btn_inicio";
            this.btn_inicio.Size = new System.Drawing.Size(50, 50);
            this.btn_inicio.TabIndex = 5;
            this.btn_inicio.Tag = "inicio";
            this.btn_inicio.Text = "Inicio";
            this.btn_inicio.UseVisualStyleBackColor = false;
            // 
            // btn_fin
            // 
            this.btn_fin.BackColor = System.Drawing.Color.Red;
            this.btn_fin.Location = new System.Drawing.Point(196, 28);
            this.btn_fin.Name = "btn_fin";
            this.btn_fin.Size = new System.Drawing.Size(50, 50);
            this.btn_fin.TabIndex = 6;
            this.btn_fin.Tag = "fin";
            this.btn_fin.Text = "Fin";
            this.btn_fin.UseVisualStyleBackColor = false;
            // 
            // AsignarTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(281, 166);
            this.Controls.Add(this.btn_fin);
            this.Controls.Add(this.btn_inicio);
            this.Controls.Add(this.btn_pared);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_camino);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AsignarTipo";
            this.Padding = new System.Windows.Forms.Padding(25);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AsignarTipo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_camino;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_pared;
        private System.Windows.Forms.Button btn_inicio;
        private System.Windows.Forms.Button btn_fin;
    }
}