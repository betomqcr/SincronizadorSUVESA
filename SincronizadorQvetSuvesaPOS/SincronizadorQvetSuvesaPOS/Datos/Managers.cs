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

        public int InsertarAlbaranes(List<Dato> datos)
        {
            try
            {
                foreach (Dato dato in datos)
                {
                    //aqui inserto
                    // Consulto id del que inserto
                    // con id del insertado y inserto la lineas
                }
                
            }
            catch(Exception ex)
            {

            }
            return 0; 
        }

        public long ObtenerIdDeAlbaranMigrado(long id)
        {
            try
            {
                var query = from c in entities.Albarans
                            where c.Id_Qvet_Migrado == id
                            select c;

                List<Albaran> albaran = query.ToList();
                foreach (Albaran al in albaran)
                {
                    return al.id;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //un metodo para obtener id del alabaran insertado(id Qvet migrado)
        // un metod para validar que no este insertado
        // metodo para insertar lineas llamar en albaran



    }
}
