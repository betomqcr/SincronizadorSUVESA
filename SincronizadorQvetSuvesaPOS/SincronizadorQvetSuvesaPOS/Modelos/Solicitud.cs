using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SincronizadorQvetSuvesaPOS.Modelos
{
    public  class Solicitud
    {
        [JsonProperty("pagina")]
        public long Pagina { get; set; }

        //[JsonProperty("id")]
        //public string Id { get; set; }

        [JsonProperty("desde_fecha_actualizacion")]
        public string DesdeFechaActualizacion { get; set; }

        //[JsonProperty("registros_por_pagina")]
        //public long RegistrosPorPagina { get; set; }

        public  Solicitud FromJson(string json) => JsonConvert.DeserializeObject<Solicitud>(json, SincronizadorQvetSuvesaPOS.Modelos.Converter.Settings);

        //public  string ToJson(this Solicitud self) => JsonConvert.SerializeObject(self, SincronizadorQvetSuvesaPOS.Modelos.Converter.Settings);

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
