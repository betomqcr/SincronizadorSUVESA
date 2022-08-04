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
                int resa = 0;
                int resb = 0;
                foreach (Dato dato in datos)
                {
                    Albaran a = new Albaran();
                    a.NombreCliente = dato.Cliente.Nombre;
                    a.NombreMascota = (dato.Mascota==null)?" ": dato.Mascota.Nombre;
                    a.Fecha = DateTime.Parse(dato.Fecha.ToString());
                    a.Id_Qvet_Migrado = dato.IdAlbaran;
                    a.Cedula = dato.Cliente.Documento;
                    a.Id_Mascota_Qvet = (dato.Mascota==null)?0 : int.Parse(dato.Mascota.IdMascota.ToString());
                    a.Email = dato.Cliente.Email;
                    a.Direccion = dato.Cliente.Domicilio;
                    a.NHC_Mascota = (dato.Mascota== null)?" ": dato.Mascota.Nhc;
                    a.Responsable = dato.ResponsableVenta;
                    a.Tipo_Cliente = dato.Cliente.TipoCliente;
                    a.CHIP_Mascota = (dato.Mascota==null)?" ": dato.Mascota.Chip;
                    a.facturado = false;
                   // entities.Albarans.Add(a);
                    //entities.SaveChanges();
                    resa++;
                    //long t= ObtenerIdDeAlbaranMigrado(dato.IdAlbaran);
                    // Consulto id del que inserto
                    List<Albaran_Detalle> listat = new List<Albaran_Detalle>();  
                    foreach (ListaLinea lista in dato.ListaLineas)
                    {
                        Albaran_Detalle d = new Albaran_Detalle();
                        //d.idEncabezado = t;
                        d.Descripcion = lista.Descripcion;
                        d.CodigoInternoQvet = int.Parse(lista.IdArticulo.ToString());
                        d.IVA = int.Parse(lista.Iva.Valor.ToString());
                        d.descuento = lista.Descuento;
                        d.PrecioVenta = lista.Tarifa.PrecioUnitario;
                        d.Cantidad = lista.Cantidad;
                        d.Total = lista.Total;
                        //entities.Albaran_Detalle.Add(d);
                        //entities.SaveChanges();
                        listat.Add(d);
                        resb++;
                        
                    }
                    a.Albaran_Detalle=listat;

                    entities.Albarans.Add(a);
                    entities.SaveChanges();

                    // con id del insertado y inserto la lineas
                }
                if (resa==0 && resb==0)
                
                    return 0;
                
                else
                    return resa;
                
            }
            catch(Exception ex)
            {
                throw ex;
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

        public bool ExisteAlbaranInsertado(long registro)
        {
            try
            {
                long res = 0;
                var query = from c in entities.Albarans
                            where c.Id_Qvet_Migrado == registro
                            select c;
                List<Albaran> lista = query.ToList();

                foreach(Albaran temp in lista)
                {
                    res = temp.Id_Qvet_Migrado;
                }
                if(res== registro)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // un metod para validar que no este insertado


        // metodo para insertar lineas llamar en albaran



    }
}
