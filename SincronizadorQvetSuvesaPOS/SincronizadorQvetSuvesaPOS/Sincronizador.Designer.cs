namespace SincronizadorQvetSuvesaPOS
{
    partial class Sincronizador
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.st_Inicio = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.st_Inicio)).BeginInit();
            // 
            // st_Inicio
            // 
            this.st_Inicio.Enabled = true;
            this.st_Inicio.Interval = 10000D;
            this.st_Inicio.Elapsed += new System.Timers.ElapsedEventHandler(this.st_Inicio_Elapsed);
            // 
            // Sincronizador
            // 
            this.ServiceName = "Sincronizador";
            ((System.ComponentModel.ISupportInitialize)(this.st_Inicio)).EndInit();

        }

        #endregion

        private System.Timers.Timer st_Inicio;
    }
}
