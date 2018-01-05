using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCliente
    {
        //Método incluir que llama al método insertar de la capa datos  
        public static string Insertar(int idcliente, string rif, string razon, string contacto, string telefono, string direccion, string email, string fax, int clasificacion, string web, string observacion, int status)
        {
            DCliente Obj = new DCliente();
            Obj.IdCliente = idcliente;
            Obj.Rif = rif;
            Obj.Razon = razon;
            Obj.Contacto = contacto;
            Obj.Telefono = telefono;
            Obj.Direccion = direccion;
            Obj.Email = email;
            Obj.Fax = fax;
            Obj.Clasificacion = clasificacion;
            Obj.Web= web;
            Obj.Observacion= observacion;
            Obj.Status = status;
            return Obj.Insertar(Obj);
        }
        //Método Modificar que llama al método Editar Unidad de la capa datos
        public static string Editar(int idcliente, string rif, string razon, string contacto, string telefono, string direccion, string email, string fax, int clasificacion, string web, string observacion, int status)
        {
            DCliente Obj = new DCliente();
            Obj.IdCliente = idcliente;
            Obj.Rif = rif;
            Obj.Razon = razon;
            Obj.Contacto = contacto;
            Obj.Telefono = telefono;
            Obj.Direccion = direccion;
            Obj.Email = email;
            Obj.Fax = fax;
            Obj.Clasificacion = clasificacion;
            Obj.Web = web;
            Obj.Observacion = observacion;
            Obj.Status = status;
            return Obj.Editar(Obj);
        }
        //Método eliminar que llama al método eliminar Unidad de la capa datos
        public static string Eliminar(int idcliente, string rif)
        {
            DCliente Obj = new DCliente();
            Obj.IdCliente = idcliente;
            Obj.Rif = rif;
            return Obj.Eliminar(Obj);
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable mostrar()
        {
            return new DCliente().Mostrar();
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
