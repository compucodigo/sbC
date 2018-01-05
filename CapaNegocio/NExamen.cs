using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;


namespace CapaNegocio
{
    public class NExamen
    {
        //Método incluir que llama al método insertar de la capa datos
        public static string Insertar(string idexamen, string codigobarra, string nombre, int idimpuesto, string observacion, 
            int status, int idunidad, int idclasificacion, string diaspago, int stomax, int stomin, int exento, string garantia,

            DataTable dEPrecio, DataTable dEUbicacion)
        {
            DExamen Obj = new DExamen();
            Obj.IdExamen = idexamen;
            Obj.CodigoBarra = codigobarra;
            Obj.Nombre = nombre;
            Obj.IdImpuesto = idimpuesto;
            Obj.Observacion = observacion;
            Obj.Status = status;
            Obj.IdUnidad = idunidad;
            Obj.IdClasificacion = idclasificacion;
            Obj.DiasPago = diaspago;
            Obj.StoMax = stomax;
            Obj.StoMin = stomin;
            Obj.Exento = exento;
            Obj.Garantia = garantia;
            //el datalle de precio del artículo
            List<DExamenPrecio> deprecio = new List<DExamenPrecio>();
            foreach (DataRow row in dEPrecio.Rows)
            {
                DExamenPrecio detalle = new DExamenPrecio();
                detalle.IdExamen = idexamen;
                detalle.Base = Convert.ToDecimal(row["Base"].ToString());
                detalle.Impuesto = Convert.ToDecimal(row["Impuesto"].ToString());
                deprecio.Add(detalle);
            }
            //el datalle de la ubicación del artículo
            List<DExamenUbicacion> deubicacion = new List<DExamenUbicacion>();
            foreach (DataRow row in dEUbicacion.Rows)
            {
                DExamenUbicacion detalle = new DExamenUbicacion();
                detalle.IdExamen = idexamen;
                detalle.IdUbicacion = Convert.ToInt32(row["IdUbicacion"].ToString());                
                deubicacion.Add(detalle);
            }
            return Obj.Insertar(Obj, deprecio, deubicacion);
        }
        //Método editar que llama al método insertar de la capa datos
        public static string Editar(string idexamen, string codigobarra, string nombre, int idimpuesto, string observacion,
            int status, int idunidad, int idclasificacion, string diaspago, int stomax, int stomin, int exento, string garantia,
            DataTable dEPrecio, DataTable dEUbicacion)
        {
            DExamen Obj = new DExamen();
            Obj.IdExamen = idexamen;
            Obj.CodigoBarra = codigobarra;
            Obj.Nombre = nombre;
            Obj.IdImpuesto = idimpuesto;
            Obj.Observacion = observacion;
            Obj.Status = status;
            Obj.IdUnidad = idunidad;
            Obj.IdClasificacion = idclasificacion;
            Obj.DiasPago = diaspago;
            Obj.StoMax = stomax;
            Obj.StoMin = stomin;
            Obj.Exento = exento;
            Obj.Garantia = garantia;
            //el datalle de precio del artículo
            List<DExamenPrecio> deprecio = new List<DExamenPrecio>();
            foreach (DataRow row in dEPrecio.Rows)
            {
                DExamenPrecio detalle = new DExamenPrecio();
                detalle.IdExamen = idexamen;
                detalle.Base = Convert.ToDecimal(row["Base"].ToString());
                detalle.Impuesto = Convert.ToDecimal(row["Impuesto"].ToString());
                deprecio.Add(detalle);
            }
            //el datalle de la ubicación del artículo
            List<DExamenUbicacion> deubicacion = new List<DExamenUbicacion>();
            foreach (DataRow row in dEUbicacion.Rows)
            {
                DExamenUbicacion detalle = new DExamenUbicacion();
                detalle.IdExamen = idexamen;
                detalle.IdUbicacion = Convert.ToInt32(row["IdUbicacion"].ToString());
                deubicacion.Add(detalle);
            }
            return Obj.Editar(Obj, deprecio, deubicacion);
        }
        public static DataTable mostrar()
        {
            return new DExamen().Mostrar();
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable BuscarNombre(string opcion, string textobuscar)
        {
            DExamen Obj = new DExamen();
            Obj.Opcion = opcion;
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
