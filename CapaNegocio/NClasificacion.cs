using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NClasificacion
    {
        //Método incluir que llama al método insertar de la capa datos  
        public static string Insertar(int idclasificacion, string descripcion, int status)
        {
            DClasificacion Obj = new DClasificacion();
            Obj.IdClasificacion = idclasificacion;
            Obj.Descripcion = descripcion;
            Obj.Status = status;
            return Obj.Insertar(Obj);
        }
        //Método Modificar que llama al método Editar de la capa datos
        public static string Editar(int idclasificacion, string descripcion, int status)
        {
            DClasificacion Obj = new DClasificacion();
            Obj.IdClasificacion = idclasificacion;
            Obj.Descripcion = descripcion;            
            Obj.Status = status;
            return Obj.Editar(Obj);
        }
        //Método que llama eliminar de la capa datos
        public static string Eliminar(int idclasificacion)
        {
            DClasificacion Obj = new DClasificacion();
            Obj.IdClasificacion = idclasificacion;
            return Obj.Eliminar(Obj);
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable mostrar()
        {
            return new DClasificacion().Mostrar();
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DClasificacion Obj = new DClasificacion();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
