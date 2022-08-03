using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SincronizadorQvetSuvesaPOS.Modelos
{
    public class Dato
    {
        [JsonProperty("id_albaran")]
        public long IdAlbaran { get; set; }

        [JsonProperty("cliente")]
        public Cliente Cliente { get; set; }

        [JsonProperty("mascota")]
        public object Mascota { get; set; }

        [JsonProperty("empresa")]
        public string Empresa { get; set; }

        [JsonProperty("caso")]
        public object Caso { get; set; }

        [JsonProperty("referidor")]
        public object Referidor { get; set; }

        [JsonProperty("tarifa")]
        public string Tarifa { get; set; }

        [JsonProperty("fecha")]
        public string Fecha { get; set; }

        [JsonProperty("almacen")]
        public string Almacen { get; set; }

        [JsonProperty("numero_factura")]
        public object NumeroFactura { get; set; }

        [JsonProperty("responsable_venta")]
        public string ResponsableVenta { get; set; }

        [JsonProperty("total_bruto")]
        public long TotalBruto { get; set; }

        [JsonProperty("descuento")]
        public long Descuento { get; set; }

        [JsonProperty("importe_base")]
        public long ImporteBase { get; set; }

        [JsonProperty("importe_iva")]
        public long ImporteIva { get; set; }

        [JsonProperty("subtotal")]
        public long Subtotal { get; set; }

        [JsonProperty("importe_irpf")]
        public long ImporteIrpf { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("id_factura")]
        public long IdFactura { get; set; }

        [JsonProperty("lista_lineas")]
        public List<ListaLinea> ListaLineas { get; set; }
    }
}
