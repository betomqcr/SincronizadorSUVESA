using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SincronizadorQvetSuvesaPOS.Datos;

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

            }
            catch(Exception ex)
            {

            }
            return 0; 
        }


    }
}
