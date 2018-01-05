using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NProveedor
    {
        //Método incluir que llama al método insertar de la capa datos  
        public static string Insertar(int idproveedor, string rif, string nombre, string contacto, string toficina, string tfax, string tmovil, string nrocuenta, string email, string website, string direccion, int tipo, int clasificacion, string observacion, int idbanco, int status)
        {
            DProveedor Obj = new DProveedor();
            Obj.IdProveedor = idproveedor;
            Obj.Rif = rif;
            Obj.Nombre = nombre;
            Obj.Contacto = contacto;
            Obj.TOficina = toficina;
            Obj.TFax = tfax;
            Obj.TMovil = tmovil;
            Obj.NroCuenta = nrocuenta;
            Obj.Email = email;
            Obj.WebSite = website;
            Obj.Direccion = direccion;
            Obj.Tipo = tipo;
            Obj.Clasificacion = clasificacion;
            Obj.Observacion = observacion;
            Obj.IdBanco = idbanco;
            Obj.Status = status;
            return Obj.Insertar(Obj);
        }
        //Método Modificar que llama al método Editar Unidad de la capa datos
        public static string Editar(int idproveedor, string rif, string nombre, string contacto, string toficina, string tfax, string tmovil, string nrocuenta, string email, string website, string direccion, int tipo, int clasificacion, string observacion, int idbanco, int status)
        {
            DProveedor Obj = new DProveedor();
            Obj.IdProveedor = idproveedor;
            Obj.Rif = rif;
            Obj.Nombre = nombre;
            Obj.Contacto = contacto;
            Obj.TOficina = toficina;
            Obj.TFax = tfax;
            Obj.TMovil = tmovil;
            Obj.NroCuenta = nrocuenta;
            Obj.Email = email;
            Obj.WebSite = website;
            Obj.Direccion = direccion;
            Obj.Tipo = tipo;
            Obj.Clasificacion = clasificacion;
            Obj.Observacion = observacion;
            Obj.IdBanco = idbanco;
            Obj.Status = status;
            return Obj.Editar(Obj);
        }
        //Método eliminar que llama al método eliminar Unidad de la capa datos
        public static string Eliminar(int idproveedor, string rif)
        {
            DProveedor Obj = new DProveedor();
            Obj.IdProveedor = idproveedor;
            Obj.Rif = rif;
            return Obj.Eliminar(Obj);
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable mostrar()
        {
            return new DProveedor().Mostrar();
        }
        //Método mostrar que llama al método mostrar Unidad de la capa datos
        public static DataTable BuscarNombre(string textobuscar, int idproveedor, string rifproveedor, int opcion)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            Obj.IdProveedor = idproveedor;
            Obj.Rif = rifproveedor;
            Obj.Opcion = opcion;
            return Obj.BuscarNombre(Obj);
        }
        public static DataTable BuscarCodigo(string textobuscar, int idproveedor, string rifproveedor, int opcion)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            Obj.IdProveedor = idproveedor;
            Obj.Rif = rifproveedor;
            Obj.Opcion = opcion;
            return Obj.BuscarCodigo(Obj);
        }
    }
}
