using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DVendedor
    {
        private int _IdVendedor;
        private string _Nombre;
        private decimal _Porc;
        private string _TextoBuscar;
        public int IdVendedor
        {
            get { return _IdVendedor; }
            set { _IdVendedor = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public decimal Porc
        {
            get { return _Porc; }
            set { _Porc = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        //contructor vacio
        public DVendedor()
        {

        }
        //contructor con todos los parametros
        public DVendedor(int idvendedor, string nombre, decimal porc, string textobuscar)
        {
            IdVendedor = idvendedor;
            Nombre = nombre;
            Porc = porc;
            TextoBuscar = textobuscar;
        }
        //Método insertar
        public string Insertar(DVendedor Vendedor)
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
                SqlCmd.CommandText = "spInsertar_Vendedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVendedor = new SqlParameter();
                ParIdVendedor.ParameterName = "@idvendedor";
                ParIdVendedor.SqlDbType = SqlDbType.Int;
                ParIdVendedor.Value = Vendedor.IdVendedor;
                SqlCmd.Parameters.Add(ParIdVendedor);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.NVarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Vendedor.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParPorc = new SqlParameter();
                ParPorc.ParameterName = "@porc";
                ParPorc.SqlDbType = SqlDbType.Decimal;
                //ParPorc.Size=50;
                ParPorc.Value = Vendedor.Porc;
                SqlCmd.Parameters.Add(ParPorc);

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
        public string Editar(DVendedor Vendedor)
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
                SqlCmd.CommandText = "spEditar_Vendedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVendedor = new SqlParameter();
                ParIdVendedor.ParameterName = "@idvendedor";
                ParIdVendedor.SqlDbType = SqlDbType.Int;
                ParIdVendedor.Value = Vendedor.IdVendedor;
                SqlCmd.Parameters.Add(ParIdVendedor);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Vendedor.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParPorc = new SqlParameter();
                ParPorc.ParameterName = "@porc";
                ParPorc.SqlDbType = SqlDbType.Decimal;
                //ParPorc.Size=50;
                ParPorc.Value = Vendedor.Porc;
                SqlCmd.Parameters.Add(ParPorc);

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
        public string Eliminar(DVendedor Vendedor)
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
                SqlCmd.CommandText = "spEliminar_Vendedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVendedor = new SqlParameter();
                ParIdVendedor.ParameterName = "@idvendedor";
                ParIdVendedor.SqlDbType = SqlDbType.Int;
                ParIdVendedor.Value = Vendedor.IdVendedor;
                SqlCmd.Parameters.Add(ParIdVendedor);


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
            DataTable dtResultado = new DataTable("Vendedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spMostrar_Vendedor";
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
        public DataTable BuscarNombre(DVendedor Vendedor)
        {
            DataTable dtResultado = new DataTable("Vendedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spBuscar_Vendedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTexto = new SqlParameter();
                ParTexto.ParameterName = "@textobuscar";
                ParTexto.SqlDbType = SqlDbType.NVarChar;
                ParTexto.Size = 50;
                ParTexto.Value = Vendedor.TextoBuscar;
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
