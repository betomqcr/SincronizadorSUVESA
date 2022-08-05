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
        public string linkAPI = "";
        public Conections()
        {
            linkAPI = GetUrlApiQvet();

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

        public string GetToken()
        {
            try
            {
                Token token = new Token();
                token.clientid = ConfigurationSettings.AppSettings["QvetWS"].ToString();
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            GLinkApi.linkApi+ "/auth",
                            new StringContent(token.ToString(), Encoding.UTF8, "application/json")
                            );
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Llave reslink = new Llave();
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        var jsonstrig = task2.Result;
                        reslink = JsonConvert.DeserializeObject<Llave>(jsonstrig);
                        GtokenApi.tokenApi = reslink.token;
                        return reslink.token;
                        
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        return "Error de credenciales";
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


        public Marca ObtenerResultadosApiVentas(long pagina)
        {
            try
            {
                
                Solicitud solicitud = new Solicitud();

                solicitud.DesdeFechaActualizacion = "2022-08-04";
                //solicitud.RegistrosPorPagina = 0;
                solicitud.Pagina = pagina;

                Marca marca = new Marca();

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GtokenApi.tokenApi);
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            GLinkApi.linkApi + "/ventas",
                            new StringContent(solicitud.ToString(), Encoding.UTF8, "application/json")
                            ); ;
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        var jsonstrig = task2.Result;
                        marca = JsonConvert.DeserializeObject<Marca>(jsonstrig);
                        
                        return marca;
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        return marca;
                    }
                    
                }
                return marca;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Marca ObtenerResultadosApiVentasSinPagina()
        {
            try
            {

                Solicitud solicitud = new Solicitud();

                //solicitud.DesdeFechaActualizacion = DateTime.Now.ToShortDateString();
                solicitud.DesdeFechaActualizacion = "2022-08-04";
                //solicitud.RegistrosPorPagina = 0;

                solicitud.Pagina = 1;
                Marca marca = new Marca();

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GtokenApi.tokenApi);
                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            GLinkApi.linkApi + "/ventas",
                            new StringContent(solicitud.ToString(), Encoding.UTF8, "application/json")
                            ); ;
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        var jsonstrig = task2.Result;
                        marca = JsonConvert.DeserializeObject<Marca>(jsonstrig);

                        return marca;
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        return marca;
                    }

                }
                return marca;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
