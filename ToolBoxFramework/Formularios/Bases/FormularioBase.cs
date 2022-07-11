using BibliotecaPublica;
using BibliotecaPublica.CaixaFerramenta;
using BibliotecaPublica.CaixaFerramenta.Componentes;
using BibliotecaPublica.CaixaFerramenta.Interfaces;
using BibliotecaPublica.CamadaNotificadora;
using BibliotecaPublica.CamadaNotificadora.Enums;
using BibliotecaPublica.CamadaNotificadora.Interfaces;
using BibliotecaPublica.Classes.Verificadores;
using BibliotecaPublica.Enums;
using BibliotecaPublica.Estruturas;
using BibliotecaPublica.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFerramenta.Formularios.Bases
{
    [Serializable()]
    [DefaultEvent( "CarregarFormulario" )]
    public partial class FormularioBase : Form, IFormulario, INotificacao
    {
        private EventoAoAlterarModoJanela _aoAlterarModoJanela;

        #region Atributos

        #region Apenas Leitura

        private readonly Color _corFundoPadrao = Color.Silver;

        private readonly Point _localizacaoPadrao = new Point( 0, 0 );

        #endregion Apenas Leitura

        private bool _fecharJanela = true;

        private string _titulo = string.Empty;

        private ModoJanela _modoJanela = ModoJanela.Navegacao;
        private Resposta _respostaJanela = Resposta.Nenhuma;

        private EventoFormulario _carregarFormulario;

        private IBotao _botaoPesquisar = null;
        private IBotao _botaoAceitar = null;
        private IBotao _botaoCancelar = null;

        private List<IComponente> _ListaIComponente = new List<IComponente>();
        private List<ILimpeza> _listaILimpeza = new List<ILimpeza>();

        #endregion Atributos

        #region Propriedades

        #region Propriedades Sobreescritas

        [Browsable( false )]
        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }

            set
            {
                base.Enabled = value;
            }
        }

        [Browsable( false )]
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
        public new bool RightToLeftLayout
        {
            get
            {
                return base.RightToLeftLayout;
            }

            set
            {
                base.RightToLeftLayout = value;
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
        public new AutoValidate AutoValidate
        {
            get
            {
                return base.AutoValidate;
            }

            set
            {
                base.AutoValidate = value;
            }
        }

        [Browsable( false )]
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
        public new IButtonControl AcceptButton
        {
            get
            {
                return base.AcceptButton;
            }

            set
            {
                base.AcceptButton = value;
            }
        }

        [Browsable( false )]
        public new IButtonControl CancelButton
        {
            get
            {
                return base.CancelButton;
            }

            set
            {
                base.CancelButton = value;
            }
        }

        [Browsable( false ), DefaultValue( true )]
        public new bool KeyPreview
        {
            get
            {
                return base.KeyPreview;
            }

            set
            {
                base.KeyPreview = true;
            }
        }

        [Browsable( true ), Category( TextosPadroes.BotoesCategoria ), DisplayName( "Habilitar botão de fechar" )]
        public new bool ControlBox
        {
            get
            {
                return base.ControlBox;
            }

            set
            {
                base.ControlBox = value;
            }
        }

        [Browsable( true ), Category( TextosPadroes.BotoesCategoria ), DisplayName( "Habilitar botão de ajuda" )]
        public new bool HelpButton
        {
            get
            {
                return base.HelpButton;
            }

            set
            {
                base.HelpButton = value;
            }
        }

        [Browsable( false )]
        public new Icon Icon
        {
            get
            {
                return base.Icon;
            }

            set
            {
                base.Icon = value;
            }
        }

        [Browsable( false )]
        public new bool IsMdiContainer
        {
            get
            {
                return base.IsMdiContainer;
            }

            set
            {
                base.IsMdiContainer = value;
            }
        }

        [Browsable( false )]
        public new MenuStrip MainMenuStrip
        {
            get
            {
                return base.MainMenuStrip;
            }

            set
            {
                base.MainMenuStrip = value;
            }
        }

        [Browsable( true ), Category( TextosPadroes.BotoesCategoria ), DisplayName( "Habilitar botão maximizar" )]
        public new bool MaximizeBox
        {
            get
            {
                return base.MaximizeBox;
            }

            set
            {
                base.MaximizeBox = value;
            }
        }

        [Browsable( true ), Category( TextosPadroes.BotoesCategoria ), DisplayName( "Habilitar botão de minimizar" )]
        public new bool MinimizeBox
        {
            get
            {
                return base.MinimizeBox;
            }

            set
            {
                base.MinimizeBox = value;
            }
        }

        /// <summary>
        /// Indica se as barras de rolagem são exibidas automaticamente quando o conteúdo do controle é maior qua a área visivel.
        /// </summary>
        [
            Browsable( true ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DisplayName( "Habilitar barras de rolagem" ),
            DefaultValue( true )
        ]
        public new bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }

            set
            {
                base.AutoScroll = value;
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DisplayName( "Margem das barras de rolagem" )
        ]
        public new Size AutoScrollMargin
        {
            get
            {
                return base.AutoScrollMargin;
            }

            set
            {
                base.AutoScrollMargin = value;
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DisplayName( "Margem mínima das barras de rolagem" )
        ]
        public new Size AutoScrollMinSize
        {
            get
            {
                return base.AutoScrollMinSize;
            }

            set
            {
                base.AutoScrollMinSize = value;
            }
        }

        [Browsable( false )]
        public new bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }

            set
            {
                base.AutoSize = false;
            }
        }

        [Browsable( false )]
        public new AutoSizeMode AutoSizeMode
        {
            get
            {
                return base.AutoSizeMode;
            }

            set
            {
                base.AutoSizeMode = value;
            }
        }

        [Browsable( true ), DisplayName( "Localização" ), Description( "Obtém ou define o local da tela que abrirá o formulário." ), Category( "Comportamento" )]
        public new Point Location
        {
            get
            {
                return base.Location;
            }

            set
            {
                if ( value.X < 0 || value.Y < 0 )
                {
                    value = _localizacaoPadrao;
                }

                base.Location = value;
            }
        }

        [Browsable( false )]
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

        [Browsable( false )]
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

        [Browsable( false )]
        public new Padding Padding
        {
            get
            {
                return base.Padding;
            }

            set
            {
                base.Padding = value;
            }
        }

        [Browsable( false )]
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
        public new FormStartPosition StartPosition
        {
            get
            {
                return base.StartPosition;
            }

            set
            {
                base.StartPosition = value;
            }
        }

        [Browsable( false )]
        public new FormWindowState WindowState
        {
            get
            {
                return base.WindowState;
            }

            set
            {
                base.WindowState = value;
            }
        }

        #region Não Usar

        [Browsable( false ), Category( "Ah! Não Usar" )]
        public new double Opacity
        {
            get
            {
                return base.Opacity;
            }

            set
            {
                base.Opacity = value;
            }
        }

        [Browsable( false ), Category( "Ah! Não Usar" )]
        public new bool ShowIcon
        {
            get
            {
                return base.ShowIcon;
            }

            set
            {
                base.ShowIcon = value;
            }
        }

        [Browsable( false ), Category( "Ah! Não Usar" )]
        public new bool ShowInTaskbar
        {
            get
            {
                return base.ShowInTaskbar;
            }

            set
            {
                base.ShowInTaskbar = value;
            }
        }

        [Browsable( false ), Category( "Ah! Não Usar" )]
        public new SizeGripStyle SizeGripStyle
        {
            get
            {
                return base.SizeGripStyle;
            }

            set
            {
                base.SizeGripStyle = value;
            }
        }

        [Browsable( false ), Category( "Ah! Não Usar" )]
        public new bool TopMost
        {
            get
            {
                return base.TopMost;
            }

            set
            {
                base.TopMost = value;
            }
        }

        [Browsable( false ), Category( "Ah! Não Usar" )]
        public new Color TransparencyKey
        {
            get
            {
                return base.TransparencyKey;
            }

            set
            {
                base.TransparencyKey = value;
            }
        }

        [Browsable( false ), Category( "Ah! Não Usar" )]
        public new bool DoubleBuffered
        {
            get
            {
                return base.DoubleBuffered;
            }

            set
            {
                base.DoubleBuffered = value;
            }
        }

        [Browsable( false ), Category( "Ah! Não Usar" )]
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

        #endregion Não Usar

        [Browsable( false )]
        public new DialogResult DialogResult
        {
            get
            {
                return base.DialogResult;
            }

            set
            {
                base.DialogResult = value;
            }
        }

        #endregion Propriedades Sobreescritas

        #region Aparência

        [Browsable( true ), DisplayName( TextosPadroes.EstiloBorda ), Category( TextosPadroes.AparenciaCategoria )]
        public new FormBorderStyle FormBorderStyle
        {
            get
            {
                return base.FormBorderStyle;
            }

            set
            {
                base.FormBorderStyle = value;
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.CorFundo ), Category( TextosPadroes.AparenciaCategoria )]
        public new Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                if ( value.IsEmpty )
                {
                    value = _corFundoPadrao;
                }

                base.BackColor = value;
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

        [Browsable( true ), DisplayName( TextosPadroes.Fonte ), Category( TextosPadroes.AparenciaCategoria )]
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

        [Browsable( true ), DisplayName( "Habilitar botão de ajuda" ), Description( "Se deve mostrar o botão de ajuda na barra de legenda." ), Category( TextosPadroes.AparenciaCategoria ), DefaultValue( false )]
        public virtual bool HabilitarBotaoAjuda
        {
            get
            {
                return HelpButton;
            }

            set
            {
                HelpButton = value;
            }
        }

        [Browsable( true ), DisplayName( "Ícone da janela" ), Description( "Indica o ícone da janela." ), Category( TextosPadroes.AparenciaCategoria )]
        public virtual Icon Icone
        {
            get
            {
                return Icon;
            }

            set
            {
                Icon = value;
            }
        }

        [DisplayName( "Imagem de fundo" ), Browsable( true ), Category( TextosPadroes.AparenciaCategoria )]
        public new Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }

            set
            {
                base.BackgroundImage = value;
            }
        }

        [Browsable( true ), DisplayName( "Layout da imagem de fundo" ), Category( TextosPadroes.AparenciaCategoria )]
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }

            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        [Browsable( true ), DisplayName( "Tamanho da janela" ), Description( "Tamanho da janela." ), Category( TextosPadroes.AparenciaCategoria )]
        public Size TamanhoJanela
        {
            get
            {
                return Size;
            }

            set
            {
                Size = value;
            }
        }

        [Browsable( true ), DisplayName( TextosPadroes.TituloJanela ), Description( TextosPadroes.TituloJanelaDescricao ), Category( TextosPadroes.AparenciaCategoria ), DefaultValue( "" )]
        public string TituloJanela
        {
            get
            {
                return _titulo;
            }

            set
            {
                if ( value.Diferente( _titulo ) )
                {
                    _titulo = value;
                    AoAlterarTitulo();
                }
            }
        }

        #endregion Aparência

        #region Menu

        [DisplayName( "Opções com clique botão direito" ), Browsable( true ), Description( "Opções que serão exibidas ao clicar com o botão direito do mouse." ), Category( "Menu" ), DefaultValue( null )]
        public ContextMenuStrip Opcoes
        {
            get
            {
                return ContextMenuStrip;
            }

            set
            {
                ContextMenuStrip = value;
            }
        }

        [DisplayName( "Barra de menu da janela." ), Browsable( true ), Description( "Indica a barra de menu principal da janela." ), Category( "Menu" ), DefaultValue( null )]
        public MenuStrip BarraMenu
        {
            get
            {
                return MainMenuStrip;
            }

            set
            {
                MainMenuStrip = value;
            }
        }

        #endregion Menu

        #region Atalhos

        [DisplayName( "Botão de atalho para pesquisar" ), Browsable( true ), Description( "Botão que será executado ao apertar F3." ), Category( "Atalhos" ), DefaultValue( null )]
        public virtual IBotao AtalhoPesquisa
        {
            get
            {
                return _botaoPesquisar;
            }

            set
            {
                _botaoPesquisar = value;
            }
        }

        [DisplayName( "Botão de atalho para Aceitar/Gravar" ), Browsable( true ), Description( "Botão que será executado ao apertar Enter." ), Category( "Atalhos" ), DefaultValue( null )]
        public IBotao AtalhoAceitar
        {
            get
            {
                return _botaoAceitar;
            }

            set
            {
                _botaoAceitar = value;
            }
        }

        [DisplayName( "Botão de atalho para Cancelar/Sair" ), Browsable( true ), Description( "Botão que será executado ao apertar Esc." ), Category( "Atalhos" ), DefaultValue( null )]
        public IBotao AtalhoCancelar
        {
            get
            {
                return _botaoCancelar;
            }

            set
            {
                _botaoCancelar = value;
            }
        }

        #endregion Atalhos

        #region Comportamento

        [DisplayName( "Fechar janela" ), Browsable( true ), Description( "Indica se deve fechar a janela ao aceitar ou cancelar." ), Category( "Comportamento" ), DefaultValue( true )]
        public bool FecharJanela
        {
            get
            {
                return _fecharJanela;
            }

            set
            {
                _fecharJanela = value;
            }
        }

        [DisplayName( TextosPadroes.ModoJanela ), Browsable( false ), Description( TextosPadroes.ModoJanelaDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( ModoJanela.Navegacao )]
        public ModoJanela ModoJanela
        {
            get
            {
                return _modoJanela;
            }

            set
            {
                MudarModoJanela( value );
            }
        }

        [DisplayName( "Tamanho máximo" ), Browsable( true ), Description( "Tamanho máximo da janela." ), Category( "Comportamento" ), DefaultValue( null )]
        public Size TamanhoMaximoJanela
        {
            get
            {
                return MaximumSize;
            }

            set
            {
                MaximumSize = value;
            }
        }

        [DisplayName( "Tamanho mínimo" ), Browsable( true ), Description( "Tamanho mínimo da janela." ), Category( "Comportamento" ), DefaultValue( null )]
        public Size TamanhoMinimoJanela
        {
            get
            {
                return MinimumSize;
            }

            set
            {
                MinimumSize = value;
            }
        }

        [DisplayName( "Usar eventos de botões" ), Browsable( true ), Description( "Indica se deve fechar a janela ao aceitar ou cancelar." ), Category( "Comportamento" ), DefaultValue( true )]
        public bool UsarEventosBotoes
        {
            get
            {
                return base.KeyPreview;
            }

            set
            {
                base.KeyPreview = value;
            }
        }

        [DisplayName( "Modo auto redimensionamento da janela" ), Browsable( false ), Category( "Comportamento" )]
        public new AutoScaleMode AutoScaleMode
        {
            get
            {
                return base.AutoScaleMode;
            }

            set
            {
                if ( DesignMode )
                {
                    base.AutoScaleMode = AutoScaleMode.None;
                }

                base.AutoScaleMode = AutoScaleMode.None;
            }
        }

        #endregion Comportamento

        [DisplayName( "Preenchimento interno" ), Browsable( true ), Description( "Margem interna da janela." ), Category( "" ), DefaultValue( null )]
        public Padding Preenchimento
        {
            get
            {
                return Padding;
            }

            set
            {
                Padding = value;
            }
        }

        [DisplayName( "Posição Inicial" ), Browsable( true ), Description( "Posição inicial da janela na tela." ), Category( "" ), DefaultValue( FormStartPosition.CenterScreen )]
        public FormStartPosition PosicaoInicial
        {
            get
            {
                return StartPosition;
            }

            set
            {
                StartPosition = value;
            }
        }

        [DisplayName( "Estado inicial da janela" ), Browsable( true ), Description( "Estado inicial da janela na tela." ), Category( "" ), DefaultValue( FormWindowState.Normal )]
        public virtual FormWindowState EstadoInicialJanela
        {
            get
            {
                return WindowState;
            }

            set
            {
                WindowState = value;
            }
        }

        [DisplayName( "Resposta" ), Browsable( false ), Description( "Resposta obtida de outros componentes." ), Category( "" ), DefaultValue( Resposta.Nenhuma )]
        public Resposta Resposta
        {
            get
            {
                return _respostaJanela;
            }

            set
            {
                ReceberResposta( value );
            }
        }

        [Browsable( false ), DisplayName( TextosPadroes.Notificacoes ), Category( TextosPadroes.ValidacaoCategoria ), Description( TextosPadroes.NotificacoesDescricao )]
        public NotificacaoColecao Notificacoes
        {
            get; private set;
        }

        #endregion Propriedades

        #region Construtores

        public FormularioBase()
        {
            InitializeComponent();
            AoAlterarTitulo();

            Notificacoes = new NotificacaoColecao( this );
        }

        #endregion Construtores

        #region Eventos

        #region Ocultadas

        [Browsable( false )]
        public new event EventHandler Load;

        #endregion Ocultadas

        /// <summary>
        /// Acionado ao alterar o modo de janela.
        /// </summary>
        [Browsable( true ), DisplayName( "Ao alterar modo de janela" ), Description( "Evento gerado ao alterar o modo da janela." ), Category( "Comportamento" )]
        public event EventoAoAlterarModoJanela AoAlterarModoJanela { add { _aoAlterarModoJanela += value; } remove { _aoAlterarModoJanela -= value; } }

        /// <summary>
        /// Evento acionado ao carregar formulário.
        /// </summary>
        [Browsable( true ), DisplayName( TextosPadroes.CarregarFormulario ), Description( TextosPadroes.CarregarFormularioDescricao ), Category( TextosPadroes.ComportamentoCategoria )]
        public event EventoFormulario CarregarFormulario
        {
            add
            {
                _carregarFormulario += value;
            }

            remove
            {
                _carregarFormulario -= value;
            }
        }

        #endregion Eventos

        #region Métodos Privados

        #region Métodos de Eventos

        private void AoReceberResposta( object enviador, EventArgs argumento )
        {
            switch ( Resposta )
            {
                case Resposta.Ok:
                case Resposta.Sim:
                case Resposta.Cancelar:
                case Resposta.Nao:
                {
                    if ( FecharJanela && ModoJanela == ModoJanela.Navegacao )
                    {
                        Close();
                    }

                    break;
                }
            }
        }

        private void AoMudarModoJanela( object enviador, EventArgs argumento )
        {
            switch ( ModoJanela )
            {
                case ModoJanela.Inclusao:
                {
                    DesbloquearComponentes();
                    break;
                }

                case ModoJanela.Alteracao:
                {
                    DesbloquearComponentes();
                    break;
                }

                case ModoJanela.Navegacao:
                case ModoJanela.Exclusao:
                {
                    BloquearComponentes();
                    break;
                }
            }

            _aoAlterarModoJanela?.Invoke();
        }

        private void AoAlterarTitulo()
        {
            Text = $"{ConfiguracoesCaixaFerramenta.TituloFormularios}";

            if ( !DesignMode && _titulo.TemConteudo() )
            {
                Text += $" | ";
            }

            Text += _titulo;
        }

        #endregion Métodos de Eventos

        private void ReceberResposta( Resposta valor )
        {
            if ( _respostaJanela == valor )
            {
                return;
            }

            _respostaJanela = valor;

            AoReceberResposta( this, EventArgs.Empty );
        }

        private void MudarModoJanela( ModoJanela valor )
        {
            Resposta = Resposta.Nenhuma;

            if ( _modoJanela == valor )
            {
                return;
            }

            _modoJanela = valor;

            AoMudarModoJanela( this, EventArgs.Empty );
        }

        private void ObterComponentes()
        {
            if ( DesignMode )
            {
                return;
            }

            foreach ( object item in components.Components )
            {
                if ( item is IComponente )
                {
                    _ListaIComponente.Add( item as IComponente );
                }
                else if ( item is ILimpeza )
                {
                    _listaILimpeza.Add( item as ILimpeza );
                }
            }
        }

        #endregion Métodos Privados

        #region Métodos Protegidos

        /// <summary>
        /// Desabilita os componentes do formulário que estão com a propriedade "BloquearComponente" como true.
        /// </summary>
        protected virtual void BloquearComponentes()
        {
            if ( DesignMode )
            {
                return;
            }

            foreach ( IComponente componente in _ListaIComponente )
            {
                if ( componente.BloquearComponente )
                {
                    componente.Bloqueado = true;
                }
            }
        }

        /// <summary>
        /// Habilita os componentes do formulário que estão com a propriedade "BloquearComponente" como true.
        /// </summary>
        protected virtual void DesbloquearComponentes()
        {
            if ( DesignMode )
            {
                return;
            }

            foreach ( IComponente componente in _ListaIComponente )
            {
                if ( componente.BloquearComponente )
                {
                    componente.Bloqueado = false;
                }
            }
        }

        /// <summary>
        /// Executa a limpeza de todos componentes que implementam a interface ILimpeza.
        /// </summary>
        protected virtual void LimparSujeiraComponentes()
        {
            foreach ( ILimpeza componente in _listaILimpeza )
            {
                if ( componente.FazerLimpeza )
                {
                    componente.Limpar();
                }
            }
        }

        protected virtual void AdicionarComponentes( IContainer componentes )
        {
            components = componentes;
        }

        #endregion Métodos Protegidos

        #region Métodos Sobreescritos

        protected override void OnKeyDown( KeyEventArgs e )
        {
            base.OnKeyDown( e );

            if ( ModoJanela == ModoJanela.Navegacao )
            {
                switch ( e.KeyData )
                {
                    case Keys.F3:
                    {
                        if ( AtalhoPesquisa != null )
                        {
                            Resposta = AtalhoPesquisa.ExecutarCliqueBotao();
                        }

                        break;
                    }

                    case Keys.Enter:
                    {
                        if ( AtalhoAceitar != null )
                        {
                            Resposta = AtalhoAceitar.ExecutarCliqueBotao();
                            DialogResult = Resposta == Resposta.Ok ? DialogResult.OK : DialogResult.None;
                        }

                        break;
                    }

                    case Keys.Escape:
                    {
                        if ( AtalhoCancelar != null )
                        {
                            Resposta = AtalhoCancelar.ExecutarCliqueBotao();
                            DialogResult = Resposta == Resposta.Cancelar ? DialogResult.Cancel : DialogResult.None;
                        }

                        break;
                    }

                    default:
                    {
                        if ( components == null )
                        {
                            break;
                        }

                        foreach ( var item in components.Components )
                        {
                            if ( item is IBotao )
                            {
                                IBotao botao = item as IBotao;

                                if ( botao.TeclaAtalho == e.KeyData )
                                {
                                    botao.Focar();
                                    botao.ExecutarCliqueBotao();
                                    break;
                                }
                            }
                        }

                        break;
                    }
                }
            }
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            ObterComponentes();

            if ( ModoJanela == ModoJanela.Navegacao )
            {
                BloquearComponentes();
            }

            _carregarFormulario?.Invoke();
        }

        #endregion Métodos Sobreescritos

        #region INotificacao

        /// <summary>
        /// Adicionar notificações.
        /// </summary>
        /// <param name="resultado">Resultado da validação.</param>
        public void AdicionarNotificacoes( ValidationResult resultado )
        {
            Notificacoes.AdicionarResultadoValidacao( resultado );
        }

        /// <summary>
        /// Método para mostrar notificações da camada de negócio.
        /// </summary>
        public void Notificar()
        {
            Notificar( Notificacoes.ToString(), TipoNotificacao.Aviso );
        }

        /// <summary>
        /// Método para mostrar notificações da camada de negócio.
        /// </summary>
        /// <param name="mensagem">Mensagem que será mostrada para o usuário.</param>
        public void Notificar( string mensagem )
        {
            Notificar( mensagem, TipoNotificacao.Aviso );
        }

        /// <summary>
        /// Método para mostrar notificações da camada de negócio.
        /// </summary>
        /// <param name="mensagem">Mensagem que será mostrada para o usuário.</param>
        /// <param name="tipoNotificacao">Define se será uma notificação para informar, avisar ou perguntar para o usuário.</param>
        public void Notificar( string mensagem, TipoNotificacao tipoNotificacao )
        {
            switch ( tipoNotificacao )
            {
                case TipoNotificacao.Informacao:
                {
                    Mensagem.Informar( mensagem );
                    break;
                }

                case TipoNotificacao.Aviso:
                {
                    Mensagem.Avisar( mensagem );
                    break;
                }

                case TipoNotificacao.Pergunta:
                {
                    Mensagem.Perguntar( mensagem );
                    break;
                }

                default:
                {
                    Mensagem.Avisar( @"Usar notificação para erro no ""catch"" da interface de usuário." );
                    break;
                }
            }
        }

        /// <summary>
        /// Verifica se há alguma notificação na lista.
        /// </summary>
        /// <returns>Retorna true se houver alguma notificação.</returns>
        public bool TemNotificacao()
        {
            return Notificacoes.QuantidadeItens > 0;
        }

        #endregion INotificacao
    }
}