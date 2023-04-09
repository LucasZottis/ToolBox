using BibliotecaPublica.Extensoes.Extensoes;

namespace ToolBox.UserControls;

public delegate void AfterSearchPath( string caminho );

[ToolboxItem( true )]
public partial class SearchPath
    : UserControlBase, ICleanUp
{
    private AfterSearchPath? _onAfterSearch;
    private bool _useIcon = true;

    [Browsable( true ), DisplayName( TextosPadroes.TituloJanela ), Description( TextosPadroes.TituloJanelaDescricao ), Category( TextosPadroes.AparenciaCategoria ), DefaultValue( "" )]
    public string Title
    {
        get => cgpCaminho.Text;
        set => cgpCaminho.Text = value;
    }

    [Browsable( false ), DisplayName( "Caminho" ), Description( "Define ou obtém o caminho de uma pasta ou arquivo." ), Category( TextosPadroes.DadosCateogria ), DefaultValue( "" )]
    public string SelectedPath
    {
        get => txtPath.Text;
        set => txtPath.Text = value;
    }

    [Browsable( true ), DisplayName( "Usar Ícone" ), Description( "Define ou obtém se deve mostrar o ícone no botão buscar ao invés de texto." ), Category( TextosPadroes.AparenciaCategoria ), DefaultValue( true )]
    public bool UseIcon
    {
        get => _useIcon;

        set
        {
            _useIcon = value;
            OnUseIconChange();
        }
    }

    [Browsable( true ), DisplayName( "Buscar por pastas" ), Description( "Define ou obtém se deve executar a busca por pastas ou por arquivos." ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
    public bool SearchFolder { get; set; }

    [Browsable( true ), DisplayName( TextosPadroes.FazerLimpeza ), Description( TextosPadroes.FazerLimpezaDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( true )]
    public bool RunCleanUp { get; set; } = true;

    [Browsable( true ), DisplayName( "Extensões de arquivo" ), Description( "Define ou obtém as extensões que serão buscadas." ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( "" )]
    public string Extensions { get; set; } = string.Empty;

    [Browsable( true ), DisplayName( TextosPadroes.TextoAjuda ), Description( TextosPadroes.TextoAjudaDescricao ), Category( TextosPadroes.DadosCateogria ), DefaultValue( "" )]
    public string PlaceHolder
    {
        get => txtPath.PlaceholderText;
        set => txtPath.PlaceholderText = value;
    }

    [Browsable( true ), DisplayName( "Após buscar caminho" ), Description( "Evento que ocorre após selecionar um caminho." ), Category( TextosPadroes.DadosCateogria )]
    public event AfterSearchPath OnAfterSearchPath
    {
        add => _onAfterSearch += value;
        remove => _onAfterSearch -= value;
    }

    [Browsable( false ), DisplayName( "Diretório inicial" ), Description( "Define ou obtém a pasta que deve mostrar ao abrir o diálogo." ), Category( TextosPadroes.DadosCateogria ), DefaultValue( "" )]
    public string InitialDirectory { get; set; } = string.Empty;

    public new Color ForeColor
    {
        set
        {
            cgpCaminho.ForeColor = value;
            btfSearch.ForeColor = value;
            btfSearch.FlatAppearance.BorderColor = value;
        }
    }

    public SearchPath()
    {
        InitializeComponent();
    }

    private void OnUseIconChange()
    {
        if ( _useIcon )
            SetToUseIcon();
        else
            SetToUseText();
    }

    private void SetToUseIcon()
    {
        btfSearch.Text = "";
        btfSearch.Image = Properties.Resources.icons8_pasta_24;
    }

    private void SetToUseText()
    {
        btfSearch.Text = "Buscar";
        btfSearch.Image = null;
    }

    private void SearchFilePath()
    {
        using var browser = new OpenFileDialog()
        {
            Filter = Extensions,
            InitialDirectory = this.InitialDirectory,
            Multiselect = false,
            RestoreDirectory = false,
        };

        if ( browser.ShowDialog() == DialogResult.OK )
            SelectedPath = browser.FileName;
    }

    private void SearchFolderPath()
    {
        using var browser = new FolderBrowserDialog()
        {
            InitialDirectory = this.InitialDirectory,
            ShowNewFolderButton = true,
            ShowHiddenFiles = true,
        };

        if ( browser.ShowDialog() == DialogResult.OK )
            SelectedPath = browser.SelectedPath;
    }

    private void OnClick( object sender, EventArgs e )
    {
        try
        {
            if ( SearchFolder )
                SearchFolderPath();
            else
                SearchFilePath();

            if ( SelectedPath.TemConteudo() )
                _onAfterSearch?.Invoke( SelectedPath );
        }
        catch ( Exception ex )
        {
            Mensagem.MostrarErro( ex );
        }
    }

    public void CleanUp()
    {
        try
        {
            txtPath.CleanUp();
        }
        catch ( Exception ex )
        {
            Mensagem.MostrarErro( ex );
        }
    }

    public bool PathExists()
        => SelectedPath.TemConteudo() && System.IO.Path.Exists( SelectedPath );
}