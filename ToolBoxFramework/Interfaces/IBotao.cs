using BibliotecaPublica.BibliotecaPublicaFramework.Enums;
using System.Windows.Forms;

namespace ToolBox.ToolBoxFramework.Interfaces
{
    public interface IBotao
    {
        Keys TeclaAtalho { get; set; }

        Resposta ExecutarCliqueBotao();
        void Focar();
    }
}