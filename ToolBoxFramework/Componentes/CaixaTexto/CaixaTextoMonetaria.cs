using BibliotecaPublica.BibliotecaPublicaFramework.Classes.Servicos.Conversores;
using BibliotecaPublica.BibliotecaPublicaFramework.Classes.Verificadores;
using BibliotecaPublica.BibliotecaPublicaFramework.Estruturas;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using ToolBox.ToolBoxWinForms.Framework.Componentes.Bases;

namespace ToolBox.ToolBoxWinForms.Framework.Componentes.CaixaTexto
{
    [DesignerCategory( "Caixa de texto monetária" ), ToolboxItem( true )]
    public class CaixaTextoMonetaria : CaixaTextoBase
    {
        #region Atributos



        #endregion Atributos

        #region Propriedades

        #region Ocultadas

        [Browsable( false )]
        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

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
            set { base.Multiline = false; }
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
                base.TextAlign = value;
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

        [Browsable( false )]
        public new bool PermitirNumeros
        {
            get { return base.PermitirNumeros; }
            set { base.PermitirNumeros = true; }
        }

        [Browsable( false )]
        public new bool PermitirLetras
        {
            get { return base.PermitirLetras; }
            set { base.PermitirLetras = value; }
        }

        [Browsable( false )]
        public new bool PermitirSimbolos
        {
            get { return base.PermitirSimbolos; }
            set { base.PermitirSimbolos = value; }
        }

        [Browsable( false )]
        public new CharacterCasing CharacterCasing
        {
            get => base.CharacterCasing;
            set => base.CharacterCasing = CharacterCasing.Normal;
        }

        [Browsable( false )]
        public new bool AcceptsTab
        {
            get => base.AcceptsTab;
            set => base.AcceptsTab = false;
        }

        [Browsable( false )]
        public new int MaxLength
        {
            get => base.MaxLength;
            set
            {
                base.MaxLength = value;
            }
        }

        [Browsable( false ), DisplayName( TextosPadroes.Valor ), Description( TextosPadroes.ValorDescricao ), Category( TextosPadroes.DadosCateogria )]
        public decimal Valor
        {
            get
            {
                return Text.ParaDecimal();
            }

            set
            {
                if ( value == 0 )
                {
                    Text = string.Empty;
                    return;
                }

                Text = value.ToString();
            }
        }

        #endregion Ocultadas

        #endregion Propriedades

        #region Construtores

        public CaixaTextoMonetaria( IContainer container ) : base( container )
        {
            PermitirLetras = false;
            PermitirSimbolos = false;

            MaxLength = 120000;
            TextAlign = HorizontalAlignment.Right;
        }

        #endregion Construtores

        #region Privados



        #endregion Privados

        #region Protegidos

        protected override void OnKeyUp( KeyEventArgs e )
        {
            base.OnKeyUp( e );

            if ( Valor == 0 )
            {
                return;
            }

            Text = Valor.ToString( "C2", CultureInfo.CurrentCulture );

            SelectionStart = Text.Length;
            SelectionLength = 0;
        }

        protected override bool VerificarSeSimboloFoiInserido( char caractere )
        {
            if ( caractere.SimboloNegativo() )
            {
                if ( SelectionStart > 0 )
                {
                    return true;
                }

                if ( Text.Contains( "-" ) )
                {
                    return true;
                }
            }

            return caractere.Simbolo( true );
        }

        #endregion Protegidos

        #region Públicos



        #endregion Públicos
    }
}