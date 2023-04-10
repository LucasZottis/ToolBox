using ToolBox.Helpers;

namespace ToolBox.DropDownLists;

/// <summary>
/// Classe base para de componentes drop down.
/// </summary>
[DesignerCategory( "Caixa de seleção" ), ToolboxItem( false )]
public class DropDownListBase 
    : ComboBox, IControl, ICleanUp
{
    /// <summary>
    /// Determina se deve bloquear os componentes quando o formulário estiver em modo de navegação.
    /// </summary>
    [
        Browsable( true ),
        DisplayName( TextosPadroes.BloquearComponente ),
        Description( TextosPadroes.BloquearComponenteDescricao ),
        Category( TextosPadroes.ComportamentoCategoria ),
        DefaultValue( false )
    ]
    public bool DisableControl { get; set; } = false;

    /// <summary>
    /// Define se o componente está bloqueado.
    /// </summary>
    [
        Browsable( true ),
        DisplayName( TextosPadroes.Bloqueado ),
        Description( TextosPadroes.BloqueadoDescricao ),
        Category( TextosPadroes.ComportamentoCategoria ),
        DefaultValue( true )
    ]
    public bool Disabled
    {
        set => Enabled = !value;
    }

    /// <summary>
    /// Determina se deve limpar a sujeira do componente.
    /// </summary>
    [
        Browsable( true ),
        DisplayName( TextosPadroes.FazerLimpeza ),
        Description( TextosPadroes.FazerLimpezaDescricao ),
        Category( TextosPadroes.DadosCateogria ),
        DefaultValue( false )
    ]
    public bool RunCleanUp { get; set; } = false;

    /// <summary>
    /// Construtor padrão com injeção de IContainer.
    /// </summary>
    /// <param name="container">Um container que irá guardar o componente.</param>
    public DropDownListBase( IContainer container )
    {
        if ( container != null )
            container.Add( this );
    }

    /// <summary>
    /// Obtém o ponto central do componente.
    /// </summary>
    /// <returns>Retorna uma struct do tipo Point.</returns>
    public Point GetCenterPoint()
        => PointHelper.GetCenterPoint( Size );

    /// <summary>
    /// Executa a limpeza do componente, tirando qualquer texto e removendo a seleção.
    /// </summary>
    public void CleanUp()
    {
        SelectedIndex = -1;
        Text = "";
    }
}