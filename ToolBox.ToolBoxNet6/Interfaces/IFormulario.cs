namespace ToolBox.Geral.Interfaces
{
    public interface IFormulario
    {
        bool FecharJanela { get; set; }

        string TituloJanela { get; set; }

        ModoJanela ModoJanela { get; set; }

        Point ObterPontoCentral();
    }
}