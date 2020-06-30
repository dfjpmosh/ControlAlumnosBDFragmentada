namespace CDA_CDI
{
    partial class FRegAlumno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRegAlumno));
            this.cbGruReg = new System.Windows.Forms.ComboBox();
            this.cbCarReg = new System.Windows.Forms.ComboBox();
            this.lbCarIns = new System.Windows.Forms.Label();
            this.lbAMIns = new System.Windows.Forms.Label();
            this.lbAPIns = new System.Windows.Forms.Label();
            this.tbClaReg = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.lbGroIns = new System.Windows.Forms.Label();
            this.lbNomIns = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNomReg = new System.Windows.Forms.TextBox();
            this.tbAPReg = new System.Windows.Forms.TextBox();
            this.tbAMReg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbGruReg
            // 
            this.cbGruReg.FormattingEnabled = true;
            this.cbGruReg.Location = new System.Drawing.Point(101, 171);
            this.cbGruReg.Name = "cbGruReg";
            this.cbGruReg.Size = new System.Drawing.Size(136, 27);
            this.cbGruReg.TabIndex = 5;
            this.cbGruReg.Text = "118704";
            this.cbGruReg.Visible = false;
            // 
            // cbCarReg
            // 
            this.cbCarReg.FormattingEnabled = true;
            this.cbCarReg.Items.AddRange(new object[] {
            "ING. CIVIL",
            "ING. GEOLOGO",
            "ING. MECANICO ELECTRICISTA",
            "ING. AGROINDUSTRIAL",
            "ING. MECANICO ADMINISTRADOR",
            "ING. MECANICO",
            "ING. INFORMATICA",
            "ING. COMPUTACION",
            "ING. METALURGISTA Y DE MATERIALES",
            "ING. AMBIENTAL",
            "ING. ELECTRICIDAD Y AUTOMATIZACION",
            "ING. GEOMATICA",
            "ING. MECATRÓNICA",
            "ING. TOPOGRAFIA Y CONSTRUCCION",
            "ING. GEOINFORMATICA"});
            this.cbCarReg.Location = new System.Drawing.Point(101, 138);
            this.cbCarReg.Name = "cbCarReg";
            this.cbCarReg.Size = new System.Drawing.Size(136, 27);
            this.cbCarReg.TabIndex = 4;
            this.cbCarReg.Text = "Seleccionar";
            this.cbCarReg.Visible = false;
            // 
            // lbCarIns
            // 
            this.lbCarIns.AutoSize = true;
            this.lbCarIns.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCarIns.Location = new System.Drawing.Point(12, 141);
            this.lbCarIns.Name = "lbCarIns";
            this.lbCarIns.Size = new System.Drawing.Size(61, 19);
            this.lbCarIns.TabIndex = 24;
            this.lbCarIns.Text = "Carrera:";
            this.lbCarIns.Visible = false;
            // 
            // lbAMIns
            // 
            this.lbAMIns.AutoSize = true;
            this.lbAMIns.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAMIns.Location = new System.Drawing.Point(12, 108);
            this.lbAMIns.Name = "lbAMIns";
            this.lbAMIns.Size = new System.Drawing.Size(88, 19);
            this.lbAMIns.TabIndex = 23;
            this.lbAMIns.Text = "Ap. Mateno:";
            // 
            // lbAPIns
            // 
            this.lbAPIns.AutoSize = true;
            this.lbAPIns.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAPIns.Location = new System.Drawing.Point(12, 75);
            this.lbAPIns.Name = "lbAPIns";
            this.lbAPIns.Size = new System.Drawing.Size(92, 19);
            this.lbAPIns.TabIndex = 22;
            this.lbAPIns.Text = "Ap. Paterno: ";
            // 
            // tbClaReg
            // 
            this.tbClaReg.Location = new System.Drawing.Point(101, 6);
            this.tbClaReg.MaxLength = 10;
            this.tbClaReg.Name = "tbClaReg";
            this.tbClaReg.Size = new System.Drawing.Size(136, 27);
            this.tbClaReg.TabIndex = 7;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRegistrar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(48, 216);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(155, 28);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar e Inscribir";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // lbGroIns
            // 
            this.lbGroIns.AutoSize = true;
            this.lbGroIns.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGroIns.Location = new System.Drawing.Point(12, 174);
            this.lbGroIns.Name = "lbGroIns";
            this.lbGroIns.Size = new System.Drawing.Size(52, 19);
            this.lbGroIns.TabIndex = 18;
            this.lbGroIns.Text = "Grupo:";
            this.lbGroIns.Visible = false;
            // 
            // lbNomIns
            // 
            this.lbNomIns.AutoSize = true;
            this.lbNomIns.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomIns.Location = new System.Drawing.Point(12, 42);
            this.lbNomIns.Name = "lbNomIns";
            this.lbNomIns.Size = new System.Drawing.Size(85, 19);
            this.lbNomIns.TabIndex = 17;
            this.lbNomIns.Text = "Nombre(s): ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Clave: ";
            // 
            // tbNomReg
            // 
            this.tbNomReg.Location = new System.Drawing.Point(101, 39);
            this.tbNomReg.MaxLength = 10;
            this.tbNomReg.Name = "tbNomReg";
            this.tbNomReg.Size = new System.Drawing.Size(136, 27);
            this.tbNomReg.TabIndex = 1;
            // 
            // tbAPReg
            // 
            this.tbAPReg.Location = new System.Drawing.Point(101, 72);
            this.tbAPReg.MaxLength = 10;
            this.tbAPReg.Name = "tbAPReg";
            this.tbAPReg.Size = new System.Drawing.Size(136, 27);
            this.tbAPReg.TabIndex = 2;
            // 
            // tbAMReg
            // 
            this.tbAMReg.Location = new System.Drawing.Point(101, 105);
            this.tbAMReg.MaxLength = 10;
            this.tbAMReg.Name = "tbAMReg";
            this.tbAMReg.Size = new System.Drawing.Size(136, 27);
            this.tbAMReg.TabIndex = 3;
            // 
            // FRegAlumno
            // 
            this.AcceptButton = this.btnRegistrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(249, 254);
            this.Controls.Add(this.tbAMReg);
            this.Controls.Add(this.tbAPReg);
            this.Controls.Add(this.tbNomReg);
            this.Controls.Add(this.cbGruReg);
            this.Controls.Add(this.cbCarReg);
            this.Controls.Add(this.lbCarIns);
            this.Controls.Add(this.lbAMIns);
            this.Controls.Add(this.lbAPIns);
            this.Controls.Add(this.tbClaReg);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.lbGroIns);
            this.Controls.Add(this.lbNomIns);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRegAlumno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Nuevo Alumno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbGruReg;
        private System.Windows.Forms.ComboBox cbCarReg;
        private System.Windows.Forms.Label lbCarIns;
        private System.Windows.Forms.Label lbAMIns;
        private System.Windows.Forms.Label lbAPIns;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lbGroIns;
        private System.Windows.Forms.Label lbNomIns;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAPReg;
        private System.Windows.Forms.TextBox tbAMReg;
        public System.Windows.Forms.TextBox tbClaReg;
        public System.Windows.Forms.TextBox tbNomReg;
    }
}