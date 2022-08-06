﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using SincronizadorQvetSuvesaPOS.Helpers;
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
                // Iniciar el tiempo aqui
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                bandera = true;

                // Establece el nombre del archivo de texto
                EscrituraArchivo.nameFile = $"SincronizadorSuvesa{DateTime.Now.ToString("yyyyMMddTHHmmss")}";

                // Escribe Hora Inicial
                EscrituraArchivo.escribirArchivo(tipoEscritura.HoraInicio, DateTime.Now.ToString());

                GLinkApi.linkApi = con.GetUrlApiQvet();
                GtokenApi.tokenApi = con.GetToken();

                int res = pro.insertarDatos();

                // Escribe Hora Final
                EscrituraArchivo.escribirArchivo(tipoEscritura.HoraFinal, DateTime.Now.ToString());

                // Escribe Tiempo Empleado
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                    ts.Hours, ts.Minutes, ts.Seconds,
                                                    ts.Milliseconds / 10);
                EscrituraArchivo.escribirArchivo(tipoEscritura.TiempoEmpleado, elapsedTime);

                bandera = false;

                OnStop();
            }
            catch(Exception ex)
            {
                EventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
            
        }

    }
}
