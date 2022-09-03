namespace ToolBox.CaixaTexto
{
    [DesignerCategory( "Caixa de Texto" ), ToolboxItem( false )]
    public class CaixaTextoBase : TextBox, ICaixaTexto, IComponente, ILimpeza
    {
        #region Atributos

        protected string _valorPadrao = string.Empty;

        #endregion Atributos

        #region Propriedades

        #region ICaixaTexto

        [Browsable( true ), DisplayName( TextosPadroes.PermitirNumeros ), Description( TextosPadroes.PermitirNumerosDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( true )]
        public bool PermitirNumeros { get; set; } = true;

        [Browsable( true ), DisplayName( TextosPadroes.PermitirLetras ), Description( TextosPadroes.PermitirLetrasDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( true )]
        public bool PermitirLetras { get; set; } = true;

        [Browsable( true ), DisplayName( TextosPadroes.PermitirSimbolos ), Description( TextosPadroes.PermitirSimbolosDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( true )]
        public bool PermitirSimbolos { get; set; } = true;

        #endregion ICaixaTexto

        #region IComponente

        [Browsable( true ), DisplayName( TextosPadroes.BloquearComponente ), Description( TextosPadroes.BloquearComponenteDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
        public bool BloquearComponente { get; set; } = false;

        [Browsable( true ), DisplayName( TextosPadroes.Bloqueado ), Description( TextosPadroes.BloqueadoDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( true )]
        public bool Bloqueado
        {
            set
            {
                Enabled = !value;
            }
        }

        #endregion IComponente

        #region ILimpeza

        [Browsable( true ), DisplayName( TextosPadroes.FazerLimpeza ), Description( TextosPadroes.FazerLimpezaDescricao ), Category( TextosPadroes.DadosCateogria ), DefaultValue( false )]
        public bool FazerLimpeza { get; set; } = false;

        #endregion ILimpeza

        #region Ocultadas

        [Browsable( false ), DisplayName( TextosPadroes.PermitirTab ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
        public new bool AcceptsTab
        {
            get
            {
                return base.AcceptsTab;
            }

            set
            {
                base.AcceptsTab = value;
            }
        }

        [Browsable( false )]
        public new bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }

            set
            {
                base.AllowDrop = value;
            }
        }

        [Browsable( false )]
        public new bool HideSelection
        {
            get
            {
                return base.HideSelection;
            }

            set
            {
                base.HideSelection = value;
            }
        }

        [Browsable( false )]
        public new ImeMode ImeMode
        {
            get
            {
                return base.ImeMode;
            }

            set
            {
                base.ImeMode = value;
            }
        }

        [Browsable( false )]
        public new string[] Lines
        {
            get
            {
                return base.Lines;
            }

            set
            {
                base.Lines = value;
            }
        }

        #endregion Ocultadas

        #region Acessibilidade

        [DisplayName( "Descrição" )]
        public new string AccessibleDescription
        {
            get
            {
                return base.AccessibleDescription;
            }

            set
            {
                base.AccessibleDescription = value;
            }
        }

        [DisplayName( "Nome" )]
        public new string AccessibleName
        {
            get
            {
                return base.AccessibleName;
            }

            set
            {
                base.AccessibleName = value;
            }
        }

        [DisplayName( "Função" )]
        public new AccessibleRole AccessibleRole
        {
            get
            {
                return base.AccessibleRole;
            }

            set
            {
                base.AccessibleRole = value;
            }
        }

        #endregion Acessibilidade

        #region Aparência

        [Browsable( true ), DisplayName( TextosPadroes.CorFundo ), Category( TextosPadroes.AparenciaCategoria )]
        public new Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
            }
        }

        [DisplayName( "Estilo de borda" )]
        public new BorderStyle BorderStyle
        {
            get
            {
                return base.BorderStyle;
            }

            set
            {
                base.BorderStyle = value;
            }
        }

        [Browsable( false )]
        public new Cursor Cursor
        {
            get
            {
                return base.Cursor;
            }

            set
            {
                base.Cursor = value;
            }
        }

        [DisplayName( "Estilo da fonte" )]
        public new Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                base.Font = value;
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.CorFonte ), Category( TextosPadroes.AparenciaCategoria )]
        public new Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                base.ForeColor = value;
            }
        }

        [Category( "Aparência" ), DisplayName( "Tamanho" )]
        public new Size Size
        {
            get
            {
                return base.Size;
            }

            set
            {
                base.Size = value;
            }
        }

        [Browsable( false )]
        public new RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }

            set
            {
                base.RightToLeft = value;
            }
        }

        [Browsable( false )]
        public new bool UseWaitCursor
        {
            get
            {
                return base.UseWaitCursor;
            }

            set
            {
                base.UseWaitCursor = value;
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.CaractereSenha ), Category( TextosPadroes.AparenciaCategoria ), DefaultValue( false )]
        public new char PasswordChar
        {
            get
            {
                return base.PasswordChar;
            }

            set
            {
                base.PasswordChar = value;
            }
        }

        #endregion Aparência

        #region Comportamento

        [Browsable( true )]
        public new bool AcceptsReturn
        {
            get
            {
                return base.AcceptsReturn;
            }

            set
            {
                base.AcceptsReturn = value;
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.QuantidadeMaxima ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( ValoresPadroes.QuantidadeMaxima )]
        public new int MaxLength
        {
            get
            {
                return base.MaxLength;
            }

            set
            {
                base.MaxLength = value;
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.MultiLinha ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
        public new bool Multiline
        {
            get
            {
                return base.Multiline;
            }

            set
            {
                base.Multiline = value;
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.BarraRolagem ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( ScrollBars.None )]
        public new ScrollBars ScrollBars
        {
            get
            {
                return base.ScrollBars;
            }

            set
            {
                base.ScrollBars = value;
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.AlinhamentoTexto ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( HorizontalAlignment.Left )]
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

        [Browsable( true ), DisplayName( TextosPadroes.ConverterCaractereParaMinusculasOuMaiusculas ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( CharacterCasing.Normal )]
        public new CharacterCasing CharacterCasing
        {
            get
            {
                return base.CharacterCasing;
            }

            set
            {
                base.CharacterCasing = value;
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.MenuContexto ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( null )]
        public new ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return base.ContextMenuStrip;
            }

            set
            {
                base.ContextMenuStrip = value;
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.Habilitado ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( true )]
        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }

            set
            {
                bool valorAntigo = Enabled;

                if ( value != valorAntigo )
                {
                    base.Enabled = value;
                    OnEnabledChanged( EventArgs.Empty );
                }
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.ApenasLeitura ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
        public new bool ReadOnly
        {
            get
            {
                return base.ReadOnly;
            }

            set
            {
                base.ReadOnly = value;
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.HabilitarAtalhos ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( true )]
        public new bool ShortcutsEnabled
        {
            get
            {
                return base.ShortcutsEnabled;
            }

            set
            {
                base.ShortcutsEnabled = value;
            }
        }

        [Category( TextosPadroes.ComportamentoCategoria ), DisplayName( "Índice de tabulação" )]
        public new int TabIndex
        {
            get
            {
                return base.TabIndex;
            }

            set
            {
                base.TabIndex = value;
            }
        }

        [Category( TextosPadroes.ComportamentoCategoria ), DisplayName( "Parar na caixa de texto" )]
        public new bool TabStop
        {
            get
            {
                return base.TabStop;
            }

            set
            {
                base.TabStop = value;
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.UsarCaractereSenha ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
        public new bool UseSystemPasswordChar
        {
            get
            {
                return base.UseSystemPasswordChar;
            }

            set
            {
                base.UseSystemPasswordChar = value;
            }
        }

        [Category( TextosPadroes.ComportamentoCategoria ), DisplayName( "Visível" )]
        public new bool Visible
        {
            get
            {
                return base.Visible;
            }

            set
            {
                base.Visible = value;
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.QuebraLinhaAutomatica ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
        public new bool WordWrap
        {
            get
            {
                return base.WordWrap;
            }

            set
            {
                base.WordWrap = value;
            }
        }

        [Category( TextosPadroes.ComportamentoCategoria ), DisplayName( "Âncora" )]
        public new AnchorStyles Anchor
        {
            get
            {
                return base.Anchor;
            }

            set
            {
                base.Anchor = value;
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.Fixar ), Category( TextosPadroes.ComportamentoCategoria )]
        public new DockStyle Dock
        {
            get
            {
                return base.Dock;
            }

            set
            {
                base.Dock = value;
            }
        }

        [Category( TextosPadroes.ComportamentoCategoria ), DisplayName( "Tamanho máximo" )]
        public new Size MaximumSize
        {
            get
            {
                return base.MaximumSize;
            }

            set
            {
                base.MaximumSize = value;
            }
        }

        [Category( TextosPadroes.ComportamentoCategoria ), DisplayName( "Tamanho mínimo" )]
        public new Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }

            set
            {
                base.MinimumSize = value;
            }
        }

        #endregion Comportamento

        #region Dados

        [Browsable( true ), DisplayName( TextosPadroes.TextoAjuda ), Description( TextosPadroes.TextoAjudaDescricao ), Category( TextosPadroes.DadosCateogria ), DefaultValue( null )]
        public new string PlaceholderText
        {
            get { return base.PlaceholderText; }
            set { base.PlaceholderText = value; }
        }

        [Browsable( true ), DisplayName( TextosPadroes.Texto ), Category( TextosPadroes.DadosCateogria ), DefaultValue( null )]
        public new string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                if ( DesignMode )
                {
                    AlterarTextoPadrao( value );
                }

                base.Text = value;
            }
        }

        #endregion Dados

        #region Diversos

        [Category( "Diversos" ), DisplayName( "Localização" )]
        public new Point Location
        {
            get
            {
                return base.Location;
            }

            set
            {
                base.Location = value;
            }
        }

        [Browsable( false )]
        public new AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get
            {
                return base.AutoCompleteCustomSource;
            }

            set
            {
                base.AutoCompleteCustomSource = value;
            }
        }

        [Browsable( false )]
        public new AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return base.AutoCompleteMode;
            }

            set
            {
                base.AutoCompleteMode = value;
            }
        }

        [Browsable( false )]
        public new AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return base.AutoCompleteSource;
            }

            set
            {
                base.AutoCompleteSource = value;
            }
        }

        #endregion Diversos

        #region Foco

        [Browsable( false )]
        public new bool CausesValidation
        {
            get
            {
                return base.CausesValidation;
            }

            set
            {
                base.CausesValidation = value;
            }
        }

        #endregion Foco

        #region Layout

        [Browsable( false )]
        public new Padding Margin
        {
            get
            {
                return base.Margin;
            }

            set
            {
                base.Margin = value;
            }
        }

        #endregion Layout

        #endregion Propriedades

        #region Construtores

        private CaixaTextoBase()
        {
            Margin = new Padding( 10, 5, 10, 5 );
            MaxLength = ValoresPadroes.QuantidadeMaxima.ParaInt();
            Text = _valorPadrao;
        }

        public CaixaTextoBase( IContainer container ) : this()
        {
            if ( container != null )
            {
                container.Add( this );
            }
        }

        #endregion Construtores

        #region Métodos

        #region Privados

        private void AlterarTextoPadrao( string texto )
        {
            if ( VerificarTextoInserido( texto ) )
            {
                _valorPadrao = texto;
            }
        }

        #endregion Privados

        #region Protegidos

        protected override void OnEnabledChanged( EventArgs e )
        {
            base.OnEnabledChanged( e );

            if ( Enabled )
            {
                BackColor = Color.White;
            }
            else
            {
                BackColor = Color.Gainsboro;
            }
        }

        protected override void OnKeyPress( KeyPressEventArgs e )
        {
            if ( VerificarCaractereInvalidoInserido( e.KeyChar ) )
            {
                e.Handled = true;
                return;
            }

            base.OnKeyPress( e );
        }

        protected virtual bool VerificarSeLetraFoiInserido( char caractere )
        {
            return !PermitirLetras && caractere.Letra();
        }

        protected virtual bool VerificarSeNumeroFoiInserido( char caractere )
        {
            return !PermitirNumeros && caractere.Numero();
        }

        protected virtual bool VerificarSeSimboloFoiInserido( char caractere )
        {
            return !PermitirSimbolos && caractere.Simbolo();
        }

        protected bool VerificarCaractereInvalidoInserido( char caractere )
        {
            if ( caractere.Retorno() )
            {
                return false;
            }

            if ( VerificarSeLetraFoiInserido( caractere ) )
            {
                return true;
            }

            if ( VerificarSeNumeroFoiInserido( caractere ) )
            {
                return true;
            }

            if ( VerificarSeSimboloFoiInserido( caractere ) )
            {
                return true;
            }

            return false;
        }

        protected bool VerificarTextoInserido( string valor )
        {
            for ( int i = 0; i < valor.Length; i++ )
            {
                if ( VerificarCaractereInvalidoInserido( valor[ i ] ) )
                {
                    return false;
                }
            }

            return true;
        }

        #endregion Protegidos

        #region Públicos

        #region ICaixaTexto

        public bool TemTexto()
        {
            return Text.TemConteudo();
        }

        #endregion ICaixaTexto

        #region IComponente

        public Point ObterPontoCentral()
        {
            return new Point( ( Size.Width / 2 ).ParaInt(), ( Size.Height / 2 ).ParaInt() );
        }

        #endregion IComponente

        #region ILimpeza

        public void Limpar()
        {
            Clear();
            Text = _valorPadrao;
        }

        #endregion ILimpeza

        #endregion Públicos

        #endregion Métodos
    }
}