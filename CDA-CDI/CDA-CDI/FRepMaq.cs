using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CDA_CDI
{
    public partial class FRepMaq : Form
    {
        List<CUsuario> lU;

        public FRepMaq()
        {
            InitializeComponent();
            cargaUsuario();
        }

        public void cargaUsuario()
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            lU = new List<CUsuario>();
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

            cbBecarioRep.Text = "Seleccionar";
            cbBecarioRep.Items.Clear();
            foreach (CUsuario u in lU)
                cbBecarioRep.Items.Add(u.nombre);

        }

        private void btnAcepRep_Click(object sender, EventArgs e)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            long idU;
            string query;
            bool b1 = false;

            idU = buscarIdU(cbBecarioRep.Text);

            lF = conSC.leerFragmentos("REPNOFUNCIONA");

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
                                    query = "INSERT INTO " + f.nombre + "(reporto, idUsuario, fecha, hora, idMaquina, descripcion) VALUES('" +
                                        tbReportoRep.Text + "'," + 
                                        idU + "," + 
                                        "GETDATE()," +
                                        "GETDATE()," +
                                        lbMaquinaRep.Text.Substring(lbMaquinaRep.Text.Length-2) + ",'" +
                                        tbDescRep.Text + "')";
                                    b1 = conS1.agregarUsuario(query);
                                    break;
                                case 2:
                                    break;
                            }
                            break;
                    }
                }
            }

            if (b1)
            {
                //MessageBox.Show("El Usuario Se Registro Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        public long buscarIdU(string nom)
        {
            foreach (CUsuario u in lU)
                if (u.nombre == nom)
                    return u.idUsuario;

            return 0;
        }
    }
}
