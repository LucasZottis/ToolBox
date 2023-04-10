using ToolBox.Forms.Base;

namespace ToolBox.WinForms.Tests;

public partial class FormularioBase
    : FormBase
{
    public FormularioBase()
        : base()
    {
        InitializeComponent();
        Mensagem.Avisar( "Teste!" );
        //tag1.Text = Font.ToString();
    }
}