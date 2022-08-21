namespace ToolBox.ToolBoxWinForms.Net6.Componentes.Dados.Base
{
    [ToolboxItem( false ), DesignerCategory( "Paineis" )]
    public class GradeDadosBase : DataGridView, IComponente
    {
        #region Propriedades

        #region IComponente

        [Browsable( true ), DisplayName( TextosPadroes.BloquearComponente ), Description( TextosPadroes.BloquearComponenteDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
        public bool BloquearComponente { get; set; } = false;

        [Browsable( false )]
        public bool Bloqueado { set => base.Enabled = !value; }

        #endregion IComponente

        #endregion Propriedades

        #region Construtores

        public GradeDadosBase( IContainer container ) : base()
        {
            if ( container != null )
            {
                container.Add( this );
            }

            ExecutarConfiguracaoPadrao();
        }

        #endregion Construtores

        #region Métodos

        #region Privados

        private void ExecutarConfiguracaoPadrao()
        {
            BackgroundColor = Color.LightGray;

            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;
            AllowUserToOrderColumns = false;

            RowHeadersWidth = 15;
            RowHeadersVisible = false;
            MultiSelect = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        #endregion Privados

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