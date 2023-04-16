using MyGears.Helpers;

namespace MyGears.Components.Buttons;

/// <summary>
/// Botão base.
/// </summary>
[DesignerCategory( "Botão Base" ), ToolboxItem( false )]
public class ButtonBase : Button, IControl
{
    /// <summary>
    /// Determina o cursor que será mostrado ao colocar o mouse sobre.
    /// </summary>
    [Browsable( false )]
    public new Cursor Cursor
    {
        get => Cursors.Hand;
        set => base.Cursor = Cursors.Hand;
    }

    /// <summary>
    /// Determina se o controle está desabilitado.
    /// </summary>
    [Browsable( false )]
    public bool Disabled
    {
        set => Enabled = !value;
    }

    /// <summary>
    /// Determina se deve desabilitar o controle quando o formulário estiver em modo de navegação.
    /// </summary>
    [Browsable( true ), DisplayName( TextosPadroes.BloquearComponente ), Description( TextosPadroes.BloquearComponenteDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
    public bool DisableControl { get; set; } = false;

    /// <summary>
    /// Fonte de texto do controle.
    /// </summary>
    [Browsable( false ), DisplayName( TextosPadroes.Fonte ), Category( TextosPadroes.AparenciaCategoria ), DesignerSerializationVisibility( DesignerSerializationVisibility.Visible )]
    public new Font Font
    {
        get => base.Font;
        set => base.Font = value;
    }

    /// <summary>
    /// Construtor padrão que recebe um container.
    /// </summary>
    /// <param name="container">Container do formulário.</param>
    public ButtonBase( IContainer container )
    {
        container?.Add( this );

        Cursor = Cursors.Hand;
    }

    /// <summary>
    /// Obtém o ponto central do controle.
    /// </summary>
    /// <returns>Struct Point com o ponto centrar do controle.</returns>
    public Point GetCenterPoint()
        => PointHelper.GetCenterPoint( Size );
}