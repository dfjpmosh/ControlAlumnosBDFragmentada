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
    public partial class FRegAlumno : Form
    {
        public FRegAlumno()
        {
            InitializeComponent();
        }

        //FALTA VALIDAR LOS CONTROLES QUE NO SEAN NULL O ESTEN VACIOS
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CConexionSC conSC = new CConexionSC();
            CConexionS1 conS1 = new CConexionS1();
            CConexionS2 conS2 = new CConexionS2();
            CAlumno alu = new CAlumno();
            string query;
            bool b1=false, b2=false;

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
                            query = "INSERT INTO " + f.nombre + "(";
                            for(int i=0; i<la.Count-1; i++)
                                query += la[i] + ",";
                            query += la[la.Count-1];
                            switch (f.sitio)
                            {
                                case 1:
                                    query += ") VALUES(" + tbClaReg.Text + ",'00:00:00', 'ALTA')";
                                    //LLAMAR INSERCION EN S1
                                    b1 = conS1.insertaAlumno1(query);
                                    break;
                                case 2:
                                    query += ") VALUES(" + tbClaReg.Text + ",'" + tbNomReg.Text
                                        + "','" + tbAPReg.Text + "','" + tbAMReg.Text
                                        + "','" + cbCarReg.Text + "','" + cbGruReg.Text + "')";
                                    //LLAMAR INSERCION EN S2
                                    b2 = conS2.insertaAlumno2(query);
                                    break;
                            }
                            break;
                    }
                }
            }

            if (b1 && b2)
                MessageBox.Show("El Alumno Se Registro Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

    }
}
