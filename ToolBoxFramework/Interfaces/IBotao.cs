using BibliotecaPublica.BibliotecaPublicaFramework.Enums;
using System.Windows.Forms;

namespace ToolBox.ToolBoxWinForms.Framework.Interfaces
{
    public interface IBotao
    {
        Keys TeclaAtalho { get; set; }

        Resposta ExecutarCliqueBotao();
        void Focar();
    }
}