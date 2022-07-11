using BibliotecaPublica.Enums;
using System.Windows.Forms;

namespace BibliotecaPublica.Interfaces
{
    public interface IBotao
    {
        Keys TeclaAtalho { get; set; }

        Resposta ExecutarCliqueBotao();
        void Focar();
    }
}