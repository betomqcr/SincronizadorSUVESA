using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SincronizadorQvetSuvesaPOS.Datos;
using SincronizadorQvetSuvesaPOS.Conections;
using SincronizadorQvetSuvesaPOS.Modelos;

namespace SincronizadorQvetSuvesaPOS.Negocio
{
    public  class Proccess
    {
        Managers manager = new Managers();
        Conections.Conections con = new Conections.Conections();
        Marca marca = new Marca();// modelo
        
        public Proccess()
        {

        }

        public int insertarDatos()
        {
            try
            {
                Marca marca1 = new Marca();// modelo
                marca1 = con.ObtenerResultadosApiVentasSinPagina();
                long paginas = marca1.PaginasTotales;
                List<Dato> listaDatos = new List<Dato>();

                for (int i=1;i<=2;i++)
                {
                    marca = con.ObtenerResultadosApiVentas(i);
                    
                    foreach (Dato datos in marca.Datos)
                    {
                        if (!manager.ExisteAlbaranInsertado(datos.IdAlbaran))
                        {
                            listaDatos.Add(datos);
                        }
                    }
                }

                if(listaDatos.Count !=0 || listaDatos != null)
                {
                    int res =manager.InsertarAlbaranes(listaDatos);
                    return res;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
