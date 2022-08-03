using SincronizadorQvetSuvesaPOS.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;


namespace SincronizadorQvetSuvesaPOS.Modelos
{
    public static class Serialize
    {
        public static string ToJson(this Marca self) => JsonConvert.SerializeObject(self, SincronizadorQvetSuvesaPOS.Modelos.Converter.Settings);

        public static string ToJson2(this Solicitud self) => JsonConvert.SerializeObject(self, SincronizadorQvetSuvesaPOS.Modelos.Converter.Settings);
    }
}
