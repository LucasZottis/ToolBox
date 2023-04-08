namespace ToolBox.Buttons
{
    [DesignerCategory( "Botão" ), ToolboxItem( false )]
    public class ButtonBase : Button, IControl
    {
        #region Atributos



        #endregion Atributos

        #region Propriedades

        #region Ocultadas



        #endregion Ocultadas

        #region IComponente

        [Browsable( true ), DisplayName( TextosPadroes.BloquearComponente ), Description( TextosPadroes.BloquearComponenteDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
        public bool DisableControl { get; set; } = false;

        [Browsable( false )]
        public bool Disabled { set => base.Enabled = !value; }

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

        public ButtonBase( IContainer container )
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

        public Point GetCenterPoint()
        {
            return new Point( Size.Width / 2, Size.Height / 2 );
        }

        #endregion IComponente

        #endregion

        #endregion Métodos
    }
}