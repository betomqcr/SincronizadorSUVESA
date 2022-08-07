using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincronizadorQvetSuvesaPOS.Models
{
    public class Lote
    {
        [JsonProperty("id_lote")]
        public long IdLote { get; set; }



        [JsonProperty("id_almacen")]
        public long IdAlmacen { get; set; }



        [JsonProperty("almacen")]
        public string Almacen { get; set; }



        [JsonProperty("referencia")]
        public string Referencia { get; set; }



        [JsonProperty("caducidad")]
        public string Caducidad { get; set; }



        [JsonProperty("cantidad")]
        public long Cantidad { get; set; }
    }
}
