using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluacion02.Models
{
    public class SucursalModels
    {

        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("NOMBRE")]
        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(200)]
        public string nombre { get; set; }
        [DisplayName("DIRECCIÓN")]
        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(200)]
        public string direccion { get; set; }
        [DisplayName("FECHA DE REGISTRO")]
        [DataType(DataType.DateTime)]
        public DateTime fecharegistro { get; set; }

        [DisplayName("BANCO")]
        [Required(ErrorMessage = "Campo Requerido")]
        public List<BancoModels> lbancos { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public int id_banco { get; set; }
        
        [DisplayName("BANCO")]
        public string nombre_banco { get; set; }
    }
}