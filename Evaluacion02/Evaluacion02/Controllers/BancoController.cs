using Evaluacion02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using EntityLayer;
namespace Evaluacion02.Controllers
{
    public class BancoController : Controller
    {
        BancoDL oBancoDL = new BancoDL();
        SucursalDL oSucursalDL = new SucursalDL();
        //
        // GET: /Banco/

        public ActionResult Index()
        {

            //List<Banco> resultado = oBancoDL.get();

            List<BancoModels> oBancoModels = oBancoDL.get().Select((item, i) => new BancoModels {
                id = item.id,
                nombre = item.nombre,
                direccion = item.direccion,
                fecharegistro = item.fecharegistro
            }).ToList();

            return View(oBancoModels);
        }
        public ActionResult BancoAdd()
        {
            return View();
        }

        public ActionResult BancoEdit(int id,string nombre,string direccion,string operacion)
        {
            if(operacion.Equals("modificar"))
            return View(new BancoModels { id=id,nombre=nombre,direccion=direccion});
            else
            return BancoDelete(id);
        }

        [HttpPost]
        public ActionResult BancoAdd(BancoModels bancoModel)
        {
            try
            {
                oBancoDL.add(new Banco
                {
                    nombre = bancoModel.nombre,
                    direccion = bancoModel.direccion,
                    fecharegistro = DateTime.Now
                });
            }
            catch (Exception)
            {
                throw;
            }
            
            return RedirectToAction("Index", "Banco");
        }

        [HttpPost]
        public ActionResult BancoEdit(BancoModels bancoModel)
        {
            try
            {
                oBancoDL.update(new Banco
                {
                    id = bancoModel.id,
                    nombre = bancoModel.nombre,
                    direccion = bancoModel.direccion
                });
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Index", "Banco");
        }
        [HttpPost]
        public ActionResult BancoDelete(int id)
        {
            try
            {
                if(!oSucursalDL.existe_sucursal(id))

                oBancoDL.delete(new Banco
                {
                    id = id,
                });                
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Index", "Banco");
        }
    }
}
