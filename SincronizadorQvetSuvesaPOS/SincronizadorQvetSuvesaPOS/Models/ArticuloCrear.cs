using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincronizadorQvetSuvesaPOS.Models
{
    public  class ArticuloCrear
    {
        [JsonProperty ("id_articulo")]
        public int id_articulo { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("descripcion2")]
        public string Descripcion2 { get; set; }

        [JsonProperty("codigo_barras")]
        public string CodigoBarras { get; set; }

        [JsonProperty("codigo_alternativo")]
        public string CodigoAlternativo { get; set; }

        [JsonProperty("referencia")]
        public string Referencia { get; set; }

        [JsonProperty("factor_conversion")]
        public long? FactorConversion { get; set; }

        [JsonProperty("precio")]
        public double Precio { get; set; }

        [JsonProperty("pvp_bi")]
        public long PvpBi { get; set; }

        [JsonProperty("upc_bi")]
        public long UpcBi { get; set; }

        [JsonProperty("tipo_escandallo")]
        public long TipoEscandallo { get; set; }

        [JsonProperty("control_stock")]
        public long ControlStock { get; set; }

        [JsonProperty("activo")]
        public bool Activo { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("iva")]
        public Iva Iva { get; set; }

        [JsonProperty("iva_compra")]
        public Iva IvaCompra { get; set; }

        [JsonProperty("re")]
        public Iva Re { get; set; }

        [JsonProperty("fecha_alta")]
        public string FechaAlta { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        public override string ToString()
        {
            return ToJsonString();
        }
    }
}
