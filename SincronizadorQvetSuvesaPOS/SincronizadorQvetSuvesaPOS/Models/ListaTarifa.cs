using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincronizadorQvetSuvesaPOS.Models
{
    public class ListaTarifa
    {
        [JsonProperty("id_tarifa")]
        public long IdTarifa { get; set; }



        [JsonProperty("nombre")]
        public string Nombre { get; set; }



        [JsonProperty("precio_unitario")]
        public double PrecioUnitario { get; set; }
    }
}
