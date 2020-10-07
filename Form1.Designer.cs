namespace AnalizadorLexico
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxAnalisis = new System.Windows.Forms.TextBox();
            this.buttonAnalizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewLexico = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLexico)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxAnalisis
            // 
            this.textBoxAnalisis.Location = new System.Drawing.Point(25, 45);
            this.textBoxAnalisis.Name = "textBoxAnalisis";
            this.textBoxAnalisis.Size = new System.Drawing.Size(521, 20);
            this.textBoxAnalisis.TabIndex = 0;
            // 
            // buttonAnalizar
            // 
            this.buttonAnalizar.Location = new System.Drawing.Point(471, 94);
            this.buttonAnalizar.Name = "buttonAnalizar";
            this.buttonAnalizar.Size = new System.Drawing.Size(75, 23);
            this.buttonAnalizar.TabIndex = 1;
            this.buttonAnalizar.Text = "Analizar";
            this.buttonAnalizar.UseVisualStyleBackColor = true;
            this.buttonAnalizar.Click += new System.EventHandler(this.buttonAnalizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cadena a analizar";
            // 
            // dataGridViewLexico
            // 
            this.dataGridViewLexico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLexico.Location = new System.Drawing.Point(25, 80);
            this.dataGridViewLexico.Name = "dataGridViewLexico";
            this.dataGridViewLexico.Size = new System.Drawing.Size(431, 284);
            this.dataGridViewLexico.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 376);
            this.Controls.Add(this.dataGridViewLexico);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAnalizar);
            this.Controls.Add(this.textBoxAnalisis);
            this.Name = "Form1";
            this.Text = "Analizador Lexico";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLexico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAnalisis;
        private System.Windows.Forms.Button buttonAnalizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewLexico;
    }
}

