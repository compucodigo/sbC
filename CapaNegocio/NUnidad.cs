using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NUnidad
    {
          //Método incluir que llama al método insertar Unidad de la capa datos  
        public static string Insertar(int idunidad, string descripcion, DateTime fecha, int dime, int fec, int inve, int seri)
        {
            DUnidad Obj = new DUnidad();
            Obj.Idunidad = idunidad;
            Obj.Descripcion = descripcion;
            Obj.Fecha = fecha;
            Obj.Dime = dime;
            Obj.Fec = fec;
            Obj.Inve = inve;
            Obj.Seri = seri;
            return Obj.Insertar(Obj);
        }
        //Método Modificar que llama al método Editar Unidad de la capa datos
        public static string Editar(int idunidad, string descripcion, DateTime fecha, int dime, int fec, int inve, int seri)
        {
            DUnidad Obj = new DUnidad();
            Obj.Idunidad = idunidad;
            Obj.Descripcion = descripcion;
            Obj.Fecha = fecha;
            Obj.Dime = dime;
            Obj.Fec = fec;
            Obj.Inve = inve;
            Obj.Seri = seri;
            return Obj.Editar(Obj);
        }        
        //Método eliminar que llama al método eliminar Unidad de la capa datos
        public static string Eliminar(int idunidad)
        {
            DUnidad Obj = new DUnidad();
            Obj.Idunidad = idunidad;
            return Obj.Eliminar(Obj);
        }        
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable mostrar(int Parametro)
        {
            return new DUnidad().Mostrar(Parametro);
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DUnidad Obj = new DUnidad();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
