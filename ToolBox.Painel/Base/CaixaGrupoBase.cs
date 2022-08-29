namespace ToolBox.Painel.Base
{
    [ToolboxItem( false ), DesignerCategory( "Paineis" )]
    public class CaixaGrupoBase : GroupBox, IComponente
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

        public CaixaGrupoBase( IContainer container ) : base()
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
            return new Point( ( Size.Width / 2 ).ParaInt(), ( Size.Height / 2 ).ParaInt() );
        }

        #endregion IComponente

        #endregion Públicos

        #endregion Métodos
    }
}