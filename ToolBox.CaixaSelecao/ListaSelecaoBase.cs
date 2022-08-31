namespace ToolBox.ListaSelecao
{
    [DesignerCategory( "Caixa de seleção" ), ToolboxItem( true )]
    public class ListaSelecaoBase : ComboBox, IComponente, ILimpeza
    {
        #region Atributos



        #endregion Atributos

        #region Propriedades

        #region IComponente

        [
            Browsable( true ),
            DisplayName( TextosPadroes.BloquearComponente ),
            Description( TextosPadroes.BloquearComponenteDescricao ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DefaultValue( false )
        ]
        public bool BloquearComponente { get; set; } = false;

        [
            Browsable( true ),
            DisplayName( TextosPadroes.Bloqueado ),
            Description( TextosPadroes.BloqueadoDescricao ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DefaultValue( true )
        ]
        public bool Bloqueado
        {
            set
            {
                Enabled = !value;
            }
        }

        #endregion IComponente

        #region ILimpeza

        [
            Browsable( true ),
            DisplayName( TextosPadroes.FazerLimpeza ),
            Description( TextosPadroes.FazerLimpezaDescricao ),
            Category( TextosPadroes.DadosCateogria ),
            DefaultValue( false )
        ]
        public bool FazerLimpeza { get; set; } = false;

        #endregion ILimpeza

        #endregion Propriedades

        #region Construtores

        public ListaSelecaoBase( IContainer container )
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

        public void Limpar()
        {
            SelectedIndex = -1;
            Text = "";
        }

        #endregion Públicos

        #endregion Métodos
    }
}