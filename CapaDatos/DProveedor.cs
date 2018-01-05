
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProveedor
    {
        private int _IdProveedor;
        private string _Rif;
        private string _Nombre;
        private string _Contacto;
        private string _TOficina;
        private string _TFax;
        private string _TMovil;
        private string _NroCuenta;
        private string _Email;
        private string _WebSite;
        private string _Direccion;
        private int _Tipo;
        private int _Clasificacion;
        private string _Observacion;
        private int _IdBanco;
        private int _Status;
        private string _TextoBuscar;
        private int _Opcion;

        public int IdProveedor
        {
            get { return _IdProveedor; }
            set { _IdProveedor = value; }
        }
        public string Rif
        {
            get { return _Rif; }
            set { _Rif = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Contacto
        {
            get { return _Contacto; }
            set { _Contacto = value; }
        }
        public string TOficina
        {
            get { return _TOficina; }
            set { _TOficina = value; }
        }
        public string TFax
        {
            get { return _TFax; }
            set { _TFax = value; }
        }
        public string TMovil
        {
            get { return _TMovil; }
            set { _TMovil = value; }
        }
        public string NroCuenta
        {
            get { return _NroCuenta; }
            set { _NroCuenta = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string WebSite
        {
            get { return _WebSite; }
            set { _WebSite = value; }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public int Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
        public int Clasificacion
        {
            get { return _Clasificacion; }
            set { _Clasificacion = value; }
        }
        public string Observacion
        {
            get { return _Observacion; }
            set { _Observacion = value; }
        }
        public int IdBanco
        {
            get { return _IdBanco; }
            set { _IdBanco = value; }
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
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        //crear método sin parametro
        public DProveedor()
        {

        }
        //crear método con todos los parametros
        public DProveedor(int idproveedor, string rif, string nombre, string contacto, string toficina, string tfax, string tmovil, string nrocuenta, string email, string website, string direccion, int tipo, int clasificacion, string observacion, int idbanco, int status, string textobuscar, int opcion)
        {
            IdProveedor = idproveedor;
            Rif = rif;
            Nombre = nombre;
            Contacto = contacto;
            TOficina = toficina;
            TFax = tfax;
            TMovil = tmovil;
            NroCuenta = nrocuenta;
            Email = email;
            WebSite = website;
            Direccion = direccion;
            Tipo = tipo;
            Clasificacion = clasificacion;
            Observacion = observacion;
            IdBanco = idbanco;
            Status = status;
            TextoBuscar = textobuscar;
            Opcion = opcion;
        }
        //Método insertar
        public string Insertar(DProveedor Proveedor)
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
                SqlCmd.CommandText = "spInsertar_Proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.IdProveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParRif = new SqlParameter();
                ParRif.ParameterName = "@rif";
                ParRif.SqlDbType = SqlDbType.NVarChar;
                ParRif.Size = 15;
                ParRif.Value = Proveedor.Rif;
                SqlCmd.Parameters.Add(ParRif);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.NVarChar;
                ParNombre.Size = 75;
                ParNombre.Value = Proveedor.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParContacto = new SqlParameter();
                ParContacto.ParameterName = "@contacto";
                ParContacto.SqlDbType = SqlDbType.NVarChar;
                ParContacto.Size = 50;
                ParContacto.Value = Proveedor.Contacto;
                SqlCmd.Parameters.Add(ParContacto);

                SqlParameter ParTOficina = new SqlParameter();
                ParTOficina.ParameterName = "@toficina";
                ParTOficina.SqlDbType = SqlDbType.NVarChar;
                ParTOficina.Size = 15;
                ParTOficina.Value = Proveedor.TOficina;
                SqlCmd.Parameters.Add(ParTOficina);

                SqlParameter ParTFax = new SqlParameter();
                ParTFax.ParameterName = "@tfax";
                ParTFax.SqlDbType = SqlDbType.NVarChar;
                ParTFax.Size = 15;
                ParTFax.Value = Proveedor.TFax;
                SqlCmd.Parameters.Add(ParTFax);

                SqlParameter ParTMovil = new SqlParameter();
                ParTMovil.ParameterName = "@tmovil";
                ParTMovil.SqlDbType = SqlDbType.NVarChar;
                ParTMovil.Size = 15;
                ParTMovil.Value = Proveedor.TMovil;
                SqlCmd.Parameters.Add(ParTMovil);

                SqlParameter ParNroCta = new SqlParameter();
                ParNroCta.ParameterName = "@nrocuenta";
                ParNroCta.SqlDbType = SqlDbType.NVarChar;
                ParNroCta.Size = 20;
                ParNroCta.Value = Proveedor.NroCuenta;
                SqlCmd.Parameters.Add(ParNroCta);

                SqlParameter ParMail = new SqlParameter();
                ParMail.ParameterName = "@email";
                ParMail.SqlDbType = SqlDbType.NVarChar;
                ParMail.Size = 100;
                ParMail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParMail);

                SqlParameter ParWeb = new SqlParameter();
                ParWeb.ParameterName = "@website";
                ParWeb.SqlDbType = SqlDbType.NVarChar;
                ParWeb.Size = 100;
                ParWeb.Value = Proveedor.WebSite;
                SqlCmd.Parameters.Add(ParWeb);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.NVarChar;
                ParDireccion.Size = 1024;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.SmallInt;
                ParTipo.Value = Proveedor.Tipo;
                SqlCmd.Parameters.Add(ParTipo);

                SqlParameter ParClasificacion = new SqlParameter();
                ParClasificacion.ParameterName = "@clasificacion";
                ParClasificacion.SqlDbType = SqlDbType.SmallInt;
                ParClasificacion.Value = Proveedor.Clasificacion;
                SqlCmd.Parameters.Add(ParClasificacion);

                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@observacion";
                ParObservacion.SqlDbType = SqlDbType.NVarChar;
                ParObservacion.Size = 1024;
                ParObservacion.Value = Proveedor.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                SqlParameter ParBanco = new SqlParameter();
                ParBanco.ParameterName = "@idbanco";
                ParBanco.SqlDbType = SqlDbType.Int;
                ParBanco.Value = Proveedor.IdBanco;
                SqlCmd.Parameters.Add(ParBanco);

                SqlParameter ParStatus = new SqlParameter();
                ParStatus.ParameterName = "@status";
                ParStatus.SqlDbType = SqlDbType.SmallInt;
                ParStatus.Value = Proveedor.Status;
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
        public string Editar(DProveedor Proveedor)
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
                SqlCmd.CommandText = "spEditar_Proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.IdProveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParRif = new SqlParameter();
                ParRif.ParameterName = "@rif";
                ParRif.SqlDbType = SqlDbType.NVarChar;
                ParRif.Size = 15;
                ParRif.Value = Proveedor.Rif;
                SqlCmd.Parameters.Add(ParRif);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.NVarChar;
                ParNombre.Size = 75;
                ParNombre.Value = Proveedor.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParContacto = new SqlParameter();
                ParContacto.ParameterName = "@contacto";
                ParContacto.SqlDbType = SqlDbType.NVarChar;
                ParContacto.Size = 50;
                ParContacto.Value = Proveedor.Contacto;
                SqlCmd.Parameters.Add(ParContacto);

                SqlParameter ParTOficina = new SqlParameter();
                ParTOficina.ParameterName = "@toficina";
                ParTOficina.SqlDbType = SqlDbType.NVarChar;
                ParTOficina.Size = 15;
                ParTOficina.Value = Proveedor.TOficina;
                SqlCmd.Parameters.Add(ParTOficina);

                SqlParameter ParTFax = new SqlParameter();
                ParTFax.ParameterName = "@tfax";
                ParTFax.SqlDbType = SqlDbType.NVarChar;
                ParTFax.Size = 15;
                ParTFax.Value = Proveedor.TFax;
                SqlCmd.Parameters.Add(ParTFax);

                SqlParameter ParTMovil = new SqlParameter();
                ParTMovil.ParameterName = "@tmovil";
                ParTMovil.SqlDbType = SqlDbType.NVarChar;
                ParTMovil.Size = 15;
                ParTMovil.Value = Proveedor.TMovil;
                SqlCmd.Parameters.Add(ParTMovil);

                SqlParameter ParNroCta = new SqlParameter();
                ParNroCta.ParameterName = "@nrocuenta";
                ParNroCta.SqlDbType = SqlDbType.NVarChar;
                ParNroCta.Size = 20;
                ParNroCta.Value = Proveedor.NroCuenta;
                SqlCmd.Parameters.Add(ParNroCta);

                SqlParameter ParMail = new SqlParameter();
                ParMail.ParameterName = "@email";
                ParMail.SqlDbType = SqlDbType.NVarChar;
                ParMail.Size = 100;
                ParMail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParMail);

                SqlParameter ParWeb = new SqlParameter();
                ParWeb.ParameterName = "@website";
                ParWeb.SqlDbType = SqlDbType.NVarChar;
                ParWeb.Size = 100;
                ParWeb.Value = Proveedor.WebSite;
                SqlCmd.Parameters.Add(ParWeb);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.NVarChar;
                ParDireccion.Size = 150;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipo";
                ParTipo.SqlDbType = SqlDbType.SmallInt;
                ParTipo.Value = Proveedor.Tipo;
                SqlCmd.Parameters.Add(ParTipo);

                SqlParameter ParClasificacion = new SqlParameter();
                ParClasificacion.ParameterName = "@clasificacion";
                ParClasificacion.SqlDbType = SqlDbType.SmallInt;
                ParClasificacion.Value = Proveedor.Clasificacion;
                SqlCmd.Parameters.Add(ParClasificacion);

                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@observacion";
                ParObservacion.SqlDbType = SqlDbType.NVarChar;
                ParObservacion.Size = 400;
                ParObservacion.Value = Proveedor.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                SqlParameter ParBanco = new SqlParameter();
                ParBanco.ParameterName = "@idbanco";
                ParBanco.SqlDbType = SqlDbType.Int;
                ParBanco.Value = Proveedor.IdBanco;
                SqlCmd.Parameters.Add(ParBanco);

                SqlParameter ParStatus = new SqlParameter();
                ParStatus.ParameterName = "@status";
                ParStatus.SqlDbType = SqlDbType.SmallInt;
                ParStatus.Value = Proveedor.Status;
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
        public string Eliminar(DProveedor Proveedor)
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
                SqlCmd.CommandText = "spEliminar_Proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.IdProveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParRif = new SqlParameter();
                ParRif.ParameterName = "@rif";
                ParRif.SqlDbType = SqlDbType.NVarChar;
                ParRif.Size = 15;
                ParRif.Value = Proveedor.Rif;
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
            DataTable dtResultado = new DataTable("Proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spMostrar_Proveedor";
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
        //Método Buscar Nombre
        public DataTable BuscarNombre(DProveedor Proveedor)
        {
            DataTable dtResultado = new DataTable("Proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spBuscar_Proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTexto = new SqlParameter();
                ParTexto.ParameterName = "@textobuscar";
                ParTexto.SqlDbType = SqlDbType.NVarChar;
                ParTexto.Size = 50;
                ParTexto.Value = Proveedor.TextoBuscar;
                SqlCmd.Parameters.Add(ParTexto);
                //parametro id a buscar
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@idbuscar";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Proveedor.IdProveedor;
                SqlCmd.Parameters.Add(ParId);
                //parametro Rif a buscar
                SqlParameter ParRif = new SqlParameter();
                ParRif.ParameterName = "@rifbuscar";
                ParRif.SqlDbType = SqlDbType.NVarChar;
                ParRif.Size = 15;
                ParRif.Value = Proveedor.Rif;
                SqlCmd.Parameters.Add(ParRif);
                //parametro opción si busca codigo o nombre
                SqlParameter ParOpc = new SqlParameter();
                ParOpc.ParameterName = "@opcion";
                ParOpc.SqlDbType = SqlDbType.SmallInt;
                ParOpc.Value = Proveedor.Opcion;
                SqlCmd.Parameters.Add(ParOpc);

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }
            return dtResultado;
        }
        //Método Buscar Código
        public DataTable BuscarCodigo(DProveedor Proveedor)
        {
            DataTable dtResultado = new DataTable("Proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spBuscar_Proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //parametro nombre a buscar
                SqlParameter ParTexto = new SqlParameter();
                ParTexto.ParameterName = "@textobuscar";
                ParTexto.SqlDbType = SqlDbType.NVarChar;
                ParTexto.Size = 50;
                ParTexto.Value = Proveedor.TextoBuscar;
                SqlCmd.Parameters.Add(ParTexto);
                //parametro id a buscar
                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@idbuscar";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Proveedor.IdProveedor;                
                SqlCmd.Parameters.Add(ParId);
                //parametro Rif a buscar
                SqlParameter ParRif = new SqlParameter();
                ParRif.ParameterName = "@rifbuscar";
                ParRif.SqlDbType = SqlDbType.NVarChar;
                ParRif.Size = 15;
                ParRif.Value = Proveedor.Rif;
                SqlCmd.Parameters.Add(ParRif);
                //parametro opción si busca codigo o nombre
                SqlParameter ParOpc = new SqlParameter();
                ParOpc.ParameterName = "@opcion";
                ParOpc.SqlDbType = SqlDbType.SmallInt;
                ParOpc.Value = Proveedor.Opcion;
                SqlCmd.Parameters.Add(ParOpc);

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
