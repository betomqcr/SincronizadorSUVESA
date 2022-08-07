//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SincronizadorQvetSuvesaPOS.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventario
    {
        public long Codigo { get; set; }
        public string Cod_Articulo { get; set; }
        public string Barras { get; set; }
        public string Descripcion { get; set; }
        public double PresentaCant { get; set; }
        public int CodPresentacion { get; set; }
        public int CodMarca { get; set; }
        public string SubFamilia { get; set; }
        public double Minima { get; set; }
        public double PuntoMedio { get; set; }
        public double Maxima { get; set; }
        public double Existencia { get; set; }
        public string SubUbicacion { get; set; }
        public string Observaciones { get; set; }
        public int MonedaCosto { get; set; }
        public double PrecioBase { get; set; }
        public double Fletes { get; set; }
        public double OtrosCargos { get; set; }
        public double Costo { get; set; }
        public int MonedaVenta { get; set; }
        public double IVenta { get; set; }
        public double Precio_A { get; set; }
        public double Precio_B { get; set; }
        public double Precio_C { get; set; }
        public double Precio_D { get; set; }
        public double Precio_Promo { get; set; }
        public bool Promo_Activa { get; set; }
        public System.DateTime Promo_Inicio { get; set; }
        public System.DateTime Promo_Finaliza { get; set; }
        public double Max_Comision { get; set; }
        public double Max_Descuento { get; set; }
        public byte[] Imagen { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public bool Servicio { get; set; }
        public bool Inhabilitado { get; set; }
        public int Proveedor { get; set; }
        public double Precio_Sugerido { get; set; }
        public double SugeridoIV { get; set; }
        public bool PreguntaPrecio { get; set; }
        public bool Lote { get; set; }
        public bool Consignacion { get; set; }
        public int Id_Bodega { get; set; }
        public double ExistenciaBodega { get; set; }
        public double MAX_Inventario { get; set; }
        public double MAX_Bodega { get; set; }
        public Nullable<double> CantidadDescarga { get; set; }
        public string CodigoDescarga { get; set; }
        public Nullable<bool> DescargaOtro { get; set; }
        public int Cod_PresentOtro { get; set; }
        public double CantidadPresentOtro { get; set; }
        public Nullable<double> ExistenciaForzada { get; set; }
        public Nullable<bool> bloqueado { get; set; }
        public Nullable<bool> pantalla { get; set; }
        public Nullable<bool> clinica { get; set; }
        public Nullable<bool> mascotas { get; set; }
        public Nullable<bool> receta { get; set; }
        public Nullable<bool> peces { get; set; }
        public Nullable<bool> taller { get; set; }
        public string barras2 { get; set; }
        public string barras3 { get; set; }
        public Nullable<double> Apartado { get; set; }
        public Nullable<bool> promo3x1 { get; set; }
        public Nullable<bool> orden { get; set; }
        public Nullable<bool> bonificado { get; set; }
        public string encargado { get; set; }
        public long serie { get; set; }
        public Nullable<bool> armamento { get; set; }
        public Nullable<bool> tienda { get; set; }
        public Nullable<double> prestamo { get; set; }
        public Nullable<bool> maquinaria { get; set; }
        public Nullable<bool> productos_organicos { get; set; }
        public Nullable<long> rifa { get; set; }
        public bool PromoCON { get; set; }
        public bool PromoCRE { get; set; }
        public Nullable<double> CostoReal { get; set; }
        public bool ValidaExistencia { get; set; }
        public bool Actualizado { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }
        public decimal Id_Impuesto { get; set; }
        public bool ActivarBodega2 { get; set; }
        public double ExistenciaBodega2 { get; set; }
        public bool EnToma { get; set; }
        public bool UsaGalon { get; set; }
        public bool ApicarDescuentoTarjeta { get; set; }
        public bool SoloContado { get; set; }
        public bool SoloConExistencia { get; set; }
        public bool MAG { get; set; }
        public bool SinDecimal { get; set; }
        public string CODCABYS { get; set; }
        public long CodigoPrestamo { get; set; }
        public bool Muestra { get; set; }
        public bool Web { get; set; }
        public bool SoloUsoInterno { get; set; }
    }
}