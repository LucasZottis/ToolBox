using BibliotecaPublica.Core.Structs;
using System.ComponentModel;
using ToolBox.Geral.Interfaces;

namespace ToolBox.Controles;

public partial class ControleUsuarioBase
    : UserControl, IComponente
{
    [Browsable( true ), DisplayName( TextosPadroes.BloquearComponente ), Description( TextosPadroes.BloquearComponenteDescricao ), Category( TextosPadroes.ComportamentoCategoria )]
    public bool BloquearComponente { get; set; }

    [Browsable( false ), DisplayName( TextosPadroes.Bloqueado ), Description( TextosPadroes.BloqueadoDescricao ), Category( TextosPadroes.ComportamentoCategoria )]
    public bool Bloqueado { set => Enabled = !Enabled; }

    public Point ObterPontoCentral()
    {
        return new Point( 0, 0 );
    }
}
