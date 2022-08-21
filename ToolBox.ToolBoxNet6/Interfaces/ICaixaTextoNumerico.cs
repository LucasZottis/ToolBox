namespace ToolBox.ToolBoxWinForms.Net6.Interfaces
{
    public interface ICaixaTextoNumerico
    {
        long Valor { get; }

        long ValorMaximo { get; set; }

        long ValorMinimo { get; set; }
    }
}