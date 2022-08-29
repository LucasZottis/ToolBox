namespace ToolBox.CaixaMarcacao
{
    [DesignerCategory( "Caixas marcação" ), ToolboxItem( false )]
    public class CaixaMarcacaoBase : CheckBox, IComponente
    {
        #region Atributos



        #endregion Atributos

        #region Propriedades

        [Browsable( true ), DisplayName( TextosPadroes.BloquearComponente ), Description( TextosPadroes.BloquearComponenteDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
        public bool BloquearComponente { get; set; } = false;

        [Browsable( true ), DisplayName( TextosPadroes.Bloqueado ), Description( TextosPadroes.BloqueadoDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( true )]
        public bool Bloqueado
        {
            set
            {
                Enabled = !value;
            }
        }

        #endregion Propriedades

        #region Construtores

        public CaixaMarcacaoBase( IContainer container )
        {
            if ( container != null )
            {
                container.Add( this );
            }
        }

        #endregion Construtores

        #region Métodos

        #region Públicos

        public Point ObterPontoCentral()
        {
            throw new NotImplementedException();
        }

        #endregion Públicos

        #endregion Métodos
    }
}