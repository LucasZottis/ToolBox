using MyGears.Helpers;

namespace MyGears.Components.Tags;

[DesignerCategory( "Tags" ), ToolboxItem( false )]
public class BaseTag
    : Label, IControl
{
    [Browsable( true ), DisplayName( TextosPadroes.BloquearComponente ), Description( TextosPadroes.BloquearComponenteDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
    public bool DisableControl { get; set; } = false;

    [Browsable( true ), DisplayName( TextosPadroes.Bloqueado ), Description( TextosPadroes.BloqueadoDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( true )]
    public bool Disabled
    {
        set => Enabled = !value;
    }

    [Browsable( false ), DisplayName( TextosPadroes.Fonte ), Category( TextosPadroes.AparenciaCategoria )]
    public new Font Font
    {
        get => ToolBoxEnvironment.GeneralFont;
        set => base.Font = ToolBoxEnvironment.GeneralFont;
    }
    [Browsable( true ), DisplayName( TextosPadroes.Bloqueado ), Description( TextosPadroes.BloqueadoDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( true )]
    /// <summary>
    /// Determina se irá ajustar o tamanho do controle automaticamente.
    /// </summary>

    public new bool AutoSize
    {
        get => base.AutoSize;
        set => base.AutoSize = value;
    }

    /// <summary>
    /// Construtor padrão que recebe um container.
    /// </summary>
    /// <param name="container">Container do formulário.</param>
    public BaseTag( IContainer container )
    {
        container?.Add( this );
    }

    /// <summary>
    /// Obtém o ponto central do controle.
    /// </summary>
    /// <returns>Struct Point com o ponto centrar do controle.</returns>
    public Point GetCenterPoint()
        => PointHelper.GetCenterPoint( Size );
}