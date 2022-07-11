using BibliotecaPublica.CaixaFerramenta.Interfaces;
using CaixaFerramenta.Formularios.Bases;
using System.Collections.Generic;

namespace BibliotecaPublica.CaixaFerramenta
{
    public static class ConfiguracoesCaixaFerramenta
    {
        #region Atributos

        private static List<IFormulario> _formulariosAbertos;

        #endregion Atributos

        public static List<IFormulario> FormulariosAbertos
        {
            get
            {
                if (_formulariosAbertos == null)
                {
                    _formulariosAbertos = new List<IFormulario>();
                }

                return _formulariosAbertos;
            }
        }

        public static IFormulario FormularioPai { get; set; }

        public static string TituloFormularios { get; set; }
    }
}