using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SincronizadorQvetSuvesaPOS.Datos;
using SincronizadorQvetSuvesaPOS.Modelos;

namespace SincronizadorQvetSuvesaPOS.Datos
{
    
    public  class Managers
    {
        public SINCRONIZADOREntities entities;
        public Managers()
        {
            entities = new SINCRONIZADOREntities();
        }

        public int InsertarAlbaranes()
        {
            try
            {
                string link = GLinkApi.linkApi; //Borrar solo para explicarle a Beto
            }
            catch(Exception ex)
            {

            }
            return 0; 
        }


    }
}
