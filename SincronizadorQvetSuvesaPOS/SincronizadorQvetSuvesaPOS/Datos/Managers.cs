using System;
using System.Collections.Generic;
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
                long res = 0;
                var query = from c in entities.Albarans
                            where c.Id_Qvet_Migrado == registro
                            select c;
                List<Albaran> lista = query.ToList();

                foreach (Albaran temp in lista)
                {
                    res = temp.Id_Qvet_Migrado;
                }
                if (res == registro)
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

        public List<Inventario> PendientesDeActualizar()
        {
            try
            {
                List<Inventario> lista;
                var query = from c in entities.Inventarios
                            where c.FechaIngreso.Equals(DateTime.Now.Date) || c.FechaActualizacion.Equals(DateTime.Now.Date)
                            select c;
                lista = query.ToList();

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

                foreach(Inventario temp in lista)
                {
                    Articulo art = new Articulo()
                    {
                        IdArticulo = long.Parse(temp.Cod_Articulo),
                        Descripcion = temp.Descripcion,
                        Descripcion2 = temp.Descripcion,
                        CodigoBarras = temp.Barras,
                        FactorConversion = 1,
                        Seccion = null,
                        Familia = null,
                        Subfamilia = null,
                        Tipo = "Normal",
                        TipoEscandallo = 0,
                        ControlStock = 0,
                        FechaAlta = temp.FechaIngreso.ToString(),
                        Activo=true,
                        Precio=long.Parse(temp.Precio_A.ToString()),
                                
                    };
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
                        PrecioUnitario= long.Parse(temp.Precio_A.ToString())
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



    }
}
