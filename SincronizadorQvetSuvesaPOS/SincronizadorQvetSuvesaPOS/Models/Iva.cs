using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincronizadorQvetSuvesaPOS.Models
{
    public class Iva
    {
        [JsonProperty("id")]
        public long Id { get; set; }



        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }



        [JsonProperty("valor")]
        public long Valor { get; set; }
    }
}
