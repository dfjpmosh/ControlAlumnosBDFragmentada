using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CDA_CDI
{
    class CConexionSC
    {
        private String conexion = "Data Source=localhost; Initial Catalog=SITIOCENTRAL;Integrated Security=true;";

        public List<CFragmento> leerFragmentos(string tabla)
        {
            List<CFragmento> lF = new List<CFragmento>();
            CFragmento fragmento;

            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                string query = "SELECT * FROM FRAGMENTOS WHERE tabla = '"+ tabla +"'";
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {//switchear si es vertical u horizontal para que no truenen los null
                        fragmento = new CFragmento();
                        fragmento.id = reader.GetInt32(0);
                        fragmento.nombre = reader.GetString(1);
                        fragmento.tabla = reader.GetString(2);
                        fragmento.tipo = reader.GetString(3);
                        fragmento.sitio = reader.GetInt32(4);
                        fragmento.condicion = reader.GetString(5);
                                                
                        lF.Add(fragmento);
                    }
                }
                cnn.Close();
                return lF;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al Leer:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public List<string> leerAtributos(int idf)
        {
            List<string> la = new List<string>();
            
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                string query = "SELECT * FROM ATRIBUTOS WHERE idFragmento = '" + idf + "'";
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        la.Add(reader.GetString(2));
                    }
                }
                cnn.Close();
                return la;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al Leer:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
    }
}
