using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using EntityLayer;
using Evaluacion02.Models;

namespace Evaluacion02.Controllers
{
    public class SucursalController : Controller
    {
        //
        // GET: /Sucursal/
        SucursalDL oSucursalDL = new SucursalDL();
        BancoDL oBancoDL = new BancoDL();
        
        public ActionResult Index()
        {   
            
            List<SucursalModels> oSucursalModels = oSucursalDL.get().Select((item, i) => new SucursalModels
            {
                id = item.id,
                nombre = item.nombre,
                direccion = item.direccion,
                fecharegistro = item.fecharegistro,
                nombre_banco = item.oBanco.nombre,
                id_banco = item.oBanco.id
            }).ToList();

            return View(oSucursalModels);
        }

        public ActionResult SucursalAdd()
        {
            return View(new SucursalModels { lbancos = oBancoDL.get().Select((item, i) => new BancoModels
            {
                id = item.id,
                nombre = item.nombre
            }).ToList()});
        }

        public ActionResult SucursalEdit(int id, string nombre, string direccion,int id_banco, string operacion)
        {
            if (operacion.Equals("modificar"))
                return View(new SucursalModels { id = id, nombre = nombre, direccion = direccion,
                    lbancos = oBancoDL.get().Select((item, i) => new BancoModels
                    {
                        id = item.id,
                        nombre = item.nombre
                    }).ToList(), id_banco = id_banco
            });

            else
                return SucursalDelete(id);
        }



        [HttpPost]
        public ActionResult SucursalAdd(SucursalModels sucursalModel)
        {
            try
            {
                oSucursalDL.add(new Sucursal
                {
                    nombre = sucursalModel.nombre,
                    direccion = sucursalModel.direccion,
                    fecharegistro = DateTime.Now,
                    oBanco = new Banco { id = sucursalModel.id_banco }
                });

                return RedirectToAction("Index", "Sucursal");
            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost]
        public ActionResult SucursalEdit(SucursalModels sucursalModel)
        {
            try
            {
                oSucursalDL.update(new Sucursal
                {
                    id = sucursalModel.id,
                    nombre = sucursalModel.nombre,
                    direccion = sucursalModel.direccion,
                    oBanco=new Banco { id= sucursalModel.id_banco}
                });
                return RedirectToAction("Index", "Sucursal");
            }
            catch (Exception)
            {
                throw;
            }

            
        }

        [HttpPost]
        public ActionResult SucursalDelete(int id)
        {
            try
            {
                //if (!oSucursalDL.existe_sucursal(id))
                oSucursalDL.delete(new Sucursal
                {
                    id = id
                });
                  //  });
                return RedirectToAction("Index", "Sucursal");
            }
            catch (Exception)
            {
                throw;
            }

        }

       

    }
}
