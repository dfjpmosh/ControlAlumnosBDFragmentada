namespace CDA_CDI
{
    partial class FRepMaq
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
            this.lbMaquinaRep = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbReportoRep = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBecarioRep = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDescRep = new System.Windows.Forms.TextBox();
            this.btnAcepRep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMaquinaRep
            // 
            this.lbMaquinaRep.AutoSize = true;
            this.lbMaquinaRep.Location = new System.Drawing.Point(19, 16);
            this.lbMaquinaRep.Name = "lbMaquinaRep";
            this.lbMaquinaRep.Size = new System.Drawing.Size(54, 13);
            this.lbMaquinaRep.TabIndex = 0;
            this.lbMaquinaRep.Text = "Maquina: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reporto";
            // 
            // tbReportoRep
            // 
            this.tbReportoRep.Location = new System.Drawing.Point(80, 40);
            this.tbReportoRep.Name = "tbReportoRep";
            this.tbReportoRep.Size = new System.Drawing.Size(121, 20);
            this.tbReportoRep.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Becario";
            // 
            // cbBecarioRep
            // 
            this.cbBecarioRep.FormattingEnabled = true;
            this.cbBecarioRep.Location = new System.Drawing.Point(80, 79);
            this.cbBecarioRep.Name = "cbBecarioRep";
            this.cbBecarioRep.Size = new System.Drawing.Size(121, 21);
            this.cbBecarioRep.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Descripcion";
            // 
            // tbDescRep
            // 
            this.tbDescRep.Location = new System.Drawing.Point(24, 149);
            this.tbDescRep.Multiline = true;
            this.tbDescRep.Name = "tbDescRep";
            this.tbDescRep.Size = new System.Drawing.Size(177, 98);
            this.tbDescRep.TabIndex = 6;
            // 
            // btnAcepRep
            // 
            this.btnAcepRep.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAcepRep.Location = new System.Drawing.Point(73, 263);
            this.btnAcepRep.Name = "btnAcepRep";
            this.btnAcepRep.Size = new System.Drawing.Size(75, 23);
            this.btnAcepRep.TabIndex = 7;
            this.btnAcepRep.Text = "Aceptar";
            this.btnAcepRep.UseVisualStyleBackColor = true;
            this.btnAcepRep.Click += new System.EventHandler(this.btnAcepRep_Click);
            // 
            // FRepMaq
            // 
            this.AcceptButton = this.btnAcepRep;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 298);
            this.Controls.Add(this.btnAcepRep);
            this.Controls.Add(this.tbDescRep);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbBecarioRep);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbReportoRep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbMaquinaRep);
            this.Name = "FRepMaq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Maquina";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbMaquinaRep;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbReportoRep;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbBecarioRep;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbDescRep;
        private System.Windows.Forms.Button btnAcepRep;
    }
}