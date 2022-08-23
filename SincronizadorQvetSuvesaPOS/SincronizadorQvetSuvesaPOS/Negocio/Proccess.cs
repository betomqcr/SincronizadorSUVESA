using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SincronizadorQvetSuvesaPOS.Datos;
using SincronizadorQvetSuvesaPOS.Helpers;
using SincronizadorQvetSuvesaPOS.Modelos;
using SincronizadorQvetSuvesaPOS.Models;


namespace SincronizadorQvetSuvesaPOS.Negocio
{
    public  class Proccess
    {
        Managers manager;
        Conections.Conections con;
        Modelos.Marca marca;// modelo 
        Models.Marca marcaArt;
        
        public Proccess() 
        {
            manager = new Managers();
            con = new Conections.Conections();
            marca = new Modelos.Marca();
            marcaArt = new Models.Marca();
        }

        public int insertarDatos()
        {
            try
            {
                long paginas = con.ObtenerPaginasTotales();
                List<Dato> listaDatos = new List<Dato>();
                List<Dato> listaDatosTemp = new List<Dato>();
                List<Albaran> listaAlbaran = new List<Albaran>();

                for (int i=1; i<=paginas; i++)
                {
                    marca = con.ObtenerResultadosApiVentas(i);
                    listaAlbaran = manager.ObtenerAlbaranesInsertados(marca.Datos);
                    //listaDatosTemp = manager.ObtenerDatosInsertados(marca.Datos);

                    //foreach(Albaran albaran in listaAlbaran)
                    //{
                    //    manager.BorrarAlbaranesPorActualizar(albaran);
                    //}                    

                    foreach (Dato datos in marca.Datos)
                    {
                        if (!manager.ExisteAlbaranInsertado(datos.IdAlbaran))
                        {
                            if(manager.ObtenerUltimoIdInsertado() < datos.IdAlbaran)
                            {
                                listaDatos.Add(datos);
                            }
                        }
                        else
                        {
                            foreach (Albaran al in listaAlbaran)
                            {
                                if (manager.ActualizarAlbaran(datos, al))
                                {
                                    if (manager.BorrarAlbaranesPorActualizar(al))
                                    {
                                        listaDatos.Add(datos);
                                    }
                                }
                            }
                        }
                    }
                }

                if (listaDatos.Count !=0)
                {
                    Dato first = listaDatos.First();
                    Dato last = listaDatos.Last();
                    Bitacora.Observaciones = $"Se inserto desde el número de albaran {first.IdAlbaran} hasta el número de albran {last.IdAlbaran}";
                    return manager.InsertarAlbaranes(listaDatos);
                }
                else
                {
                    EscrituraArchivo.escribirArchivo(tipoEscritura.CantidadAlbaranes, "0");
                    Bitacora.Observaciones = $"No se inserto nada en la base de datos";
                    return 0;
                }

                //return 0;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public List<ResultadoAPI> ActualizarArticulos()
        {
            try
            {
                Estadistica.cantidadActualizados = 0;
                Estadistica.cantidadCreados = 0;

                List<Articulo> articulosAPI = obtenerTodosArticulosAPI();

                List<Inventario> lista = manager.PendientesDeActualizar();
                List<Articulo> articulos = manager.ConvertirDeInventarioaArticulo(lista);

                List<ResultadoAPI> resultado = new List<ResultadoAPI>();
                string respuesta = "";

                foreach (Articulo temp in articulos)
                {
                    Articulo isValidArt = articulosAPI.Find(x => x.Descripcion == temp.Descripcion || x.IdArticulo == temp.IdArticulo);

                    if( isValidArt == null || (isValidArt != null && temp.IdArticulo != null))
                    {
                        if (temp.IdArticulo != null)
                        {
                            respuesta = con.ActualizarArticulos(temp);

                            if (respuesta == "1")
                                Estadistica.cantidadActualizados++;

                        }
                        else if (temp.IdArticulo == null)
                        {
                            respuesta = con.CrearArticulos(temp);
                            if (respuesta == "1")
                                Estadistica.cantidadCreados++;
                        }

                        ResultadoAPI dato = new ResultadoAPI()
                        {
                            codigo = (temp.IdArticulo != null) ? long.Parse(temp.IdArticulo.ToString()) : 0,
                            res = respuesta

                        };
                        resultado.Add(dato);
                    }
                    
                }

                return resultado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Articulo> obtenerTodosArticulosAPI()
        {
            try
            {
                List<Articulo> listaArt = new List<Articulo>();
                long paginas = con.ObtenerPaginasTotalesArticulos();

                for (int i = 1; i <= paginas; i++)
                {
                    marcaArt = con.ObtenerResultadosApiArticulos(i);

                    foreach (Models.Articulo datos in marcaArt.Articulos)
                    {
                        listaArt.Add(datos);
                    }
                }

                return listaArt;

            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public void escribirBitacora()
        {
            try
            {
                manager.InsertarBitacora();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
