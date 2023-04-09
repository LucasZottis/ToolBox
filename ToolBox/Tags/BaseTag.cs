namespace ToolBox.Tags;

[DesignerCategory( "Rotulos" ), ToolboxItem( false )]
public class BaseTag : Label, IControl
{
    #region Propriedades

    [Browsable( true ), DisplayName( TextosPadroes.BloquearComponente ), Description( TextosPadroes.BloquearComponenteDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
    public bool DisableControl { get; set; } = false;

    [Browsable( true ), DisplayName( TextosPadroes.Bloqueado ), Description( TextosPadroes.BloqueadoDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( true )]
    public bool Disabled
    {
        set
        {
            Enabled = !value;
        }
    }

    #endregion Propriedades

    #region Construtores

    public BaseTag( IContainer container )
    {
        if ( container != null )
        {
            container.Add( this );
        }

        AutoSize = true;
    }

    #endregion Construtores

    #region Métodos

    #region Públicos

    public Point GetCenterPoint()
    {
        throw new NotImplementedException();
    }

    #endregion Públicos

    #endregion Métodos
}