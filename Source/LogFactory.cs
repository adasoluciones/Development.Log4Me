using System;

namespace Ada.Framework.Development.Log4Me
{
    /// <summary>
    /// Factoría del Log.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public static class LogFactory
    {
        /// <summary>
        /// Obtener una implementación de Log4Me.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="clase">Clase que será logeada.</param>
        /// <returns>Implementacion de Log4Me</returns>
        public static ILog ObtenerLog(Type clase)
        {
            return new ManualLog();
        }
        
        /// <summary>
        /// Inicializa el estado del log y carga los valores para su correcto funcionamiento. Debe ser llamado cada vez que se inicie un hilo, y antes
        /// de logear cualquier cosa. (Se recomienda que en una aplicación web, se llame en Application_BeginRequest).
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static void Inicializar()
        {
            Log4MeManager.Inicializar();
        }
    }
}
