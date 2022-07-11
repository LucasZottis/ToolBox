using BibliotecaPublica.Enums;

namespace BibliotecaPublica.CaixaFerramenta.Interfaces
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