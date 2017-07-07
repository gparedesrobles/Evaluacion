using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evaluacion02.Models
{
    public class BancoModels
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("NOMBRE")]
        [Required(ErrorMessage="Campo Requerido")]
        [StringLength(200)]
        public string nombre { get; set; }
        [DisplayName("DIRECCIÓN")]
        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(200)]
        public string direccion { get; set; }
        [DisplayName("FECHA DE REGISTRO")]
        [DataType(DataType.DateTime)]
        public DateTime fecharegistro { get; set; }
    }
}