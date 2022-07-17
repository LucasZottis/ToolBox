namespace ToolBox.ToolBoxFramework.Interfaces
{
    public interface ICaixaTexto : ILimpeza
    {
        bool PermitirNumeros { get; set; }
        bool PermitirLetras { get; set; }
        bool PermitirSimbolos { get; set; }

        bool TemTexto();
    }
}