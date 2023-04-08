namespace ToolBox.TextBoxes
{
    [DesignerCategory( "Caixa de Texto" ), ToolboxItem( true )]
    public class CaixaTextoNumerico : CaixaTextoBase, INumericInput
    {
        #region Atributos

        private long _valorMaximo = long.MaxValue;
        private long _valorMinimo = long.MinValue;

        #endregion Atributos

        #region Propriedades

        #region ICaixaTextoNumerico

        [Browsable( true ), DisplayName( TextosPadroes.ValorMaximo ), Description( TextosPadroes.ValorMaximoDescricao ), Category( TextosPadroes.DadosCateogria ), DefaultValue( long.MaxValue )]
        public long MaxValue
        {
            get
            {
                return _valorMaximo;
            }

            set
            {
                if ( value < long.MinValue || value > long.MaxValue )
                {
                    throw new ArgumentOutOfRangeException( TextosPadroes.ValorLimiteTipoLong );
                }

                if ( value <= MinValue )
                {
                    throw new ArgumentException( TextosPadroes.ValorMaximoMenorValorMinimo );
                }

                _valorMaximo = value;
                AoAlterarValorMaximoMinimo();
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.ValorMinimo ), Description( TextosPadroes.ValorMinimoDescricao ), Category( TextosPadroes.DadosCateogria ), DefaultValue( long.MinValue )]
        public long MinValue
        {
            get
            {
                return _valorMinimo;
            }

            set
            {
                if ( value < long.MinValue || value > long.MaxValue )
                {
                    throw new ArgumentOutOfRangeException( TextosPadroes.ValorLimiteTipoLong );
                }

                if ( value >= MaxValue )
                {
                    throw new ArgumentException( TextosPadroes.ValorMinimoMaiorValorMaximo );
                }

                _valorMinimo = value;
                AoAlterarValorMaximoMinimo();
            }
        }

        [Browsable( false ), DisplayName( TextosPadroes.Valor ), Description( TextosPadroes.ValorDescricao ), Category( TextosPadroes.DadosCateogria )]
        public long Value
        {
            get
            {
                return Text.ParaLong();
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

        #endregion ICaixaTextoNumerico

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
            get { return base.AllowNumbers; }
            set { base.AllowNumbers = true; }
        }

        [Browsable( false )]
        public new bool PermitirLetras
        {
            get { return base.AllowLetters; }
            set { base.AllowLetters = value; }
        }

        [Browsable( false )]
        public new bool PermitirSimbolos
        {
            get { return base.AllowSymbols; }
            set { base.AllowSymbols = value; }
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

        #endregion Ocultadas

        #endregion Propriedades

        #region Construtores

        public CaixaTextoNumerico( IContainer container ) : base( container )
        {
            PermitirLetras = false;
            PermitirSimbolos = false;

            MaxLength = 120000;
            TextAlign = HorizontalAlignment.Center;
        }

        #endregion Construtores

        #region Métodos

        #region Privados

        private void AoAlterarValorMaximoMinimo()
        {
            if ( _valorMaximo > _valorMinimo * -1 )
            {
                MaxLength = _valorMaximo.ToString().Length;
            }
            else
            {
                MaxLength = _valorMinimo.ToString().Length;
            }
        }

        #endregion Privados

        #region Protegidos

        protected override void OnValidating( CancelEventArgs e )
        {
            base.OnValidating( e );

            if ( Value < _valorMinimo )
            {
                Mensagem.Avisar( $"Valor ultrapassou o limite mínimo permitido de {_valorMinimo}." );
                CleanUp();
            }
            else if ( Value > _valorMaximo )
            {
                Mensagem.Avisar( $"Valor ultrapassou o limite máximo permitido de {_valorMaximo}." );
                CleanUp();
            }
        }

        protected override void OnKeyUp( KeyEventArgs e )
        {
            base.OnKeyUp( e );

            if ( Value == 0 )
            {
                return;
            }

            Text = Value.ToString( "N0", CultureInfo.CurrentCulture );

            SelectionStart = Text.Length;
            SelectionLength = 0;
        }

        protected override void OnKeyPress( KeyPressEventArgs e )
        {
            if ( e.KeyChar.ApenasEspaco() )
            {
                e.Handled = true;
                return;
            }

            base.OnKeyPress( e );
        }

        protected override bool VerificarSeSimboloFoiInserido( char caractere )
        {
            if ( caractere.SimboloNegativo() )
            {
                if ( SelectionStart > 0 )
                {
                    return true;
                }

                if ( Text.Contains( '-' ) )
                {
                    return true;
                }
            }

            return caractere.Simbolo( _valorMinimo < 0 );
        }

        #endregion Protegidos

        #endregion Métodos
    }
}