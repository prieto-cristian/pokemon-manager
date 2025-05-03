using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonManager.negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector{
            get{ return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = "Server=.\\SQLEXPRESS; Data Source=POKEDEX_DB; Integrated Security=true;";
            comando = new SqlCommand();
            comando.Connection = conexion;
        }

        public void SetearConsulta(string consultaSql)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consultaSql;
        }

        public void ejecutarConsulta()
        {
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Guardar()
        {
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void CerrarConexion()
        {
            if(lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }

        public void parametrizarConsulta(string nombreParametro, object valor)
        {
            comando.Parameters.AddWithValue(nombreParametro, valor);
        }
    }
}
