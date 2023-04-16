namespace MyGears.Forms.Base;

/// <summary>
/// Classe de formulário que serve de base para criação de novos formulários.
/// </summary>
public partial class FormBase
    : Form, IForm, INotificacao
{
    private EventoAoAlterarModoJanela _aoAlterarModoJanela;
    private EventoFormulario _aoCarregarFormulario;

    private bool _closeView;
    private string _formTitle = string.Empty;

    private ModoJanela _formMode = ModoJanela.Navegacao;
    private Theme _theme = Theme.White;

    private Color _corFundoPadrao = Color.White;

    private Font _font = ToolBoxEnvironment.GeneralFont;
    private List<IControl> _ListaIComponente = new List<IControl>();
    private List<ICleanUp> _listaILimpeza = new List<ICleanUp>();

    [Browsable( true ), DisplayName( TextosPadroes.EstiloBorda ), Category( TextosPadroes.AparenciaCategoria )]
    public new FormBorderStyle FormBorderStyle
    {
        get => base.FormBorderStyle;
        set => base.FormBorderStyle = value;
    }

    [Browsable( true ), DisplayName( TextosPadroes.CorFundo ), Category( TextosPadroes.AparenciaCategoria )]
    public new Color BackColor
    {
        get => base.BackColor;
        set
        {
            if ( value.IsEmpty )
                value = _corFundoPadrao;

            base.BackColor = value;
        }
    }

    [Browsable( true ), DisplayName( TextosPadroes.CorFonte ), Category( TextosPadroes.AparenciaCategoria )]
    public new Color ForeColor
    {
        get => base.ForeColor;
        set => base.ForeColor = value;
    }

    /// <summary>
    /// Fonte de texto do controle.
    /// </summary>
    [Browsable( false ), DisplayName( TextosPadroes.Fonte ), Category( TextosPadroes.AparenciaCategoria )]
    public new Font Font
    {
        get => ToolBoxEnvironment.GeneralFont;
        set => base.Font = ToolBoxEnvironment.GeneralFont;
    }

    /// <summary>
    /// Título do formulário.
    /// Ele será concatenado com o nome do projeto.
    /// </summary>
    [Browsable( true ), DisplayName( TextosPadroes.TituloJanela ), Description( TextosPadroes.TituloJanelaDescricao ), Category( TextosPadroes.AparenciaCategoria ), DefaultValue( "" )]
    public string FormTitle
    {
        get => _formTitle;

        set
        {
            if ( value.Igual( _formTitle ) )
                return;

            _formTitle = value;
            OnTitleChange();
        }
    }

    /// <summary>
    /// Modo de formulário usado para CRUD.
    /// </summary>
    [Browsable( false ), DisplayName( TextosPadroes.ModoJanela ), Description( TextosPadroes.ModoJanelaDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( ModoJanela.Navegacao )]
    public ModoJanela FormMode
    {
        get => _formMode;
        set => ChangeFormMode( value );
    }

    public Theme Theme
    {
        get => _theme;
        internal set => _theme = value;
    }

    #region Propriedades

    #region Ocultadas

    [Browsable( false )]
    public new string Text
    {
        get { return base.Text; }
        set { base.Text = value; }
    }

    #endregion Ocultadas

    #region Comportamento

    [Browsable( true ), DisplayName( TextosPadroes.FecharJanela ), Description( TextosPadroes.FecharJanelaDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( true )]
    public bool CloseForm
    {
        get
        {
            return _closeView;
        }

        set
        {
            _closeView = value;
        }
    }

    #endregion Comportamento

    #region Validação

    [Browsable( false ), DisplayName( TextosPadroes.Notificacoes ), Description( TextosPadroes.NotificacoesDescricao ), Category( TextosPadroes.ValidacaoCategoria )]
    public NotificacaoColecao Notificacoes { get; set; }

    #endregion Validação

    #endregion Propriedades

    public FormBase()
    {
        InitializeComponent();
        SetGlobalSettings();
    }

    /// <summary>
    /// Acionado ao alterar o modo de janela.
    /// </summary>
    [Browsable( true ), Description( "Evento gerado ao alterar o modo da janela." ), Category( "Comportamento" ), DisplayName( "Ao alterar modo de janela" )]
    public event EventoAoAlterarModoJanela AoAlterarModoJanela { add { _aoAlterarModoJanela += value; } remove { _aoAlterarModoJanela -= value; } }

    [Browsable( true ), Description( TextosPadroes.EventoAoCarregarFormularioDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DisplayName( TextosPadroes.EventoAoCarregarFormulario )]
    public event EventoFormulario AoCarregarFormulario { add { _aoCarregarFormulario += value; } remove { _aoCarregarFormulario -= value; } }

    [Browsable( false )]
    public new event EventHandler Load { add { base.Load += value; } remove { base.Load -= value; } }

    #region Métodos

    private void OnTitleChange()
    {
        Text = $"{ToolBoxEnvironment.AppName}";

        if ( !DesignMode && _formTitle.TemConteudo() )
            Text += $" | {_formTitle}";
    }

    private void OnFormModeChange( object enviador, EventArgs argumento )
    {
        switch ( FormMode )
        {
            case ModoJanela.Inclusao:
                DesbloquearComponentes();
                break;
            case ModoJanela.Alteracao:
                DesbloquearComponentes();
                break;
            case ModoJanela.Navegacao:
            case ModoJanela.Exclusao:
                DisableComponents();
                break;
        }

        _aoAlterarModoJanela?.Invoke();
    }

    private void GetComponents()
    {
        if ( DesignMode )
            return;

        foreach ( object item in components.Components )
        {
            if ( item is IControl )
                _ListaIComponente.Add( item as IControl );
            else if ( item is ICleanUp )
                _listaILimpeza.Add( item as ICleanUp );
        }
    }

    private void SetGlobalSettings()
    {
        Font = ToolBoxEnvironment.GeneralFont;
    }

    protected virtual void AddComponents( IContainer componentes )
    {
        components = componentes;
    }

    protected void ChangeFormMode( ModoJanela valor )
    {
        try
        {
            if ( _formMode == valor )
                return;

            _formMode = valor;
            OnFormModeChange( this, EventArgs.Empty );
        }
        catch ( Exception ex )
        {
            Mensagem.MostrarErro( ex );
        }
    }

    protected virtual void DisableComponents()
    {
        if ( DesignMode )
            return;

        foreach ( IControl componente in _ListaIComponente )
            if ( componente.DisableControl )
                componente.Disabled = true;
    }

    protected virtual void DesbloquearComponentes()
    {
        if ( DesignMode )
            return;

        foreach ( IControl componente in _ListaIComponente )
            if ( componente.DisableControl )
                componente.Disabled = false;
    }

    protected virtual void LimparSujeiraComponentes()
    {
        foreach ( ICleanUp componente in _listaILimpeza )
            if ( componente.RunCleanUp )
                componente.CleanUp();
    }

    protected override void OnLoad( EventArgs e )
    {
        try
        {
            GetComponents();

            if ( FormMode == ModoJanela.Navegacao )
                DisableComponents();

            _aoCarregarFormulario?.Invoke();
        }
        catch ( Exception ex )
        {
            Mensagem.MostrarErro( ex );
        }
    }

    #region Públicos

    #region IFormulario

    public Point GetCenterPoint()
    {
        return new Point( ( Size.Width / 2 ), ( Size.Height / 2 ) );
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
                Mensagem.Informar( mensagem );
                break;

            case TipoNotificacao.Aviso:
                Mensagem.Avisar( mensagem );
                break;

            case TipoNotificacao.Pergunta:
                Mensagem.Perguntar( mensagem );
                break;

            default:
                Mensagem.Avisar( @"Usar método ""MostrarErro"" da classe ""Mensagem"" para mostrar erro no ""catch"" da interface de usuário." );
                break;
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