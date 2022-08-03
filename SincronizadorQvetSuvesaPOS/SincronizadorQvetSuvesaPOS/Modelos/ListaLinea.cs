using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SincronizadorQvetSuvesaPOS.Modelos
{
    public  class ListaLinea
    {
        [JsonProperty("id_linea")]
        public long IdLinea { get; set; }

        [JsonProperty("id_articulo")]
        public long IdArticulo { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("cantidad")]
        public long Cantidad { get; set; }

        [JsonProperty("pvp")]
        public long Pvp { get; set; }

        [JsonProperty("descuento")]
        public long Descuento { get; set; }

        [JsonProperty("iva")]
        public Iva Iva { get; set; }

        [JsonProperty("importe_base")]
        public long ImporteBase { get; set; }

        [JsonProperty("importe_irpf")]
        public long ImporteIrpf { get; set; }

        [JsonProperty("importe_iva")]
        public long ImporteIva { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("lote")]
        public object Lote { get; set; }

        [JsonProperty("tarifa")]
        public Tarifa Tarifa { get; set; }
    }
}
