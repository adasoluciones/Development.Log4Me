using System.Collections.Generic;

namespace Ada.Framework.Development.Log4Me.Entities
{
    /// <summary>
    ///  Representación del registro de un método.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class MetodoTO : RegistroTO
    {
        /// <summary>
        /// Constructor que inicializa las propiedades de la instancia.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public MetodoTO()
        {
            Parametros = new List<ParametroTO>();
            Llamadas = new List<MetodoTO>();
            Mensajes = new List<MensajeTO>();
            Excepciones = new List<ExcepcionTO>();
            Variables = new List<VariableTO>();
        }

        /// <summary>
        /// Obtiene o establece el registro del inicio del método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public InicioTO Inicio { get; set; }

        /// <summary>
        /// Obtiene o establece el registro de los parámetros del método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public IList<ParametroTO> Parametros { get; set; }

        /// <summary>
        /// Obtiene o establece el registro de las llamadas que realizó el método a otros o a sí mismo.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public IList<MetodoTO> Llamadas { get; set; }

        /// <summary>
        /// Obtiene o establece el registro los mensajes que fueron guardados por el método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public IList<MensajeTO> Mensajes { get; set; }

        /// <summary>
        /// Obtiene o establece el registro las excepciones lanzadas en el método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public IList<ExcepcionTO> Excepciones { get; set; }

        /// <summary>
        /// Obtiene o establece el registro las variables existentes en el método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public IList<VariableTO> Variables { get; set; }

        /// <summary>
        /// Obtiene o establece el registro del retorno del método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public RetornoTO Retorno { get; set; }
    }
}
