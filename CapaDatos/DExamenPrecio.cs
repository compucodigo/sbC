using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DExamenPrecio
    {
        //variables
        private string _IdExamen;
        private decimal _Base;
        private decimal _Impuesto;
        //propiedades
        public string IdExamen
        {
            get { return _IdExamen; }
            set { _IdExamen = value; }
        }
        public decimal Base
        {
            get { return _Base; }
            set { _Base = value; }
        }
        public decimal Impuesto
        {
            get { return _Impuesto; }
            set { _Impuesto = value; }
        }
        //contructores
        public DExamenPrecio()
        {

        }
        public DExamenPrecio(string idexamen, decimal bases, decimal impuesto)
        {
            IdExamen = idexamen;
            Base = bases;
            Impuesto = impuesto;
        }
        //Método insertar precio del artículo
        public string Insertar(DExamenPrecio ExamenPrecio, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string strRpta = "";
            try
            {
                //Definir comandos para envio de parametros
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spInsertar_Examen_Precio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdExamen = new SqlParameter();
                ParIdExamen.ParameterName = "@IdExamen";
                ParIdExamen.SqlDbType = SqlDbType.NVarChar;
                ParIdExamen.Size = 15;
                ParIdExamen.Value = ExamenPrecio.IdExamen;
                //ParIdExamen.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdExamen);

                SqlParameter ParBase = new SqlParameter();
                ParBase.ParameterName = "@Base";
                ParBase.SqlDbType = SqlDbType.Money;
                ParBase.Precision = 10;
                ParBase.Scale = 2;
                ParBase.Value = ExamenPrecio.Base;
                SqlCmd.Parameters.Add(ParBase);

                SqlParameter ParImpuesto = new SqlParameter();
                ParImpuesto.ParameterName = "@Impuesto";
                ParImpuesto.SqlDbType = SqlDbType.Money;
                ParImpuesto.Precision = 10;
                ParImpuesto.Scale = 2;
                ParImpuesto.Value = ExamenPrecio.Impuesto;
                SqlCmd.Parameters.Add(ParImpuesto);

                //ejecutar comando o .execute en VB
                strRpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se completo el registro";
            }
            catch (Exception ex)
            {
                strRpta = ex.Message;
            }
            return strRpta;
        }
        //Método editar precio del artículo
        public string Editar(DExamenPrecio ExamenPrecio, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string strRpta = "";
            try
            {
                //Definir comandos para envio de parametros
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spEditar_Examen_Precio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdExamen = new SqlParameter();
                ParIdExamen.ParameterName = "@IdExamen";
                ParIdExamen.SqlDbType = SqlDbType.NVarChar;
                ParIdExamen.Size = 15;
                ParIdExamen.Value = ExamenPrecio.IdExamen;                
                SqlCmd.Parameters.Add(ParIdExamen);

                SqlParameter ParBase = new SqlParameter();
                ParBase.ParameterName = "@Base";
                ParBase.SqlDbType = SqlDbType.Decimal;
                ParBase.Value = ExamenPrecio.Base;
                SqlCmd.Parameters.Add(ParBase);

                SqlParameter ParImpuesto = new SqlParameter();
                ParImpuesto.ParameterName = "@Impuesto";
                ParImpuesto.SqlDbType = SqlDbType.Decimal;
                ParImpuesto.Value = ExamenPrecio.Impuesto;
                SqlCmd.Parameters.Add(ParImpuesto);

                //ejecutar comando o .execute en VB
                strRpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se completo el registro";
            }
            catch (Exception ex)
            {
                strRpta = ex.Message;
            }
            return strRpta;
        }
    }
}
