using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SincronizadorQvetSuvesaPOS.Helpers
{
    public enum tipoEscritura
    {
        HoraInicio,
        CantidadAlbaranes,
        CantidadLineasAlbaranes,
        HoraFinal,
        TiempoEmpleado
    }


    public static class EscrituraArchivo
    {
        
        public static string nameFile { get; set; }

        public static void escribirArchivo(tipoEscritura tipoEscritura, string value)
        {
            try
            {
                string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\LOG", nameFile + ".txt");

                if(CreateFolder(AppDomain.CurrentDomain.BaseDirectory + "\\LOG"))
                {
                    if (CreateFile(pathFile))
                    {

                        string line = "";

                        using (var fileStream = File.Open(pathFile, FileMode.Open))
                        {
                            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                            {
                                line = streamReader.ReadToEnd();
                            }
                        }

                        switch (tipoEscritura)
                        {
                            case tipoEscritura.HoraInicio:
                                value = $"Hora Inicial: {value}";
                                break;

                            case tipoEscritura.CantidadAlbaranes:
                                value = $"Cantidad Albaranes: {value}";
                                break;

                            case tipoEscritura.CantidadLineasAlbaranes:
                                value = $"Cantidad Lineas Albaranes: {value}";
                                break;

                            case tipoEscritura.HoraFinal:
                                value = $"Hora Final: {value}";
                                break;

                            case tipoEscritura.TiempoEmpleado:
                                value = $"Tiempo Empleado: {value}";
                                break;

                            default:
                                break;
                        }

                        line += Environment.NewLine + value;
                        File.WriteAllText(pathFile, line, Encoding.UTF8);
                    }
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        private static bool CreateFolder(string path)
        {
            bool created = true;
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch
            {
                created = false;
            }

            return created;
        }

        private static bool CreateFile(string where)
        {
            bool created = true;
            try
            {
                if (!File.Exists(where))
                {
                    File.Create(where).Close();
                }
            }
            catch
            {
                created = false;
            }
            return created;
        }

    }
}
