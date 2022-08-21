namespace ToolBox.ToolBoxWinForms.Framework.Interfaces
{
    public interface ICaixaMonetaria
    {
        decimal ValorMaximo { get; set; }

        decimal ValorMinimo { get; set; }

        decimal Valor { get; set; }

        bool ValidarValorDigitado(char caractere);

        string AplicarRegrasValorMonetario(string valorSemRegras);
    }
}