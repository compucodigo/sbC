using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DUnidad
    {
        private int _idunidad;
        private string _descripcion;
        private DateTime _fecha;
        private int _dime;
        private int _fec;
        private int _inve;
        private int _seri;
        private string _TextoBuscar;
        public int Idunidad
        {
            get { return _idunidad; }
            set { _idunidad = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public int Dime
        {
            get { return _dime; }
            set { _dime = value; }
        }
        public int Fec
        {
            get { return _fec; }
            set { _fec = value; }
        }
        public int Inve
        {
            get { return _inve; }
            set { _inve = value; }
        }
        public int Seri
        {
            get { return _seri; }
            set { _seri = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        //Constructor vacio
        public DUnidad()
        {

        }
        //Constructor con todos los parametros
        public DUnidad(int idunidad, string descripcion, DateTime fecha, int dime, int fec, int inve, int seri, string textobuscar)
        {
            this.Idunidad = idunidad;
            this.Descripcion = descripcion;
            this.Fecha = fecha;
            this.Dime = dime;
            this.Fec = fec;
            this.Inve = inve;
            this.Seri = seri;
            this.TextoBuscar = textobuscar;
            
        }
        //Método Insertar 
        public string Insertar(DUnidad Unidad)
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
                SqlCmd.CommandText = "spinsertar_unidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUnidad = new SqlParameter();
                ParIdUnidad.ParameterName = "@idunidad";
                ParIdUnidad.SqlDbType = SqlDbType.Int;
                ParIdUnidad.Value = Unidad.Idunidad;                
                SqlCmd.Parameters.Add(ParIdUnidad);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Unidad.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;                
                ParFecha.Value = Unidad.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParDime = new SqlParameter();
                ParDime.ParameterName = "@dime";
                ParDime.SqlDbType = SqlDbType.SmallInt;
                ParDime.Value = Unidad.Dime;
                SqlCmd.Parameters.Add(ParDime);

                SqlParameter ParFec = new SqlParameter();
                ParFec.ParameterName = "@fec";
                ParFec.SqlDbType = SqlDbType.SmallInt;
                ParFec.Value = Unidad.Fec;
                SqlCmd.Parameters.Add(ParFec);

                SqlParameter ParInve = new SqlParameter();
                ParInve.ParameterName = "@inve";
                ParInve.SqlDbType = SqlDbType.SmallInt;
                ParInve.Value = Unidad.Inve;
                SqlCmd.Parameters.Add(ParInve);

                SqlParameter ParSeri = new SqlParameter();
                ParSeri.ParameterName = "@seri";
                ParSeri.SqlDbType = SqlDbType.SmallInt;
                ParSeri.Value = Unidad.Seri;
                SqlCmd.Parameters.Add(ParSeri);

                //ejecutar comando o .execute en VB
                strRpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se completo el registro";
                            }
            catch(Exception ex)
            {
                strRpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return strRpta;
        }
        //Método Editar
        public string Editar(DUnidad Unidad)
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
                SqlCmd.CommandText = "speditar_unidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUnidad = new SqlParameter();
                ParIdUnidad.ParameterName = "@idunidad";
                ParIdUnidad.SqlDbType = SqlDbType.Int;
                ParIdUnidad.Value = Unidad.Idunidad;
                SqlCmd.Parameters.Add(ParIdUnidad);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Unidad.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.DateTime;
                ParFecha.Value = Unidad.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParDime = new SqlParameter();
                ParDime.ParameterName = "@dime";
                ParDime.SqlDbType = SqlDbType.SmallInt;
                ParDime.Value = Unidad.Dime;
                SqlCmd.Parameters.Add(ParDime);

                SqlParameter ParFec = new SqlParameter();
                ParFec.ParameterName = "@fec";
                ParFec.SqlDbType = SqlDbType.SmallInt;
                ParFec.Value = Unidad.Fec;
                SqlCmd.Parameters.Add(ParFec);

                SqlParameter ParInve = new SqlParameter();
                ParInve.ParameterName = "@inve";
                ParInve.SqlDbType = SqlDbType.SmallInt;
                ParInve.Value = Unidad.Inve;
                SqlCmd.Parameters.Add(ParInve);

                SqlParameter ParSeri = new SqlParameter();
                ParSeri.ParameterName = "@seri";
                ParSeri.SqlDbType = SqlDbType.SmallInt;
                ParSeri.Value = Unidad.Seri;
                SqlCmd.Parameters.Add(ParSeri);

                //ejecutar comando o .execute en VB
                strRpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el registro";
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
        public string Eliminar(DUnidad Unidad)
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
                SqlCmd.CommandText = "speliminar_unidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdUnidad = new SqlParameter();
                ParIdUnidad.ParameterName = "@idunidad";
                ParIdUnidad.SqlDbType = SqlDbType.Int;
                ParIdUnidad.Value = Unidad.Idunidad;
                SqlCmd.Parameters.Add(ParIdUnidad);


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
        public DataTable Mostrar(int OpcionPar)
        {
            DataTable dtResultado = new DataTable("Unidad");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_unidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParOpcion = new SqlParameter();
                ParOpcion.ParameterName = "@Opcion";
                ParOpcion.SqlDbType = SqlDbType.Int;
                ParOpcion.Value = OpcionPar;
                SqlCmd.Parameters.Add(ParOpcion);

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(dtResultado);
            }
            catch(Exception ex)
            {
                dtResultado=null;
            }
            return dtResultado;
        }
        //Método Buscar 
        public DataTable BuscarNombre(DUnidad Unidad)
        {
            DataTable dtResultado = new DataTable("Unidad");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_unidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTexto = new SqlParameter();
                ParTexto.ParameterName="@textobuscar";
                ParTexto.SqlDbType=SqlDbType.NVarChar;
                ParTexto.Size=50;
                ParTexto.Value=Unidad.TextoBuscar;
                SqlCmd.Parameters.Add(ParTexto);


                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(dtResultado);
            }
            catch(Exception ex)
            {
                dtResultado=null;
            }
            return dtResultado;
        }
    }
}
