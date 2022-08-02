using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SincronizadorQvetSuvesaPOS.Modelos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Configuration;
using System.Net.Http.Headers;

namespace SincronizadorQvetSuvesaPOS.Conections
{
    public class Conections
    {
        public Conections()
        {

        }

        public  string GetUrlApiQvet()
        {
            try
            {
                string url = ConfigurationSettings.AppSettings["RutaApiUrl"].ToString();
                string id = ConfigurationSettings.AppSettings["QvetWS"].ToString();

                Link link = new Link();
                link.id = id;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            url,
                            new StringContent(link.ToString(), Encoding.UTF8, "application/json")
                            );
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ResultadoLink reslink = new ResultadoLink();
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        var jsonstrig = task2.Result;
                        reslink = JsonConvert.DeserializeObject<ResultadoLink>(jsonstrig);
                        string resultStr = reslink.ObtenerUrlApiResult;
                        return resultStr;
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        return "Error de Servidor";
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        return error.Exceptionmessage;
                    }
                }


            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
    }
}
