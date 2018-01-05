using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DExamenUbicacion
    {
        //variables
        private string _IdExamen;
        private int _IdUbicacion;
        //propiedades
        public string IdExamen
        {
            get { return _IdExamen; }
            set { _IdExamen = value; }
        }        
        public int IdUbicacion
        {
            get { return _IdUbicacion; }
            set { _IdUbicacion = value; }
        }
        //métodos contructor vacio
        public DExamenUbicacion()
        {

        }
        //método con todos los parametros
        public DExamenUbicacion(string idexamen, int idubicacion)
        {
            IdExamen = idexamen;
            IdUbicacion = idubicacion;
        }
        //Método insertar
        public string Insertar(DExamenUbicacion ExamenUbicacion, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string strRpta = "";
            try
            {
                //Definir comandos para envio de parametros
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spInsertar_Examen_Ubicacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdExamen = new SqlParameter();
                ParIdExamen.ParameterName = "@IdExamen";
                ParIdExamen.SqlDbType = SqlDbType.NVarChar;
                ParIdExamen.Size = 15;
                ParIdExamen.Value = ExamenUbicacion.IdExamen;
                //ParIdExamen.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdExamen);

                SqlParameter ParIdUbicacion = new SqlParameter();
                ParIdUbicacion.ParameterName = "@IdUbicacion";
                ParIdUbicacion.SqlDbType = SqlDbType.Decimal;
                ParIdUbicacion.Value = ExamenUbicacion.IdUbicacion;
                SqlCmd.Parameters.Add(ParIdUbicacion);

                //ejecutar comando o .execute en VB
                strRpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se completo el registro";
            }
            catch (Exception ex)
            {
                strRpta = ex.Message;
            }
            return strRpta;
        }
        //Método Editar Ubicación del producto
        public string Editar(DExamenUbicacion ExamenUbicacion, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string strRpta = "";
            try
            {
                //Definir comandos para envio de parametros
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spEditar_Examen_Ubicacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdExamen = new SqlParameter();
                ParIdExamen.ParameterName = "@IdExamen";
                ParIdExamen.SqlDbType = SqlDbType.NVarChar;
                ParIdExamen.Size = 15;
                ParIdExamen.Value = ExamenUbicacion.IdExamen;
                //ParIdExamen.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdExamen);

                SqlParameter ParIdUbicacion = new SqlParameter();
                ParIdUbicacion.ParameterName = "@IdUbicacion";
                ParIdUbicacion.SqlDbType = SqlDbType.Decimal;
                ParIdUbicacion.Value = ExamenUbicacion.IdUbicacion;
                SqlCmd.Parameters.Add(ParIdUbicacion);

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
