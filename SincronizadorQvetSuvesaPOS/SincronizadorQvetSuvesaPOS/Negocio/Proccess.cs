using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SincronizadorQvetSuvesaPOS.Datos;
using SincronizadorQvetSuvesaPOS.Conections;

namespace SincronizadorQvetSuvesaPOS.Negocio
{
    public  class Proccess
    {
        Managers manager = new Managers();
        Conections.Conections con = new Conections.Conections();
        public Proccess()
        {

        }

        public int insertarDatos()
        {
            try
            {

                return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
