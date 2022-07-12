using BibliotecaPublica.Classes.Servicos.Conversores;
using BibliotecaPublica.Classes.Verificadores;
using BibliotecaPublica.Estruturas;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ToolBox.ToolBoxFramework.Interfaces;

namespace ToolBox.ToolBoxFramework.Componentes.Bases
{
    [DesignerCategory( "Caixa de Texto" ), ToolboxItem( false )]
    public class CaixaTextoBase : TextBox, ICaixaTexto, IComponente, ILimpeza
    {
        #region Atributos

        protected bool _naoPermitirNumeros = false;
        protected bool _bloquearComponente = false;
        protected bool _fazerValidacao = false;

        protected uint _quantidadeMinima = 0;

        private string _valorPadrao = string.Empty;

        #endregion Atributos

        #region Propriedadades

        #region Propriedades Sobreescritas

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

        [DisplayName( "Cor de fundo" )]
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

        [DisplayName( "Cor do texto" )]
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

        #endregion Aparência

        #region Comportamento

        [Category( "Comportamento" ), DisplayName( "Barras de rolagem" )]
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

        [Category( "Comportamento" ), DisplayName( "Alinhamento de texto" )]
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

        [Browsable( false )]
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

        [Category( "Comportamento" ), DisplayName( "Menu ao clicar botão direito" )]
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

        [Category( "Comportamento" ), DefaultValue( true ), DisplayName( "Habilitada" )]
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

        [Browsable( false )]
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

        [Browsable( false )]
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

        [Category( "Comportamento" ), DisplayName( "Apenas leitura" )]
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

        [Browsable( false )]
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

        [Category( "Comportamento" ), DisplayName( "Índice de tabulação" )]
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

        [Category( "Comportamento" ), DisplayName( "Parar na caixa de texto" )]
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

        [Browsable( false )]
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

        [Category( "Comportamento" ), DisplayName( "Visível" )]
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

        [Browsable( false )]
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

        [Category( "Comportamento" ), DisplayName( "Âncora" )]
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

        [Category( "Comportamento" ), DisplayName( "Fixado" )]
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

        [Category( "Comportamento" ), DisplayName( "Tamanho máximo" )]
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

        [Category( "Comportamento" ), DisplayName( "Tamanho mínimo" )]
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

        [Category( "Dados" ), DisplayName( "Texto" )]
        public new string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
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

        #endregion Propriedades Sobreescritas

        #region Propriedades de Interface

        #region IComponente

        [
            Browsable( true ),
            Category( TextosPadroes.ValidacaoCategoria ),
            DisplayName( TextosPadroes.FazerValidacao ),
            Description( TextosPadroes.FazerValidacaoDescricao ),
            DefaultValue( false )
        ]
        public bool FazerValidacao
        {
            get
            {
                return _fazerValidacao;
            }

            set
            {
                _fazerValidacao = true;
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.ComportamentoCategoria ),
            Description( TextosPadroes.BloquearComponenteDescricao ),
            DisplayName( TextosPadroes.BloquearComponente ),
            DefaultValue( false )
        ]
        public bool BloquearComponente
        {
            get
            {
                return _bloquearComponente;
            }

            set
            {
                _bloquearComponente = value;
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DisplayName( TextosPadroes.Bloqueado ),
            Description( TextosPadroes.BloqueadoDescricao ),
            DefaultValue( true ),
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

        [Browsable( true ), Category( TextosPadroes.DadosCateogria ), Description( TextosPadroes.FazerLimpezaDescricao ), DisplayName( TextosPadroes.FazerLimpeza ), DefaultValue( false )]
        public bool FazerLimpeza { get; set; } = false;

        #endregion ILimpeza

        #endregion Propriedades de Interface

        #region Comportamento

        [
            Browsable( true ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DisplayName( TextosPadroes.PermitirNumeros ),
            Description( TextosPadroes.PermitirNumerosDescricao ),
            DefaultValue( false ),
        ]
        public bool NaoPermitirNumeros
        {
            get
            {
                return _naoPermitirNumeros;
            }

            set
            {
                _naoPermitirNumeros = value;
            }
        }

        #endregion Comportamento

        #endregion Propriedadades

        #region Construtores

        private CaixaTextoBase()
        {
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

        #region Métodos Privados

        private bool VerificarSeNumeroInserido( char caractere )
        {
            return caractere > 47 && caractere < 58 && _naoPermitirNumeros;
        }

        private bool VerificarValorPadrao( string valor )
        {
            for ( int i = 0; i < valor.Length; i++ )
            {
                if ( VerificarSeNumeroInserido( valor[ i ] ) )
                {
                    return false;
                }
            }

            return true;
        }

        #endregion Métodos Privados

        #region Métodos Protegidos

        protected void AoDesabilitar()
        {
            BackColor = Color.Gainsboro;
        }

        protected void AoHabilitar()
        {
            BackColor = Color.White;
        }

        #endregion Métodos Protegidos

        #region Métodos Sobrescritos

        protected override void OnKeyPress( KeyPressEventArgs e )
        {
            if ( VerificarSeNumeroInserido( e.KeyChar ) )
            {
                e.Handled = true;
            }
            else
            {
                base.OnKeyPress( e );
            }
        }

        protected override void OnEnabledChanged( EventArgs e )
        {
            if ( Enabled )
            {
                AoHabilitar();
            }
            else
            {
                AoDesabilitar();
            }

            base.OnEnabledChanged( e );
        }

        #endregion Métodos Sobrescritos

        #region Métodos Públicos

        #region Métodos de Interface

        public bool Validar()
        {
            throw new NotImplementedException();
        }

        public bool TemTexto()
        {
            return Text.TemConteudo();
        }

        /// <summary>
        /// Executa a limpeza de resíduo do componente.
        /// </summary>
        public void Limpar()
        {
            Clear();
        }

        #endregion Métodos de Interface

        #endregion Métodos Públicos
    }
}