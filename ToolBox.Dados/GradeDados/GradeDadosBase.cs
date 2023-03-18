namespace ToolBox.Dados.GradeDados
{
    [ToolboxItem( false ), DesignerCategory( "Paineis" )]
    public class GradeDadosBase 
        : DataGridView, IComponente
    {
        [
            Browsable( true ),
            DisplayName( TextosPadroes.BloquearComponente ),
            Description( TextosPadroes.BloquearComponenteDescricao ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DefaultValue( false )
        ]
        public bool BloquearComponente { get; set; } = false;

        [Browsable( false )]
        public bool Bloqueado { set => Enabled = !value; }

        [
            Browsable( true ),
            DisplayName( "Gerar Colunas Automaticamente" ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DefaultValue( false )
        ]
        public new bool AutoGenerateColumns
        {
            get => base.AutoGenerateColumns;
            set => base.AutoGenerateColumns = value;
        }

        public GradeDadosBase( IContainer container ) 
            : base()
        {
            if ( container != null )
                container.Add( this );

            ExecutarConfiguracaoPadrao();
        }

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
            AutoGenerateColumns = false;
        }

        public Point ObterPontoCentral()
            => new Point( ( Size.Width / 2 ), ( Size.Height / 2 ) );
    }
}