using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace SincronizadorQvetSuvesaPOS.Modelos
{
   public  class Cliente
    {
        [JsonProperty("id_cliente")]
        public long IdCliente { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("apellido1")]
        public string Apellido1 { get; set; }

        [JsonProperty("apellido2")]
        public string Apellido2 { get; set; }

        [JsonProperty("nombre_completo")]
        public string NombreCompleto { get; set; }

        [JsonProperty("cif_nif")]
        public string CifNif { get; set; }

        [JsonProperty("documento")]
        public string Documento { get; set; }

        [JsonProperty("tipo_documento")]
        public object TipoDocumento { get; set; }

        [JsonProperty("centro")]
        public string Centro { get; set; }

        [JsonProperty("domicilio")]
        public string Domicilio { get; set; }

        [JsonProperty("id_poblacion")]
        public long IdPoblacion { get; set; }

        [JsonProperty("poblacion")]
        public object Poblacion { get; set; }

        [JsonProperty("cp")]
        public string Cp { get; set; }

        [JsonProperty("provincia")]
        public object Provincia { get; set; }

        [JsonProperty("sexo")]
        public string Sexo { get; set; }

        [JsonProperty("fecha_nacimiento")]
        public object FechaNacimiento { get; set; }

        [JsonProperty("municipio")]
        public object Municipio { get; set; }

        [JsonProperty("id_pais")]
        public long IdPais { get; set; }

        [JsonProperty("pais")]
        public string Pais { get; set; }

        [JsonProperty("id_nacionalidad")]
        public long IdNacionalidad { get; set; }

        [JsonProperty("nacionalidad")]
        public object Nacionalidad { get; set; }

        [JsonProperty("tipo_cliente")]
        public string TipoCliente { get; set; }

        [JsonProperty("procede")]
        public object Procede { get; set; }

        [JsonProperty("telefono1")]
        public string Telefono1 { get; set; }

        [JsonProperty("telefono2")]
        public string Telefono2 { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        [JsonProperty("iban")]
        public object Iban { get; set; }

        [JsonProperty("pais_sms")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PaisSms { get; set; }

        [JsonProperty("telefono_movil")]
        public string TelefonoMovil { get; set; }

        [JsonProperty("idioma")]
        public string Idioma { get; set; }

        [JsonProperty("tipo_comunicacion")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TipoComunicacion { get; set; }

        [JsonProperty("guid")]
        public Guid Guid { get; set; }

        [JsonProperty("rgpd_autoriza_uso_datos_prestacion_servicio")]
        public bool RgpdAutorizaUsoDatosPrestacionServicio { get; set; }

        [JsonProperty("rgpd_autoriza_uso_datos_marketing")]
        public bool RgpdAutorizaUsoDatosMarketing { get; set; }

        [JsonProperty("rgpd_autoriza_uso_datos_evaluacion_satisfaccion_cliente")]
        public bool RgpdAutorizaUsoDatosEvaluacionSatisfaccionCliente { get; set; }

        [JsonProperty("rgpd_autoriza_cesion_derecho_imagenes")]
        public bool RgpdAutorizaCesionDerechoImagenes { get; set; }

        [JsonProperty("ultima_modificacion")]
        public object UltimaModificacion { get; set; }

        [JsonProperty("fecha_alta")]
        public DateTimeOffset? FechaAlta { get; set; }

        [JsonProperty("laclinica_usuario")]
        public object LaclinicaUsuario { get; set; }

        [JsonProperty("laclinica_password")]
        public object LaclinicaPassword { get; set; }
    }
}
