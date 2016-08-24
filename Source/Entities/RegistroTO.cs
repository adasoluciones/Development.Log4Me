using System;

namespace Ada.Framework.Development.Log4Me.Entities
{
    /// <summary>
    /// Representación del registro del flujo de un método.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public abstract class RegistroTO
    {
        /// <summary>
        /// Obtiene o establece el identificador único del hilo(GUID).
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string ThreadGUID { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del método(GUID).
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string MethodGUID { get; set; }

        /// <summary>
        /// Obtiene o establece el espacio de nombres al que pertenece la clase.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string Namespace { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la clase a la que pertenece el método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string Clase { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del método de que se está registrando.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string Metodo { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha en que se registró el evento.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public DateTime Fecha { get; set; }

        /// <summary>
        ///  Obtiene o establece el número de la llamada actual de la instancia en el método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public int Llamada { get; set; }
    }
}
