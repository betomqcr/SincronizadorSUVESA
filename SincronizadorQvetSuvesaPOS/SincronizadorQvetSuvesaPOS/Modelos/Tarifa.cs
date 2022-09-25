using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SincronizadorQvetSuvesaPOS.Modelos
{
    public  class Tarifa
    {
        [JsonProperty("id_tarifa")]
        public long IdTarifa { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("precio_unitario")]
        public decimal PrecioUnitario { get; set; }
    }
}
