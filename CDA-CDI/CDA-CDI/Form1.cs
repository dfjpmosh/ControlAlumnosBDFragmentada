using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Printing;
using System.IO;

namespace CDA_CDI
{
    public partial class Form1 : Form
    {
        CCrearPagina cp;
        TabPage tb;
        //private string usuario;
        List<DataGridView> ldgv = new List<DataGridView>();
        List<Label> llb = new List<Label>();
        List<Button> lbtn = new List<Button>();
        List<Label> llbAux = new List<Label>();
        List<Button> lbtnAux = new List<Button>();
        DataGridView dgv;
        //Label lb;
        //Button btn;
        CPC equipo;
        CAlumno alumno;
        CUsuario usuario = new CUsuario();

        private Font Fuente;
        private StreamReader streamParaImp;
        
        public Form1()
        {
            InitializeComponent();
            tFechaHora.Enabled = true;

            cp = new CCrearPagina(pbPCSelec, btnSelecPC);
            //lb = new Label();
            tb = cp.crearPaginaV2("D-01", 1, ref llbAux, ref lbtnAux);
            llb.AddRange(llbAux);
            lbtn.AddRange(lbtnAux);
            //tb = cp.crearPagina("D-01", 1);
            tcPestañas.Controls.Add(tb);

            cp = new CCrearPagina(pbPCSelec, btnSelecPC);
            //lb = new Label();
            tb = cp.crearPaginaV2("D-02", 25, ref llbAux, ref lbtnAux);
            llb.AddRange(llbAux);
            lbtn.AddRange(lbtnAux);
            //tb = cp.crearPagina("D-02", 25);
            tcPestañas.Controls.Add(tb);

            cp = new CCrearPagina(pbPCSelec, btnSelecPC);
            //lb = new Label();
            tb = cp.crearPaginaV2("D-03", 49, ref llbAux, ref lbtnAux);
            llb.AddRange(llbAux);
            lbtn.AddRange(lbtnAux);
            //tb = cp.crearPaginaD3("D-03", 49);
            tcPestañas.Controls.Add(tb);

            cp = new CCrearPagina(pbPCSelec);
            dgv = new DataGridView();
            tb = cp.crearPagAltaAlumnos("Alta Alumnos", ref dgv);
            ldgv.Add(dgv);
            tcPestañas.Controls.Add(tb);
            
            cp = new CCrearPagina(pbPCSelec);
            tb = cp.crearPagReportes("Reportes");
            tcPestañas.Controls.Add(tb);

            /*cp = new CCrearPagina(pbPCSelec);
            dgv = new DataGridView();
            tb = cp.crearPagAgregarPC("Equipo", ref dgv);
            ldgv.Add(dgv);
            tcPestañas.Controls.Add(tb);

            cp = new CCrearPagina(pbPCSelec);
            dgv = new DataGridView();
            tb = cp.crearPagAgrGrupo("Grupo", ref dgv);
            ldgv.Add(dgv);
            tcPestañas.Controls.Add(tb);

            cp = new CCrearPagina(pbPCSelec);
            dgv = new DataGridView();
            tb = cp.crearPagAgrUsuario("Usuario", ref dgv);
            ldgv.Add(dgv);
            tcPestañas.Controls.Add(tb);*/

            panelAsistencia.Visible = true;
            panelAsistencia.Dock = DockStyle.Fill;
            tcPestañas.SelectedIndex = 2;
            panelIzquierdo.Visible = true;
            panelIzquierdo.Dock = DockStyle.Left;
            panelIzquierdo.BorderStyle = BorderStyle.None;
            gbAsistencia.Dock = DockStyle.Fill;
            
            
            //BORRAR
            tbUser.Text = "admin";
            tbPass.Text = "admin";
        }

        public void crearPaginaAdmin()
        {
            cp = new CCrearPagina(pbPCSelec);
            dgv = new DataGridView();
            tb = cp.crearPagAgregarPC("Equipo", ref dgv);
            ldgv.Add(dgv);
            tcPestañas.Controls.Add(tb);

            cp = new CCrearPagina(pbPCSelec);
            dgv = new DataGridView();
            tb = cp.crearPagAgrGrupo("Grupo", ref dgv);
            ldgv.Add(dgv);
            tcPestañas.Controls.Add(tb);

            cp = new CCrearPagina(pbPCSelec);
            dgv = new DataGridView();
            tb = cp.crearPagAgrUsuario("Usuario", ref dgv);
            ldgv.Add(dgv);
            tcPestañas.Controls.Add(tb);
        }

        private void tFechaHora_Tick(object sender, EventArgs e)
        {
            lFechaHora.Text = "CENTRO DE INFORMATICA        Bienvenid@: " + usuario.nombre + "    " + DateTime.Now.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelLogin.Dock = DockStyle.Fill;
            panelAsistencia.Visible = false;
            panelPestañas.Visible = false;
            usuario.nombre = "USUARIO";
        }

        private void tcPestañas_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;

            switch (current.Text)
            {
                case "Alta Alumnos":
                    panelAlumnos.Visible = true;
                    panelAlumnos.Dock = DockStyle.Fill;
                    gbAlumnos.Dock = DockStyle.Fill;
                    panelUsuario.Visible = false;
                    panelAsistencia.Visible = false;
                    panelPCs.Visible = false;
                    panelGrupo.Visible = false;
                    panelReportes.Visible = false;
                    muestraAluIns();
                    cargaGrupo();
                    tbClaIns.Focus();
                    break;
                case "Equipo":
                    panelPCs.Visible = true;
                    panelPCs.Dock = DockStyle.Fill;
                    gbPC.Dock = DockStyle.Fill;
                    panelUsuario.Visible = false;
                    panelAsistencia.Visible = false;
                    panelAlumnos.Visible = false;
                    panelGrupo.Visible = false;
                    panelReportes.Visible = false;
                    muestraMaqReg();
                    tbIdPC.Focus();
                    break;
                case "Grupo":
                    panelGrupo.Visible = true;
                    panelGrupo.Dock = DockStyle.Fill;
                    gbGrupo.Dock = DockStyle.Fill;
                    panelUsuario.Visible = false;
                    panelPCs.Visible = false;
                    panelAsistencia.Visible = false;
                    panelAlumnos.Visible = false;
                    panelReportes.Visible = false;
                    muestraGruReg();
                    tbClaGru.Focus();
                    break;
                case "Usuario":
                    panelUsuario.Visible = true;
                    panelUsuario.Dock = DockStyle.Fill;
                    gbUsuario.Dock = DockStyle.Fill;
                    panelGrupo.Visible = false;
                    panelPCs.Visible = false;
                    panelAsistencia.Visible = false;
                    panelAlumnos.Visible = false;
                    panelReportes.Visible = false;
                    muestraUsrReg();
                    tbIdUsr.Focus();
                    break;
                case "Reportes":
                    panelReportes .Visible = true;
                    panelReportes.Dock = DockStyle.Fill;
                    gbReportes.Dock = DockStyle.Fill;
                    panelGrupo.Visible = false;
                    panelPCs.Visible = false;
                    panelAsistencia.Visible = false;
                    panelAlumnos.Visible = false;
                    panelUsuario.Visible = false;
                    cargaGrupoRep();
                    //tbIdUsr.Focus();
                    break;
                default:
                    panelAsistencia.Visible = true;
                    panelAsistencia.Dock = DockStyle.Fill;
                    panelAlumnos.Visible = false;
                    panelPCs.Visible = false;
                    panelGrupo.Visible = false;
                    panelUsuario.Visible = false;
                    panelReportes.Visible = false;
                    break;
            }

        }
        
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            CUsuario user = new CUsuario();
            string query;
            
            lF = conSC.leerFragmentos("USUARIOS");

            if (lF.Count > 0 && tbUser.Text.Length > 1 && tbPass.Text.Length > 1)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {
                        case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre + " WHERE nombre='" + tbUser.Text + "' AND contrasena='" + tbPass.Text + "'";
                                    user = conS1.buscarUsuario(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre + " WHERE nombre='" + tbUser.Text + "' AND contrasena='" + tbPass.Text + "'";
                                    user = conS2.buscarUsuario(query);
                                    break;
                            }
                            break;
                    }
                }
            }
            else
                user = null;

            if (user != null)
            {
                panelAsistencia.Visible = true;
                panelPestañas.Visible = true;
                lFechaHora.Visible = true;
                lUser.Visible = false;
                tbUser.Visible = false;
                lPass.Visible = false;
                tbPass.Visible = false;
                btnEntrar.Visible = false;
                btnSalir.Visible = true;
                pbCI.Visible = true;
                panelLogin.Dock = DockStyle.Top;
                usuario = user;
                if (usuario.tipo == "Administrador")
                    crearPaginaAdmin();
            }
            else
                MessageBox.Show("Usuario y/o Contraseña Incorrecta");
            //cargar paginas basicas y ver si se crean las de admin
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            panelLogin.Dock = DockStyle.Fill;
            panelAsistencia.Visible = false;
            panelPestañas.Visible = false;
            
            panelAsistencia.Visible = false;
            panelPestañas.Visible = false;
            lFechaHora.Visible = false;
            lUser.Visible = true;
            tbUser.Visible = true;
            lPass.Visible = true;
            tbPass.Visible = true;
            btnEntrar.Visible = true;
            btnSalir.Visible = false;
            pbCI.Visible = false;

            tbUser.Text = "";
            tbPass.Text = "";

            //eliminar paginas de admin
        }

        private void btnBusIns_Click(object sender, EventArgs e)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            CAlumno alu = new CAlumno();
            string query;

            lF = conSC.leerFragmentos("ALUMNOS");

            if (lF.Count > 0 && tbClaIns.Text.Length > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {   //Solo se cocidera VERTICAL por que así esta fragmentada la Tabla ALUMNOS
                        case "VERTICAL":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre + " WHERE clavealumno = "+tbClaIns.Text;
                                    conS1.buscarAlumno1(query, ref alu);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre + " WHERE clavealumno = "+tbClaIns.Text;
                                    conS2.buscarAlumno2(query, ref alu);
                                    break;
                            }
                            break;
                    }
                }
            }

            if (alu.claveAlumno != 0 && alu.nombres != null)
            {
                lbNomIns.Text += alu.nombres;
                lbAPIns.Text += alu.aPaterno;
                lbAMIns.Text += alu.aMaterno;
            }
            else
                if (MessageBox.Show("El Alumno No Existe\n¿Desea Registrarlo?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FRegAlumno fra = new FRegAlumno();
                    fra.tbClaReg.Text = tbClaIns.Text;
                    if (fra.ShowDialog() == DialogResult.OK)
                        muestraAluIns();
                }
        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            List<string> lv;
            CAlumno alu = new CAlumno();
            string query;
            bool b1 = false, b2 = false;

            lF = conSC.leerFragmentos("ALUMNOS");

            if (lF.Count > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {
                        case "VERTICAL":
                            List<string> la = new List<string>();
                            la = conSC.leerAtributos(f.id);
                            query = "UPDATE " + f.nombre + " SET ";
                            switch (f.sitio)
                            {
                                case 1:
                                    for (int i = 1; i < la.Count -1; i++)
                                        query += la[i] + "=@" + la[i] + ", ";
                                    query += la[la.Count - 1] + "=@" + la[la.Count - 1];
                                    lv = new List<string>();         
                                    lv.Add("00:00:00");
                                    lv.Add("ALTA");
                                    query += " WHERE claveAlumno=" + tbClaIns.Text;
                                    //LLAMAR INSCRIBIR EN S1
                                    b1 = conS1.inscribeAlumno1(query, la, lv);
                                    break;
                                case 2:
                                    for (int i = 1; i < la.Count -1; i++)
                                        query += la[i] + "=:" + la[i] + ", ";
                                    query += la[la.Count - 1] + "=:" + la[la.Count - 1];
                                    lv = new List<string>();
                                    lv.Add(lbNomIns.Text.Substring(11));
                                    lv.Add(lbAPIns.Text.Substring(13));
                                    lv.Add(lbAMIns.Text.Substring(12));
                                    lv.Add(cbCarIns.Text);
                                    lv.Add(cbGroIns.Text);
                                    query += " WHERE CLAVEALUMNO=" + tbClaIns.Text;
                                    //LLAMAR INSERCION EN S2
                                    b2 = conS2.inscribeAlumno2(query, la, lv);
                                    break;
                            }
                            break;
                    }
                }
            }

            if (b1 && b2)
            {
                MessageBox.Show("El Alumno Se Inscribio Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                muestraAluIns();
            }

            tbClaIns.Text = "";
            tbClaIns.Focus();
            lbNomIns.Text = "Nombre(s): ";
            lbAPIns.Text = "Ap. Paterno: ";
            lbAMIns.Text = "Ap. Materno: ";
            cbCarIns.Text = "Seleccionar";
            cbGroIns.Text = "Seleccionar";
        }

        public void muestraAluIns()
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
                foreach (DataGridView d in ldgv)
                    if (d.Name == "dgvAltAlu")
                    {
                        d.Rows.Clear();
                        for (int i = 0; i < lA2.Count; i++)
                            d.Rows.Add(lA2[i].claveAlumno, lA2[i].nombres, lA2[i].aPaterno, lA2[i].aMaterno, lA2[i].carrera, lA2[i].grupo);
                    }
                                
        }

        public void cargaGrupo()
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            List<CGrupo> lG = new List<CGrupo>();
            CGrupo grupo = new CGrupo();
            string query;

            lF = conSC.leerFragmentos("GRUPOS");

            if (lF.Count > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {   case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre;
                                    lG = conS1.buscarGrupos(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre;
                                    lG = conS2.buscarGrupos(query);
                                    break;
                            }
                            break;
                    }
                }
            }

            cbGroIns.Text = "Seleccionar";
            cbGroIns.Items.Clear();
            foreach (CGrupo g in lG)
                cbGroIns.Items.Add(g.clavegrupo);            

        }

        public void cargaGrupoRep()
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            List<CGrupo> lG = new List<CGrupo>();
            CGrupo grupo = new CGrupo();
            string query;

            lF = conSC.leerFragmentos("GRUPOS");

            if (lF.Count > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {
                        case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre;
                                    lG = conS1.buscarGrupos(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre;
                                    lG = conS2.buscarGrupos(query);
                                    break;
                            }
                            break;
                    }
                }
            }

            cbImpRep.Text = "Seleccionar";
            cbImpRep.Items.Clear();
            foreach (CGrupo g in lG)
                cbImpRep.Items.Add(g.clavegrupo);

        }

        private void tbClaIns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnBusIns_Click(null, null);
            else
            {
                if (e.KeyChar == Convert.ToChar(Keys.Back))
                    e.Handled = false;
                else
                {
                    if (!Char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                        MessageBox.Show("Solo Debe Contener Numeros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void tbIdPC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnBusPC_Click(null, null);
            else
            {
                if (e.KeyChar == Convert.ToChar(Keys.Back))
                    e.Handled = false;
                else
                {
                    if (!Char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                        MessageBox.Show("Solo Debe Contener Numeros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnBusPC_Click(object sender, EventArgs e)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            CPC pc = new CPC();
            string query;

            lF = conSC.leerFragmentos("MAQUINAS");

            if (lF.Count > 0 && tbIdPC.Text.Length > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {   //Solo se concidera HORIZONTAL porque así esta fragmentada la Tabla MAQUINAS
                        case "HORIZONTAL":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre + " WHERE idMaquina=" + tbIdPC.Text;
                                    pc = conS1.buscarPC(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre + " WHERE idMaquina=" + tbIdPC.Text;
                                    pc = conS2.buscarPC(query);
                                    break;
                            }
                            break;
                    }

                    if (pc != null)
                        break;
                }
            }

            if (pc != null)
            {
                cbLabPC.Text = pc.laboratorio;
                cbEstPC.Text = pc.estado;
                nupCXPC.Value = pc.coordenadaX;
                nupCYPC.Value = pc.coordenadaY;
                //btnModPC.Enabled = true;
                btnAgrePC.Enabled = false;
            }
            else
                if (MessageBox.Show("El Equipo No Existe\n¿Desea Registrarlo?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cbLabPC.Focus();
                    //btnModPC.Enabled = false;
                    btnAgrePC.Enabled = true;
                }
        }

        //FALTA VALIDAR LOS CONTROLES QUE NO SEAN NULL O ESTEN VACIOS
        private void btnAgrePC_Click(object sender, EventArgs e)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            CPC pc = new CPC();
            bool bpc = false, bandera=false, result=false;
            List<bool> lB = new List<bool>();
            string query;
            int cont = 0;

            string[] co=null;
            string[] av=null;

            lF = conSC.leerFragmentos("MAQUINAS");

            if (lF.Count > 0 && tbIdPC.Text.Length > 0)
            {
                pc.idMaquina = Convert.ToInt64(tbIdPC.Text);
                pc.laboratorio = cbLabPC.Text;
                pc.estado = cbEstPC.Text;
                pc.coordenadaX = Convert.ToInt64(nupCXPC.Value);
                pc.coordenadaY = Convert.ToInt64(nupCYPC.Value);

                foreach (CFragmento f in lF)
                {
                    lB.Clear();
                    switch (f.tipo)
                    {   //Solo se cocidera HORIZONTAL porque así esta fragmentada la Tabla MAQUINAS
                        case "HORIZONTAL":
                            co = f.condicion.Split(' ');
                            for (int i = 0; i < co.Length; i += 2)
                            {
                                if(co[i].Contains('=') && !bpc)
                                {
                                    //Solo debería contener 2 registros
                                    av = co[i].Split('=');
                                    //Solo debería tener 1 valor
                                    char[] c ={'\''};
                                    string va = av[1].Trim(c);
                                    
                                    switch (av[0])
                                    {
                                        case "laboratorio":
                                            bandera = (pc.laboratorio==va);
                                            lB.Add(bandera);
                                            break;
                                    }

                                    
                                }
                                else
                                    if (co[i].Contains('<') && co[i].Contains('>') && !bpc)
                                    {
                                        //Solo debería contener 2 registros
                                        av = co[i].Split('<', '>');
                                        //Solo debería tener 1 valor
                                        char[] c = { '\'' };
                                        string va = av[2].Trim(c);

                                        switch (av[0])
                                        {
                                            case "laboratorio":
                                                bandera = (pc.laboratorio != va);
                                                /*if (f.sitio == 1)
                                                    bandera = false;*/
                                                lB.Add(bandera);
                                                break;
                                        }
                                    }
                                    else
                                        if (co[i].Contains('<') && !bpc)
                                        {
                                        }
                                        else
                                            if (co[i].Contains('>') && !bpc)
                                        {
                                        }
                            }
                            break;
                    }

                    if (co.Length > 1 && lB.Count > 0)
                    {
                        cont = 3;
                        switch (co[1])
                        {
                            case "OR":
                                result = lB[0] || lB[1];
                                break;
                            case "AND":
                                result = lB[0] && lB[1];
                                break;
                        }

                        for (int j = 3; j < co.Length; j += 2)
                        {
                            switch (co[j])
                            {
                                case "OR":
                                    result = lB[cont] || lB[cont + 1];
                                    break;
                                case "AND":
                                    result = lB[cont] && lB[cont + 1];
                                    break;
                            }
                            cont += 2;
                        }
                    }
                    else
                        if (lB.Count > 0)
                            result = lB[0];
                        else
                            result = false;

                    if(result)
                        switch (f.sitio)
                        {
                            case 1:
                                query = "INSERT INTO " + f.nombre + "(idMaquina, laboratorio, estado, coordenadaX, coordenadaY) VALUES(" +
                                pc.idMaquina + ",'" + pc.laboratorio + "','" + pc.estado + "'," + pc.coordenadaX + "," + pc.coordenadaY + ")";
                                bpc = conS1.agregarPC(query);
                                break;
                            case 2:
                                query = "INSERT INTO " + f.nombre + "(idMaquina, laboratorio, estado, coordenadaX, coordenadaY) VALUES(" +
                                pc.idMaquina + ",'" + pc.laboratorio + "','" + pc.estado + "'," + pc.coordenadaX + "," + pc.coordenadaY + ")";
                                bpc = conS2.agregarPC(query);
                                break;
                        }
                }
            }

            if (bpc)
            {
                MessageBox.Show("El Equipo Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nupCYPC.Value = 0;
                nupCXPC.Value = 0;
                cbEstPC.Text = "Disponible";
                cbLabPC.Text = "D-01";
                tbIdPC.Text = "";
                tbIdPC.Focus();
                muestraMaqReg();
            }

            btnAgrePC.Enabled = false;
            
        }

        public void muestraMaqReg()
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

            foreach (DataGridView d in ldgv)
                if (d.Name == "dgvAgrPC")
                {
                    d.Rows.Clear();
                    //PARA MOSTRAR ORDENADO METER UNA LISTA EN LA OTRA Y HACER UN SORT
                    if (lE1.Count > 0)
                        for (int i = 0; i < lE1.Count; i++)
                            d.Rows.Add(lE1[i].idMaquina, lE1[i].laboratorio, lE1[i].estado, lE1[i].coordenadaX, lE1[i].coordenadaY);

                    if (lE2.Count > 0)
                        for (int i = 0; i < lE2.Count; i++)
                            d.Rows.Add(lE2[i].idMaquina, lE2[i].laboratorio, lE2[i].estado, lE2[i].coordenadaX, lE2[i].coordenadaY);
                }

        }

        private void btnBusGru_Click(object sender, EventArgs e)
        {//GRUPOS
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            CGrupo grupo = new CGrupo();
            string query;

            lF = conSC.leerFragmentos("GRUPOS");

            if (lF.Count > 0 && tbClaGru.Text.Length > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {   //Solo se concidera HORIZONTAL porque así esta fragmentada la Tabla MAQUINAS
                        case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre + " WHERE clavegrupo=" + tbClaGru.Text;
                                    grupo = conS1.buscarGrupo(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre + " WHERE clavegrupo=" + tbClaGru.Text;
                                    grupo = conS2.buscarGrupo(query);
                                    break;
                            }
                            break;
                    }

                    if (grupo != null && grupo.clavegrupo != 0)
                        break;
                }
            }

            if (grupo != null)
            {
                tbMatGru.Text = grupo.materia;
                tbProGru.Text = grupo.profesor;
                cbHorGru.Text = grupo.horario;
                tbAulGru.Text = grupo.aula;
            }
            else
                if (MessageBox.Show("El Grupo No Existe\n¿Desea Registrarlo?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tbMatGru.Focus();
                    tbMatGru.Text = "";
                    tbProGru.Text = "";
                    cbHorGru.Text = "07:00 - 08:00";
                    tbAulGru.Text = "";
                }
        }

        private void btnAltGru_Click(object sender, EventArgs e)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            CGrupo grupo = new CGrupo();
            string query;
            bool b1 = false;

            lF = conSC.leerFragmentos("GRUPOS");

            if (lF.Count > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {
                        case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "INSERT INTO " + f.nombre + "(clavegrupo, materia, profesor, horario, aula) VALUES(" +
                                        tbClaGru.Text + ",'" + tbMatGru.Text + "','" + tbProGru.Text + "','" + cbHorGru.Text + "','" + tbAulGru.Text + "')";
                                    b1 = conS1.agregarGrupo(query);
                                    break;
                                case 2:
                                    query = "INSERT INTO " + f.nombre + "(clavegrupo, materia, profesor, horario, aula) VALUES(" +
                                        tbClaGru.Text + ",'"+ tbMatGru.Text + "','" + tbProGru.Text + "','" + cbHorGru.Text + "','" + tbAulGru.Text + "')";
                                    b1 = conS2.agregarGrupo(query);
                                    break;
                            }
                            break;
                    }
                }
            }

            if (b1)
            {
                MessageBox.Show("El Grupo Se Registro Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                muestraGruReg();
                tbMatGru.Focus();
                tbMatGru.Text = "";
                tbProGru.Text = "";
                cbHorGru.Text = "07:00 - 08:00";
                tbAulGru.Text = "";
            }
        }
        
        private void btnBajGru_Click(object sender, EventArgs e)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            CGrupo grupo = new CGrupo();
            string query;

            lF = conSC.leerFragmentos("GRUPOS");

            if (lF.Count > 0 && tbClaGru.Text.Length > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {   //Solo se concidera HORIZONTAL porque así esta fragmentada la Tabla MAQUINAS
                        case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre + " WHERE clavegrupo=" + tbClaGru.Text;
                                    grupo = conS1.buscarGrupo(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre + " WHERE clavegrupo=" + tbClaGru.Text;
                                    grupo = conS2.buscarGrupo(query);
                                    break;
                            }
                            break;
                    }

                    if (grupo != null)
                    {
                        switch (f.sitio)
                        {
                            case 1:
                                query = "DELETE FROM " + f.nombre + " WHERE clavegrupo=" + tbClaGru.Text;
                                grupo = conS1.buscarGrupo(query);
                                break;
                            case 2:
                                query = "DELETE FROM " + f.nombre + " WHERE clavegrupo=" + tbClaGru.Text;
                                grupo = conS2.buscarGrupo(query);
                                break;
                        }
                        MessageBox.Show("El Grupo Se Elimino Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbClaGru.Focus();
                        tbClaGru.Text = "";
                        tbMatGru.Text = "";
                        tbProGru.Text = "";
                        cbHorGru.Text = "07:00 - 08:00";
                        tbAulGru.Text = "";
                        muestraGruReg();
                        break;
                    }
                }
            }

        }
        
        public void muestraGruReg()
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            List<CGrupo> lG = new List<CGrupo>();
            CGrupo grupo = new CGrupo();
            string query;

            lF = conSC.leerFragmentos("GRUPOS");

            if (lF.Count > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {   case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre;
                                    lG = conS1.buscarGrupos(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre;
                                    lG = conS2.buscarGrupos(query);
                                    break;
                            }
                            break;
                    }
                }
            }

            foreach (DataGridView d in ldgv)
                if (d.Name == "dgvAgrGru")
                {
                    d.Rows.Clear();
                    if (lG.Count > 0)
                        for (int i = 0; i < lG.Count; i++)
                            d.Rows.Add(lG[i].clavegrupo, lG[i].materia, lG[i].profesor, lG[i].horario, lG[i].aula);
                }

        }

        private void btnBusUsr_Click(object sender, EventArgs e)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            CUsuario usuario = new CUsuario();
            string query;

            lF = conSC.leerFragmentos("USUARIOS");

            if (lF.Count > 0 && tbIdUsr.Text.Length > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {   //Solo se concidera HORIZONTAL porque así esta fragmentada la Tabla MAQUINAS
                        case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre + " WHERE idUsuario=" + tbIdUsr.Text;
                                    usuario = conS1.buscarUsuario(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre + " WHERE idUsuario=" + tbIdUsr.Text;
                                    usuario = conS2.buscarUsuario(query);
                                    break;
                            }
                            break;
                    }

                    if (usuario != null)
                        break;
                }
            }

            if (usuario != null)
            {
                tbNomUsr.Text = usuario.nombre;
                tbPassUsr.Text = "******";
                cbTipUsr.Text = usuario.tipo;
            }
            else
                if (MessageBox.Show("El Usuario No Existe\n¿Desea Registrarlo?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tbNomUsr.Focus();
                    tbNomUsr.Text = "";
                    tbPassUsr.Text = "";
                    cbTipUsr.Text = "Becario";
                }
        }

        private void btnAgrUsr_Click(object sender, EventArgs e)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            CUsuario usuario = new CUsuario();
            string query;
            bool b1 = false;

            lF = conSC.leerFragmentos("USUARIOS");

            if (lF.Count > 0 && tbIdUsr.Text.Length > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {
                        case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "INSERT INTO " + f.nombre + "(nombre, contrasena, tipo) VALUES('" +
                                        tbNomUsr.Text + "','" + tbPassUsr.Text + "','" + cbTipUsr.Text + "')";
                                    b1 = conS1.agregarUsuario(query);
                                    break;
                                case 2:
                                    query = "INSERT INTO " + f.nombre + "(nombre, contrasena, tipo) VALUES('" +
                                        tbNomUsr.Text + "','" + tbPassUsr.Text + "','" + cbTipUsr.Text + "')";
                                    b1 = conS2.agregarUsuario(query);
                                    break;
                            }
                            break;
                    }
                }
            }

            if (b1)
            {
                MessageBox.Show("El Usuario Se Registro Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                muestraUsrReg();
                tbIdUsr.Focus();
                tbIdUsr.Text = "";
                tbNomUsr.Text = "";
                tbPassUsr.Text = "";
                cbTipUsr.Text = "Becario";
            }
        }

        private void btnEliUsr_Click(object sender, EventArgs e)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            CUsuario usuario = new CUsuario();
            string query;

            lF = conSC.leerFragmentos("USUARIOS");

            if (lF.Count > 0 && tbIdUsr.Text.Length > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {   //Solo se concidera HORIZONTAL porque así esta fragmentada la Tabla MAQUINAS
                        case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre + " WHERE idUsuario=" + tbIdUsr.Text;
                                    usuario = conS1.buscarUsuario(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre + " WHERE idUsuario=" + tbIdUsr.Text;
                                    usuario = conS2.buscarUsuario(query);
                                    break;
                            }
                            break;
                    }

                    if (usuario != null)
                    {
                        switch (f.sitio)
                        {
                            case 1:
                                query = "DELETE FROM " + f.nombre + " WHERE idUsuario=" + tbIdUsr.Text;
                                usuario = conS1.buscarUsuario(query);
                                break;
                            case 2:
                                query = "DELETE FROM " + f.nombre + " WHERE idUsuario=" + tbIdUsr.Text;
                                usuario = conS2.buscarUsuario(query);
                                break;
                        }
                        MessageBox.Show("El Usuario Se Elimino Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbIdUsr.Focus();
                        tbIdUsr.Text = "";
                        tbNomUsr.Text = "";
                        tbPassUsr.Text = "";
                        cbTipUsr.Text = "Becario";
                        muestraUsrReg();
                        break;
                    }
                }
            }
        }

        public void muestraUsrReg()
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            List<CUsuario> lU = new List<CUsuario>();
            CUsuario usuario = new CUsuario();
            string query;

            lF = conSC.leerFragmentos("USUARIOS");

            if (lF.Count > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {
                        case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre;
                                    lU = conS1.buscarUsuarios(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre;
                                    lU = conS2.buscarUsuarios(query);
                                    break;
                            }
                            break;
                    }
                }
            }

            foreach (DataGridView d in ldgv)
                if (d.Name == "dgvAgrUsr")
                {
                    d.Rows.Clear();
                    if (lU.Count > 0)
                        for (int i = 0; i < lU.Count; i++)
                            d.Rows.Add(lU[i].idUsuario, lU[i].nombre, lU[i].tipo);
                }

        }

        private void btnSelecPC_BackgroundImageChanged(object sender, EventArgs e)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            equipo = new CPC();
            string query;

            lF = conSC.leerFragmentos("MAQUINAS");

            if (lF.Count > 0 && btnSelecPC.Text.Length > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {   //Solo se concidera HORIZONTAL porque así esta fragmentada la Tabla MAQUINAS
                        case "HORIZONTAL":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre + " WHERE idMaquina=" + btnSelecPC.Text;
                                    equipo = conS1.buscarPC(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre + " WHERE idMaquina=" + btnSelecPC.Text;
                                    equipo = conS2.buscarPC(query);
                                    break;
                            }
                            break;
                    }

                    if (equipo != null)
                        break;
                }
            }

            if (equipo != null)
            {
                switch (equipo.estado)
                {
                    case "Disponible":
                        tbClaveAlum.Enabled = true;
                        tbClaveAlum.Text = "";
                        lbNomAA.Text = "Nombre: ";
                        lbGrupAA.Text = "Grupo: ";
                        lbTiemAA.Text = "Tiempo: ";
                        tbClaveAlum.Focus();
                        btnBClave.Enabled = true;
                        btnEntradaAsis.Enabled = true;
                        btnSalirAsis.Enabled = false;
                        btnRevisionbtnRevision.Enabled = false;
                        break;
                    case "Descompuesta":
                        tbClaveAlum.Enabled = false;
                        btnBClave.Enabled = false;
                        btnEntradaAsis.Enabled = false;
                        btnSalirAsis.Enabled = false;
                        btnRevisionbtnRevision.Enabled = false;
                        cbNoFunciona.Focus();
                        //mostrar dialogo de revision con controles desactivados
                        break;
                    case "Ocupada":
                        tbClaveAlum.Text = "";
                        lbNomAA.Text = "Nombre: ";
                        lbGrupAA.Text = "Grupo: ";
                        lbTiemAA.Text = "Tiempo: ";
                        tbClaveAlum.Enabled = false;
                        btnBClave.Enabled = false;
                        btnEntradaAsis.Enabled = false;
                        btnSalirAsis.Enabled = true;
                        btnRevisionbtnRevision.Enabled = true;
                        mostrarAlumno(equipo.idMaquina);
                        break;
                }
            }
            else
                MessageBox.Show("A Ocurrido un Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
        }

        public void buscaAlumno(string clave)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            alumno = new CAlumno();
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
                                    query = "SELECT * FROM " + f.nombre + " WHERE clavealumno = " + clave;
                                    conS1.buscarAlumno1(query, ref alumno);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre + " WHERE clavealumno = " + clave;
                                    conS2.buscarAlumno2(query, ref alumno);
                                    break;
                            }
                            break;
                    }
                }
            }

            if (alumno.claveAlumno != 0 && alumno.nombres != null)
            {
                tbClaveAlum.Text = "";
                lbNomAA.Text = "Nombre: ";
                lbGrupAA.Text = "Grupo: ";
                lbTiemAA.Text = "Tiempo: ";
                tbClaveAlum.Text = alumno.claveAlumno.ToString();
                lbNomAA.Text += " " + alumno.aPaterno + " " + alumno.aMaterno + " " + alumno.nombres;
                lbGrupAA.Text += " " + alumno.grupo;
                lbTiemAA.Text += " " + alumno.tiempo;
            }
            else
                MessageBox.Show("El Alumno no esta Registrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBClave_Click(object sender, EventArgs e)
        {
            if (tbClaveAlum.Text != null && tbClaveAlum.Text.Length > 0)
                buscaAlumno(tbClaveAlum.Text);
        }

        private void btnEntradaAsis_Click(object sender, EventArgs e)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            string query;
            bool b1 = false, b2 = false;
            long idA = 0;

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
                                    query = "INSERT INTO "+ f.nombre + " (claveAlumno, idMaquina, idUsuario, fecha, horaEntrada, horaSalida,revision) VALUES(" +
                                        alumno.claveAlumno.ToString() + "," +
                                        equipo.idMaquina.ToString() + "," +
                                        usuario.idUsuario + "," +
                                        "GETDATE()," +
                                        "GETDATE()," +
                                        "GETDATE()," +
                                        "0)";
                                    b1 = conS1.insertaAsistencia(query, ref idA);
                                    break;
                                case 2:
                                    query = "INSERT INTO " + f.nombre + " (idAsistencia,claveAlumno, idMaquina, idUsuario, fecha, horaEntrada, horaSalida, revision) VALUES(" +
                                        idA + "," +
                                        alumno.claveAlumno.ToString() + "," +
                                        equipo.idMaquina.ToString() + "," +
                                        usuario.idUsuario + "," +
                                        "SYSDATE," +
                                        "TO_CHAR(SYSDATE,'HH24:MI:SS')," +
                                        "TO_CHAR(SYSDATE,'HH24:MI:SS')," +
                                        "0)";
                                    b2 = conS2.insertaAsistencia(query);
                                    break;
                            }
                            break;
                        case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "INSERT INTO " + f.nombre + " (claveAlumno, idMaquina, idUsuario, fecha, horaEntrada, horaSalida,revision) VALUES(" +
                                        alumno.claveAlumno.ToString() + "," +
                                        equipo.idMaquina.ToString() + "," +
                                        usuario.idUsuario + "," +
                                        "GETDATE()," +
                                        "GETDATE()," +
                                        "GETDATE()," +
                                        "0)";
                                    b1 = conS1.insertaAsistencia(query, ref idA);
                                    b2 = true;
                                    break;
                                case 2:
                                    query = "INSERT INTO " + f.nombre + " (claveAlumno, idMaquina, idUsuario, fecha, horaEntrada, horaSalida, revision) VALUES(" +
                                        alumno.claveAlumno.ToString() + "," +
                                        equipo.idMaquina.ToString() + "," +
                                        usuario.idUsuario + "," +
                                        "SYSDATE," +
                                        "TO_CHAR(SYSDATE,'HH24:MI:SS')," +
                                        "TO_CHAR(SYSDATE,'HH24:MI:SS')," +
                                        "0)";
                                    b2 = conS2.insertaAsistencia(query);
                                    b1 = true;
                                    break;
                            }
                            break;
                    }
                }
            }

            if (b1 && b2)
            {
                btnSelecPC.BackgroundImage = null;
                btnSelecPC.Text = "";
                tbClaveAlum.Text = "";
                tbClaveAlum.Enabled = false;
                btnBClave.Enabled = false;
                lbNomAA.Text = "Nombre: ";
                lbGrupAA.Text = "Grupo: ";
                lbTiemAA.Text = "Tiempo: ";
                btnEntradaAsis.Enabled = false;

                ponerNombre();
                //MessageBox.Show("La Asistencia se Registro Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void ponerNombre()
        {
            foreach (Label l in llb)
                if (l.Name == "lb" + equipo.idMaquina)
                {
                    l.Text = alumno.aPaterno + " " + alumno.aMaterno + " " + alumno.nombres;
                    break;
                }

            foreach (Button b in lbtn)
                if (b.Name == "pb" + equipo.idMaquina)
                {
                    b.Image = Image.FromFile("C:\\Users\\dfjpmosh\\Dropbox\\CDA-CDI\\Imagenes\\o.png");
                    break;
                }

            //Cambiar el estado de la maquina a ocupada
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            bool bpc = false;
            string query;

            lF = conSC.leerFragmentos("MAQUINAS");

            if (lF.Count > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {   //Solo se concidera HORIZONTAL porque así esta fragmentada la Tabla MAQUINAS
                        case "HORIZONTAL":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "UPDATE " + f.nombre + " SET estado='Ocupada' WHERE idMaquina=" + equipo.idMaquina;
                                    bpc = conS1.actuzalizarPC(query);
                                    break;
                                case 2:
                                    query = "UPDATE " + f.nombre + " SET estado='Ocupada' WHERE idMaquina=" + equipo.idMaquina;
                                    bpc = conS2.actualizarPC(query);
                                    break;
                            }
                            break;
                    }
                }
            }
        }

        public void mostrarAlumno(long idM)
        {
            List<CAlumno> lAl = new List<CAlumno>();
            List<CAsistencia> lAs = new List<CAsistencia>();
            List<CPC> lPs = new List<CPC>();
            bool enc = false;

            lAl = dameAlumnos(ref lAl);
            lAs = dameAsistencias();
            lPs = damePCs();

            foreach (CAlumno al in lAl)
            {
                foreach (CAsistencia a in lAs)
                    if (al.claveAlumno == a.claveAlumno && a.horaEntrada == a.horaSalida && a.idMaquina == idM)
                    {
                        tbClaveAlum.Text = al.claveAlumno.ToString();
                        lbNomAA.Text += al.aPaterno + " " + al.aMaterno + " " + al.nombres;
                        lbGrupAA.Text += al.grupo;
                        lbTiemAA.Text += al.tiempo;
                        alumno = al;
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
                                    query = "SELECT * FROM " + f.nombre + " ORDER BY claveAlumno ASC";
                                    lA1 = conS1.buscarAlumnoS1(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre + " ORDER BY claveAlumno ASC";
                                    lA2 = conS2.buscarAlumnoS2(query);
                                    break;
                            }
                            break;
                        case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre + " ORDER BY claveAlumno ASC";
                                    lA1 = conS1.buscarAlumnoS1(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre + " ORDER BY claveAlumno ASC";
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

        private void btnSalirAsis_Click(object sender, EventArgs e)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            string query;
            bool b1 = false, b2 = false;
            long idA = buscarAsistencia(equipo.idMaquina);

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
                                    query = "UPDATE " + f.nombre + " SET horaSalida=GETDATE() WHERE idAsistencia=" + idA;
                                    b1 = conS1.salidaAsistencia(query);
                                    break;
                                case 2:
                                    query = "UPDATE " + f.nombre + " SET horaSalida=TO_CHAR(SYSDATE,'HH24:MI:SS') WHERE idAsistencia=" + idA;
                                    b2 = conS2.salidaAsistencia(query);
                                    break;
                            }
                            break;
                        case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "UPDATE " + f.nombre + " SET horaSalida=GETDATE() WHERE idAsistencia=" + idA;
                                    b1 = conS1.salidaAsistencia(query);
                                    b2 = true;
                                    break;
                                case 2:
                                    query = "UPDATE " + f.nombre + " SET horaSalida=TO_CHAR(SYSDATE,'HH24:MI:SS') WHERE idAsistencia=" + idA;
                                    b2 = conS2.salidaAsistencia(query);
                                    b1 = true;
                                    break;
                            }
                            break;
                    }
                }
            }

            if (b1 && b2)
            {
                btnSelecPC.BackgroundImage = null;
                btnSelecPC.Text = "";
                tbClaveAlum.Text = "";
                tbClaveAlum.Enabled = false;
                btnBClave.Enabled = false;
                lbNomAA.Text = "Nombre: ";
                lbGrupAA.Text = "Grupo: ";
                lbTiemAA.Text = "Tiempo: ";
                btnEntradaAsis.Enabled = false;

                salidaEquipo(equipo.idMaquina);
                calculoHoras(idA);//Tambien manda a insertar en la BD
            }
        }

        public long buscarAsistencia(long idM)
        {
            List<CAlumno> lAl = new List<CAlumno>();
            List<CAsistencia> lAs = new List<CAsistencia>();
            List<CPC> lPs = new List<CPC>();
            
            lAl = dameAlumnos(ref lAl);
            lAs = dameAsistencias();
            lPs = damePCs();

            foreach (CAlumno al in lAl)
                foreach (CAsistencia a in lAs)
                    if (al.claveAlumno == a.claveAlumno && a.horaEntrada == a.horaSalida && a.idMaquina == idM)
                        return a.idAsistencia;
            
            return 0;
        }

        public void salidaEquipo(long idMaq)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            bool enc=false;
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
                                    query = "UPDATE " + f.nombre + " SET estado='Disponible' WHERE idMaquina=" + idMaq;
                                    enc = conS1.salidaPC(query);
                                    break;
                                case 2:
                                    query = "UPDATE " + f.nombre + " SET estado='Disponible' WHERE idMaquina=" + idMaq;
                                    enc = conS2.salidaPC(query);
                                    break;
                            }
                            break;
                    }
                }
            }

            if (enc)
            {
                foreach (Label l in llb)
                    if ("lb" + idMaq == l.Name)
                    {
                        l.Text = "";
                        break;
                    }
                foreach (Button b in lbtn)
                    if (b.Name == "pb" + equipo.idMaquina)
                    {
                        b.Image = Image.FromFile("C:\\Users\\dfjpmosh\\Dropbox\\CDA-CDI\\Imagenes\\"+equipo.idMaquina+".png");
                        break;
                    }
            }
            

        }

        public void calculoHoras(long idA)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            CAsistencia asistencia = new CAsistencia();
            CAsistencia primerAsis = new CAsistencia();
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
                                    query = "SELECT * FROM " + f.nombre + " WHERE idAsistencia=" + idA;
                                    asistencia = conS1.buscaAsistencia(query);
                                    query = "SELECT TOP 1 * FROM " + f.nombre + " WHERE claveAlumno=" + alumno.claveAlumno + "ORDER BY fecha, horaEntrada ASC";
                                    primerAsis = conS1.buscaAsistencia(query);
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
                                    query = "SELECT * FROM " + f.nombre + " WHERE idAsistencia=" + idA;
                                    asistencia = conS1.buscaAsistencia(query);
                                    query = "SELECT TOP 1 * FROM " + f.nombre + " WHERE claveAlumno=" + alumno.claveAlumno + "ORDER BY fecha, horaEntrada ASC";
                                    primerAsis = conS1.buscaAsistencia(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre + " WHERE idAsistencia=" + idA;
                                    asistencia = conS2.buscaAsistencia(query);
                                    break;
                            }
                            break;
                    }
                }
            }

            if (asistencia != null && asistencia.idAsistencia > 0)
            {
                DateTime fEntrada = new DateTime(Convert.ToInt32(asistencia.fecha.ToString().Substring(6, 4)),
                                                Convert.ToInt32(asistencia.fecha.ToString().Substring(3, 2)),
                                                Convert.ToInt32(asistencia.fecha.ToString().Substring(0, 2)),
                                                Convert.ToInt32(asistencia.horaEntrada.Substring(0, 2)),
                                                Convert.ToInt32(asistencia.horaEntrada.Substring(3, 2)),
                                                Convert.ToInt32(asistencia.horaEntrada.Substring(6, 2)));
               
                DateTime fSalida = new DateTime(Convert.ToInt32(asistencia.fecha.ToString().Substring(6, 4)),
                                                Convert.ToInt32(asistencia.fecha.ToString().Substring(3, 2)),
                                                Convert.ToInt32(asistencia.fecha.ToString().Substring(0, 2)),
                                                Convert.ToInt32(asistencia.horaSalida.Substring(0, 2)),
                                                Convert.ToInt32(asistencia.horaSalida.Substring(3, 2)),
                                                Convert.ToInt32(asistencia.horaSalida.Substring(6, 2)));

                /*DateTime fprimer = new DateTime(Convert.ToInt32(primerAsis.fecha.ToString().Substring(6, 4)),
                                                Convert.ToInt32(primerAsis.fecha.ToString().Substring(3, 2)),
                                                Convert.ToInt32(primerAsis.fecha.ToString().Substring(0, 2)),
                                                Convert.ToInt32(primerAsis.horaSalida.Substring(0, 2)),
                                                Convert.ToInt32(primerAsis.horaSalida.Substring(3, 2)),
                                                Convert.ToInt32(primerAsis.horaSalida.Substring(6, 2)));*/
                //Esto se puedo simplificar pero lo decide hacer así para ver los calculos
                int horas = (fSalida - fEntrada).Hours;
                int minutos = (fSalida - fEntrada).Minutes;
                int segundos = (fSalida - fEntrada).Seconds;

                int horasAlu = Convert.ToInt32(alumno.tiempo.Substring(0,2));
                int minutosAlu = Convert.ToInt32(alumno.tiempo.Substring(3,2));
                int segundosAlu = Convert.ToInt32(alumno.tiempo.Substring(6, 2));

                int segundosTot;
                int modseg = 0;
                int minutosTot;
                int modmin = 0;
                if ((segundosTot = segundos + segundosAlu) > 59)
                {
                    modseg = segundosTot / 59;
                    segundosTot = segundosTot % 59;                    
                }

                
                if ((minutosTot = minutos + minutosAlu + modseg) > 59)
                {
                    modmin = minutosTot / 59;
                    minutosTot = minutosTot % 59;
                }

                int horasTot = horas + horasAlu + modmin;
                
                


                actualizaTiempoAlumno(horasTot, minutosTot, segundosTot, idA);
            }
        }

        public void actualizaTiempoAlumno(int horas, int minutos, int segundos, long idA)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            //CAlumno alu = new CAlumno();
            string query;
            bool b1 = false;

            lF = conSC.leerFragmentos("ALUMNOS");

            if (lF.Count > 0)
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {
                        case "VERTICAL":
                            List<string> la = new List<string>();
                            la = conSC.leerAtributos(f.id);
                            if(la.Contains("tiempo"))
                                switch (f.sitio)
                                {
                                    case 1:
                                        query = "UPDATE " + f.nombre + " SET tiempo='" + 
                                            horas.ToString("00") + ":" + 
                                            minutos.ToString("00") + ":" +
                                            segundos.ToString("00") + "' WHERE claveAlumno=" + alumno.claveAlumno;
                                        //LLAMAR INSERCION EN S1
                                        b1 = conS1.actualizaAlumno1(query);
                                        break;
                                    case 2:
                                        query = "UPDATE " + f.nombre + " SET tiempo='" +
                                            horas.ToString("00") + ":" +
                                            minutos.ToString("00") + ":" +
                                            segundos.ToString("00") + "' WHERE claveAlumno=" + alumno.claveAlumno;
                                        b1 = conS2.actualizaAlumno2(query);
                                        break;
                                }
                            break;
                    }
                }

                if(b1)
                    MessageBox.Show(alumno.aPaterno + " " + alumno.aMaterno + " " + alumno.nombres + "\n" + 
                                    "Tiempo: " + horas.ToString("00") + ":" + minutos.ToString("00") + ":" + segundos.ToString("00"),
                                    "Tiempo Acumulado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRevisionbtnRevision_Click(object sender, EventArgs e)
        {
            CComentarioA dca = new CComentarioA();
            string comentario = "";
            
            if (dca.ShowDialog() == DialogResult.OK)
            {
                comentario = dca.tbCA.Text;
            }

            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            string query;
            bool b1 = false, b2 = false;
            long idA = buscarAsistencia(equipo.idMaquina);

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
                                    query = "UPDATE " + f.nombre + " SET revision=1, comentarios='" + comentario + "' WHERE idAsistencia=" + idA;
                                    b1 = conS1.actualizaAsistencia(query);
                                    break;
                                case 2:
                                    query = "UPDATE " + f.nombre + " SET revision=1, comentario='" + comentario + "' WHERE idAsistencia=" + idA;
                                    b2 = conS2.actualizaAsistencia(query);
                                    break;
                            }
                            break;
                        case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "UPDATE " + f.nombre + " SET revision=1, comentarios='" + comentario + "' WHERE idAsistencia=" + idA;
                                    b1 = conS1.actualizaAsistencia(query);
                                    break;
                                case 2:
                                    query = "UPDATE " + f.nombre + " SET revision=1, comentario='" + comentario + "' WHERE idAsistencia=" + idA;
                                    b2 = conS2.actualizaAsistencia(query);
                                    break;
                            }
                            break;
                    }
                }
            }

            if (b1 && b2)
            {
                MessageBox.Show("El Comentario Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Se puede llamar a baja 
            }

        }

        private void cbNoFunciona_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbNoFunciona_Click(object sender, EventArgs e)
        {
            FRepMaq frm = new FRepMaq();

            frm.lbMaquinaRep.Text += equipo.idMaquina;
            switch(cbNoFunciona.Checked)
            {
                case true://Se supone que cambio de false a true
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("El Equipo se Reporto Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        repmaquina(equipo.idMaquina);
                    }
                    break;
                case false:
                    //Checar para mostrar la info
                    break;
            }
        }

        public void repmaquina(long idM)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            bool enc = false;
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
                                    query = "UPDATE " + f.nombre + " SET estado='Descompuesta' WHERE idMaquina=" + idM;
                                    enc = conS1.salidaPC(query);
                                    break;
                                case 2:
                                    query = "UPDATE " + f.nombre + " SET estado='Descompuesta' WHERE idMaquina=" + idM;
                                    enc = conS2.salidaPC(query);
                                    break;
                            }
                            break;
                    }
                }
            }

            if (enc)
            {
                foreach (Label l in llb)
                    if ("lb" + idM == l.Name)
                    {
                        l.Text = "";
                        break;
                    }
                foreach (Button b in lbtn)
                    if (b.Name == "pb" + equipo.idMaquina)
                    {
                        b.Image = Image.FromFile("C:\\Users\\dfjpmosh\\Dropbox\\CDA-CDI\\Imagenes\\m.png");
                        break;
                    }
            }
        }

        private void btnImprimirRepGr_Click(object sender, EventArgs e)
        {
            List<CAlumno> lA = new List<CAlumno>();
            CGrupo grupo = new CGrupo();
            //Buscar Grupo
            grupo = buscarGrupo(cbImpRep.Text);
            //Buscar Alumnos en ese grupo
            lA = dameAlumnosRep(cbImpRep.Text);
            //mandar a generar el reporte
            imprimir(grupo, lA);
        }

        public CGrupo buscarGrupo(string idG)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            CGrupo grupo = new CGrupo();
            string query;

            lF = conSC.leerFragmentos("GRUPOS");

            if (lF.Count > 0 )
            {
                foreach (CFragmento f in lF)
                {
                    switch (f.tipo)
                    {   //Solo se concidera HORIZONTAL porque así esta fragmentada la Tabla MAQUINAS
                        case "N":
                            switch (f.sitio)
                            {
                                case 1:
                                    query = "SELECT * FROM " + f.nombre + " WHERE clavegrupo=" + idG;
                                    grupo = conS1.buscarGrupo(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre + " WHERE clavegrupo=" + idG;
                                    grupo = conS2.buscarGrupo(query);
                                    break;
                            }
                            break;
                    }

                    if (grupo != null && grupo.clavegrupo != 0)
                        return grupo;
                }
            }

            return null;
        }

        public List<CAlumno> dameAlumnosRep(string idG)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            List<CAlumno> lA1 = new List<CAlumno>();
            List<CAlumno> lA2 = new List<CAlumno>();
            List<CAlumno> lA3 = new List<CAlumno>();
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
                                    query = "SELECT * FROM " + f.nombre + " ORDER BY claveAlumno ASC";
                                    lA1 = conS1.buscarAlumnoS1(query);
                                    break;
                                case 2:
                                    query = "SELECT * FROM " + f.nombre + " ORDER BY claveAlumno ASC";
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

                    if (lA2[i].grupo == idG)
                        lA3.Add(lA2[i]);
                }

            return lA3;

        }   

        public void imprimir(CGrupo grupo, List<CAlumno> lA)
        {
            PrintPreviewDialog vistaPrevia = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();

            if (lA.Count > 0)
            {
                crearArchivoVentas(grupo, lA);

                try
                {
                    streamParaImp = new StreamReader("C:\\temporalSW\\ejemplo.txt");
                    try
                    {
                        Fuente = new Font("Lucida Console", 10);
                        pd = new PrintDocument();
                        pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                        vistaPrevia.Document = pd;

                        Form f = vistaPrevia as Form;
                        Control[] ts = vistaPrevia.Controls.Find("toolStrip1", true);
                        ToolStrip to = ts[0] as ToolStrip;
                        to.Items.RemoveAt(0);
                        f.WindowState = FormWindowState.Maximized;
                        f.ShowDialog();
                        streamParaImp.Close();

                        streamParaImp = new StreamReader("C:\\temporalSW\\ejemplo.txt");
                        pd = new PrintDocument();
                        pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                        pd.Print();
                    }
                    finally
                    {
                        streamParaImp.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se Puede Imprimir\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    File.Delete("C:\\temporalSW\\ejemplo.txt");
                }
            }
        }

        private void crearArchivoVentas(CGrupo grupo, List<CAlumno> lA)
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\temporalSW\\ejemplo.txt", true, Encoding.ASCII);

                sw.WriteLine("                          HORAS ALUMNO");
                sw.WriteLine("");
                sw.WriteLine("Fecha: " + DateTime.Now.ToLongDateString());
                sw.WriteLine("");
                sw.WriteLine("Clave Grupo: " + grupo.clavegrupo);
                sw.WriteLine("Materia: " + grupo.materia);
                sw.WriteLine("Profesor: " + grupo.profesor);
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("========================================================================");
                sw.WriteLine("[Clave]      " + "[Nombre]                    " + "[Tiempo]");
                sw.WriteLine("========================================================================");
                sw.WriteLine("");
                foreach (CAlumno a in lA)
                {
                    sw.WriteLine(a.claveAlumno + calculaEspacio(a.claveAlumno.ToString(),10) +" "+ a.aPaterno + " " + a.aMaterno + " " + a.nombres + calculaEspacio(a.aPaterno+a.aMaterno+a.nombres, 30) + " " + a.tiempo);
                }
                sw.WriteLine("");
                
                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se Puede Imprimir\n" + e.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float lineasPorPagina = 0;
            float yPos = 0;
            int count = 0;
            float margenIzquierda = ev.MarginBounds.Left;
            float margenArriba = ev.MarginBounds.Top;
            string linea = null;

            lineasPorPagina = ev.MarginBounds.Height / Fuente.GetHeight(ev.Graphics);

            while (count < lineasPorPagina && ((linea = streamParaImp.ReadLine()) != null))
            {
                yPos = margenArriba + (count * Fuente.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(linea, Fuente, Brushes.Black, margenIzquierda, yPos, new StringFormat());
                count++;
            }

            if (linea != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }

        private string calculaEspacio(string c, int t)
        {
            int x;
            int s = c.Length;
            int es = t - s;
            string cad = "";
            for (x = 0; x < es; x++)
                cad += " ";
            return cad;
        }

        public void imprimirMaqRep(List<CPC> lP)
        {
            PrintPreviewDialog vistaPrevia = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();

            if (lP.Count > 0)
            {
                crearArchivoMaquinas(lP);

                try
                {
                    streamParaImp = new StreamReader("C:\\temporalSW\\ejemplo.txt");
                    try
                    {
                        Fuente = new Font("Lucida Console", 10);
                        pd = new PrintDocument();
                        pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                        vistaPrevia.Document = pd;

                        Form f = vistaPrevia as Form;
                        Control[] ts = vistaPrevia.Controls.Find("toolStrip1", true);
                        ToolStrip to = ts[0] as ToolStrip;
                        to.Items.RemoveAt(0);
                        f.WindowState = FormWindowState.Maximized;
                        f.ShowDialog();
                        streamParaImp.Close();

                        streamParaImp = new StreamReader("C:\\temporalSW\\ejemplo.txt");
                        pd = new PrintDocument();
                        pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                        pd.Print();
                    }
                    finally
                    {
                        streamParaImp.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se Puede Imprimir\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    File.Delete("C:\\temporalSW\\ejemplo.txt");
                }
            }
        }

        private void crearArchivoMaquinas(List<CPC> lP)
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\temporalSW\\ejemplo.txt", true, Encoding.ASCII);

                sw.WriteLine("                          EQUIPO DESCOMPUESTO");
                sw.WriteLine("");
                sw.WriteLine("Fecha: " + DateTime.Now.ToLongDateString());
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("========================================================================");
                sw.WriteLine("[Id] " + "[Laboratorio]   " + "[Estado]");
                sw.WriteLine("========================================================================");
                sw.WriteLine("");
                foreach (CPC p in lP)
                {
                    sw.WriteLine(p.idMaquina + calculaEspacio(p.idMaquina.ToString(), 5) + " " + p.laboratorio + calculaEspacio(p.laboratorio, 15) + " " + p.estado);
                }
                sw.WriteLine("");

                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se Puede Imprimir\n" + e.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImpDesc_Click(object sender, EventArgs e)
        {
            List<CPC> lE = new List<CPC>();

            lE = damePCsDesc();

            imprimirMaqRep(lE);
        }

        public List<CPC> damePCsDesc()
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
    }
}
