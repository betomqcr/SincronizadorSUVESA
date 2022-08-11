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
using SincronizadorQvetSuvesaPOS.Models;

namespace SincronizadorQvetSuvesaPOS.Conections
{
    public class Conections
    {
        public Conections() { }

        public string GetUrlApiQvet()//obtener la url del api a consultar
        {
            try
            {
                string url = ConfigurationSettings.AppSettings["RutaApiUrl"].ToString();
                string id = ConfigurationSettings.AppSettings["QvetWS"].ToString();

                Link link = new Link()
                {
                    id = id,
                };

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
                throw ex;
            }
        }

        public string GetToken()// obtener token del api
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

        public Modelos.Marca ObtenerResultadosApiVentas(long pagina)// obtener las ventas del api
        {
            try
            {

                Solicitud solicitud = new Solicitud()
                {
                    DesdeFechaActualizacion = DateTime.Now.ToString("yyyy/MM/dd"),
                    Pagina = pagina
                };

                Modelos.Marca marca = new Modelos.Marca();

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
                        marca = JsonConvert.DeserializeObject<Modelos.Marca>(jsonstrig);
                        
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

        public long ObtenerPaginasTotales()// obtener las paginas del resulta del api
        {
            try
            {

                Solicitud solicitud = new Solicitud()
                {
                    DesdeFechaActualizacion = DateTime.Now.ToString("yyyy/MM/dd"),
                    Pagina = 1
                };

                Modelos.Marca marca = new Modelos.Marca();

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GtokenApi.tokenApi);

                    var task = Task.Run(async () =>
                    {
                        return await client.PostAsync(
                            GLinkApi.linkApi + "/ventas",
                            new StringContent(solicitud.ToString(), Encoding.UTF8, "application/json")); ;
                    });

                    HttpResponseMessage message = task.Result;

                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });

                        var jsonstrig = task2.Result;

                        marca = JsonConvert.DeserializeObject<Modelos.Marca>(jsonstrig);

                        return marca.PaginasTotales;
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        return 0;
                    }

                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CrearArticulos(Articulo Articulo)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GtokenApi.tokenApi);

                    var task = Task.Run(async () =>
                    {
                        return await client.PutAsync(
                            GLinkApi.linkApi + "/articulos",
                            new StringContent(Articulo.ToString(), Encoding.UTF8, "application/json")
                        );
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "0";
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string ActualizarArticulos(Articulo Articulo)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + GtokenApi.tokenApi);

                    var task = Task.Run(async () =>
                    {
                        return await client.PutAsync(
                            GLinkApi.linkApi + "/articulos",
                            new StringContent(Articulo.ToString(), Encoding.UTF8, "application/json")
                        );
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return "1";
                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return "0";
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
                throw ex;
            }
        }
    }
}
