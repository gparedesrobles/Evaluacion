using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluacion02.Models
{
    public class OrdenPagoModels
    {

        [DisplayName("ID")]
        public int id { get; set; }

        [DisplayName("BANCO")]
        [Required(ErrorMessage = "Campo Requerido")]
        public List<BancoModels> lbancos { get; set; }

        [DisplayName("SUCURSAL")]
        [Required(ErrorMessage = "Campo Requerido")]
        public List<SucursalModels> lsucursal { get; set; }

        [DisplayName("MONTO")]
        [Required(ErrorMessage = "Campo Requerido")]
        //[StringLength(19, ErrorMessage = "Solo puedes ingresar 18 numeros", MinimumLength = 1)]
 
        public decimal monto { get; set; }

        [DisplayName("MONEDA")]
        [Required(ErrorMessage = "Campo Requerido")]
        public List<Item> moneda { get; set; }

        [DisplayName("ESTADO")]
        [Required(ErrorMessage = "Campo Requerido")]
        public List<Item> estado { get; set; }

        [DisplayName("BANCO")]
        public string nombre_banco { get; set; }

        [DisplayName("SUCURSAL")]
        public string nombre_sucursal{ get; set; }


        [DisplayName("FECHA DE PAGO")]
        [DataType(DataType.DateTime)]
        public DateTime fecharegistro { get; set; }

        //[Required(ErrorMessage = "Campo Requerido")]
        public int id_banco { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public int id_sucursal { get; set; }

        [DisplayName("ESTADO")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string nombre_estado { get; set; }

        [DisplayName("MONEDA")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string nombre_moneda { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string descripcion { get; set; }
    }
}