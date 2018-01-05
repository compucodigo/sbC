using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DClasificacion
    {
        private int _IdClasificacion;
        private string _Descripcion;
        private int _Status;
        private string _TextoBuscar;
        public int IdClasificacion
        {
            get { return _IdClasificacion; }
            set { _IdClasificacion = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        //Crear método constructor
        public DClasificacion()
        {

        }
        //Crar método constructor con todos los parametros
        public DClasificacion(int idclasificacion, string descripcion, int status)
        {
            IdClasificacion = idclasificacion;
            Descripcion = descripcion;
            Status = status;
        }
        //Método insertar
        public string Insertar(DClasificacion Clasificacion)
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
                SqlCmd.CommandText = "spInsertar_Clasificacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdClasificacion = new SqlParameter();
                ParIdClasificacion.ParameterName = "@idclasificacion";
                ParIdClasificacion.SqlDbType = SqlDbType.Int;
                ParIdClasificacion.Value = Clasificacion.IdClasificacion;
                SqlCmd.Parameters.Add(ParIdClasificacion);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Clasificacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParStatus = new SqlParameter();
                ParStatus.ParameterName = "@status";
                ParStatus.SqlDbType = SqlDbType.SmallInt;
                ParStatus.Value = Clasificacion.Status;
                SqlCmd.Parameters.Add(ParStatus);

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
        public string Editar(DClasificacion Clasificacion)
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
                SqlCmd.CommandText = "spEditar_Clasificacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdClasificacion = new SqlParameter();
                ParIdClasificacion.ParameterName = "@idclasificacion";
                ParIdClasificacion.SqlDbType = SqlDbType.Int;
                ParIdClasificacion.Value = Clasificacion.IdClasificacion;
                SqlCmd.Parameters.Add(ParIdClasificacion);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Clasificacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParStatus = new SqlParameter();
                ParStatus.ParameterName = "@status";
                ParStatus.SqlDbType = SqlDbType.SmallInt;
                ParStatus.Value = Clasificacion.Status;
                SqlCmd.Parameters.Add(ParStatus);

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
        public string Eliminar(DClasificacion Clasificacion)
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
                SqlCmd.CommandText = "spEliminar_Clasificacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdClasificacion = new SqlParameter();
                ParIdClasificacion.ParameterName = "@idclasificacion";
                ParIdClasificacion.SqlDbType = SqlDbType.Int;
                ParIdClasificacion.Value = Clasificacion.IdClasificacion;
                SqlCmd.Parameters.Add(ParIdClasificacion);

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
            DataTable dtResultado = new DataTable("Clasificacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spMostrar_Clasificacion";
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
        public DataTable BuscarNombre(DClasificacion Clasificacion)
        {
            DataTable dtResultado = new DataTable("Clasificacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spBuscar_Clasificacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTexto = new SqlParameter();
                ParTexto.ParameterName = "@textobuscar";
                ParTexto.SqlDbType = SqlDbType.NVarChar;
                ParTexto.Size = 50;
                ParTexto.Value = Clasificacion.TextoBuscar;
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
