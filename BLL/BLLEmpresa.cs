using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class BLLEmpresa
    {
        DALEmpresa dalempresa = new DALEmpresa();
        //public Entities.Empresa Insertarempresa(Entities.Empresa objeto)
        //{
        //    try
        //    {
        //        dalempresa.InsertarEmpresa(objeto);
        //        // Guardo una bitacora Local
              
        //    }
        //    catch (Exception ex)
        //    {
        //        //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = Sesion.sesion.Nombreusuario, CustomError = ex.StackTrace });
        //        throw ex;
        //    }
        //    return objeto;
        //}
        public Entities.Empresa CreateProveedor(Entities.Empresa objeto)
        {
            try
            {
                objeto.Tipo_Empresa = 2;
                dalempresa.CreateEmpresa(objeto);
                // Guardo una bitacora Local

            }
            catch (Exception ex)
            {
                //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = Sesion.sesion.Nombreusuario, CustomError = ex.StackTrace });
                throw ex;
            }
            return objeto;
        }

        public Entities.Empresa CreateCliente(Entities.Empresa objeto)
        {
            try
            {
                objeto.Tipo_Empresa = 1;
                dalempresa.CreateEmpresa(objeto);
                // Guardo una bitacora Local

            }
            catch (Exception ex)
            {
                //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = Sesion.sesion.Nombreusuario, CustomError = ex.StackTrace });
                throw ex;
            }
            return objeto;
        }


        public Entities.Empresa UpdateProveedor(Entities.Empresa proveedor)
        {
            try
            {
                proveedor.Tipo_Empresa = 2;
                dalempresa.UpdateById(proveedor);
                // Guardo una bitacora Local

            }
            catch (Exception ex)
            {
                //logSQL.CrearBitacora(new Services.BitacoraSQL() { mensaje = ex.Message, tipo = "sistema", Usuario = Sesion.sesion.Nombreusuario, CustomError = ex.StackTrace });
                throw ex;
            }
            return proveedor;
        }

        public List<Empresa> AllProveedor()
        {
            var clienteDac = new DALEmpresa();
            var result = clienteDac.SelectProveedor();
            return result;
        }

        public List<Empresa> AllCliente()
        {
            var clienteDac = new DALEmpresa();
            var result = clienteDac.SelectCliente();
            return result;
        }

        public List<Empresa> Search(string text)
        {
            var clienteDac = new DALEmpresa();
            var result = clienteDac.Search(text);
            return result;

        }
        public Empresa SelectByID(int id)
        {
            var clienteDac = new DALEmpresa();
            var result = clienteDac.SelectbyID(id);
            return result;
        }
    }
}
