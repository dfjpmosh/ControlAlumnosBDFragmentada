namespace CDA_CDI
{
    partial class CComentarioA
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
            this.tbCA = new System.Windows.Forms.TextBox();
            this.btnACA = new System.Windows.Forms.Button();
            this.btnCCA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbCA
            // 
            this.tbCA.Location = new System.Drawing.Point(12, 12);
            this.tbCA.Multiline = true;
            this.tbCA.Name = "tbCA";
            this.tbCA.Size = new System.Drawing.Size(296, 91);
            this.tbCA.TabIndex = 0;
            // 
            // btnACA
            // 
            this.btnACA.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnACA.Location = new System.Drawing.Point(233, 118);
            this.btnACA.Name = "btnACA";
            this.btnACA.Size = new System.Drawing.Size(75, 23);
            this.btnACA.TabIndex = 1;
            this.btnACA.Text = "Aceptar";
            this.btnACA.UseVisualStyleBackColor = true;
            // 
            // btnCCA
            // 
            this.btnCCA.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCCA.Location = new System.Drawing.Point(12, 118);
            this.btnCCA.Name = "btnCCA";
            this.btnCCA.Size = new System.Drawing.Size(75, 23);
            this.btnCCA.TabIndex = 2;
            this.btnCCA.Text = "Cancelar";
            this.btnCCA.UseVisualStyleBackColor = true;
            // 
            // CComentarioA
            // 
            this.AcceptButton = this.btnACA;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCCA;
            this.ClientSize = new System.Drawing.Size(320, 153);
            this.Controls.Add(this.btnCCA);
            this.Controls.Add(this.btnACA);
            this.Controls.Add(this.tbCA);
            this.Name = "CComentarioA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comentarios Asistencia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbCA;
        private System.Windows.Forms.Button btnACA;
        private System.Windows.Forms.Button btnCCA;
    }
}