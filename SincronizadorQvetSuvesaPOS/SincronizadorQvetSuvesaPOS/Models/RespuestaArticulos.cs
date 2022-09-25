using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincronizadorQvetSuvesaPOS.Models
{
    public class RespuestaArticulos
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("mensaje")]
       public string mensaje { get; set; }

        public string Error { get; set; }
    }
}
