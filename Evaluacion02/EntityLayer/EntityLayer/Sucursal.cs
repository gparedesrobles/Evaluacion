using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [DataContract]
    public class Sucursal
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public DateTime fecharegistro { get; set; }
        [DataMember]
        public Banco oBanco { get; set; }
    }
}
