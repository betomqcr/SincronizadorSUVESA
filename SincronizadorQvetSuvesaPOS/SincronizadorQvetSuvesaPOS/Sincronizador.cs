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

        // Variables globales
        bool bandera= false;
        Conections.Conections con = new Conections.Conections();
        Negocio.Proccess pro = new Negocio.Proccess();

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
                int res = pro.insertarDatos();


                bandera = false;

                OnStop();
            }
            catch(Exception ex)
            {
                // VER VIDEO PARA VER COMO SE ESCRIBE EL LOG
            }
            
        }
    }
}
