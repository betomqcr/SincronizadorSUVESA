using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace SincronizadorQvetSuvesaPOS.Models
{
    public class Marca
    {
        [JsonProperty("registros_totales")]
        public long RegistrosTotales { get; set; }

        [JsonProperty("registros_por_pagina")]
        public long RegistrosPorPagina { get; set; }

        [JsonProperty("paginas_totales")]
        public long PaginasTotales { get; set; }

        [JsonProperty("pagina_actual")]
        public long PaginaActual { get; set; }

        [JsonProperty("datos")]
        public List<Articulo> Articulos { get; set; }

        public static Marca FromJson(string json) => JsonConvert.DeserializeObject<Marca>(json, SincronizadorQvetSuvesaPOS.Modelos.Converter.Settings);
    }
}
