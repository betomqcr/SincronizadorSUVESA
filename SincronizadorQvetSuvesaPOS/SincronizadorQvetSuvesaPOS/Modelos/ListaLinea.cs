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
        public decimal Cantidad { get; set; }

        [JsonProperty("pvp")]
        public decimal Pvp { get; set; }

        [JsonProperty("descuento")]
        public decimal Descuento { get; set; }

        [JsonProperty("iva")]
        public Iva Iva { get; set; }

        [JsonProperty("importe_base")]
        public decimal ImporteBase { get; set; }

        [JsonProperty("importe_irpf")]
        public decimal ImporteIrpf { get; set; }

        [JsonProperty("importe_iva")]
        public decimal ImporteIva { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("lote")]
        public object Lote { get; set; }

        [JsonProperty("tarifa")]
        public Tarifa Tarifa { get; set; }
    }
}
