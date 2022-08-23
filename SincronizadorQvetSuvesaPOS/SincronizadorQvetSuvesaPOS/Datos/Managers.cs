using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SincronizadorQvetSuvesaPOS.Datos;
using SincronizadorQvetSuvesaPOS.Helpers;
using SincronizadorQvetSuvesaPOS.Modelos;
using SincronizadorQvetSuvesaPOS.Models;

namespace SincronizadorQvetSuvesaPOS.Datos
{

    public class Managers
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
                    a.NombreMascota = (dato.Mascota == null) ? " " : dato.Mascota.Nombre;
                    a.Fecha = DateTime.Parse(dato.Fecha.ToString());
                    a.Id_Qvet_Migrado = dato.IdAlbaran;
                    a.Cedula = dato.Cliente.Documento;
                    a.Id_Mascota_Qvet = (dato.Mascota == null) ? 0 : int.Parse(dato.Mascota.IdMascota.ToString());
                    a.Email = dato.Cliente.Email;
                    a.Direccion = dato.Cliente.Domicilio;
                    a.NHC_Mascota = (dato.Mascota == null) ? " " : dato.Mascota.Nhc;
                    a.Responsable = dato.ResponsableVenta;
                    a.Tipo_Cliente = dato.Cliente.TipoCliente;
                    a.CHIP_Mascota = (dato.Mascota == null) ? " " : dato.Mascota.Chip;
                    a.facturado = false;
                    entities.Albarans.Add(a);
                    entities.SaveChanges();
                    resa++;
                    long t = ObtenerIdDeAlbaranMigrado(dato.IdAlbaran);
                    // Consulto id del que inserto
                    //List<Albaran_Detalle> listat = new List<Albaran_Detalle>();  
                    foreach (ListaLinea lista in dato.ListaLineas)
                    {
                        Albaran_Detalle d = new Albaran_Detalle();
                        d.idEncabezado = t;
                        d.Descripcion = lista.Descripcion;
                        d.CodigoInternoQvet = int.Parse(lista.IdArticulo.ToString());
                        d.IVA = int.Parse(lista.Iva.Valor.ToString());
                        d.descuento = lista.Descuento;
                        d.PrecioVenta = lista.Tarifa.PrecioUnitario;
                        d.Cantidad = lista.Cantidad;
                        d.Total = lista.Total;
                        entities.Albaran_Detalle.Add(d);
                        entities.SaveChanges();
                        //listat.Add(d);
                        resb++;

                    }
                    //a.Albaran_Detalle=listat;

                    //entities.Albarans.Add(a);
                    //entities.SaveChanges();

                    // con id del insertado y inserto la lineas
                }

                //Verificar los datos de los contadores y escribrir el archivo
                EscrituraArchivo.escribirArchivo(tipoEscritura.CantidadAlbaranes, resa.ToString());
                EscrituraArchivo.escribirArchivo(tipoEscritura.CantidadLineasAlbaranes, resb.ToString());

                if (resa == 0 && resb == 0)
                    return 0;
                else
                    return resa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                //long res = 0;
                //var query = from c in entities.Albarans
                //            where c.Id_Qvet_Migrado == registro
                //            select c;
                //List<Albaran> lista = query.ToList();

                //foreach (Albaran temp in lista)
                //{
                //    res = temp.Id_Qvet_Migrado;
                //}

                Albaran albaran = entities.Albarans.FirstOrDefault(x => x.Id_Qvet_Migrado == registro);

                if (albaran != null)
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

        public long ObtenerUltimoIdInsertado()
        {
            try
            {
                var id = from c in entities.Albarans
                         select c.Id_Qvet_Migrado;

                List<long> numbers = id.ToList();
                if (numbers.Count > 0)
                    return numbers.Max();

                return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActualizarAlbaran(Dato dato, Albaran albaran )
        {
            try
            {
                if(dato.IdAlbaran == albaran.Id_Qvet_Migrado)
                {
                    decimal SumaDato = 0;
                    decimal SumaAlbaran = 0;

                    foreach (ListaLinea temp in dato.ListaLineas)
                    {
                        SumaDato = SumaDato + temp.Total;
                    }
                    foreach (Albaran_Detalle temp2 in albaran.Albaran_Detalle)
                    {
                        SumaAlbaran = SumaAlbaran + temp2.Total;
                    }

                    if (SumaAlbaran == SumaDato)
                        return false;
                    else
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

        public bool BorrarAlbaranesPorActualizar(Albaran albaran)
        {
            try
            {
                if(albaran.facturado == false)
                {

                    Albaran alb = entities.Albarans.FirstOrDefault(x => x.Id_Qvet_Migrado == albaran.Id_Qvet_Migrado);

                    if(alb != null )
                    {
                        List<Albaran_Detalle> temp = entities.Albaran_Detalle.Where(x => x.idEncabezado == alb.id).ToList();
                        foreach (Albaran_Detalle albaran_Detalle in temp)
                        {
                            entities.Albaran_Detalle.Remove(albaran_Detalle);
                        }

                        Albaran temp2 = entities.Albarans.FirstOrDefault(x => x.Id_Qvet_Migrado == albaran.Id_Qvet_Migrado);

                        int res1 = entities.SaveChanges();
                        if (res1 != 0)
                        {
                            entities.Albarans.Remove(temp2);
                            int res2 = entities.SaveChanges();
                            if (res2 != 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public bool BorrarAlbaranesLista(List<Albaran> albaranes)
        {
            try
            {
                bool isCorrect = false;

                foreach(Albaran albaran in albaranes)
                {
                    if (albaran.facturado == false)
                    {
                        long id = entities.Albarans.FirstOrDefault(x => x.Id_Qvet_Migrado == albaran.Id_Qvet_Migrado).id;
                        Albaran_Detalle temp = entities.Albaran_Detalle.FirstOrDefault(x => x.idEncabezado == id);

                        Albaran temp2 = entities.Albarans.FirstOrDefault(x => x.Id_Qvet_Migrado == albaran.Id_Qvet_Migrado);

                        entities.Albaran_Detalle.Remove(temp);

                        if (entities.SaveChanges() != 0)
                        {
                            entities.Albarans.Remove(temp2);
                            if (entities.SaveChanges() != 0)
                            {
                                isCorrect = true;
                            }
                            else
                            {
                                isCorrect = false;
                            }
                        } else
                        {
                            isCorrect = false;
                        }

                    }
                }

                return isCorrect;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Albaran> ObtenerAlbaranesInsertados(List<Dato> datos)
        {
            try
            {
                List<Albaran> lista = new List<Albaran>();

                foreach(Dato temp in datos)
                {
                    List<Albaran> lista1 = entities.Albarans.Where(x => x.Id_Qvet_Migrado == temp.IdAlbaran).ToList();
                    if(lista1.Count != 0)
                        lista.Add(lista1.First());

                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Dato> ObtenerDatosInsertados(List<Dato> datos)
        {
            try
            {
                List<Dato> lista = new List<Dato>();

                foreach (Dato temp in datos)
                {
                   
                    if(ExisteAlbaranInsertado(temp.IdAlbaran))
                    {
                        lista.Add(temp);
                    }

                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Inventario> PendientesDeActualizar()
        {
            try
            {
                List<Inventario> lista = new List<Inventario>();

                var rslt = entities.Inventarios
                  .Where(v => SqlFunctions.DatePart("year", v.FechaActualizacion) == SqlFunctions.DatePart("year", DateTime.Now))
                  .Where(v => SqlFunctions.DatePart("dayofyear", v.FechaActualizacion) == SqlFunctions.DatePart("dayofyear", DateTime.Now)) 
                  .ToList();

                var rslt2 = entities.Inventarios
                 .Where(v => SqlFunctions.DatePart("year", v.FechaIngreso) == SqlFunctions.DatePart("year", DateTime.Now))
                 .Where(v => SqlFunctions.DatePart("dayofyear", v.FechaIngreso) == SqlFunctions.DatePart("dayofyear", DateTime.Now))
                 .ToList();

                foreach( Inventario temp in rslt)
                {
                    lista.Add(temp);
                }
                
                foreach (Inventario temp in rslt2)
                {
                    Inventario inventario = lista.Find(x => x.Codigo == temp.Codigo);
                    if(inventario == null)
                    {
                        lista.Add(temp);
                    }
                }

                return lista;
            
            }   
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Articulo> ConvertirDeInventarioaArticulo(List<Inventario> lista)
        {
            try
            {
                List<Articulo> resultado = new List<Articulo>();
                

                foreach (Inventario temp in lista)
                {
                    Articulo art = new Articulo();

                    if(temp.Cod_Articulo != "" && temp.Cod_Articulo.All(char.IsDigit))
                    {
                        art.IdArticulo = long.Parse(temp.Cod_Articulo);
                    }

                    art.Descripcion = temp.Descripcion;
                    art.Descripcion2 = temp.Descripcion;
                    art.CodigoBarras = temp.Barras;
                    art.FactorConversion = 1;
                    art.Seccion = null;
                    art.Familia = null;
                    art.Subfamilia = null;
                    art.Tipo = "Normal";
                    art.TipoEscandallo = 0;
                    art.ControlStock = 0;
                    art.FechaAlta = temp.FechaIngreso.ToString();
                    art.Activo = true;
                    art.Precio = temp.Precio_A;

                    Models.Iva iva = new Models.Iva()
                    {
                        Id=22,
                        Descripcion="13 %",
                        Valor=13
                    };

                    Models.ListaTarifa tarifas = new ListaTarifa()
                    {
                        IdTarifa=46,
                        Nombre= "Tarifa 1",
                        PrecioUnitario= temp.Precio_A
                    };
                    List<ListaTarifa> listaTarifas = new List<ListaTarifa>();
                    art.Iva = iva;
                    listaTarifas.Add(tarifas);
                    art.ListaTarifas = listaTarifas;
                    

                    resultado.Add(art);
                }
                return resultado;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int InsertarBitacora()
        {
            try
            {
                Bitacora_Albaran bitacora = new Bitacora_Albaran()
                {
                    Usuario_Suvesa = Bitacora.UsuarioSuvesa,
                    Accion = Bitacora.Accion,
                    Fecha_Hora = DateTime.Now,
                    Observaciones = Bitacora.Observaciones
                };

                entities.Bitacora_Albaran.Add(bitacora);
                int res = entities.SaveChanges();

                //Escribrir el archivo
                if(res != 0)
                    EscrituraArchivo.escribirArchivo(tipoEscritura.Bitacora, Bitacora.UsuarioSuvesa);

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
