using MyGears.Components;
using MyGears.Forms.Base;

namespace MyGears.WinForms.Tests;

public partial class FormularioBase
    : FormBase
{
    public FormularioBase()
        : base()
    {
        InitializeComponent();
        Mensagem.Avisar( "Teste!" );
    }
}