namespace ToolBox.ToolBoxWinForms.Net6.Componentes.Botao.Base
{
    [DesignerCategory( "Botão" ), ToolboxItem( false )]
    public class BotaoBase : Button, IComponente
    {
        #region Atributos



        #endregion Atributos

        #region Propriedades

        #region Ocultadas



        #endregion Ocultadas

        #region IComponente

        [Browsable( true ), DisplayName( TextosPadroes.BloquearComponente ), Description( TextosPadroes.BloquearComponenteDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
        public bool BloquearComponente { get; set; } = false;

        [Browsable( false )]
        public bool Bloqueado { set => base.Enabled = !value; }

        #endregion IComponente

        #region Comportamento

        [Browsable( true ), DisplayName( TextosPadroes.Habilitado )]
        public new bool Enabled
        {
            get { return base.Enabled; }
            set { base.Enabled = value; }
        }

        #endregion Comportamento

        #endregion Propriedades

        #region Construtores

        public BotaoBase( IContainer container )
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

        #endregion

        #endregion Métodos
    }
}