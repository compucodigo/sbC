using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DBanco
    {
        private int _IdBanco;
        private string _Descripcion;
        private string _TextoBuscar;

        public int IdBanco
        {
            get { return _IdBanco; }
            set { _IdBanco = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        //Contructor Vacio
        public DBanco()
        {

        }
        //Método contructor con todos sus parametros
        public DBanco(int idbanco, string descrpcion, string textobuscar)
        {
            IdBanco = idbanco;
            Descripcion = descrpcion;
            TextoBuscar = textobuscar;
        }
        //Método insertar
        public string Insertar(DBanco Banco)
        {
            string strRpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCon.Open();
                //Definir comandos para envio de parametros
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spInsertar_Banco";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdBanco = new SqlParameter();
                ParIdBanco.ParameterName = "@idbanco";
                ParIdBanco.SqlDbType = SqlDbType.Int;
                ParIdBanco.Value = Banco.IdBanco;
                SqlCmd.Parameters.Add(ParIdBanco);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Banco.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //ejecutar comando o .execute en VB
                strRpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se completo el registro";
            }
            catch (Exception ex)
            {
                strRpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return strRpta;
        }
        //Método editar
        public string Editar(DBanco Banco)
        {
            string strRpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCon.Open();
                //Definir comandos para envio de parametros
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spEditar_Banco";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdBanco = new SqlParameter();
                ParIdBanco.ParameterName = "@idbanco";
                ParIdBanco.SqlDbType = SqlDbType.Int;
                ParIdBanco.Value = Banco.IdBanco;
                SqlCmd.Parameters.Add(ParIdBanco);

                SqlParameter ParDescricpion = new SqlParameter();
                ParDescricpion.ParameterName = "@descripcion";
                ParDescricpion.SqlDbType = SqlDbType.VarChar;
                ParDescricpion.Size = 50;
                ParDescricpion.Value = Banco.Descripcion;
                SqlCmd.Parameters.Add(ParDescricpion);

                //ejecutar comando o .execute en VB
                strRpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se completo el registro";
            }
            catch (Exception ex)
            {
                strRpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return strRpta;
        }
        //Método Eliminar
        public string Eliminar(DBanco Banco)
        {
            string strRpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCon.Open();
                //Definir comandos para envio de parametros
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spEliminar_Banco";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdBanco = new SqlParameter();
                ParIdBanco.ParameterName = "@idbanco";
                ParIdBanco.SqlDbType = SqlDbType.Int;
                ParIdBanco.Value = Banco.IdBanco;
                SqlCmd.Parameters.Add(ParIdBanco);


                //ejecutar comando o .execute en VB
                strRpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino el registro";
            }
            catch (Exception ex)
            {
                strRpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return strRpta;

        }
        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable dtResultado = new DataTable("Banco");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spMostrar_Banco";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }
            return dtResultado;
        }
        //Método Buscar 
        public DataTable BuscarNombre(DBanco Banco)
        {
            DataTable dtResultado = new DataTable("Banco");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spBuscar_Banco";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTexto = new SqlParameter();
                ParTexto.ParameterName = "@textobuscar";
                ParTexto.SqlDbType = SqlDbType.NVarChar;
                ParTexto.Size = 50;
                ParTexto.Value = Banco.TextoBuscar;
                SqlCmd.Parameters.Add(ParTexto);


                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }
            return dtResultado;
        }
    }
}
