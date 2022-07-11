using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaPublica.Interfaces
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