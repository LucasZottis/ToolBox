using System.Collections.Generic;
using ToolBox.ToolBoxWinForms.Framework.Interfaces;

namespace ToolBox.ToolBoxWinForms.Framework
{
    public static class ToolBoxConfig
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