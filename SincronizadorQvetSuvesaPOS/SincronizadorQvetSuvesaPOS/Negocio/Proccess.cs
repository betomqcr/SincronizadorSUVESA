using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SincronizadorQvetSuvesaPOS.Datos;
using SincronizadorQvetSuvesaPOS.Modelos;
using SincronizadorQvetSuvesaPOS.Models;


namespace SincronizadorQvetSuvesaPOS.Negocio
{
    public  class Proccess
    {
        Managers manager = new Managers();
        Conections.Conections con = new Conections.Conections();
        Modelos.Marca marca = new Modelos.Marca();// modelo
        Articulo articulo = new Articulo();
        

        
        public Proccess() { }

        public int insertarDatos()
        {
            try
            {
                //Marca marca1 = new Marca();// modelo
                //marca1 = con.ObtenerResultadosApiVentasSinPagina();

                long paginas = con.ObtenerPaginasTotales();
                List<Dato> listaDatos = new List<Dato>();

                for (int i=1; i<=paginas; i++)
                {
                    marca = con.ObtenerResultadosApiVentas(i);
                    
                    foreach (Dato datos in marca.Datos)
                    {
                        if (!manager.ExisteAlbaranInsertado(datos.IdAlbaran))
                        {
                           if(manager.ObtenerUltimoIdInsertado() < datos.IdAlbaran)
                            listaDatos.Add(datos);
                        }
                    }
                }

                if(listaDatos.Count !=0 || listaDatos != null)
                    return manager.InsertarAlbaranes(listaDatos);

                return 0;
                
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
                List<Inventario> lista = manager.PendientesDeActualizar();
                List<Articulo> articulos = manager.ConvertirDeInventarioaArticulo(lista);
                bool bandera = false;
                List<ResultadoAPI> resultado = new List<ResultadoAPI>();
                string respuesta;

                foreach (Articulo temp in articulos)
                {
             
                   respuesta= con.CrearoActualizarArticulos(temp);
                    ResultadoAPI dato = new ResultadoAPI()
                    {
                        codigo= long.Parse(temp.IdArticulo.ToString()),
                        res= respuesta

                    };
                    resultado.Add(dato);
                }

                return resultado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
