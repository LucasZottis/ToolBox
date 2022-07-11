//using BibliotecaPublica.Interfaces;
//using CaixaFerramenta.Componentes.CaixaTexto;
//using CaixaFerramenta.Componentes.ToolStripComponentes;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Diagnostics;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace CaixaFerramenta.Componentes.Dados
//{
//    public partial class Controlador : Component
//    {
//        #region Delegados

//        private EventHandler _aoAtualizarItens = null;

//        #endregion Delegados

//        #region Eventos

//        [
//            Browsable(true),
//            Description("Evento gerado ao atualizar os itens."),
//            DisplayName("Ao atualizar os itens")
//        ]
//        public event EventHandler EventoAtualizarItens
//        {
//            add
//            {
//                _aoAtualizarItens += value;
//            }
//            remove
//            {
//                _aoAtualizarItens -= value;
//            }
//        }

//        #endregion Eventos

//        #region Constantes

//        private const string MENSAGEM_EXCECAO_ITENS_PADROES = "Não é permitido esse tipo de item tool strip.";
//        private const string TEXTO_ITEN = "";

//        #endregion Constantes

//        #region Atributos

//        private bool _permitidoAdicionarNovoItem = true;
//        private bool _permitidoEditarItem = true;
//        private bool _permitidoExcluirItem = true;
//        private bool _permitidoGravarAlteracao = true;
//        private bool _permitidoCancelarAlteracao = true;
//        private bool _permitidoPesquisarItem = true;
//        private bool _inicializando = false;

//        #region Botões

//        private IBotao _adicionarNovoItem = null;
//        private IBotao _editarItem = null;
//        private IBotao _excluirItem = null;
//        private IBotao _pesquisaCompletaItem = null;
//        private IBotao _gravarAlteracoes = null;
//        private IBotao _cancelarAlteracoes = null;
//        private IBotao _moverPrimeiro = null;
//        private IBotao _moverAnterior = null;
//        private IBotao _moverProximo = null;
//        private IBotao _moverUltimo = null;

//        #endregion Botões

//        #region Caixas de Texto

//        private CaixaNumero _pesquisarPorCodigo = null;

//        #endregion Caixas de Texto

//        private NavegadorRegistros _navegador = null;

//        private DataGridView _grade = null;

//        private DataRowView _linha = null;

//        private FonteLigacao _fonteLigacao = null;

//        private IFormulario _formulario = null;

//        #endregion Atributos

//        #region Propriedades

//        #region Dados

//        [
//            Browsable(true),
//            Category("Dados"),
//            Description("Fonte de ligação navegado pelo navegador."),
//            DisplayName("Fonte de ligação"),
//            DefaultValue(null),
//            TypeConverter(typeof(ReferenceConverter)),
//            SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")
//        ]
//        public FonteLigacao FonteLigacao
//        {
//            get
//            {
//                return _fonteLigacao;
//            }

//            set
//            {
//                SetarFonteLigacao(ref _fonteLigacao, value);
//            }
//        }

//        [Browsable(true), Category("Dados"), Description("Formulário que abriga esse navegador de registros."), DisplayName("Formulário")]
//        public IFormulario FormularioContainer
//        {
//            get
//            {
//                return _formulario;
//            }

//            set
//            {
//                _formulario = value;
//            }
//        }

//        [Browsable(true), Category("Dados"), Description("Grade de dados que será controlada."), DisplayName("Grade de dados")]
//        public DataGridView GradeDados
//        {
//            get
//            {
//                return _grade;
//            }

//            set
//            {
//                if (value != null && _navegador != null)
//                {
//                    _navegador = null;
//                }

//                _grade = value;
//            }
//        }

//        [Browsable(true), Category("Dados"), Description("Navegador de registros que será controlado."), DisplayName("Navegador")]
//        public NavegadorRegistros NavegadorRegistros
//        {
//            get
//            {
//                return _navegador;
//            }

//            set
//            {
//                if (value != null)
//                {
//                    if (_grade != null)
//                    {
//                        _grade = null;
//                    }

//                    DesvincularBotoes();
//                    VincularItensNavegador(value);
//                }

//                _navegador = value;
//            }
//        }

//        #endregion Dados

//        #region Botões

//        [
//            Browsable(true),
//            Category("Botões"),
//            Description("O ToolStripItem no navegador de registros que gera a ação incluir um novo item."),
//            DisplayName("Botão de incluir"),
//            TypeConverter(typeof(ReferenceConverter))
//        ]
//        public IBotao AdicionarNovoItem
//        {
//            get
//            {
//                if (_adicionarNovoItem != null && _adicionarNovoItem.IsDisposed)
//                {
//                    _adicionarNovoItem = null;
//                }

//                return _adicionarNovoItem;
//            }

//            set
//            {
//                VerificarValorBotoesItemTool(value);

//                if (_adicionarNovoItem != null && value != null)
//                {
//                    value.EnabledChanged += new EventHandler(AoMudarEstadoHabilitadoAdicionarNovoItem);
//                    _permitidoAdicionarNovoItem = value.Enabled;
//                }

//                SetarBotao(ref _adicionarNovoItem, value, new EventHandler(AoAdicionarNovoItem));
//            }
//        }

//        [
//            Browsable(true),
//            Category("Itens"),
//            Description("O ToolStripItem no navegador de registros que gera a ação editar um item existente."),
//            DisplayName("Botão de editar"),
//            TypeConverter(typeof(ReferenceConverter))
//        ]
//        public IBotao EditarItem
//        {
//            get
//            {
//                if (_editarItem != null && _editarItem.IsDisposed)
//                {
//                    _editarItem = null;
//                }

//                return _editarItem;
//            }

//            set
//            {
//                VerificarValorBotoesItemTool(value);

//                if (_editarItem != null && value != null)
//                {
//                    value.EnabledChanged += new EventHandler(AoMudarEstadoHabilitadoEditarItem);
//                    _permitidoEditarItem = value.Enabled;
//                }

//                SetarBotao(ref _editarItem, value, new EventHandler(AoEditarItem));
//            }
//        }

//        [
//            Browsable(true),
//            Category("Botões"),
//            Description("O ToolStripItem no navegador de registros que gera a ação excluir um item."),
//            DisplayName("Botão de excluir"),
//            TypeConverter(typeof(ReferenceConverter))
//        ]
//        public IBotao ExcluirItem
//        {
//            get
//            {
//                if (_excluirItem != null && _excluirItem.IsDisposed)
//                {
//                    _excluirItem = null;
//                }

//                return _excluirItem;
//            }

//            set
//            {
//                VerificarValorBotoesItemTool(value);

//                if (_excluirItem != null && value != null)
//                {
//                    value.EnabledChanged += new EventHandler(AoMudarEstadoHabilitadoDeletarItem);
//                    _permitidoExcluirItem = value.Enabled;
//                }

//                SetarBotao(ref _excluirItem, value, new EventHandler(AoDeletarItem));
//            }
//        }

//        [
//             Browsable(true),
//             Category("Botões"),
//             Description("O ToolStripItem no navegador de registros que gera a ação voltar para o primeiro item existente."),
//             DisplayName("Botão para voltar ao primeiro"),
//             TypeConverter(typeof(ReferenceConverter))
//         ]
//        public IBotao AoPrimeiroItem
//        {
//            get
//            {
//                if (_moverPrimeiro != null && _moverPrimeiro.IsDisposed)
//                {
//                    _moverPrimeiro = null;
//                }

//                return _moverPrimeiro;
//            }

//            set
//            {
//                VerificarValorBotoesItemTool(value);

//                SetarBotao(ref _moverPrimeiro, value, new EventHandler(AoVoltarParaPrimeiroItem));
//            }
//        }

//        [
//            Browsable(true),
//            Category("Botões"),
//            Description("O ToolStripItem no navegador de registros que gera a ação voltar para o item existente."),
//            DisplayName("Botão de voltar"),
//            TypeConverter(typeof(ReferenceConverter))
//        ]
//        public IBotao Anterior
//        {
//            get
//            {
//                if (_itemAnterior != null && _itemAnterior.IsDisposed)
//                {
//                    _itemAnterior = null;
//                }

//                return _itemAnterior;
//            }

//            set
//            {
//                VerificarValorBotoesItemTool(value);

//                SetarBotao(ref _itemAnterior, value, new EventHandler(AoVoltar));
//            }
//        }

//        [
//            Browsable(true),
//            Category("Botões"),
//            Description("O ToolStripItem no navegador de registros que gera a ação avançar para o item existente."),
//            DisplayName("Botão de avançar"),
//            TypeConverter(typeof(ReferenceConverter))
//        ]
//        public IBotao Proximo
//        {
//            get
//            {
//                if (_proximoItem != null && _proximoItem.IsDisposed)
//                {
//                    _proximoItem = null;
//                }

//                return _proximoItem;
//            }

//            set
//            {
//                VerificarValorBotoesItemTool(value);

//                SetarBotao(ref _proximoItem, value, new EventHandler(AoAvancar));
//            }
//        }

//        [
//            Browsable(true),
//            Category("Botões"),
//            Description("O ToolStripItem no navegador de registros que gera a ação avançar para o último item existente."),
//            DisplayName("Botão para avançar ao último"),
//            TypeConverter(typeof(ReferenceConverter))
//        ]
//        public IBotao AoUltimoItem
//        {
//            get
//            {
//                if (_aoUltimoItem != null && _aoUltimoItem.IsDisposed)
//                {
//                    _aoUltimoItem = null;
//                }

//                return _aoUltimoItem;
//            }

//            set
//            {
//                VerificarValorBotoesItemTool(value);

//                SetarBotao(ref _aoUltimoItem, value, new EventHandler(AoAvancarParaUltimoItem));
//            }
//        }

//        [
//            Browsable(true),
//            Category("Botões"),
//            Description("O ToolStripItem no navegador de registros que gera a ação de abrir uma janela de pesquisa itens."),
//            DisplayName("Botão de pesquisar"),
//            TypeConverter(typeof(ReferenceConverter))
//        ]
//        public IBotao PesquisarItem
//        {
//            get
//            {
//                if (_pesquisarItem != null && _pesquisarItem.IsDisposed)
//                {
//                    _pesquisarItem = null;
//                }

//                return _pesquisarItem;
//            }

//            set
//            {
//                VerificarValorBotoesItemTool(value);

//                if (_pesquisarItem != null && value != null)
//                {
//                    value.EnabledChanged += new EventHandler(AoMudarEstadoHabilitadoPesquisarItem);
//                    _permitidoPesquisarItem = value.Enabled;
//                }

//                SetarBotao(ref _pesquisarItem, value, new EventHandler(AoClicarBotaoPesquisar));
//            }
//        }

//        [
//            Browsable(true),
//            Category("Botões"),
//            Description("O ToolStripItem no navegador de registros que gera a ação de gravar um novo item ou um item em edição."),
//            DisplayName("Botão de gravar"),
//            TypeConverter(typeof(ReferenceConverter))
//        ]
//        public IBotao Gravar
//        {
//            get
//            {
//                if (_gravar != null && _gravar.IsDisposed)
//                {
//                    _gravar = null;
//                }

//                return _gravar;
//            }

//            set
//            {
//                VerificarValorBotoesItemTool(value);

//                if (_gravar != null && value != null)
//                {
//                    value.EnabledChanged += new EventHandler(AoMudarEstadoHabilitadoGravar);
//                    _permitidoGravarAlteracao = value.Enabled;
//                }

//                SetarBotao(ref _gravar, value, new EventHandler(AoGravar));
//            }
//        }

//        [
//            Browsable(true),
//            Category("Botões"),
//            Description("O ToolStripItem no navegador de registros que gera a ação de cancelar um novo item ou um item em edição."),
//            DisplayName("Botão de cancelar"),
//            TypeConverter(typeof(ReferenceConverter))
//        ]
//        public IBotao Cancelar
//        {
//            get
//            {
//                if (_cancelar != null && _cancelar.IsDisposed)
//                {
//                    _cancelar = null;
//                }

//                return _cancelar;
//            }

//            set
//            {
//                VerificarValorBotoesItemTool(value);

//                if (_cancelar != null && value != null)
//                {
//                    value.EnabledChanged += new EventHandler(AoMudarEstadoHabilitadoCancelar);
//                    _permitidoCancelarAlteracao = value.Enabled;
//                }

//                SetarBotao(ref _cancelar, value, new EventHandler(AoCancelar));
//            }
//        }

//        #endregion Botões

//        #region Caixas de Texto

//        [
//            Browsable(true),
//            Category("Caixas de Textos"),
//            Description("O ToolStripItem no navegador de registros que gera a ação editar um item existente."),
//            DisplayName("Caixa de pesquisa por código"),
//            TypeConverter(typeof(ReferenceConverter))
//        ]
//        public ToolStripCaixaNumero CaixaPesquisa
//        {
//            get
//            {
//                if (_caixaPesquisa != null && _caixaPesquisa.IsDisposed)
//                {
//                    _caixaPesquisa = null;
//                }

//                return _caixaPesquisa;
//            }

//            set
//            {
//                VerificarValorCaixaTextoItemTool(value);
//                SetarCaixaNumero(ref _caixaPesquisa, value, new KeyEventHandler(AoDigitarCaixaPesquisa));
//            }
//        }

//        #endregion Caixas de Texto

//        #endregion Propriedades

//        #region Construtores

//        public Controlador()
//        {
//            InitializeComponent();
//        }

//        public Controlador(IContainer container)
//        {
//            container.Add(this);

//            InitializeComponent();
//        }

//        #endregion Construtores

//        #region Métodos Privados

//        #region Métodos de Eventos

//        private void AoMudarEstadoFonteDados(object enviador, EventArgs argumento)
//        {
//            //AtualizarItensInternos();
//        }

//        private void AoMudarListaFonteDados(object sender, ListChangedEventArgs e)
//        {
//            //AtualizarItensInternos();
//        }

//        #endregion Métodos de Eventos

//        private void SetarFonteLigacao(ref FonteLigacao antigaFonteLigacao, FonteLigacao novaFonteLigacao)
//        {
//            if (antigaFonteLigacao != novaFonteLigacao)
//            {
//                if (antigaFonteLigacao != null)
//                {
//                    antigaFonteLigacao.PositionChanged -= new EventHandler(AoMudarEstadoFonteDados);
//                    antigaFonteLigacao.CurrentChanged -= new EventHandler(AoMudarEstadoFonteDados);
//                    antigaFonteLigacao.CurrentItemChanged -= new EventHandler(AoMudarEstadoFonteDados);
//                    antigaFonteLigacao.DataSourceChanged -= new EventHandler(AoMudarEstadoFonteDados);
//                    antigaFonteLigacao.DataMemberChanged -= new EventHandler(AoMudarEstadoFonteDados);
//                    antigaFonteLigacao.ListChanged -= new ListChangedEventHandler(AoMudarListaFonteDados);
//                }

//                if (novaFonteLigacao != null)
//                {
//                    novaFonteLigacao.PositionChanged += new EventHandler(AoMudarEstadoFonteDados);
//                    novaFonteLigacao.CurrentChanged += new EventHandler(AoMudarEstadoFonteDados);
//                    novaFonteLigacao.CurrentItemChanged += new EventHandler(AoMudarEstadoFonteDados);
//                    novaFonteLigacao.DataSourceChanged += new EventHandler(AoMudarEstadoFonteDados);
//                    novaFonteLigacao.DataMemberChanged += new EventHandler(AoMudarEstadoFonteDados);
//                    novaFonteLigacao.ListChanged += new ListChangedEventHandler(AoMudarListaFonteDados);
//                }

//                antigaFonteLigacao = novaFonteLigacao;
//            }
//        }

//        private void DesvincularBotoes()
//        {
//            _adicionarNovoItem = null;
//            _editarItem = null;
//            _excluirItem = null;
//            _pesquisaCompletaItem = null;
//            _gravarAlteracoes = null;
//            _cancelarAlteracoes = null;
//            _moverPrimeiro = null;
//            _moverAnterior = null;
//            _moverProximo = null;
//            _moverUltimo = null;
//        }

//        private void VincularItensNavegador(NavegadorRegistros navegador)
//        {
//            foreach (ToolStripItem item in navegador.Items)
//            {
//                switch (item.Name)
//                {
//                    case "btnPrimeiroItem":
//                    {
//                        _moverPrimeiro = (IBotao) item;
//                        break;
//                    }

//                    case "btnItemAnterior":
//                    {
//                        _moverAnterior = (IBotao) item;
//                        break;
//                    }

//                    case "btnProximoItem":
//                    {
//                        _moverProximo = (IBotao) item;
//                        break;
//                    }

//                    case "btnUltimoItem":
//                    {
//                        _moverUltimo = (IBotao) item;
//                        break;
//                    }

//                    case "btnPesquisarItem":
//                    {
//                        _pesquisaCompletaItem = (IBotao) item;
//                        break;
//                    }

//                    case "btnAdicionarItem":
//                    {
//                        _adicionarNovoItem = (IBotao) item;
//                        break;
//                    }

//                    case "btnEditarItem":
//                    {
//                        _editarItem = (IBotao) item;
//                        break;
//                    }

//                    case "btnDeletarItem":
//                    {
//                        _excluirItem = (IBotao) item;
//                        break;
//                    }

//                    case "btnGravar":
//                    {
//                        _gravarAlteracoes = (IBotao) item;
//                        break;
//                    }

//                    case "btnCancelar":
//                    {
//                        _cancelarAlteracoes = (IBotao) item;
//                        break;
//                    }

//                    case "cxnCodigoPesquisa":
//                    {
//                        _pesquisarPorCodigo = ((ToolStripCaixaNumero) item).TextBox;
//                        break;
//                    }
//                }
//            }
//        }

//        #endregion Métodos Privados
//    }
//}
