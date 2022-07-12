using System.Collections.Generic;
using ToolBox.ToolBoxFramework.Interfaces;

namespace ToolBox.ToolBoxFramework
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