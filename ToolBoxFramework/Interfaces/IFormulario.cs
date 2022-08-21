using BibliotecaPublica.BibliotecaPublicaFramework.Enums;

namespace ToolBox.ToolBoxWinForms.Framework.Interfaces
{
    public interface IFormulario
    {
        bool FecharJanela
        {
            get; set;
        }

        string TituloJanela
        {
            get; set;
        }

        ModoJanela ModoJanela
        {
            get; set;
        }
    }
}