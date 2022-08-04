using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace SincronizadorQvetSuvesaPOS.Modelos
{
    public class Mascota
    {
        [JsonProperty("id_mascota")]
        public long IdMascota { get; set; }

        [JsonProperty("id_cliente")]
        public long? IdCliente { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("nhc")]
        public string Nhc { get; set; }

        [JsonProperty("chip")]
        public string Chip { get; set; }

        [JsonProperty("fecha_chip")]
        public object FechaChip { get; set; }

        [JsonProperty("apto_para_consumo")]
        public bool? AptoParaConsumo { get; set; }

        [JsonProperty("especie")]
        public string Especie { get; set; }

        [JsonProperty("raza")]
        public string Raza { get; set; }

        [JsonProperty("censo")]
        public object Censo { get; set; }

        [JsonProperty("pasaporte")]
        public string Pasaporte { get; set; }

        [JsonProperty("tatuaje")]
        public string Tatuaje { get; set; }

        [JsonProperty("caracter")]
        public string Caracter { get; set; }

        [JsonProperty("dieta")]
        public string Dieta { get; set; }

        [JsonProperty("ojos")]
        public object Ojos { get; set; }

        [JsonProperty("habitat")]
        public string Habitat { get; set; }

        [JsonProperty("altura")]
        public string Altura { get; set; }

        [JsonProperty("pelo")]
        public string Pelo { get; set; }

        [JsonProperty("capa")]
        public string Capa { get; set; }

        [JsonProperty("sexo")]
        public string Sexo { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("pedigri")]
        public bool? Pedigri { get; set; }

        [JsonProperty("fecha_nacimiento")]
        public DateTimeOffset? FechaNacimiento { get; set; }

        [JsonProperty("peso")]
        public long? Peso { get; set; }

        [JsonProperty("donante_sangre")]
        public bool? DonanteSangre { get; set; }

        [JsonProperty("tipo_sangre")]
        public object TipoSangre { get; set; }

        [JsonProperty("motivo_baja")]
        public object MotivoBaja { get; set; }

        [JsonProperty("fecha_baja")]
        public object FechaBaja { get; set; }

        [JsonProperty("veterinario_habitual")]
        public string VeterinarioHabitual { get; set; }

        [JsonProperty("ultima_visita")]
        public DateTimeOffset? UltimaVisita { get; set; }

        [JsonProperty("ultimo_veterinario_referente")]
        public object UltimoVeterinarioReferente { get; set; }

        [JsonProperty("fecha_alta")]
        public DateTimeOffset? FechaAlta { get; set; }
    }
}
