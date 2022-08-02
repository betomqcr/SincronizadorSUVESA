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

namespace SincronizadorQvetSuvesaPOS
{
    partial class Sincronizador : ServiceBase
    {
        Conections.Conections con = new Conections.Conections();
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

                //string res = con.GetUrlApiQvet();
                //string res2 = res;
                OnStop();
            }
            catch(Exception ex)
            {

            }
            bandera = false;
        }
    }
}
