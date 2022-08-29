namespace ToolBox.Formulario.Base
{
    /// <summary>
    /// Classe de formulário que serve de base para criação de novos formulários.
    /// </summary>
    public partial class FormularioBase : Form, IFormulario
    {
        private EventoAoAlterarModoJanela _aoAlterarModoJanela;
        private EventoFormulario _aoCarregarFormulario;

        #region Atributos

        private bool _fecharJanela;
        private string _titulo;

        private ModoJanela _modoJanela = ModoJanela.Navegacao;

        private Color _corFundoPadrao = Color.White;

        private List<IComponente> _ListaIComponente = new List<IComponente>();
        private List<ILimpeza> _listaILimpeza = new List<ILimpeza>();

        #endregion Atributos

        #region Propriedades

        #region IFormulario

        [Browsable( false ), DisplayName( TextosPadroes.ModoJanela ), Description( TextosPadroes.ModoJanelaDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( ModoJanela.Navegacao )]
        public ModoJanela ModoJanela
        {
            get
            {
                return _modoJanela;
            }

            set
            {
                AlterarModoJanela( value );
            }
        }

        #endregion IFormulario

        #region Ocultadas

        [Browsable( false )]
        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        #endregion Ocultadas

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

        #region Comportamento

        [Browsable( true ), DisplayName( TextosPadroes.FecharJanela ), Description( TextosPadroes.FecharJanelaDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( true )]
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

        #endregion Comportamento

        #region Validação

        [Browsable( false ), DisplayName( TextosPadroes.Notificacoes ), Description( TextosPadroes.NotificacoesDescricao ), Category( TextosPadroes.ValidacaoCategoria )]
        public NotificacaoColecao Notificacoes { protected get; set; }

        #endregion Validação

        #endregion Propriedades

        #region Construtores

        public FormularioBase()
        {
            InitializeComponent();
        }

        #endregion Construtores

        #region Eventos

        /// <summary>
        /// Acionado ao alterar o modo de janela.
        /// </summary>
        [Browsable( true ), Description( "Evento gerado ao alterar o modo da janela." ), Category( "Comportamento" ), DisplayName( "Ao alterar modo de janela" )]
        public event EventoAoAlterarModoJanela AoAlterarModoJanela { add { _aoAlterarModoJanela += value; } remove { _aoAlterarModoJanela -= value; } }

        [Browsable( true ), Description( TextosPadroes.EventoAoCarregarFormularioDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DisplayName( TextosPadroes.EventoAoCarregarFormulario )]
        public event EventoFormulario AoCarregarFormulario { add { _aoCarregarFormulario += value; } remove { _aoCarregarFormulario -= value; } }

        [Browsable( false )]
        public new event EventHandler Load { add { base.Load += value; } remove { base.Load -= value; } }

        #endregion Eventos

        #region Métodos

        #region Privados

        private void AoAlterarTitulo()
        {
            Text = $"{ToolBoxConfig.TituloPadrao}";

            if ( !DesignMode && _titulo.TemConteudo() )
            {
                Text += $" | ";
            }

            Text += _titulo;
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

        #endregion Privados

        #region Protegidos

        protected virtual void AdicionarComponentes( IContainer componentes )
        {
            components = componentes;
        }

        protected void AlterarModoJanela( ModoJanela valor )
        {
            if ( _modoJanela == valor )
            {
                return;
            }

            _modoJanela = valor;

            AoMudarModoJanela( this, EventArgs.Empty );
        }

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

        protected override void OnLoad( EventArgs e )
        {
            //base.OnLoad( e );

            ObterComponentes();

            if ( ModoJanela == ModoJanela.Navegacao )
            {
                BloquearComponentes();
            }

            _aoCarregarFormulario?.Invoke();
        }

        #endregion Protegidos

        #region Públicos

        #region IFormulario

        public Point ObterPontoCentral()
        {
            return new Point( ( Size.Width / 2 ).ParaInt(), ( Size.Height / 2 ).ParaInt() );
        }

        #endregion IFormulario

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

        #endregion Públicos

        #endregion Métodos
    }
}