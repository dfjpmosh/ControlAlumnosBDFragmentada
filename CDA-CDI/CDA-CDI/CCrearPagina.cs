using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CDA_CDI
{
    class CCrearPagina
    {
        PictureBox pbPCSelec;
        Button btn, btnSelectPC; 
        TabPage tp;
        Label lb;
        
        public CCrearPagina(PictureBox pbPCSelec, Button btnSelectPC)
        {
            this.pbPCSelec = pbPCSelec;
            this.btnSelectPC = btnSelectPC;
        }

        public CCrearPagina(PictureBox pbPCSelec)
        {
            this.pbPCSelec = pbPCSelec;
        }

        /*public TabPage crearPagina(string nom, int num)
        {
            int c = num;
            tp = new TabPage(nom);
            tp.BackColor = Color.White;
            tp.BackgroundImage = Properties.Resources.EscudoPagina;
            tp.BackgroundImageLayout = ImageLayout.Center;
            
            for (int j = 0; j < 4; j++)
                for (int i = 0; i < 6; i++)
                {
                    pb = new Button();
                    pb.Name = "pb" + (j + 1) + (i + 1);
                    pb.Text = c++.ToString();
                    pb.TextAlign = ContentAlignment.MiddleCenter;
                    pb.Size = new Size(60, 60);
                    pb.Location = new Point(25 + (i * 100), 20 + (j * 100));
                    pb.Click += new EventHandler(pb_Click);
                    tp.Controls.Add(pb);

                    lb = new Label();
                    lb.Name = "lb" + (j + 1) + (i + 1);
                    lb.Size = new Size(60, 20);
                    lb.Text = "######";
                    lb.TextAlign = ContentAlignment.MiddleCenter;
                    lb.Location = new Point(25 + (i * 100), 85 + (j * 100));
                    tp.Controls.Add(lb);
                }

            return tp;
        }

        public TabPage crearPaginaD3(string nom, int num)
        {
            int c = num;
            tp = new TabPage(nom);
            tp.BackColor = Color.White;
            tp.BackgroundImage = Properties.Resources.EscudoPagina;
            tp.BackgroundImageLayout = ImageLayout.Center;

            for (int j = 0; j < 3; j++)
                for (int i = 0; i < 4; i++)
                {
                    pb = new Button();
                    pb.Name = "pb" + (j + 1) + (i + 1);
                    pb.Text = c++.ToString();
                    pb.TextAlign = ContentAlignment.MiddleCenter;
                    pb.Size = new Size(60, 60);
                    pb.Location = new Point(25 + (i * 155), 20 + (j * 100));
                    pb.Click += new EventHandler(pb_Click);
                    tp.Controls.Add(pb);

                    lb = new Label();
                    lb.Name = "lb" + (j + 1) + (i + 1);
                    lb.Size = new Size(60, 20);
                    lb.Text = "######";
                    lb.TextAlign = ContentAlignment.MiddleCenter;
                    lb.Location = new Point(25 + (i * 155), 85 + (j * 100));
                    tp.Controls.Add(lb);
                }

            return tp;
        }*/

        private void pb_Click(object sender, EventArgs e)
        {
            //pbPCSelec.BackColor = Color.Black;
            btn = (Button)sender;
            pbPCSelec.BackgroundImage = btn.Image;
            btnSelectPC.Text = btn.Name.Substring(2);
            btnSelectPC.BackgroundImage = btn.Image;            
            //MessageBox.Show("Presiono "+pb.Name+"\r X="+pb.Location.X+" Y="+pb.Location.Y + pbPCSelec.Name.ToString());
            
        }

        public TabPage crearPagAltaAlumnos(string nom, ref DataGridView dgvAltAlu)
        {
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataGridViewColumn col;
            
            tp = new TabPage(nom);
            tp.BackColor = Color.White;
            tp.BackgroundImage = Properties.Resources.EscudoPagina;
            tp.BackgroundImageLayout = ImageLayout.Center;
            
            //DataGridView dgvAltAlu = new DataGridView();
            dgvAltAlu.Name = "dgvAltAlu";
            dgvAltAlu.Dock = DockStyle.Fill;
            dgvAltAlu.RowTemplate = new DataGridViewRow(); 
            dgvAltAlu.RowHeadersVisible = false;
            
            col = new DataGridViewColumn();
            col.HeaderText = "Clave";
            col.CellTemplate = cell;
            dgvAltAlu.Columns.Add(col);
            dgvAltAlu.AllowUserToAddRows = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Nombre(s)";
            col.CellTemplate = cell;
            dgvAltAlu.Columns.Add(col);
            dgvAltAlu.AllowUserToAddRows = false;

            col = new DataGridViewColumn();
            col.HeaderText = "AP. Paterno";
            col.CellTemplate = cell;
            dgvAltAlu.Columns.Add(col);
            dgvAltAlu.AllowUserToAddRows = false;

            col = new DataGridViewColumn();
            col.HeaderText = "AP. Materno";
            col.CellTemplate = cell;
            dgvAltAlu.Columns.Add(col);
            dgvAltAlu.AllowUserToAddRows = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Carrera";
            col.CellTemplate = cell;
            dgvAltAlu.Columns.Add(col);
            dgvAltAlu.AllowUserToAddRows = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Grupo";
            col.CellTemplate = cell;
            dgvAltAlu.Columns.Add(col);
            dgvAltAlu.AllowUserToAddRows = false;
            
            tp.Controls.Add(dgvAltAlu);
            
            return tp;
        }

        public TabPage crearPagReportes(string nom)
        {
            tp = new TabPage(nom);
            tp.BackColor = Color.White;
            tp.BackgroundImage = Properties.Resources.EscudoPagina;
            tp.BackgroundImageLayout = ImageLayout.Center;


            return tp;
        }

        public TabPage crearPagAgregarPC(string nom, ref DataGridView dgvAgrPC)
        {
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataGridViewColumn col;

            tp = new TabPage(nom);
            tp.BackColor = Color.White;
            tp.BackgroundImage = Properties.Resources.EscudoPagina;
            tp.BackgroundImageLayout = ImageLayout.Center;

            dgvAgrPC.Name = "dgvAgrPC";
            dgvAgrPC.Dock = DockStyle.Fill;
            dgvAgrPC.RowTemplate = new DataGridViewRow();
            dgvAgrPC.RowHeadersVisible = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Id";
            col.CellTemplate = cell;
            dgvAgrPC.Columns.Add(col);
            dgvAgrPC.AllowUserToAddRows = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Laboratorio";
            col.CellTemplate = cell;
            dgvAgrPC.Columns.Add(col);
            dgvAgrPC.AllowUserToAddRows = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Estado";
            col.CellTemplate = cell;
            dgvAgrPC.Columns.Add(col);
            dgvAgrPC.AllowUserToAddRows = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Coordenada X";
            col.CellTemplate = cell;
            dgvAgrPC.Columns.Add(col);
            dgvAgrPC.AllowUserToAddRows = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Coordenada Y";
            col.CellTemplate = cell;
            dgvAgrPC.Columns.Add(col);
            dgvAgrPC.AllowUserToAddRows = false;

            tp.Controls.Add(dgvAgrPC);

            return tp;
        }

        public TabPage crearPagAgrGrupo(string nom, ref DataGridView dgvAgrGru)
        {
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataGridViewColumn col;

            tp = new TabPage(nom);
            tp.BackColor = Color.White;
            tp.BackgroundImage = Properties.Resources.EscudoPagina;
            tp.BackgroundImageLayout = ImageLayout.Center;

            dgvAgrGru.Name = "dgvAgrGru";
            dgvAgrGru.Dock = DockStyle.Fill;
            dgvAgrGru.RowTemplate = new DataGridViewRow();
            dgvAgrGru.RowHeadersVisible = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Clave";
            col.CellTemplate = cell;
            dgvAgrGru.Columns.Add(col);
            dgvAgrGru.AllowUserToAddRows = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Materia";
            col.CellTemplate = cell;
            dgvAgrGru.Columns.Add(col);
            dgvAgrGru.AllowUserToAddRows = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Profesor";
            col.CellTemplate = cell;
            dgvAgrGru.Columns.Add(col);
            dgvAgrGru.AllowUserToAddRows = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Horario";
            col.CellTemplate = cell;
            dgvAgrGru.Columns.Add(col);
            dgvAgrGru.AllowUserToAddRows = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Aula";
            col.CellTemplate = cell;
            dgvAgrGru.Columns.Add(col);
            dgvAgrGru.AllowUserToAddRows = false;

            tp.Controls.Add(dgvAgrGru);

            return tp;
        }

        public TabPage crearPagAgrUsuario(string nom, ref DataGridView dgvAgrUsr)
        {
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataGridViewColumn col;

            tp = new TabPage(nom);
            tp.BackColor = Color.White;
            tp.BackgroundImage = Properties.Resources.EscudoPagina;
            tp.BackgroundImageLayout = ImageLayout.Center;

            dgvAgrUsr.Name = "dgvAgrUsr";
            dgvAgrUsr.Dock = DockStyle.Fill;
            dgvAgrUsr.RowTemplate = new DataGridViewRow();
            dgvAgrUsr.RowHeadersVisible = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Id";
            col.CellTemplate = cell;
            dgvAgrUsr.Columns.Add(col);
            dgvAgrUsr.AllowUserToAddRows = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Nombre";
            col.CellTemplate = cell;
            dgvAgrUsr.Columns.Add(col);
            dgvAgrUsr.AllowUserToAddRows = false;

            col = new DataGridViewColumn();
            col.HeaderText = "Tipo";
            col.CellTemplate = cell;
            dgvAgrUsr.Columns.Add(col);
            dgvAgrUsr.AllowUserToAddRows = false;

            tp.Controls.Add(dgvAgrUsr);

            return tp;
        }

        public TabPage crearPaginaV2(string nom, int num, ref List<Label> llb, ref List<Button> lbtn)
        {
            llb = new List<Label>();
            lbtn = new List<Button>();

            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            List<CPC> lE1 = new List<CPC>();
            List<CPC> lE2 = new List<CPC>();
            CPC alu = new CPC();
            string query;

            tp = new TabPage(nom);
            tp.BackColor = Color.White;
            tp.BackgroundImage = Properties.Resources.EscudoPagina;
            tp.BackgroundImageLayout = ImageLayout.Center;

            lF = conSC.leerFragmentos("MAQUINAS");

            if (lF.Count > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {   //Solo se cocidera VERTICAL por que así esta fragmentada la Tabla ALUMNOS
                        case "HORIZONTAL":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre + " WHERE laboratorio='" + nom + "'";
                                    lE1 = conS1.buscarEquipoS1(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre + " WHERE laboratorio='" + nom + "'";
                                    lE2 = conS2.buscarEquipoS2(query);
                                    break;
                            }
                            break;
                    }
                }
            }

            if (lE1 != null && lE1.Count > 0)
            {
                foreach (CPC pc in lE1)
                {
                    int x = Convert.ToInt32(pc.coordenadaX);
                    int y = Convert.ToInt32(pc.coordenadaY);
                    lb = new Label();

                    btn = new Button();
                    btn.Name = "pb" + pc.idMaquina;
                    btn.Text = pc.idMaquina.ToString();
                    btn.TextAlign = ContentAlignment.BottomRight;
                    btn.Size = new Size(60, 60);
                    switch (pc.estado)
                    {
                        case "Descompuesta":
                            btn.Image = Image.FromFile("C:\\Users\\dfjpmosh\\Dropbox\\CDA-CDI\\Imagenes\\m.png");
                            break;
                        case "Ocupada":
                            btn.Image = Image.FromFile("C:\\Users\\dfjpmosh\\Dropbox\\CDA-CDI\\Imagenes\\o.png");
                            //Hay que hacer consulta para saber que alumno la tiene ocupada
                            mostrarAlumno(pc.idMaquina, lb);
                            break;
                        default:
                            btn.Image = Image.FromFile("C:\\Users\\dfjpmosh\\Dropbox\\CDA-CDI\\Imagenes\\" + pc.idMaquina + ".png");
                            break;
                    }
                    btn.ImageAlign = ContentAlignment.MiddleCenter;
                    btn.Location = new Point(x, y);
                    btn.Click += new EventHandler(pb_Click);
                    tp.Controls.Add(btn);

                    
                    lb.Name = "lb" + pc.idMaquina;
                    lb.Size = new Size(60, 20);
                    //lb.Text = "######";
                    lb.Font = new Font("Calibri", 7);
                    lb.TextAlign = ContentAlignment.MiddleLeft;
                    lb.Location = new Point(x, y + 65);
                    tp.Controls.Add(lb);
                    llb.Add(lb);
                    lbtn.Add(btn);
                }

            }
            else
                if (lE2 != null && lE2.Count > 0)
                {
                    foreach (CPC pc in lE2)
                    {
                        int x = Convert.ToInt32(pc.coordenadaX);
                        int y = Convert.ToInt32(pc.coordenadaY);
                        lb = new Label();

                        btn = new Button();
                        btn.Name = "pb" + pc.idMaquina;
                        btn.Text = pc.idMaquina.ToString();
                        btn.TextAlign = ContentAlignment.BottomRight;
                        btn.Size = new Size(60, 60);
                        switch (pc.estado)
                        {
                            case "Descompuesta":
                                btn.Image = Image.FromFile("C:\\Users\\dfjpmosh\\Dropbox\\CDA-CDI\\Imagenes\\m.png");
                                break;
                            case "Ocupada":
                                btn.Image = Image.FromFile("C:\\Users\\dfjpmosh\\Dropbox\\CDA-CDI\\Imagenes\\o.png");
                                mostrarAlumno(pc.idMaquina, lb);
                                break;
                            default:
                                btn.Image = Image.FromFile("C:\\Users\\dfjpmosh\\Dropbox\\CDA-CDI\\Imagenes\\" + pc.idMaquina + ".png");
                                break;
                        }
                        btn.ImageAlign = ContentAlignment.MiddleCenter;
                        btn.Location = new Point(x, y);
                        btn.Click += new EventHandler(pb_Click);
                        tp.Controls.Add(btn);

                        
                        lb.Name = "lb" + pc.idMaquina;
                        lb.Size = new Size(60, 20);
                        //lb.Text = "######";
                        lb.Font = new Font("Calibri", 7);
                        lb.TextAlign = ContentAlignment.MiddleLeft;
                        lb.Location = new Point(x, y + 65);
                        tp.Controls.Add(lb);
                        llb.Add(lb);
                        lbtn.Add(btn);
                    }

                }

            
            return tp;
        }

        public void mostrarAlumno(long idM, Label lb)
        {
            List<CAlumno> lAl = new List<CAlumno>();
            List<CAsistencia> lAs = new List<CAsistencia>();
            List<CPC> lPs = new List<CPC>();
            bool enc = false;

            lAl = dameAlumnos(ref lAl);
            lAs = dameAsistencias();            
            lPs = damePCs();

            foreach(CAlumno al in lAl)
            {
                foreach (CAsistencia a in lAs)
                    if (al.claveAlumno == a.claveAlumno && a.horaEntrada == a.horaSalida && a.idMaquina == idM)
                    {
                        lb.Text = al.aPaterno + " " + al.aMaterno + " " + al.nombres;
                        enc = true;
                        break;
                    }
                if (enc)
                    break;
            }
        }

        public List<CAlumno> dameAlumnos(ref List<CAlumno> lAl)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            List<CAlumno> lA1 = new List<CAlumno>();
            List<CAlumno> lA2 = new List<CAlumno>();
            CAlumno alu = new CAlumno();
            string query;

            lF = conSC.leerFragmentos("ALUMNOS");

            if (lF.Count > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {   //Solo se cocidera VERTICAL por que así esta fragmentada la Tabla ALUMNOS
                        case "VERTICAL":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre;
                                    lA1 = conS1.buscarAlumnoS1(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre;
                                    lA2 = conS2.buscarAlumnoS2(query);
                                    break;
                            }
                            break;
                    }
                }
            }

            if (lA1.Count > 0 && lA2.Count > 0 && lA1.Count == lA2.Count)
                for (int i = 0; i < lA1.Count; i++)
                {
                    lA2[i].estado = lA1[i].estado;
                    lA2[i].tiempo = lA1[i].tiempo;
                }
            lAl = lA2;
            return lA2;

        }

        public List<CPC> damePCs()
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            List<CPC> lE1 = new List<CPC>();
            List<CPC> lE2 = new List<CPC>();
            CPC alu = new CPC();
            string query;

            lF = conSC.leerFragmentos("MAQUINAS");

            if (lF.Count > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {   //Solo se cocidera VERTICAL por que así esta fragmentada la Tabla ALUMNOS
                        case "HORIZONTAL":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre;
                                    lE1 = conS1.buscarEquipoS1(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre;
                                    lE2 = conS2.buscarEquipoS2(query);
                                    break;
                            }
                            break;
                    }
                }
            }

            foreach (CPC p in lE2)
                lE1.Add(p);

            return lE1;

        }

        public List<CAsistencia> dameAsistencias()
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            List<CAsistencia> lA = new List<CAsistencia>();
            CAsistencia asistencia = new CAsistencia();
            string query;

            lF = conSC.leerFragmentos("ASISTENCIAS");

            if (lF.Count > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {
                        case "REPLICA":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre;
                                    lA = conS1.buscarAsistencias(query);
                                    break;
                                case 2:
                                    //query = "SELECT * FROM " + f.nombre;
                                    //lAs = conS2.buscarAsistencias(query);
                                    break;
                            }
                            break;
                        case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre;
                                    lA = conS1.buscarAsistencias(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre;
                                    lA = conS2.buscarAsistencias(query);
                                    break;
                            }
                            break;
                    }
                }
            }

            return lA;

        }
    }
}
