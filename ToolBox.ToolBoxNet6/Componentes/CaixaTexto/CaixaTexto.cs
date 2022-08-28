using ToolBox.ToolBoxWinForms.Net6.Componentes.CaixaTexto.Base;

namespace ToolBox.ToolBoxWinForms.Net6.Componentes.CaixaTexto
{
    [DesignerCategory( "Caixa de Texto" ), ToolboxItem( true )]
    public class CaixaTexto : CaixaTextoBase
    {
        #region Propriedades

        #region Ocultadas

        [Browsable( false )]
        public new char PasswordChar
        {
            get { return base.PasswordChar; }
            set { base.PasswordChar = value; }
        }

        [Browsable( false )]
        public new bool UseSystemPasswordChar
        {
            get { return base.UseSystemPasswordChar; }
            set { base.UseSystemPasswordChar = false; }
        }

        [Browsable( false )]
        public new bool Multiline
        {
            get { return base.Multiline; }
            set { base.Multiline = value; }
        }

        [Browsable( false )]
        public new ScrollBars ScrollBars
        {
            get
            {
                return base.ScrollBars;
            }

            set
            {
                base.ScrollBars = ScrollBars.None;
            }
        }

        [Browsable( false )]
        public new HorizontalAlignment TextAlign
        {
            get
            {
                return base.TextAlign;
            }

            set
            {
                base.TextAlign = HorizontalAlignment.Left;
            }
        }

        [Browsable( false )]
        public new bool WordWrap
        {
            get
            {
                return base.WordWrap;
            }

            set
            {
                base.WordWrap = false;
            }
        }

        #endregion Ocultadas

        #endregion Propriedades

        #region Construtores

        public CaixaTexto( IContainer container ) : base( container )
        {

        }

        #endregion Construtores
    }
}