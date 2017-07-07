using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [DataContract]
    public class OrdenPago
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public decimal monto { get; set; }
        [DataMember]
        public string moneda { get; set; }
        [DataMember]
        public string estado  { get; set; }
        [DataMember]
        public DateTime fecharegistro { get; set; }
        [DataMember]
        public Sucursal oSucursal { get; set; }
    }
}
