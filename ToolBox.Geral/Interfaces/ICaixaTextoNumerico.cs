namespace ToolBox.Geral.Interfaces
{
    public interface ICaixaTextoNumerico
    {
        long Valor { get; }

        long ValorMaximo { get; set; }

        long ValorMinimo { get; set; }
    }
}