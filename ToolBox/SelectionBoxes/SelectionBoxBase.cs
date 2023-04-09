namespace ToolBox.SelectionBoxes
{
    [DesignerCategory( "Caixas marcação" ), ToolboxItem( false )]
    public class SelectionBoxBase : CheckBox, IControl
    {
        #region Atributos



        #endregion Atributos

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

        public SelectionBoxBase( IContainer container )
        {
            if ( container != null )
            {
                container.Add( this );
            }
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
}