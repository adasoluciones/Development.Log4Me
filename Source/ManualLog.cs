using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Ada.Framework.Development.Log4Me
{
    /// <summary>
    /// Clase que guarda el registro de eventos de una aplicación.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public sealed class ManualLog : Logger<ManualLog>
    {
        /// <summary>
        /// Campo que contiene en un diccionario, las llamadas y su correspondiente GUID. Es utilizado para calcular el MethodGUID.
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// </summary>
        private IDictionary<string, string> LlamadaMethodGUID { get; set; }
        
        /// <summary>
        /// Obtiene el identificador único (GUID) del método actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public new string MethodGUID
        {
            get
            {
                string key = string.Empty;

                MethodBase metodo = new StackTrace().GetFrame(1).GetMethod();
                int salto = 2;

                while (metodo.DeclaringType == typeof(Log))
                {
                    metodo = new StackTrace().GetFrame(salto).GetMethod();
                    salto++;
                }

                foreach (string clave in LlamadaMethodGUID.Keys)
                {
                    if (clave.Contains(metodo.ToString()))
                    {
                        key = clave;
                    }
                }

                if (!string.IsNullOrEmpty(key) && LlamadaMethodGUID.ContainsKey(key))
                {
                    return LlamadaMethodGUID[key];
                }

                return null;
            }
        }
        
        /// <summary>
        /// Permite obtener el método actual mediante reflexión.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public new MethodBase Metodo { get; private set; }

        /// <summary>
        /// Constructor que inicializa la clase de log.
        /// Éste carga el ThreadGUID a la instancia e instancia el writter.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public ManualLog()
        {
            LlamadaMethodGUID = new Dictionary<string, string>();
            InstanciaLog = this;
        }

        /// <summary>
        /// Registra el inicio de un método, guarda la hora actual y cada parametro especificando
        /// nombre, tipo y valor. Se recomienda que esta sea la primera instrucción de cada método.
        /// Si se logea el inicio, es obligatorio logear el retorno aunque el método sea Void.
        /// </summary>
        /// <example>
        ///     public void Metodo1(int a, string b, bool c)
        ///     {
        ///         log.Inicio(a, b, c);
        ///         log.Retorno();
        ///     }
        ///     
        ///     public void Metodo2()
        ///     {
        ///         log.Inicio();
        ///         log.Retorno();
        ///     }
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="parametros">Lista de parametros del método actual.</param>
        public new void Inicio(params object[] parametros)
        {
            MethodBase metodo = new StackTrace().GetFrame(1).GetMethod();
            Metodo = metodo;

            AgregarGUID(metodo.ToString(), Guid.NewGuid().ToString());
            base.Inicio(parametros);
        }

        /// <summary>
        /// Registra el fin de la ejecución de un método, guardando la fecha de termino, el valor de retorno y su tipo.
        /// Se debe logear antes de retornar. Requiere que se haya logeado el inicio del método.
        /// </summary>
        /// <example>
        ///     public int Sumar(int valor1, int valor2)
        ///     {
        ///         log.Inicio(valor1, valor2);
        ///         int resultado = valor1 + valor2;
        ///         log.Retorno(resultado);
        ///         return resultado;
        ///     }
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="valor">Valor de retorno del método.</param>
        public new void Retorno(object valor)
        {
            base.Retorno(valor);
            VolverEjecucion(Metodo.ToString());
        }

        /// <summary>
        /// Registra el fin de la ejecución de un método, guardando la fecha de termino, y un retorno de tipo Void.
        /// Se debe logear antes de retornar. Requiere que se haya logeado el inicio del método.
        /// </summary>
        /// <example>
        ///     public void Metodo1()
        ///     {
        ///         log.Retorno();
        ///         // return; --> No es necesario. Sirve para ejemplificar que es el final del método.
        ///     }
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public new void Retorno()
        {
            base.Retorno();
            VolverEjecucion(Metodo.ToString());
        }
        
        /// <summary>
        /// Agrega el metodo y el GUID al diccionario LlamadaMethodGUID, incrementando en 1 el número del método.
        /// </summary>
        /// <example>
        ///     - "Void Metodo1()|0", "199339ba-267a-42e8-806c-c36661697f70"
        ///     - "Void Metodo1()|1", "b8b7b800-a882-4032-8232-320e95cefa66"
        ///    Nota: En este caso el método sería recursivo, puesto que se llama más de una vez.
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="metodo">Nombre del método que se está ejecutando.</param>
        /// <param name="GUID">Identificador único de ejecución (MethodGUID).</param>
        private void AgregarGUID(string metodo, string GUID)
        {
            int ejecucion = 0;
            foreach (string clave in LlamadaMethodGUID.Keys)
            {
                if (clave.Contains(metodo))
                {
                    ejecucion = Convert.ToInt32(clave.Split('|')[1]) + 1;
                }
            }
            if (!LlamadaMethodGUID.ContainsKey(metodo + "|" + ejecucion))
            {
                LlamadaMethodGUID.Add(metodo + "|" + ejecucion, GUID);
            }
        }

        /// <summary>
        /// Elimina el método y todas sus iteraciones del diccionario con los GUID´s.
        /// </summary>
        /// <example>
        ///     Con "Void Metodo1()", eliminaría:
        ///         - "Void Metodo1()|0"
        ///         - "Void Metodo1()|1"
        ///         ....
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="metodo">Nombre del método.</param>
        private void VolverEjecucion(string metodo)
        {
            string key = string.Empty;
            foreach (string clave in LlamadaMethodGUID.Keys)
            {
                if (clave.Contains(metodo))
                {
                    key = clave;
                }
            }
            if (!string.IsNullOrEmpty(key) && LlamadaMethodGUID.ContainsKey(key))
            {
                LlamadaMethodGUID.Remove(key);
            }
        }
    }
}
