namespace ToolBox.ToolBoxWinForms.Net6.Interfaces
{
    public interface IFormulario
    {
        bool FecharJanela { get; set; }

        string TituloJanela { get; set; }

        ModoJanela ModoJanela { get; set; }

        Point ObterPontoCentral();
    }
}