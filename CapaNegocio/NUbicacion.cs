using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NUbicacion
    {
        //Método incluir que llama al método insertar de la capa datos  
        public static string Insertar(int idubicacion, string descripcion, int movimiento, int status)
        {
            DUbicacion Obj = new DUbicacion();
            Obj.IdUbicacion = idubicacion;
            Obj.Descripcion = descripcion;
            Obj.Movimiento = movimiento;
            Obj.Status = status;
            return Obj.Insertar(Obj);
        }
        //Método Modificar que llama al método Editar de la capa datos
        public static string Editar(int idubicacion, string descripcion, int movimiento, int status)
        {
            DUbicacion Obj = new DUbicacion();
            Obj.IdUbicacion = idubicacion;
            Obj.Descripcion = descripcion;
            Obj.Movimiento = movimiento;
            Obj.Status = status;
            return Obj.Editar(Obj);
        }
        //Método que llama eliminar de la capa datos
        public static string Eliminar(int idubicacion)
        {
            DUbicacion Obj = new DUbicacion();
            Obj.IdUbicacion = idubicacion;
            return Obj.Eliminar(Obj);
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable mostrar()
        {
            return new DUbicacion().Mostrar();
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DUbicacion Obj = new DUbicacion();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
