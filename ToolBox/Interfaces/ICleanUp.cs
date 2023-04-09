namespace ToolBox.Interfaces;

public interface ICleanUp
{
    /// <summary>
    /// Define ou obtém se deve fazer a limpeza de resíduo do componente.
    /// </summary>
    bool RunCleanUp { get; set; }

    /// <summary>
    /// Executa a limpeza de resíduo do componente.
    /// </summary>
    void CleanUp();
}