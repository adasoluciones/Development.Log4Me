using Ada.Framework.Data.Json;
using Ada.Framework.Development.Log4Me.Entities;
using Ada.Framework.Development.Log4Me.Writers;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ada.Framework.Development.Log4Me
{
    /// <summary>
    /// Contrato ha cumplir por un tipo de Logger de Log4Me.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class Logger<T> : ILog where T : ILog
    {
        /// <summary>
        /// Permite obtener o establecer el número de llamadas que ha realizado el método actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        protected int Llamada { get; set; }

        /// <summary>
        /// Instancia de log.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        protected T InstanciaLog { get; set; }

        /// <summary>
        /// Obtiene el valor único (GUID) que identifíca el hilo de ejecución actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string ThreadGUID { get { return Log4MeManager.ThreadGUID; } }

        /// <summary>
        ///  Obtiene el valor único (GUID) que identifíca la ejecución (método) actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///          1.0 27/06/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string MethodGUID { get { return InstanciaLog.MethodGUID; } }

        /// <summary>
        /// Permite obtener el método actual mediante reflexión.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///          1.0 27/06/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public MethodBase Metodo { get { return InstanciaLog.Metodo; } }

        /// <summary>
        /// Constructor que inicializa la instancia y recibe una instancia de log.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///          1.0 27/06/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="instanciaLog">Instancia de Log.</param>
        public Logger(T instanciaLog)
        {
            InstanciaLog = instanciaLog;
        }

        /// <summary>
        /// Constructor interno que inicializa la instancia.
        /// Nota: Cargar posteriormente la instancia.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///          1.0 27/06/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        internal Logger() { }

        /// <summary>
        /// Permite obtener los escritores válidos para el método actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        protected IList<ALogWriter> Writers { get; set; }
        
        /// <summary>
        /// Registra el identificador del hilo.
        /// </summary>
        /// <example>
        ///     Log.Identificador("18.662.059-3");
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="identificador">Identificador del hilo</param>
        public static void Identificador(string identificador)
        {
            RegistroInLineTO registro = new RegistroInLineTO()
            {
                ThreadGUID = Log4MeManager.ThreadGUID,
                MethodGUID = Log4MeManager.CurrentInstance != null ? Log4MeManager.CurrentInstance.MethodGUID : null,
                Namespace = Log4MeManager.CurrentInstance != null ? Log4MeManager.CurrentInstance.Metodo.DeclaringType.Namespace : null,
                Clase = Log4MeManager.CurrentInstance != null ? Log4MeManager.CurrentInstance.Metodo.DeclaringType.FullName : null,
                Metodo = Log4MeManager.CurrentInstance != null ? Log4MeManager.CurrentInstance.Metodo.ToString() : null,
                Correlativo = 0,
                Tipo = Tipo.Identificador,
                ValorVariable = identificador
            };
            
            if (Log4MeManager.Configuration != null)
            {
                foreach (ALogWriter writer in Log4MeManager.Configuration.Writers)
                {
                    writer.Guardar(registro);
                }
            }
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
        public void Inicio(params object[] parametros)
        {
            Writers = Log4MeBO.ObtenerWriters(InstanciaLog.Metodo);
            Log4MeManager.CurrentInstance = InstanciaLog;

            Llamada++;

            RegistroInLineTO registro = new RegistroInLineTO()
            {
                ThreadGUID = Log4MeManager.ThreadGUID,
                MethodGUID = InstanciaLog.MethodGUID,
                Namespace = InstanciaLog.Metodo.DeclaringType.Namespace,
                Clase = InstanciaLog.Metodo.DeclaringType.Name,
                Metodo = InstanciaLog.Metodo.ToString(),
                Correlativo = Llamada,
                Tipo = Tipo.Inicio
            };

            foreach (ALogWriter writer in Writers)
            {
                if (writer.PermiteTipo(Tipo.Inicio))
                {
                    writer.Guardar(registro);
                }
            }

            int numParametro = 0;

            if (parametros != null && parametros.Length > 0)
            {
                foreach (ParameterInfo param in InstanciaLog.Metodo.GetParameters())
                {
                    Llamada++;
                    string valor = string.Empty;

                    try
                    {
                        valor = JsonConverterFactory.ObtenerJsonConverter().ToJson(parametros[numParametro], true);
                    }
                    catch (Exception e)
                    {
                        valor = "Error al transformar a Json - " + e.Message.Replace("\n", "\t");
                    }

                    RegistroInLineTO parametro = new RegistroInLineTO()
                    {
                        ThreadGUID = Log4MeManager.ThreadGUID,
                        MethodGUID = InstanciaLog.MethodGUID,
                        Namespace = InstanciaLog.Metodo.DeclaringType.Namespace,
                        Clase = InstanciaLog.Metodo.DeclaringType.Name,
                        Metodo = InstanciaLog.Metodo.ToString(),
                        NombreVariable = param.Name,
                        ValorVariable = valor,
                        Correlativo = Llamada,
                        Tipo = Tipo.Parametro
                    };

                    foreach (ALogWriter writer in Writers)
                    {
                        if (writer.PermiteTipo(Tipo.Parametro))
                        {
                            writer.Guardar(parametro);
                        }
                    }
                    numParametro++;
                }
            }
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
        public void Retorno(object valor)
        {
            Llamada++;

            string valorJson = string.Empty;

            try
            {
                valorJson = JsonConverterFactory.ObtenerJsonConverter().ToJson(valor, true);
            }
            catch (Exception e)
            {
                valorJson = "Error al transformar a Json - " + e.Message;
            }

            RegistroInLineTO registro = new RegistroInLineTO()
            {
                ThreadGUID = Log4MeManager.ThreadGUID,
                MethodGUID = InstanciaLog.MethodGUID,
                Namespace = InstanciaLog.Metodo.DeclaringType.Namespace,
                Clase = InstanciaLog.Metodo.DeclaringType.Name,
                Metodo = InstanciaLog.Metodo.ToString(),
                ValorVariable = valorJson,
                Correlativo = Llamada,
                Tipo = Tipo.Retorno
            };

            foreach (ALogWriter writer in Writers)
            {
                if (writer.PermiteTipo(Tipo.Retorno))
                {
                    writer.Guardar(registro);
                }
            }
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
        public void Retorno()
        {
            Retorno("<Void>");
        }

        /// <summary>
        /// Registra la información relevante de una excepción lanzada por un método. Se debe logear antes de ser lanzada.
        /// Requiere que el inicio y el retorno del método esté logeado.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="excepcion">Excepción lanzada.</param>
        /// <param name="permiteContinuar">Valor que indica si la excepción interrumpe el flujo (no permite continuar).
        /// En caso de ser falso, se logea automáticamente el retorno del método como Excepción.</param>
        public void Excepcion(Exception excepcion, bool permiteContinuar)
        {
            Llamada++;

            string valorJson = string.Empty;

            try
            {
                valorJson = JsonConverterFactory.ObtenerJsonConverter().ToJson(excepcion.Data, true);
            }
            catch (Exception ex)
            {
                valorJson = "Error al transformar a Json - " + ex.Message;
            }

            RegistroInLineTO registro = new RegistroInLineTO()
            {
                ThreadGUID = Log4MeManager.ThreadGUID,
                MethodGUID = InstanciaLog.MethodGUID,
                Namespace = InstanciaLog.Metodo.DeclaringType.Namespace,
                Clase = InstanciaLog.Metodo.DeclaringType.Name,
                Metodo = InstanciaLog.Metodo.ToString(),
                StackTrace = excepcion.StackTrace,
                Data = valorJson,
                TipoExcepcion = excepcion.GetType().FullName,
                Mensaje = excepcion.Message,
                Correlativo = Llamada,
                Tipo = Tipo.Excepcion
            };

            foreach (ALogWriter writer in Writers)
            {
                if (writer.PermiteTipo(Tipo.Excepcion))
                {
                    writer.Guardar(registro);
                }
            }

            if (!permiteContinuar)
            {
                Retorno("<" + registro.Tipo + ">");
            }
        }

        /// <summary>
        /// Registra el nombre, tipo y valor de una variable en el método actual.
        /// Requiere que el inicio y el retorno del método esté logeado.
        /// </summary>
        /// <example>
        ///     public int Sumar(int valor1, int valor2, int valor3)
        ///     {
        ///         log.Inicio(valor1, valor2);
        ///         int resultado = valor1 + valor2;
        ///         
        ///         log.Variable("resultado", resultado);
        ///         retultado += valor3;
        ///         
        ///         log.Retorno(resultado);
        ///         return resultado;
        ///     }
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="nombre">Nombre de la variable.</param>
        /// <param name="valor">Valor de la variable.</param>
        public void Variable(string nombre, object valor)
        {
            Llamada++;

            string valorJson = string.Empty;

            try
            {
                valorJson = JsonConverterFactory.ObtenerJsonConverter().ToJson(valor, true);
            }
            catch (Exception e)
            {
                valorJson = "Error al transformar a Json - " + e.Message;
            }

            RegistroInLineTO registro = new RegistroInLineTO()
            {
                ThreadGUID = Log4MeManager.ThreadGUID,
                MethodGUID = InstanciaLog.MethodGUID,
                Namespace = InstanciaLog.Metodo.DeclaringType.Namespace,
                Clase = InstanciaLog.Metodo.DeclaringType.Name,
                Metodo = InstanciaLog.Metodo.ToString(),
                NombreVariable = nombre,
                ValorVariable = valorJson,
                Correlativo = Llamada,
                Tipo = Tipo.Variable
            };

            foreach (ALogWriter writer in Writers)
            {
                if (writer.PermiteTipo(Tipo.Variable))
                {
                    writer.Guardar(registro);
                }
            }
        }

        /// <summary>
        /// Registra un mensaje con un nivel de importancia en el flujo del método actual.
        /// Requiere que el inicio y el retorno del método esté logeado.
        /// </summary>
        /// <example>
        ///     public class UsuarioBO
        ///     {
        ///         private UsuarioDAO dao = new UsuarioDAO();
        ///         
        ///         public void Agregar(UsuarioTO usuario)
        ///         {
        ///             log.Mensaje("Antes de llamar al DAO", Nivel.INFO);
        ///             dao.Agregar(usuario);
        ///             log.Mensaje("Luego de llamar al DAO", Nivel.INFO);
        ///         }
        ///     }
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="mensaje">Mensaje a registrar.</param>
        /// <param name="nivel">Nivel de importancia o tipo del mensaje.</param>
        public void Mensaje(string mensaje, Nivel nivel)
        {
            Llamada++;

            RegistroInLineTO registro = new RegistroInLineTO()
            {
                ThreadGUID = Log4MeManager.ThreadGUID,
                MethodGUID = InstanciaLog.MethodGUID,
                Namespace = InstanciaLog.Metodo.DeclaringType.Namespace,
                Clase = InstanciaLog.Metodo.DeclaringType.Name,
                Metodo = InstanciaLog.Metodo.ToString(),
                Mensaje = mensaje,
                Nivel = nivel,
                Correlativo = Llamada,
                Tipo = Tipo.Mensaje
            };

            foreach (ALogWriter writer in Writers)
            {
                if (writer.PermiteNivel(nivel))
                {
                    writer.Guardar(registro);
                }
            }
        }

        /// <summary>
        /// Carga el puntero del log (MethodGUID) en una excepción.
        /// Es útil para guardar el puntero exactamente donde ocurrió la excepción.
        /// </summary>
        /// <example>
        ///     public class UsuarioDAO
        ///     {
        ///         public void Agregar(UsuarioTO usuario)
        ///         {
        ///             try
        ///             {
        ///                 //Llamada a base de datos.
        ///             }
        ///             catch(Exception e)
        ///             {
        ///                 throw log.CargarPuntero(e);
        ///             }
        ///         }
        ///     }
        ///     
        ///     public class UsuarioBO
        ///     {
        ///         private UsuarioDAO dao = new UsuarioDAO();
        ///         
        ///         public void Agregar(UsuarioTO usuario)
        ///         {
        ///             try
        ///             {
        ///                 dao.Agregar(usuario);
        ///             }catch(Exception e)
        ///             {
        ///                 string MethodGUID = log.ObtenerPuntero(e);
        ///             }
        ///         }
        ///     }
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <typeparam name="E">Tipo de la excepción que se lanzó.</typeparam>
        /// <param name="excepcion">Excepción que se lanzó.</param>
        /// <returns>Excepción cargada.</returns>
        public E CargarPuntero<E>(E excepcion) where E : Exception
        {
            excepcion.Data.Add(Log4MeManager.PrefijoThread + "MethodGUID", InstanciaLog.MethodGUID);
            return excepcion;
        }

        /// <summary>
        /// Obtiene el puntero (MethodGUID) de una excepción con el puntero cargado mediante el método <see cref="Ada.Framework.Development.Log4Me.ILog.CargarPuntero"/>.
        /// </summary>
        /// <example>
        ///     public class UsuarioBO
        ///     {
        ///         private UsuarioDAO dao = new UsuarioDAO();
        ///         
        ///         public void Agregar(UsuarioTO usuario)
        ///         {
        ///             try
        ///             {
        ///                 dao.Agregar(usuario);
        ///             }catch(Exception e)
        ///             {
        ///                 string MethodGUID = log.ObtenerPuntero(e);
        ///             }
        ///         }
        ///     }
        ///     
        ///     public class UsuarioDAO
        ///     {
        ///         public void Agregar(UsuarioTO usuario)
        ///         {
        ///             try
        ///             {
        ///                 //Llamada a base de datos.
        ///             }
        ///             catch(Exception e)
        ///             {
        ///                 log.CargarPuntero(e);
        ///                 throw e;
        ///             }
        ///         }
        ///     }
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="excepcion">Excepción que contiene el puntero.</param>
        /// <returns>MethodGUID.</returns>
        public string ObtenerPuntero(Exception excepcion)
        {
            if (excepcion != null && excepcion.Data.Contains(Log4MeManager.PrefijoThread + "MethodGUID"))
            {
                return excepcion.Data[Log4MeManager.PrefijoThread + "MethodGUID"].ToString();
            }

            return null;
        }
    }
}