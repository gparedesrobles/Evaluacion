using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer;
using Evaluacion02.Models;
using DataLayer;
namespace Evaluacion02.Controllers
{
    public class OrdenPagoController : Controller
    {
        //
        // GET: /OrdenPago/
        OrdenPagoDL oOrdenPagoDL = new DataLayer.OrdenPagoDL();
        BancoDL oBancoDL = new BancoDL();
        SucursalDL oSucursalDL = new SucursalDL();
        List<Item> moneda = null;
        List<Item> estado = null;
        List<BancoModels> bancos = null;
        List<SucursalModels> sucursal = null;
        public OrdenPagoController()
        {
            moneda = new List<Item>() {
                new Item { id="PEN",descripcion = "PEN" },
                new Item { id="DOL",descripcion = "DOL" } };
            estado = new List<Item>() {
                new Item { id="PAGADA",descripcion = "PAGADA" },
                new Item { id="DECLINADA",descripcion = "DECLINADA" },
                new Item { id="FALLIDA",descripcion = "FALLIDA" },
                new Item { id="ANULADA",descripcion = "ANULADA" } };

            bancos = oBancoDL.get().Select((item, i) => new BancoModels
            {
                id = item.id,
                nombre = item.nombre
            }).ToList();
            

        }

        public ActionResult Index()
        {
            List<OrdenPagoModels> oOrdenPagoModels = oOrdenPagoDL.get().Select((item, i) => new OrdenPagoModels
            {
                id = item.id,
                nombre_moneda = item.moneda,
                monto = item.monto,
                fecharegistro = item.fecharegistro,
                nombre_banco = item.oSucursal.oBanco.nombre,
                id_banco = item.oSucursal.oBanco.id,
                nombre_sucursal = item.oSucursal.nombre,
                nombre_estado = item.estado,
                id_sucursal= item.oSucursal.id,
            }).ToList();

            return View(oOrdenPagoModels);
        }

        public ActionResult OrdenPagoAdd()
        {
            return View(new OrdenPagoModels
            {
                lbancos = bancos, lsucursal= sucursal, moneda = moneda , estado=estado 
            });
        }

        public ActionResult OrdenPagoEdit(int id, decimal monto, string monedai, int id_banco, int id_sucursal, string estadoi)
        {
            return View(new OrdenPagoModels
            {
                id = id,
                monto = monto,
                moneda = moneda,
                nombre_moneda = monedai,
                estado = estado,                
                lbancos = oBancoDL.get().Select((item, i) => new BancoModels
                {
                    id = item.id,
                    nombre = item.nombre
                }).ToList(),
                id_banco = id_banco,
                lsucursal = oSucursalDL.get().Select((item, i) => new SucursalModels
                {
                    id = item.id,
                    nombre = item.nombre,
                }).Where(s => s.id_banco.Equals(id_banco)).ToList(),
                id_sucursal = id_sucursal,
                nombre_estado = estadoi
            });
        }

        [HttpPost]
        public ActionResult OrdenPagoAdd(OrdenPagoModels oOrdenPagoModel)
        {
            try
            {
                oOrdenPagoDL.add(new OrdenPago
                {
                    moneda = oOrdenPagoModel.nombre_moneda,
                    monto = oOrdenPagoModel.monto,
                    oSucursal = new Sucursal() { id = oOrdenPagoModel.id_sucursal },
                    estado = oOrdenPagoModel.nombre_estado,
                    fecharegistro = DateTime.Now
                });

                return RedirectToAction("Index", "OrdenPago");
            }
            catch (Exception)
            {
                throw;
            }

           
        }

        [HttpPost]
        public ActionResult SucursalList(int id_banco)
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

            return View("OrdenPagoAdd",new OrdenPagoModels { lsucursal = oSucursalModels.Where(s=> s.id_banco.Equals(id_banco)).ToList(),
                lbancos = bancos,
                moneda = moneda,
                estado = estado 
            });
        }

        [HttpPost]
        public ActionResult SucursalList2(int id,int id_banco,string nombre_moneda,string nombre_estado,decimal monto)
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

            return View("OrdenPagoEdit", new OrdenPagoModels
            {
                lsucursal = oSucursalModels.Where(s => s.id_banco.Equals(id_banco)).ToList(),
                lbancos = bancos,
                moneda = moneda,
                nombre_moneda = nombre_moneda,
                estado = estado,
                nombre_estado= nombre_estado,
                monto = monto,id = id
            });
        }


        [HttpPost]
        public ActionResult OrdenPagoEdit(OrdenPagoModels oOrdenPagoModel)
        {
            try
            {
                oOrdenPagoDL.update(new OrdenPago
                {
                    id = oOrdenPagoModel.id,
                    moneda = oOrdenPagoModel.nombre_moneda,
                    monto = oOrdenPagoModel.monto,
                    oSucursal = new Sucursal() { id = oOrdenPagoModel.id_sucursal },
                    estado = oOrdenPagoModel.nombre_estado,
                });

                return RedirectToAction("Index", "OrdenPago");
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
