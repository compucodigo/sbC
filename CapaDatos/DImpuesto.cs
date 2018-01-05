using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DImpuesto
    {
        private string _Descripcion;
        private int _Monto;
        private int _Opc;
        private int _IdImpuesto;        
        public string Descripcion
        {
          get { return _Descripcion; }
          set { _Descripcion = value; }
        }
        public int Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }
        public int Opc
        {
            get { return _Opc; }
            set { _Opc = value; }
        }
        public int IdImpuesto
        {
            get { return _IdImpuesto; }
            set { _IdImpuesto = value; }
        }
        //Método constructor vacio
        public DImpuesto()
        {

        }
        //Método constructor con todas los parametro
        public DImpuesto(string descripcion, int monto, int opc, int idimpuesto)
        {
            Descripcion = descripcion;
            Monto = monto;
            Opc = opc;
            IdImpuesto = idimpuesto;
        }
        //Método insertar
        public string Insertar(DImpuesto Impuesto)
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
                SqlCmd.CommandText = "spInsertar_Impuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 50;
                ParDescripcion.Value = Impuesto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@monto";
                ParMonto.SqlDbType = SqlDbType.Int;
                ParMonto.Value = Impuesto.Monto;
                SqlCmd.Parameters.Add(ParMonto);
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
        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable dtResultado = new DataTable("Impuesto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spMostrar_Impuesto";
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
        public DataTable Buscar(DImpuesto Impuesto)
        {
            DataTable dtResultado = new DataTable("Impuesto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spBuscar_Impuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParOpc = new SqlParameter();
                ParOpc.ParameterName = "@opc";
                ParOpc.SqlDbType = SqlDbType.SmallInt;
                ParOpc.Value = Impuesto.Opc;
                SqlCmd.Parameters.Add(ParOpc);

                SqlParameter ParIdImpuesto = new SqlParameter();
                ParIdImpuesto.ParameterName = "@IdImpuesto";
                ParIdImpuesto.SqlDbType = SqlDbType.Int;
                ParIdImpuesto.Value = Impuesto.IdImpuesto;
                SqlCmd.Parameters.Add(ParIdImpuesto);

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
