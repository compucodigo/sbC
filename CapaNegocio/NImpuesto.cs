using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NImpuesto
    {
        //Método incluir que llama al método insertar de la capa datos  
        public static string Insertar(string descripcion, int monto)
        {
            DImpuesto Obj = new DImpuesto();
            Obj.Descripcion = descripcion;
            Obj.Monto = monto;
            return Obj.Insertar(Obj);
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable mostrar()
        {
            return new DImpuesto().Mostrar();
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable Buscar(int opc, int idimpuesto)
        {
            DImpuesto Obj = new DImpuesto();
            Obj.Opc = opc;
            Obj.IdImpuesto = idimpuesto;
            return new DImpuesto().Buscar(Obj);
        }
    }
}
