using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCliente
    {
        private int _IdCliente;
        private string _Rif;
        private string _Razon;
        private string _Contacto;
        private string _Telefono;
        private string _Direccion;
        private string _Email;
        private string _Fax;
        private int _Clasificacion;
        private string _Web;
        private string _Observacion;
        private int _Status;
        private string _TextoBuscar;

        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }
        public string Rif
        {
            get { return _Rif; }
            set { _Rif = value; }
        }
        public string Razon
        {
            get { return _Razon; }
            set { _Razon = value; }
        }
        public string Contacto
        {
            get { return _Contacto; }
            set { _Contacto = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        public int Clasificacion
        {
            get { return _Clasificacion; }
            set { _Clasificacion = value; }
        }
        public string Web
        {
            get { return _Web; }
            set { _Web = value; }
        }
        public string Observacion
        {
            get { return _Observacion; }
            set { _Observacion = value; }
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
        //Contructor vacio
        public DCliente()
        {

        }
        //contructor con todos los parametros
        public DCliente(int idcliente, string rif, string razon, string contacto, string telefono, string direccion, string email, string fax, int clasificacion, string web, string observacion, int status, string textobuscar)
        {
            IdCliente = idcliente;
            Rif = rif;
            Razon = razon;
            Contacto = contacto;
            Telefono = telefono;
            Direccion = direccion;
            Email = email;
            Fax = fax;
            Clasificacion = clasificacion;
            Web = web;
            Observacion = observacion;
            Status = status;
            TextoBuscar = textobuscar;
        }
        //Método insertar
        public string Insertar(DCliente Cliente)
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
                SqlCmd.CommandText = "spInsertar_Cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Cliente.IdCliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParRif = new SqlParameter();
                ParRif.ParameterName = "@rif";
                ParRif.SqlDbType = SqlDbType.NVarChar;
                ParRif.Size = 15;
                ParRif.Value = Cliente.Rif;
                SqlCmd.Parameters.Add(ParRif);

                SqlParameter ParRazon = new SqlParameter();
                ParRazon.ParameterName = "@razon";
                ParRazon.SqlDbType = SqlDbType.NVarChar;
                ParRazon.Size = 75;
                ParRazon.Value = Cliente.Razon;
                SqlCmd.Parameters.Add(ParRazon);

                SqlParameter ParContacto = new SqlParameter();
                ParContacto.ParameterName = "@contacto";
                ParContacto.SqlDbType = SqlDbType.NVarChar;
                ParContacto.Size = 50;
                ParContacto.Value = Cliente.Contacto;
                SqlCmd.Parameters.Add(ParContacto);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.NVarChar;
                ParTelefono.Size = 15;
                ParTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.NVarChar;
                ParDireccion.Size = 350;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.NVarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParFax = new SqlParameter();
                ParFax.ParameterName = "@fax";
                ParFax.SqlDbType = SqlDbType.NVarChar;
                ParFax.Size = 15;
                ParFax.Value = Cliente.Fax;
                SqlCmd.Parameters.Add(ParFax);

                SqlParameter ParClasificacion = new SqlParameter();
                ParClasificacion.ParameterName = "@clasificacion";
                ParClasificacion.SqlDbType = SqlDbType.SmallInt;
                ParClasificacion.Value = Cliente.Clasificacion;
                SqlCmd.Parameters.Add(ParClasificacion);

                SqlParameter ParWeb = new SqlParameter();
                ParWeb.ParameterName = "@web";
                ParWeb.SqlDbType = SqlDbType.NVarChar;
                ParWeb.Size = 100;
                ParWeb.Value = Cliente.Web;
                SqlCmd.Parameters.Add(ParWeb);

                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@observacion";
                ParObservacion.SqlDbType = SqlDbType.NVarChar;
                ParObservacion.Size = 350;
                ParObservacion.Value = Cliente.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                SqlParameter ParStatus = new SqlParameter();
                ParStatus.ParameterName = "@status";
                ParStatus.SqlDbType = SqlDbType.SmallInt;
                ParStatus.Value = Cliente.Status;
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
        public string Editar(DCliente Cliente)
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
                SqlCmd.CommandText = "spEditar_Cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Cliente.IdCliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParRif = new SqlParameter();
                ParRif.ParameterName = "@rif";
                ParRif.SqlDbType = SqlDbType.NVarChar;
                ParRif.Size = 15;
                ParRif.Value = Cliente.Rif;
                SqlCmd.Parameters.Add(ParRif);

                SqlParameter ParRazon = new SqlParameter();
                ParRazon.ParameterName = "@razon";
                ParRazon.SqlDbType = SqlDbType.NVarChar;
                ParRazon.Size = 75;
                ParRazon.Value = Cliente.Razon;
                SqlCmd.Parameters.Add(ParRazon);

                SqlParameter ParContacto = new SqlParameter();
                ParContacto.ParameterName = "@contacto";
                ParContacto.SqlDbType = SqlDbType.NVarChar;
                ParContacto.Size = 50;
                ParContacto.Value = Cliente.Contacto;
                SqlCmd.Parameters.Add(ParContacto);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.NVarChar;
                ParTelefono.Size = 15;
                ParTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.NVarChar;
                ParDireccion.Size = 350;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.NVarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParFax = new SqlParameter();
                ParFax.ParameterName = "@fax";
                ParFax.SqlDbType = SqlDbType.NVarChar;
                ParFax.Size = 15;
                ParFax.Value = Cliente.Fax;
                SqlCmd.Parameters.Add(ParFax);

                SqlParameter ParClasificacion = new SqlParameter();
                ParClasificacion.ParameterName = "@clasificacion";
                ParClasificacion.SqlDbType = SqlDbType.SmallInt;
                ParClasificacion.Value = Cliente.Clasificacion;
                SqlCmd.Parameters.Add(ParClasificacion);

                SqlParameter ParWeb = new SqlParameter();
                ParWeb.ParameterName = "@web";
                ParWeb.SqlDbType = SqlDbType.NVarChar;
                ParWeb.Size = 100;
                ParWeb.Value = Cliente.Web;
                SqlCmd.Parameters.Add(ParWeb);

                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@observacion";
                ParObservacion.SqlDbType = SqlDbType.NVarChar;
                ParObservacion.Size = 350;
                ParObservacion.Value = Cliente.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                SqlParameter ParStatus = new SqlParameter();
                ParStatus.ParameterName = "@status";
                ParStatus.SqlDbType = SqlDbType.SmallInt;
                ParStatus.Value = Cliente.Status;
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
        public string Eliminar(DCliente Cliente)
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
                SqlCmd.CommandText = "spEliminar_Cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Cliente.IdCliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParRif = new SqlParameter();
                ParRif.ParameterName = "@rif";
                ParRif.SqlDbType = SqlDbType.NVarChar;
                ParRif.Size = 15;
                ParRif.Value = Cliente.Rif;
                SqlCmd.Parameters.Add(ParRif);

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
            DataTable dtResultado = new DataTable("Cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spMostrar_Cliente";
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
        public DataTable BuscarNombre(DCliente Cliente)
        {
            DataTable dtResultado = new DataTable("Cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spBuscar_Cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTexto = new SqlParameter();
                ParTexto.ParameterName = "@textobuscar";
                ParTexto.SqlDbType = SqlDbType.NVarChar;
                ParTexto.Size = 50;
                ParTexto.Value = Cliente.TextoBuscar;
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
