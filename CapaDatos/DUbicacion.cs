using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DUbicacion
    {
        private int _IdUbicacion;
        private string _Descripcion;
        private int _Movimiento;
        private int _Status;
        private string _TextoBuscar;

        public int IdUbicacion
        {
            get { return _IdUbicacion; }
            set { _IdUbicacion = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public int Movimiento
        {
            get { return _Movimiento; }
            set { _Movimiento = value; }
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
        public DUbicacion()
        {

        }
        //Crar método constructor con todos los parametros
        public DUbicacion(int idubicacion, string descripcion, int movimiento, int status)
        {
            IdUbicacion = idubicacion;
            Descripcion = descripcion;
            Movimiento = movimiento;
            Status = status;
        }
        //Método insertar
        public string Insertar(DUbicacion Ubicacion)
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
                SqlCmd.CommandText = "spInsertar_Ubicacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUbicacion = new SqlParameter();
                ParIdUbicacion.ParameterName = "@idubicacion";
                ParIdUbicacion.SqlDbType = SqlDbType.Int;
                ParIdUbicacion.Value = Ubicacion.IdUbicacion;
                SqlCmd.Parameters.Add(ParIdUbicacion);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Ubicacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParMovimiento = new SqlParameter();
                ParMovimiento.ParameterName = "@movimiento";
                ParMovimiento.SqlDbType = SqlDbType.SmallInt;
                ParMovimiento.Value = Ubicacion.Movimiento;
                SqlCmd.Parameters.Add(ParMovimiento);

                SqlParameter ParStatus = new SqlParameter();
                ParStatus.ParameterName = "@status";
                ParStatus.SqlDbType = SqlDbType.SmallInt;
                ParStatus.Value = Ubicacion.Status;
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
        public string Editar(DUbicacion Ubicacion)
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
                SqlCmd.CommandText = "spEditar_Ubicacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUbicacion = new SqlParameter();
                ParIdUbicacion.ParameterName = "@idubicacion";
                ParIdUbicacion.SqlDbType = SqlDbType.Int;
                ParIdUbicacion.Value = Ubicacion.IdUbicacion;
                SqlCmd.Parameters.Add(ParIdUbicacion);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Ubicacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParMovimiento = new SqlParameter();
                ParMovimiento.ParameterName = "@movimiento";
                ParMovimiento.SqlDbType = SqlDbType.SmallInt;
                ParMovimiento.Value = Ubicacion.Movimiento;
                SqlCmd.Parameters.Add(ParMovimiento);

                SqlParameter ParStatus = new SqlParameter();
                ParStatus.ParameterName = "@status";
                ParStatus.SqlDbType = SqlDbType.SmallInt;
                ParStatus.Value = Ubicacion.Status;
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
        public string Eliminar(DUbicacion Ubicacion)
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
                SqlCmd.CommandText = "spEliminar_Ubicacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUbicacion = new SqlParameter();
                ParIdUbicacion.ParameterName = "@idubicacion";
                ParIdUbicacion.SqlDbType = SqlDbType.Int;
                ParIdUbicacion.Value = Ubicacion.IdUbicacion;
                SqlCmd.Parameters.Add(ParIdUbicacion);


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
            DataTable dtResultado = new DataTable("Ubicacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spMostrar_Ubicacion";
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
        public DataTable BuscarNombre(DUbicacion Ubicacion)
        {
            DataTable dtResultado = new DataTable("Ubicacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spBuscar_Ubicacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTexto = new SqlParameter();
                ParTexto.ParameterName = "@textobuscar";
                ParTexto.SqlDbType = SqlDbType.NVarChar;
                ParTexto.Size = 50;
                ParTexto.Value = Ubicacion.TextoBuscar;
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
