using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using SincronizadorQvetSuvesaPOS.Conections;
using SincronizadorQvetSuvesaPOS.Datos;
using SincronizadorQvetSuvesaPOS.Modelos;

namespace SincronizadorQvetSuvesaPOS
{
    partial class Sincronizador : ServiceBase
    {
        Conections.Conections con = new Conections.Conections();
        Managers man = new Managers(); //Borrar solo para explicarle a Beto
        bool bandera= false;

        public Sincronizador()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: agregar código aquí para iniciar el servicio.
            st_Inicio.Start();

        }

        protected override void OnStop()
        {
            // TODO: agregar código aquí para realizar cualquier anulación necesaria para detener el servicio.
            st_Inicio.Stop();
        }

        private void st_Inicio_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (bandera) return;
            try
            {
                bandera = true;

                GLinkApi.linkApi = con.GetUrlApiQvet();
                GtokenApi.tokenApi = con.GetToken();

                
                con.ObtenerResultadosApiVentas();
                //man.InsertarAlbaranes(); // borrar solo explicarle a Beto


                OnStop();
            }
            catch(Exception ex)
            {

            }
            bandera = false;
        }
    }
}
