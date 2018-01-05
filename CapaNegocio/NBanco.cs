using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NBanco
    {
        //Método incluir que llama al método insertar de la capa datos  
        public static string Insertar(int idbanco, string descripcion)
        {
            DBanco Obj = new DBanco();
            Obj.IdBanco = idbanco;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);
        }
        //Método Modificar que llama al método Editar Unidad de la capa datos
        public static string Editar(int idbanco, string descrpcion)
        {
            DBanco Obj = new DBanco();
            Obj.IdBanco = idbanco;
            Obj.Descripcion= descrpcion;
            return Obj.Editar(Obj);
        }
        //Método eliminar que llama al método eliminar Unidad de la capa datos
        public static string Eliminar(int idbanco)
        {
            DBanco Obj = new DBanco();
            Obj.IdBanco= idbanco;
            return Obj.Eliminar(Obj);
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable mostrar()
        {
            return new DBanco().Mostrar();
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DBanco Obj = new DBanco();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
