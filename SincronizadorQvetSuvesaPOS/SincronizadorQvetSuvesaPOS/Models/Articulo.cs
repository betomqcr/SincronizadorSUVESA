using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SincronizadorQvetSuvesaPOS.Models
{
    public class Articulo
    {
        [JsonProperty("id_articulo")]
        public long? IdArticulo { get; set; }



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



        [JsonProperty("seccion")]
        public Seccion Seccion { get; set; }



        [JsonProperty("familia")]
        public Familia Familia { get; set; }



        [JsonProperty("subfamilia")]
        public Subfamilia Subfamilia { get; set; }



        [JsonProperty("stock_minimo")]
        public long StockMinimo { get; set; }



        [JsonProperty("stock_almacen")]
        public long StockAlmacen { get; set; }



        [JsonProperty("stock_total")]
        public long StockTotal { get; set; }



        [JsonProperty("precio")]
        public long Precio { get; set; }



        [JsonProperty("pvp_bi")]
        public long PvpBi { get; set; }



        [JsonProperty("upc_bi")]
        public long UpcBi { get; set; }



        [JsonProperty("tipo_escandallo")]
        public long TipoEscandallo { get; set; }



        [JsonProperty("unidad_medida")]
        public string UnidadMedida { get; set; }



        [JsonProperty("pmpc")]
        public long Pmpc { get; set; }



        [JsonProperty("control_stock")]
        public long ControlStock { get; set; }



        [JsonProperty("proveedor_habitual")]
        public string ProveedorHabitual { get; set; }



        [JsonProperty("activo")]
        public bool Activo { get; set; }



        [JsonProperty("marca")]
        public string MarcaMarca { get; set; }



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



        [JsonProperty("lista_tarifas")]
        public List<ListaTarifa> ListaTarifas { get; set; }



        [JsonProperty("lotes")]
        public List<Lote> Lotes { get; set; }

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
