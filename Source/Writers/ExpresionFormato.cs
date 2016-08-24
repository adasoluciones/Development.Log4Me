using System.Collections.Generic;

namespace Ada.Framework.Development.Log4Me.Writers
{
    internal class ExpresionFormato
    {
        public string Formato { get; private set; }
        public char Separador { get; private set; }

        public IDictionary<string, string> TagFormato { get; private set; }

        public ExpresionFormato(string formato, char separador)
        {
            Recargar(formato, separador);
        }

        public void Recargar()
        {
            TagFormato.Clear();
            ExtraerTagFormato();
        }

        public void Recargar(string formato, char separador)
        {
            Formato = formato;
            Separador = separador;
            TagFormato = new Dictionary<string, string>();

            ExtraerTagFormato();
        }
        
        private void ExtraerTagFormato()
        {
            string tag = string.Empty;
            string acumulador = string.Empty;

            bool comenzarAcumulacion = false;

            foreach (char caracter in Formato)
            {
                if (caracter == Separador && string.IsNullOrEmpty(tag) && string.IsNullOrEmpty(acumulador)) continue;

                if (caracter == '[') comenzarAcumulacion = true;

                if (comenzarAcumulacion && caracter != '[' && (!string.IsNullOrEmpty(tag) || caracter != ':') && caracter != ']')
                    acumulador += caracter;

                if (caracter == ':' && string.IsNullOrEmpty(tag))
                {
                    tag = string.Format("[{0}]", acumulador.Trim());
                    acumulador = string.Empty;
                }

                if (caracter == ']')
                {
                    if (string.IsNullOrEmpty(tag))
                    {
                        tag = string.Format("[{0}]", acumulador.Trim());
                        TagFormato.Add(tag, null);
                    }
                    else
                    {
                        TagFormato.Add(tag, acumulador.Trim());
                    }
                    
                    tag = string.Empty;
                    acumulador = string.Empty;

                    comenzarAcumulacion = false;
                }
            }
        }
    }
}
