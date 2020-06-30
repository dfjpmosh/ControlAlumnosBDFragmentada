using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CDA_CDI
{
    class CConexionS1
    {
        private String conexion = "Data Source=localhost; Initial Catalog=SITIO1;Integrated Security=true;";

        public CUsuario buscarUsuario(string query)
        {
            CUsuario usuario;

            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        usuario = new CUsuario();
                        usuario.idUsuario = reader.GetInt64(0);
                        usuario.nombre = reader.GetString(1);
                        usuario.contrasena = reader.GetString(2);
                        usuario.tipo = reader.GetString(3);

                        return usuario;
                    }
                }
                cnn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al Leer:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public bool insertaAlumno1(string query)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                //MessageBox.Show("El Alumno1 Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al insertar A1:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public bool insertaAlumno2(string query)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                //MessageBox.Show("El Alumno2 Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al insertar A2:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public void buscarAlumno1(string query, ref CAlumno alumno)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        alumno.claveAlumno = reader.GetInt64(0);
                        alumno.tiempo = reader.GetString(1);
                        alumno.estado = reader.GetString(2);
                    }
                }
                cnn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al Leer:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void buscarAlumno2(string query, ref CAlumno alumno)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        alumno.nombres = reader.GetString(1);
                        alumno.aPaterno = reader.GetString(2);
                        alumno.aMaterno = reader.GetString(3);
                        alumno.carrera = reader.GetString(4);
                        alumno.grupo = reader.GetString(5);
                    }
                }
                cnn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al Leer:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool inscribeAlumno1(string query, List<string> la, List<string> lv)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                for (int i = 1; i < la.Count; i++)
                {
                    cmd.Parameters.AddWithValue(la[i], lv[i - 1]);
                }
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                //MessageBox.Show("El Alumno1 Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al insertar A1:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public bool inscribeAlumno2(string query, List<string> la, List<string> lv)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                for (int i = 1; i < la.Count; i++)
                {
                    cmd.Parameters.AddWithValue(la[i], lv[i - 1]);
                }
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                //MessageBox.Show("El Alumno1 Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al insertar A1:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public List<CAlumno> buscarAlumnoS1(string query)
        {
            List<CAlumno> lA = new List<CAlumno>();
            CAlumno alumno;
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        alumno = new CAlumno();
                        alumno.claveAlumno = reader.GetInt64(0);
                        alumno.tiempo = reader.GetString(1);
                        alumno.estado = reader.GetString(2);

                        lA.Add(alumno);
                    }
                }
                cnn.Close();
                return lA;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al Leer:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public List<CAlumno> buscarAlumnoS2(string query)
        {
            List<CAlumno> lA = new List<CAlumno>();
            CAlumno alumno;
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        alumno = new CAlumno();
                        alumno.nombres = reader.GetString(1);
                        alumno.aPaterno = reader.GetString(2);
                        alumno.aMaterno = reader.GetString(3);
                        alumno.carrera = reader.GetString(4);
                        alumno.grupo = reader.GetString(5);

                        lA.Add(alumno);
                    }
                }
                cnn.Close();
                return lA;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al Leer:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public CPC buscarPC(string query)
        {
            CPC pc;

            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pc = new CPC();
                        pc.idMaquina = reader.GetInt64(0);
                        pc.laboratorio = reader.GetString(1);
                        pc.estado = reader.GetString(2);
                        pc.coordenadaX = reader.GetInt64(3);
                        pc.coordenadaY = reader.GetInt64(4);

                        return pc;
                    }
                }
                cnn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al Leer:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public bool agregarPC(string query)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                //MessageBox.Show("El Alumno1 Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al insertar A1:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public List<CPC> buscarEquipoS1(string query)
        {
            List<CPC> lE = new List<CPC>();
            CPC pc;
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pc = new CPC();
                        pc.idMaquina = reader.GetInt64(0);
                        pc.laboratorio = reader.GetString(1);
                        pc.estado = reader.GetString(2);
                        pc.coordenadaX = reader.GetInt64(3);
                        pc.coordenadaY = reader.GetInt64(4);
                        
                        lE.Add(pc);
                    }
                }
                cnn.Close();
                return lE;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al Leer:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public CGrupo buscarGrupo(string query)
        {
            CGrupo grupo;

            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        grupo = new CGrupo();
                        grupo.clavegrupo = reader.GetInt64(0);
                        grupo.materia = reader.GetString(1);
                        grupo.profesor = reader.GetString(2);
                        grupo.horario = reader.GetString(3);
                        grupo.aula = reader.GetString(4);

                        return grupo;
                    }
                }
                cnn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al Leer:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public bool agregarGrupo(string query)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                //MessageBox.Show("El Alumno1 Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al insertar A1:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public List<CGrupo> buscarGrupos(string query)
        {
            List<CGrupo> lG = new List<CGrupo>();
            CGrupo grupo;
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        grupo = new CGrupo();
                        grupo.clavegrupo = reader.GetInt64(0);
                        grupo.materia = reader.GetString(1);
                        grupo.profesor = reader.GetString(2);
                        grupo.horario = reader.GetString(3);
                        grupo.aula = reader.GetString(4);

                        lG.Add(grupo);
                    }
                }
                cnn.Close();
                return lG;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al Leer:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public bool agregarUsuario(string query)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                //MessageBox.Show("El Alumno1 Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al insertar A1:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public List<CUsuario> buscarUsuarios(string query)
        {
            List<CUsuario> lU = new List<CUsuario>();
            CUsuario usuario;
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        usuario = new CUsuario();
                        usuario.idUsuario = reader.GetInt64(0);
                        usuario.nombre = reader.GetString(1);
                        usuario.contrasena = reader.GetString(2);
                        usuario.tipo = reader.GetString(3);

                        lU.Add(usuario);
                    }
                }
                cnn.Close();
                return lU;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al Leer:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public bool insertaAsistencia(string query, ref long idA)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                //MessageBox.Show("El Alumno1 Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al insertar A1:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM ASISTENCIAS1 ORDER BY idAsistencia DESC", cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                        idA = reader.GetInt64(0);                
                cnn.Close();
                //MessageBox.Show("El Alumno1 Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error el recuperar ID:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;
        }

        public bool actuzalizarPC(string query)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                //MessageBox.Show("El Alumno1 Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al insertar A1:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public List<CAsistencia> buscarAsistencias(string query)
        {
            List<CAsistencia> lA = new List<CAsistencia>();
            CAsistencia asistencia;
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        asistencia = new CAsistencia();
                        asistencia.idAsistencia = reader.GetInt64(0);
                        asistencia.claveAlumno = reader.GetInt64(1);
                        asistencia.idMaquina = reader.GetInt64(2);
                        asistencia.idUsuario = reader.GetInt64(3);
                        asistencia.fecha = reader.GetDateTime(4).ToString();
                        asistencia.horaEntrada = reader.GetTimeSpan(5).ToString().Substring(0, 8);
                        asistencia.horaSalida = reader.GetTimeSpan(6).ToString().Substring(0,8);
                        asistencia.revision = reader.GetString(7);
                        if (asistencia.revision=="1")
                            asistencia.comentarios = reader.GetString(8);
                        
                        lA.Add(asistencia);
                    }
                }
                cnn.Close();
                return lA;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al Leer:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public bool salidaAsistencia(string query)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                //MessageBox.Show("El Alumno1 Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al insertar A1:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public bool salidaPC(string query)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                //MessageBox.Show("El Alumno1 Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al insertar A1:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public CAsistencia buscaAsistencia(string query)
        {
            CAsistencia asistencia;

            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        asistencia = new CAsistencia();
                        asistencia.idAsistencia = reader.GetInt64(0);
                        asistencia.claveAlumno = reader.GetInt64(1);
                        asistencia.idMaquina = reader.GetInt64(2);
                        asistencia.idUsuario = reader.GetInt64(3);
                        asistencia.fecha = reader.GetDateTime(4).ToString();
                        asistencia.horaEntrada = reader.GetTimeSpan(5).ToString().Substring(0, 8);
                        asistencia.horaSalida = reader.GetTimeSpan(6).ToString().Substring(0, 8);
                        asistencia.revision = reader.GetString(7);
                        if (asistencia.revision == "1")
                            asistencia.comentarios = reader.GetString(8);

                        return asistencia;
                    }
                }
                cnn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al Leer:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        public bool actualizaAlumno1(string query)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                //MessageBox.Show("El Alumno1 Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al insertar A1:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public bool actualizaAsistencia(string query)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(conexion);
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                //MessageBox.Show("El Alumno1 Se Agrego Satisfactoriamente: ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrió un error al insertar Asis1:\n" + e, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
