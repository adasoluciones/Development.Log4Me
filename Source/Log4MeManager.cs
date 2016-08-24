using Ada.Framework.Development.Log4Me.Config;
using Ada.Framework.Development.Log4Me.Config.Entities;
using Ada.Framework.Extensions.Threading;
using System;
using System.Threading;

namespace Ada.Framework.Development.Log4Me
{
    /// <summary>
    /// Administrador de Log4Me.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class Log4MeManager : Attribute
    {
        /// <summary>
        /// Delegado inicializador de Log4Me sin parámetros.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public delegate void InicializadorDelegate();

        /// <summary>
        /// Prefijo para almacenar variables en el hilo actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly string PrefijoThread = "Log4Me_";

        /// <summary>
        /// Obtiene el identificador único (GUID) del hilo actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static string ThreadGUID
        {
            get
            {
                string threadGUID = Thread.CurrentThread.Obtener(PrefijoThread + "ThreadGUID") as string;

                if (threadGUID == null)
                {
                    threadGUID = Guid.NewGuid().ToString();
                    Thread.CurrentThread.Guardar(PrefijoThread + "ThreadGUID", threadGUID);
                }

                return threadGUID;
            }
        }
        
        /// <summary>
        /// Permite obtener la instancia actual del Logger.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static ILog CurrentInstance
        {
            get
            {
                return Thread.CurrentThread.Obtener(PrefijoThread + "CurrentInstance") as ILog;
            }
            internal set
            {
                Thread.CurrentThread.Guardar(PrefijoThread + "CurrentInstance", value);
            }
        }

        /// <summary>
        /// Permite obtener la configuración actual de Log4Me.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static Log4MeConfig Configuration { get; set; }
        
        /// <summary>
        /// Campo que contiene el delegado inicializador de Log4Me. 
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static InicializadorDelegate Inicializador;

        /// <summary>
        /// Constructor que define el delegado que inicializará Log4Me.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="inicializador">Delegado inicializador de Log4Me.</param>
        public Log4MeManager(InicializadorDelegate inicializador)
        {
            Inicializador = inicializador;
        }

        /// <summary>
        /// Inicializa el estado del log y carga los valores para su correcto funcionamiento. Debe ser llamado cada vez que se inicie un hilo, y antes
        /// de logear cualquier cosa. (Se recomienda que en una aplicación web, se llame en Application_Start).
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static void Inicializar()
        {
            if (Inicializador != null)
            {
                Inicializador();
            }
            else
            {
                if (Configuration == null)
                {
                    ReInicializar();
                }
            }
        }

        /// <summary>
        /// Inicializa el estado del log y carga los valores para su correcto funcionamiento. Debe ser llamado cada vez que se inicie un hilo, y antes
        /// de logear cualquier cosa. (Se recomienda que en una aplicación web, se llame en Application_Start).
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 01/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static void Inicializar(Log4MeConfig config)
        {
            if (Configuration == null)
            {
                Configuration = config;
            }
        }

        /// <summary>
        /// Inicializa el estado del log y carga los valores para su correcto funcionamiento. Debe ser llamado cada vez que se inicie un hilo, y antes
        /// de logear cualquier cosa. (Se recomienda que en una aplicación web, se llame en Application_Start).
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 01/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="rutaArchivo">Ruta del archivo de configuración.</param>
        public static void Inicializar(string rutaArchivo)
        {
            if (Configuration == null)
            {
                Configuration = new Log4MeConfigManager().ObtenerConfiguracion(rutaArchivo);
            }
        }

        /// <summary>
        /// Reinicializa Log4Me mediante la configuración predeterminada.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static void ReInicializar()
        {
            Configuration = new Log4MeConfigManager().ObtenerConfiguracion();
        }

        /// <summary>
        /// Reinicializa Log4Me mediante la configuración recibida.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="config">Configuración de Log4Me.</param>
        public static void ReInicializar(Log4MeConfig config)
        {
            Configuration = config;
        }

        /// <summary>
        /// Reinicializa Log4Me mediante la configuración desde un archivo.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="rutaArchivo">Ruta del archivo de configuración.</param>
        public static void ReInicializar(string rutaArchivo)
        {
            Configuration = new Log4MeConfigManager().ObtenerConfiguracion(rutaArchivo);
        }
    }
}
