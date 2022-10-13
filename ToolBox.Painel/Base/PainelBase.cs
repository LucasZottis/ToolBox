namespace ToolBox.Painel.Base
{
    [ToolboxItem( false ), DesignerCategory( "Paineis" )]
    public class PainelBase : Panel, IComponente
    {
        #region Propriedades

        #region IComponente

        [Browsable( true ), DisplayName( TextosPadroes.BloquearComponente ), Description( TextosPadroes.BloquearComponenteDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
        public bool BloquearComponente { get; set; } = false;

        [Browsable( false )]
        public bool Bloqueado { set => Enabled = !value; }

        #endregion IComponente

        #endregion Propriedades

        #region Construtores

        public PainelBase( IContainer container ) : base()
        {
            if ( container != null )
            {
                container.Add( this );
            }
        }

        #endregion Construtores

        #region Métodos

        #region Públicos

        #region IComponente

        public Point ObterPontoCentral()
        {
            return new Point( ( Size.Width / 2 ), ( Size.Height / 2 ) );
        }

        #endregion IComponente

        #endregion Públicos

        #endregion Métodos
    }
}