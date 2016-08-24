using Ada.Framework.Configuration;
using Ada.Framework.Configuration.Xml;
using Ada.Framework.Development.Log4Me.Config.Entities;
using Ada.Framework.Development.Log4Me.Writers;
using Ada.Framework.Util.FileMonitor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Config
{
    /// <summary>
    /// Administrador de la configuración de Log4Me.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public sealed class Log4MeConfigManager : ConfiguracionXmlManager<Log4MeConfig>
    {
        /// <summary>
        /// Permite obtener el nombre del archivo de configuración en Web.Config o App.Config.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public override string NombreArchivoConfiguracion
        {
            get { return "Log4MeConfig"; }
        }

        /// <summary>
        /// Permite obtener el nombre del archivo de validación (XSD) del XML establecido en Web.Config o App.Config.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public override string NombreArchivoValidacionConfiguracion
        {
            get { return "Log4MeConfigValidator"; }
        }

        /// <summary>
        /// Permite obtener un valor que indica si se debe validar el XML mediante un XSD.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        protected override bool ValidarXmlSchema
        {
            get { return false; }
        }

        /// <summary>
        /// Permite obtener el nombre del archivo de configuración por defecto.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public override string NombreArchivoPorDefecto
        {
            get { return "Log4Me.Config.xml"; }
        }

        /// <summary>
        /// Permite obtener el nombre del archivo de validación (XSD) del XML por defecto.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public override string NombreArchivoValidacionPorDefecto
        {
            get { return "Log4Me.Config.xsd"; }
        }

        /// <summary>
        /// Obtiene el serializador XML para el archivo de configuración. Carga los ensamblados de los escritores de Log4Me.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <returns></returns>
        protected override XmlSerializer ObtenerXmlSerializer()
        {
            XmlAttributeOverrides xOver = new XmlAttributeOverrides();
            XmlAttributes xAttrs = new XmlAttributes();

            List<Assembly> ensamblados = new List<Assembly>();
            Assembly assembly = null;
            
            string ruta = FrameworkConfigurationManager.ObtenerValorPropiedad<string>("Log4Me", "LibrariesFolderWriters");
            ruta = MonitorArchivoFactory.ObtenerArchivo().ObtenerRutaAbsoluta(ruta);

            string[] archivos = Directory.GetFiles(ruta, "*.dll");

            foreach (string archivo in archivos)
            {
                if (Path.GetFileName(archivo).StartsWith("Log4Me.", StringComparison.InvariantCultureIgnoreCase))
                {
                    assembly = Assembly.LoadFile(archivo);
                    ensamblados.Add(assembly);
                }
            }

            var tipos = (from lAssembly in ensamblados
                         from tipo in lAssembly.GetTypes()
                         where typeof(ALogWriter).IsAssignableFrom(tipo)
                         where !tipo.IsAbstract
                         select tipo).ToArray();

            foreach (var tipo in tipos)
            {
                xAttrs.XmlArrayItems.Add(new XmlArrayItemAttribute(tipo));
            }

            xOver.Add(typeof(Log4MeConfig), "Writers", xAttrs);

            return new XmlSerializer(typeof(Log4MeConfig), xOver);
        }

        /// <summary>
        /// Valida el archivo de configuración.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="documento">Archivo de configuración como documento XML.</param>
        protected override void ValidarXml(XmlDocument documento) { }
    }
}