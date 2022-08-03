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
                    Albaran a = new Albaran();
                    a.NombreCliente = dato.Cliente.Nombre;
                    a.NombreMascota = dato.Mascota.Nombre;
                    a.Fecha = dato.Fecha;
                    a.Id_Qvet_Migrado = dato.IdAlbaran;
                    a.Cedula = dato.Cliente.Documento;
                    a.Id_Mascota_Qvet = dato.Mascota.IdMascota;
                    a.Email = dato.Cliente.Email;
                    a.Direccion = dato.Cliente.Domicilio;
                    a.NHC_Mascota = dato.Mascota.Nhc;
                    a.Responsable = dato.ResponsableVenta;
                    a.Tipo_Cliente = dato.Cliente.TipoCliente;
                    a.CHIP_Mascota = dato.Mascota.Chip;
                    a.facturado = false;
                    entities.Albarans.Add(a);
                    return entities.SaveChanges();

                    long t= ObtenerIdDeAlbaranMigrado(dato.IdAlbaran);
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
