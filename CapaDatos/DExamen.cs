using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DExamen
    {
        string _IdExamen;
        string _CodigoBarra;
        string _Nombre;
        int _IdImpuesto;
        string _Observacion;
        int _Status;
        int _IdUnidad;
        int _IdClasificacion;
        string _DiasPago;
        int _StoMax;
        int _StoMin;
        int _Exento;
        string _Garantia;
        string _TextoBuscar;
        string _Opcion;
        public string IdExamen
        {
            get { return _IdExamen; }
            set { _IdExamen = value; }
        }
        public string CodigoBarra
        {
            get { return _CodigoBarra; }
            set { _CodigoBarra = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public int IdImpuesto
        {
            get { return _IdImpuesto; }
            set { _IdImpuesto = value; }
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
        public int IdUnidad
        {
            get { return _IdUnidad; }
            set { _IdUnidad = value; }
        }
        public int IdClasificacion
        {
            get { return _IdClasificacion; }
            set { _IdClasificacion = value; }
        }
        public string DiasPago
        {
            get { return _DiasPago; }
            set { _DiasPago = value; }
        }
        public int StoMax
        {
            get { return _StoMax; }
            set { _StoMax = value; }
        }
        public int StoMin
        {
            get { return _StoMin; }
            set { _StoMin = value; }
        }
        public int Exento
        {
            get { return _Exento; }
            set { _Exento = value; }
        }
        public string Garantia
        {
            get { return _Garantia; }
            set { _Garantia = value; }
        }
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        public string Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }
        //crear metodo constructor
        public DExamen()
        {

        }
        //crear metodo con todos los parametros
        public DExamen(string idexamen, string codigobarra, string nombre, int idimpuesto, string observacion, int status, int idunidad, int idclasificacion, string diaspago, int stomax, int stomin, int exento, string garantia, string textobuscar, string opcion)
        {
            IdExamen = idexamen;
            CodigoBarra = codigobarra;
            Nombre = nombre;
            IdImpuesto = idimpuesto;
            Observacion = observacion;
            Status = status;
            IdUnidad = idunidad;
            IdClasificacion = idclasificacion;
            DiasPago = diaspago;
            StoMax = stomax;
            StoMin = stomin;
            Exento = exento;
            Garantia = garantia;
            TextoBuscar = textobuscar;
            Opcion = opcion;
        }
        //método insertar Articulo o Producto
        public string Insertar(DExamen Examen, List<DExamenPrecio> EPrecio, List<DExamenUbicacion> EUbicacion)
        {
            string strRpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCon.Open();
                //Establecer la transacción
                SqlTransaction SqlTra = SqlCon.BeginTransaction();
                //Definir comandos para envio de parametros
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spInsertar_Examen";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdExamen = new SqlParameter();
                ParIdExamen.ParameterName = "@IdExamen";
                ParIdExamen.SqlDbType = SqlDbType.NVarChar;
                ParIdExamen.Size = 15;
                ParIdExamen.Value = Examen.IdExamen;
                SqlCmd.Parameters.Add(ParIdExamen);

                SqlParameter ParCodigoBarra = new SqlParameter();
                ParCodigoBarra.ParameterName = "@CodigoBarra";
                ParCodigoBarra.SqlDbType = SqlDbType.NVarChar;
                ParCodigoBarra.Size = 20;
                ParCodigoBarra.Value = Examen.CodigoBarra;
                SqlCmd.Parameters.Add(ParCodigoBarra);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.NVarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Examen.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParIdImpuesto = new SqlParameter();
                ParIdImpuesto.ParameterName = "@IdImpuesto";
                ParIdImpuesto.SqlDbType = SqlDbType.Int;
                ParIdImpuesto.Value = Examen.IdImpuesto;
                SqlCmd.Parameters.Add(ParIdImpuesto);

                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.NVarChar;
                ParObservacion.Size = 1024;
                ParObservacion.Value = Examen.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                SqlParameter ParStatus = new SqlParameter();
                ParStatus.ParameterName = "@Status";
                ParStatus.SqlDbType = SqlDbType.SmallInt;
                ParStatus.Value = Examen.Status;
                SqlCmd.Parameters.Add(ParStatus);

                SqlParameter ParIdUnidad = new SqlParameter();
                ParIdUnidad.ParameterName = "@IdUnidad";
                ParIdUnidad.SqlDbType = SqlDbType.Int;
                ParIdUnidad.Value = Examen.IdUnidad;
                SqlCmd.Parameters.Add(ParIdUnidad);

                SqlParameter ParIdClasificacion = new SqlParameter();
                ParIdClasificacion.ParameterName = "@IdClasificacion";
                ParIdClasificacion.SqlDbType = SqlDbType.Int;
                ParIdClasificacion.Value = Examen.IdClasificacion;
                SqlCmd.Parameters.Add(ParIdClasificacion);

                SqlParameter ParDiasPago = new SqlParameter();
                ParDiasPago.ParameterName = "@DiasPago";
                ParDiasPago.SqlDbType = SqlDbType.NVarChar;
                ParDiasPago.Size = 5;
                ParDiasPago.Value = Examen.DiasPago;
                SqlCmd.Parameters.Add(ParDiasPago);

                SqlParameter ParStoMax = new SqlParameter();
                ParStoMax.ParameterName = "@StoMax";
                ParStoMax.SqlDbType = SqlDbType.Int;
                ParStoMax.Value = Examen.StoMax;
                SqlCmd.Parameters.Add(ParStoMax);

                SqlParameter ParStoMin = new SqlParameter();
                ParStoMin.ParameterName = "@StoMin";
                ParStoMin.SqlDbType = SqlDbType.Int;
                ParStoMin.Value = Examen.StoMin;
                SqlCmd.Parameters.Add(ParStoMin);

                SqlParameter ParExento = new SqlParameter();
                ParExento.ParameterName = "@Exento";
                ParExento.SqlDbType = SqlDbType.SmallInt;
                ParExento.Value = Examen.Exento;
                SqlCmd.Parameters.Add(ParExento);

                SqlParameter ParGarantia = new SqlParameter();
                ParGarantia.ParameterName = "@Garantia";
                ParGarantia.SqlDbType = SqlDbType.NVarChar;
                ParGarantia.Size = 5;
                ParGarantia.Value = Examen.Garantia;
                SqlCmd.Parameters.Add(ParGarantia);

                //ejecutar comando o .execute en VB
                strRpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se completo el registro";
                //agregar los detalles ExamenUbicación
                if (strRpta.Equals("OK"))
                {
                    foreach (DExamenUbicacion Det in EUbicacion)
                    {
                        //llamar al método insertar de la clase DExamenUbicacion
                        strRpta = Det.Insertar(Det, ref SqlCon, ref SqlTra);
                        if (!strRpta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
                if (strRpta.Equals("OK"))
                {
                    SqlTra.Commit();
                }
                else
                {
                    SqlTra.Rollback();
                }
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
        //método Editar Articulo o Producto
        public string Editar(DExamen Examen, List<DExamenPrecio> EPrecio, List<DExamenUbicacion> EUbicacion)
        {
            string strRpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCon.Open();
                //Establecer la transacción
                SqlTransaction SqlTra = SqlCon.BeginTransaction();
                //Definir comandos para envio de parametros
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spEditar_Examen";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdExamen = new SqlParameter();
                ParIdExamen.ParameterName = "@IdExamen";
                ParIdExamen.SqlDbType = SqlDbType.NVarChar;
                ParIdExamen.Size = 15;
                ParIdExamen.Value = Examen.IdExamen;
                SqlCmd.Parameters.Add(ParIdExamen);

                SqlParameter ParCodigoBarra = new SqlParameter();
                ParCodigoBarra.ParameterName = "@CodigoBarra";
                ParCodigoBarra.SqlDbType = SqlDbType.NVarChar;
                ParCodigoBarra.Size = 20;
                ParCodigoBarra.Value = Examen.CodigoBarra;
                SqlCmd.Parameters.Add(ParCodigoBarra);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.NVarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Examen.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParIdImpuesto = new SqlParameter();
                ParIdImpuesto.ParameterName = "@IdImpuesto";
                ParIdImpuesto.SqlDbType = SqlDbType.Int;
                ParIdImpuesto.Value = Examen.IdImpuesto;
                SqlCmd.Parameters.Add(ParIdImpuesto);

                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.NVarChar;
                ParObservacion.Size = 1024;
                ParObservacion.Value = Examen.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);

                SqlParameter ParStatus = new SqlParameter();
                ParStatus.ParameterName = "@Status";
                ParStatus.SqlDbType = SqlDbType.SmallInt;
                ParStatus.Value = Examen.Status;
                SqlCmd.Parameters.Add(ParStatus);

                SqlParameter ParIdUnidad = new SqlParameter();
                ParIdUnidad.ParameterName = "@IdUnidad";
                ParIdUnidad.SqlDbType = SqlDbType.Int;
                ParIdUnidad.Value = Examen.IdUnidad;
                SqlCmd.Parameters.Add(ParIdUnidad);

                SqlParameter ParIdClasificacion = new SqlParameter();
                ParIdClasificacion.ParameterName = "@IdClasificacion";
                ParIdClasificacion.SqlDbType = SqlDbType.Int;
                ParIdClasificacion.Value = Examen.IdClasificacion;
                SqlCmd.Parameters.Add(ParIdClasificacion);

                SqlParameter ParDiasPago = new SqlParameter();
                ParDiasPago.ParameterName = "@DiasPago";
                ParDiasPago.SqlDbType = SqlDbType.NVarChar;
                ParDiasPago.Size = 5;
                ParDiasPago.Value = Examen.DiasPago;
                SqlCmd.Parameters.Add(ParDiasPago);

                SqlParameter ParStoMax = new SqlParameter();
                ParStoMax.ParameterName = "@StoMax";
                ParStoMax.SqlDbType = SqlDbType.Int;
                ParStoMax.Value = Examen.StoMax;
                SqlCmd.Parameters.Add(ParStoMax);

                SqlParameter ParStoMin = new SqlParameter();
                ParStoMin.ParameterName = "@StoMin";
                ParStoMin.SqlDbType = SqlDbType.Int;
                ParStoMin.Value = Examen.StoMin;
                SqlCmd.Parameters.Add(ParStoMin);

                SqlParameter ParExento = new SqlParameter();
                ParExento.ParameterName = "@Exento";
                ParExento.SqlDbType = SqlDbType.SmallInt;
                ParExento.Value = Examen.Exento;
                SqlCmd.Parameters.Add(ParExento);

                SqlParameter ParGarantia = new SqlParameter();
                ParGarantia.ParameterName = "@Garantia";
                ParGarantia.SqlDbType = SqlDbType.NVarChar;
                ParGarantia.Size = 5;
                ParGarantia.Value = Examen.Garantia;
                SqlCmd.Parameters.Add(ParGarantia);

                //ejecutar comando o .execute en VB
                strRpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se completo el registro";
                //agregar los detalles ExamenUbicación
                if (strRpta.Equals("OK"))
                {
                    foreach (DExamenUbicacion Det in EUbicacion)
                    {
                        //llamar al método editar de la clase DExamenUbicacion
                        strRpta = Det.Editar(Det, ref SqlCon, ref SqlTra);
                        if (!strRpta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
                if (strRpta.Equals("OK"))
                {
                    SqlTra.Commit();
                }
                else
                {
                    SqlTra.Rollback();
                }
                //agregar los detalles de precio del artículo ExamenPrecio
                if (strRpta.Equals("OK"))
                {
                    foreach (DExamenPrecio Det in EPrecio)
                    {
                        //llamar al método editar de la clase DExamenUbicacion
                        strRpta = Det.Editar(Det, ref SqlCon, ref SqlTra);
                        if (!strRpta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
                if (strRpta.Equals("OK"))
                {
                    SqlTra.Commit();
                }
                else
                {
                    SqlTra.Rollback();
                }
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
            DataTable dtResultado = new DataTable("Examen");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spMostrar_Examen";
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
        //Método para buscar el Detalle de Artículo Ubicación
        public DataTable MostrarDUbicacion(string TextoBsucar)
        {
            DataTable dtResultado = new DataTable("ExamenUbicacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spMostrar_Examen_Ubicacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.NVarChar;
                ParTextoBuscar.Size = 15;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
            }
            return dtResultado;
        }
        //Método para buscar el Detalle de Artículo Precio
        public DataTable MostrarDPrecio(string TextoBsucar)
        {
            DataTable dtResultado = new DataTable("ExamenPrecio");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spMostrar_Examen_Precio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.NVarChar;
                ParTextoBuscar.Size = 15;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

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
        public DataTable BuscarNombre(DExamen Examen)
        {
            DataTable dtResultado = new DataTable("Examen");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = CNNDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spBuscar_Examen";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParOpcion = new SqlParameter();
                ParOpcion.ParameterName = "@opcion";
                ParOpcion.SqlDbType = SqlDbType.NVarChar;
                ParOpcion.Size = 1;
                ParOpcion.Value = Examen.Opcion;
                SqlCmd.Parameters.Add(ParOpcion);

                SqlParameter ParTexto = new SqlParameter();
                ParTexto.ParameterName = "@textobuscar";
                ParTexto.SqlDbType = SqlDbType.NVarChar;
                ParTexto.Size = 100;
                ParTexto.Value = Examen.TextoBuscar;
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
