using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NVendedor
    {
        //Método incluir que llama al método insertar de la capa datos  
        public static string Insertar(int idvendedor, string nombre, decimal porc)
        {
            DVendedor Obj = new DVendedor();
            Obj.IdVendedor = idvendedor;
            Obj.Nombre = nombre;
            Obj.Porc= porc;
            return Obj.Insertar(Obj);
        }
        //Método Modificar que llama al método Editar Unidad de la capa datos
        public static string Editar(int idvendedor, string nombre, decimal porc)
        {
            DVendedor Obj = new DVendedor();
            Obj.IdVendedor = idvendedor;
            Obj.Nombre= nombre;
            Obj.Porc= porc;
            return Obj.Editar(Obj);
        }
        //Método eliminar que llama al método eliminar Unidad de la capa datos
        public static string Eliminar(int idvendedor)
        {
            DVendedor Obj = new DVendedor();
            Obj.IdVendedor= idvendedor;
            return Obj.Eliminar(Obj);
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable mostrar()
        {
            return new DVendedor().Mostrar();
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DVendedor Obj = new DVendedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
