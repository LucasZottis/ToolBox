using MyGears.Helpers;
using MyGears.Interfaces;

namespace MyGears.UserControls;

public partial class UserControlBase
    : UserControl, IControl
{
    [Browsable( true ), DisplayName( TextosPadroes.BloquearComponente ), Description( TextosPadroes.BloquearComponenteDescricao ), Category( TextosPadroes.ComportamentoCategoria )]
    public bool DisableControl { get; set; }

    [Browsable( false ), DisplayName( TextosPadroes.Bloqueado ), Description( TextosPadroes.BloqueadoDescricao ), Category( TextosPadroes.ComportamentoCategoria )]
    public bool Disabled { set => Enabled = !Enabled; }

    public Point GetCenterPoint()
        => PointHelper.GetCenterPoint( Size );
}