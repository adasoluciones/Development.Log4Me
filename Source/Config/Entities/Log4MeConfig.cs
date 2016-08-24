using Ada.Framework.Development.Log4Me.Writers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Config.Entities
{
    /// <summary>
    /// Tag raíz que representa la configuración de Log4Me.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    [XmlRoot]
    public class Log4MeConfig
    {
        /// <summary>
        /// Permite obtener o establecer los escritores del log.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlArray("Writers")]
        public List<ALogWriter> Writers { get; set; }

        /// <summary>
        /// Constructor que inicializa la instancia.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public Log4MeConfig()
        {
            Writers = new List<ALogWriter>();
        }

        /// <summary>
        /// Obtiene el primer escritor encontrado según el tipo pasado como argumento. De no encontrar ningúno, retornará <value>null</value>.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <typeparam name="T">Tipo de escritor.</typeparam>
        /// <returns>Escritor encontrado.</returns>
        public T ObtenerWriter<T>() where T: ALogWriter
        {
            if (Writers.Count(c => c is T) > 0)
            {
                return Writers.First(c => c is T) as T;
            }
            return null;
        }

        /// <summary>
        /// Obtiene un valor que indica si esta activo un escritor.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <typeparam name="T">Tipo de escritor.</typeparam>
        /// <returns><value>true</value> en caso de estar activo, o <value>false</value> de lo contrario.</returns>
        public bool estaActivo<T>() where T : ALogWriter
        {
            T logger = ObtenerWriter<T>();

            if (logger != null)
            {
                return logger.Modo.Codigo.Equals(Modo.On.Codigo, StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }
    }
}
