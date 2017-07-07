using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EntityLayer;
using DataLayer;
namespace Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class Service1 : IService1
    {

        OrdenPagoDL oPagoDL = new OrdenPagoDL();
        SucursalDL oSucursalDL = new SucursalDL();

        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getOrdenPago/{sucursal}/{moneda}")]
        public List<OrdenPago> getOrdenPago(string sucursal, string moneda)
        {
            return oPagoDL.getBySucursalAndMoneda(sucursal, moneda);
        }

        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getSucursal/{banco}")]
        public List<Sucursal> getSucursal(string banco)
        {
            return oSucursalDL.getbyBanco(banco);
        }
    }
}
