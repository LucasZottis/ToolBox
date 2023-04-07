using BibliotecaPublica.Core.Structs;
using BibliotecaPublica.Extensoes.Extensoes;
using System.ComponentModel;
using ToolBox.Geral.Interfaces;

namespace ToolBox.Controles;

public delegate void AposBuscarCaminho( string caminho );

[ToolboxItem( true )]
public partial class BuscarCaminho
    : ControleUsuarioBase
    , ILimpeza
{
    private AposBuscarCaminho? _aposBuscarCaminho;
    private bool _usoIcone = true;

    [Browsable( true ), DisplayName( TextosPadroes.TituloJanela ), Description( TextosPadroes.TituloJanelaDescricao ), Category( TextosPadroes.AparenciaCategoria ), DefaultValue( "" )]
    public string Titulo
    {
        get => cgpCaminho.Text;
        set => cgpCaminho.Text = value;
    }

    [Browsable( false ), DisplayName( "Caminho" ), Description( "Define ou obtém o caminho de uma pasta ou arquivo." ), Category( TextosPadroes.DadosCateogria ), DefaultValue( "" )]
    public string Caminho
    {
        get => cxtCaminho.Text;
        set => cxtCaminho.Text = value;
    }

    [Browsable( true ), DisplayName( "Usar Ícone" ), Description( "Define ou obtém se deve mostrar o ícone no botão buscar ao invés de texto." ), Category( TextosPadroes.AparenciaCategoria ), DefaultValue( true )]
    public bool UsoIcone
    {
        get => _usoIcone;

        set
        {
            _usoIcone = value;
            AoAlterarUsoIcone();
        }
    }

    [Browsable( true ), DisplayName( "Buscar por pastas" ), Description( "Define ou obtém se deve executar a busca por pastas ou por arquivos." ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
    public bool BuscarPasta { get; set; }

    [Browsable( true ), DisplayName( TextosPadroes.FazerLimpeza ), Description( TextosPadroes.FazerLimpezaDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( true )]
    public bool FazerLimpeza { get; set; }
        = true;

    [Browsable( true ), DisplayName( "Extensões de arquivo" ), Description( "Define ou obtém as extensões que serão buscadas." ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( "" )]
    public string Extensoes { get; set; }
        = string.Empty;

    [Browsable( true ), DisplayName( TextosPadroes.TextoAjuda ), Description( TextosPadroes.TextoAjudaDescricao ), Category( TextosPadroes.DadosCateogria ), DefaultValue( "" )]
    public string TextoAjuda
    {
        get => cxtCaminho.PlaceholderText;
        set => cxtCaminho.PlaceholderText = value;
    }

    [Browsable( true ), DisplayName( "Após buscar caminho" ), Description( "Evento que ocorre após selecionar um caminho." ), Category( TextosPadroes.DadosCateogria )]
    public event AposBuscarCaminho AposBuscarCaminho
    {
        add => _aposBuscarCaminho += value;
        remove => _aposBuscarCaminho -= value;
    }

    public new Color ForeColor
    {
        set
        {
            cgpCaminho.ForeColor = value;
            btfBuscar.ForeColor = value;
            btfBuscar.FlatAppearance.BorderColor = value;
        }
    }

    public BuscarCaminho()
    {
        InitializeComponent();
    }

    private void AoAlterarUsoIcone()
    {
        if ( _usoIcone )
            UsarIcone();
        else
            UsarTexto();
    }

    private void UsarIcone()
    {
        btfBuscar.Text = "";
        btfBuscar.Image = Properties.Resources.icons8_pasta_24;
    }

    private void UsarTexto()
    {
        btfBuscar.Text = "Buscar";
        btfBuscar.Image = null;
    }

    private void LocalizarArquivo()
    {
        using var localizador = new OpenFileDialog() { Filter = Extensoes };

        if ( localizador.ShowDialog() == DialogResult.OK )
            Caminho = localizador.FileName;
    }

    private void LocalizarPasta()
    {
        using var localizador = new FolderBrowserDialog();

        if ( localizador.ShowDialog() == DialogResult.OK )
            Caminho = localizador.SelectedPath;
    }

    private void Buscar( object sender, EventArgs e )
    {
        if ( BuscarPasta )
            LocalizarPasta();
        else
            LocalizarArquivo();

        if ( Caminho.TemConteudo() )
            _aposBuscarCaminho?.Invoke( Caminho );
    }

    public void Limpar()
    {
        cxtCaminho.Clear();
    }
}