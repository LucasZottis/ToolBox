using BibliotecaPublica.Classes.Conversores;
using BibliotecaPublica.Enums;
using BibliotecaPublica.Estruturas;
using BibliotecaPublica.Interfaces;
using CaixaFerramenta.Componentes.ToolStripComponentes;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CaixaFerramenta.Componentes.Dados
{
    [
        ComVisible(true),
        ClassInterface(ClassInterfaceType.AutoDispatch),
        DefaultProperty("BindingSource"),
        DefaultEvent("RefreshItems"),
        Designer("System.Windows.Forms.Design.BindingNavigatorDesigner, " + ReferenciaBibliotecaMicrosoft.SystemDesign),
        Description("Navegador de registros."),
        DisplayName("Navegador")
    ]
    public class BindingNavigator : ToolStrip, ISupportInitialize
    {
        #region Delegados

        private EventHandler _aoAtualizarItens = null;

        #endregion Delegados

        #region Constantes

        private const string MENSAGEM_EXCECAO_ITENS_PADROES = "Não é permitido esse tipo de item tool strip.";
        private const string TEXTO_ITEN = "";

        #endregion Constantes

        #region Atributos

        private bool _permitidoAdicionarNovoItem = true;
        private bool _permitidoEditarItem = true;
        private bool _permitidoExcluirItem = true;
        private bool _permitidoGravarAlteracao = true;
        private bool _permitidoCancelarAlteracao = true;
        private bool _permitidoPesquisarItem = true;
        private bool _inicializando = false;

        private DataRowView _linha = null;

        private FonteLigacao _fonteLigacao = null;

        private ToolStripBotao _adicionarNovoItem;
        private ToolStripBotao _editarItem = null;
        private ToolStripBotao _excluirItem;
        private ToolStripBotao _aoPrimeiroItem;
        private ToolStripBotao _itemAnterior;
        private ToolStripBotao _proximoItem;
        private ToolStripBotao _aoUltimoItem;
        private ToolStripBotao _gravar = null;
        private ToolStripBotao _cancelar = null;
        private ToolStripBotao _pesquisarItem = null;

        private ToolStripCaixaNumero _caixaPesquisa = null;

        private IFormulario _formulario = null;

        #endregion Atributos

        #region Propriedades

        #region Dados

        [
            Browsable(true),
            Category("Dados"),
            Description("Fonte de ligação navegado pelo navegador."),
            DisplayName("Fonte de ligação"),
            DefaultValue(null),
            TypeConverter(typeof(ReferenceConverter)),
            SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")
        ]
        public FonteLigacao FonteLigacao
        {
            get
            {
                return _fonteLigacao;
            }

            set
            {
                SetarFonteLigacao(ref _fonteLigacao, value);
            }
        }

        [Browsable(true), Category("Dados"), Description("Formulário que abriga esse navegador de registros."), DisplayName("Formulário")]
        public IFormulario FormularioContainer
        {
            get
            {
                return _formulario;
            }

            set
            {
                _formulario = value;
            }
        }

        #endregion Dados

        #region Botões

        [
            Browsable(true),
            Category("Botões"),
            Description("O ToolStripItem no navegador de registros que gera a ação incluir um novo item."),
            DisplayName("Botão de incluir"),
            TypeConverter(typeof(ReferenceConverter))
        ]
        public ToolStripBotao AdicionarNovoItem
        {
            get
            {
                if (_adicionarNovoItem != null && _adicionarNovoItem.IsDisposed)
                {
                    _adicionarNovoItem = null;
                }

                return _adicionarNovoItem;
            }

            set
            {
                VerificarValorBotoesItemTool(value);

                if (_adicionarNovoItem != null && value != null)
                {
                    value.EnabledChanged += new EventHandler(AoMudarEstadoHabilitadoAdicionarNovoItem);
                    _permitidoAdicionarNovoItem = value.Enabled;
                }

                SetarBotao(ref _adicionarNovoItem, value, new EventHandler(AoAdicionarNovoItem));
            }
        }

        [
            Browsable(true),
            Category("Itens"),
            Description("O ToolStripItem no navegador de registros que gera a ação editar um item existente."),
            DisplayName("Botão de editar"),
            TypeConverter(typeof(ReferenceConverter))
        ]
        public ToolStripBotao EditarItem
        {
            get
            {
                if (_editarItem != null && _editarItem.IsDisposed)
                {
                    _editarItem = null;
                }

                return _editarItem;
            }

            set
            {
                VerificarValorBotoesItemTool(value);

                if (_editarItem != null && value != null)
                {
                    value.EnabledChanged += new EventHandler(AoMudarEstadoHabilitadoEditarItem);
                    _permitidoEditarItem = value.Enabled;
                }

                SetarBotao(ref _editarItem, value, new EventHandler(AoEditarItem));
            }
        }

        [
            Browsable(true),
            Category("Botões"),
            Description("O ToolStripItem no navegador de registros que gera a ação excluir um item."),
            DisplayName("Botão de excluir"),
            TypeConverter(typeof(ReferenceConverter))
        ]
        public ToolStripBotao ExcluirItem
        {
            get
            {
                if (_excluirItem != null && _excluirItem.IsDisposed)
                {
                    _excluirItem = null;
                }

                return _excluirItem;
            }

            set
            {
                VerificarValorBotoesItemTool(value);

                if (_excluirItem != null && value != null)
                {
                    value.EnabledChanged += new EventHandler(AoMudarEstadoHabilitadoDeletarItem);
                    _permitidoExcluirItem = value.Enabled;
                }

                SetarBotao(ref _excluirItem, value, new EventHandler(AoDeletarItem));
            }
        }

        [
             Browsable(true),
             Category("Botões"),
             Description("O ToolStripItem no navegador de registros que gera a ação voltar para o primeiro item existente."),
             DisplayName("Botão para voltar ao primeiro"),
             TypeConverter(typeof(ReferenceConverter))
         ]
        public ToolStripBotao AoPrimeiroItem
        {
            get
            {
                if (_aoPrimeiroItem != null && _aoPrimeiroItem.IsDisposed)
                {
                    _aoPrimeiroItem = null;
                }

                return _aoPrimeiroItem;
            }

            set
            {
                VerificarValorBotoesItemTool(value);

                SetarBotao(ref _aoPrimeiroItem, value, new EventHandler(AoVoltarParaPrimeiroItem));
            }
        }

        [
            Browsable(true),
            Category("Botões"),
            Description("O ToolStripItem no navegador de registros que gera a ação voltar para o item existente."),
            DisplayName("Botão de voltar"),
            TypeConverter(typeof(ReferenceConverter))
        ]
        public ToolStripBotao Anterior
        {
            get
            {
                if (_itemAnterior != null && _itemAnterior.IsDisposed)
                {
                    _itemAnterior = null;
                }

                return _itemAnterior;
            }

            set
            {
                VerificarValorBotoesItemTool(value);

                SetarBotao(ref _itemAnterior, value, new EventHandler(AoVoltar));
            }
        }

        [
            Browsable(true),
            Category("Botões"),
            Description("O ToolStripItem no navegador de registros que gera a ação avançar para o item existente."),
            DisplayName("Botão de avançar"),
            TypeConverter(typeof(ReferenceConverter))
        ]
        public ToolStripBotao Proximo
        {
            get
            {
                if (_proximoItem != null && _proximoItem.IsDisposed)
                {
                    _proximoItem = null;
                }

                return _proximoItem;
            }

            set
            {
                VerificarValorBotoesItemTool(value);

                SetarBotao(ref _proximoItem, value, new EventHandler(AoAvancar));
            }
        }

        [
            Browsable(true),
            Category("Botões"),
            Description("O ToolStripItem no navegador de registros que gera a ação avançar para o último item existente."),
            DisplayName("Botão para avançar ao último"),
            TypeConverter(typeof(ReferenceConverter))
        ]
        public ToolStripBotao AoUltimoItem
        {
            get
            {
                if (_aoUltimoItem != null && _aoUltimoItem.IsDisposed)
                {
                    _aoUltimoItem = null;
                }

                return _aoUltimoItem;
            }

            set
            {
                VerificarValorBotoesItemTool(value);

                SetarBotao(ref _aoUltimoItem, value, new EventHandler(AoAvancarParaUltimoItem));
            }
        }

        [
            Browsable(true),
            Category("Botões"),
            Description("O ToolStripItem no navegador de registros que gera a ação de abrir uma janela de pesquisa itens."),
            DisplayName("Botão de pesquisar"),
            TypeConverter(typeof(ReferenceConverter))
        ]
        public ToolStripBotao PesquisarItem
        {
            get
            {
                if (_pesquisarItem != null && _pesquisarItem.IsDisposed)
                {
                    _pesquisarItem = null;
                }

                return _pesquisarItem;
            }

            set
            {
                VerificarValorBotoesItemTool(value);

                if (_pesquisarItem != null && value != null)
                {
                    value.EnabledChanged += new EventHandler(AoMudarEstadoHabilitadoPesquisarItem);
                    _permitidoPesquisarItem = value.Enabled;
                }

                SetarBotao(ref _pesquisarItem, value, new EventHandler(AoClicarBotaoPesquisar));
            }
        }

        [
            Browsable(true),
            Category("Botões"),
            Description("O ToolStripItem no navegador de registros que gera a ação de gravar um novo item ou um item em edição."),
            DisplayName("Botão de gravar"),
            TypeConverter(typeof(ReferenceConverter))
        ]
        public ToolStripBotao Gravar
        {
            get
            {
                if (_gravar != null && _gravar.IsDisposed)
                {
                    _gravar = null;
                }

                return _gravar;
            }

            set
            {
                VerificarValorBotoesItemTool(value);

                if (_gravar != null && value != null)
                {
                    value.EnabledChanged += new EventHandler(AoMudarEstadoHabilitadoGravar);
                    _permitidoGravarAlteracao = value.Enabled;
                }

                SetarBotao(ref _gravar, value, new EventHandler(AoGravar));
            }
        }

        [
            Browsable(true),
            Category("Botões"),
            Description("O ToolStripItem no navegador de registros que gera a ação de cancelar um novo item ou um item em edição."),
            DisplayName("Botão de cancelar"),
            TypeConverter(typeof(ReferenceConverter))
        ]
        public ToolStripBotao Cancelar
        {
            get
            {
                if (_cancelar != null && _cancelar.IsDisposed)
                {
                    _cancelar = null;
                }

                return _cancelar;
            }

            set
            {
                VerificarValorBotoesItemTool(value);

                if (_cancelar != null && value != null)
                {
                    value.EnabledChanged += new EventHandler(AoMudarEstadoHabilitadoCancelar);
                    _permitidoCancelarAlteracao = value.Enabled;
                }

                SetarBotao(ref _cancelar, value, new EventHandler(AoCancelar));
            }
        }

        #endregion Botões

        #region Caixas de Texto

        [
            Browsable(true),
            Category("Caixas de Textos"),
            Description("O ToolStripItem no navegador de registros que gera a ação editar um item existente."),
            DisplayName("Caixa de pesquisa por código"),
            TypeConverter(typeof(ReferenceConverter))
        ]
        public ToolStripCaixaNumero CaixaPesquisa
        {
            get
            {
                if (_caixaPesquisa != null && _caixaPesquisa.IsDisposed)
                {
                    _caixaPesquisa = null;
                }

                return _caixaPesquisa;
            }

            set
            {
                VerificarValorCaixaTextoItemTool(value);
                SetarCaixaNumero(ref _caixaPesquisa, value, new KeyEventHandler(AoDigitarCaixaPesquisa));
            }
        }


        #endregion Caixas de Texto

        #endregion Propriedades

        #region Construtores

        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindingNavigator() : this(false)
        {
        }

        public BindingNavigator(FonteLigacao fonteLigacao) : this(true)
        {
            FonteLigacao = fonteLigacao;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindingNavigator(IContainer container) : this(false)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            container.Add(this);
        }

        public BindingNavigator(bool adicionarItensPadroes)
        {
            if (adicionarItensPadroes)
            {
                AdicionarItensPadroes();
            }
        }

        #endregion Construtores

        #region Eventos

        [
            Browsable(true),
            Description("Evento gerado ao atualizar os itens."),
            DisplayName("Ao atualizar os itens")
        ]
        public event EventHandler EventoAtualizarItens
        {
            add
            {
                _aoAtualizarItens += value;
            }
            remove
            {
                _aoAtualizarItens -= value;
            }
        }

        #endregion Eventos

        #region Métodos Privados

        #region Métodos de Eventos

        #region Eventos de Estado

        private void AoMudarEstadoHabilitadoAdicionarNovoItem(object enviador, EventArgs argumento)
        {
            if (AdicionarNovoItem != null)
            {
                _permitidoAdicionarNovoItem = _adicionarNovoItem.Enabled;
            }
        }

        private void AoMudarEstadoHabilitadoEditarItem(object enviador, EventArgs argumento)
        {
            if (EditarItem != null)
            {
                _permitidoEditarItem = _editarItem.Enabled;
            }
        }

        private void AoMudarEstadoHabilitadoDeletarItem(object enviador, EventArgs argumento)
        {
            if (ExcluirItem != null)
            {
                _permitidoExcluirItem = ExcluirItem.Enabled;
            }
        }

        private void AoMudarEstadoHabilitadoGravar(object enviador, EventArgs argumento)
        {
            if (_gravar != null)
            {
                _permitidoGravarAlteracao = _gravar.Enabled;
            }
        }

        private void AoMudarEstadoHabilitadoCancelar(object enviador, EventArgs argumento)
        {
            if (_cancelar != null)
            {
                _permitidoCancelarAlteracao = _cancelar.Enabled;
            }
        }

        private void AoMudarEstadoHabilitadoPesquisarItem(object enviador, EventArgs argumento)
        {
            if (_pesquisarItem != null)
            {
                _permitidoPesquisarItem = _pesquisarItem.Enabled;
            }
        }

        #endregion Eventos de Estado

        #region Eventos dos Botões

        private void AoVoltarParaPrimeiroItem(object enviador, EventArgs argumento)
        {
            if (Validar())
            {
                if (_fonteLigacao != null && _fonteLigacao.FonteDados != null)
                {
                    _fonteLigacao.MoveFirst();
                    AtualizarItensInternos();
                }
            }
        }

        private void AoVoltar(object enviador, EventArgs argumento)
        {
            if (Validar())
            {
                if (_fonteLigacao != null && _fonteLigacao.FonteDados != null)
                {
                    _fonteLigacao.MovePrevious();
                    AtualizarItensInternos();
                }
            }
        }

        private void AoAvancar(object enviador, EventArgs argumento)
        {
            if (Validar())
            {
                if (_fonteLigacao != null && _fonteLigacao.FonteDados != null)
                {
                    _fonteLigacao.MoveNext();
                    AtualizarItensInternos();
                }
            }
        }

        private void AoAvancarParaUltimoItem(object enviador, EventArgs argumento)
        {
            if (Validar())
            {
                if (_fonteLigacao != null && _fonteLigacao.FonteDados != null)
                {
                    _fonteLigacao.MoveLast();
                    AtualizarItensInternos();
                }
            }
        }

        private void AoAdicionarNovoItem(object enviador, EventArgs argumento)
        {
            _formulario.ModoJanela = ModoJanela.Inclusao;

            if (Validar())
            {
                if (_fonteLigacao != null && _fonteLigacao.FonteDados != null)
                {
                    _linha = _fonteLigacao.AdicionarNovo();
                    _fonteLigacao.MoveLast();
                    _linha.BeginEdit();

                    AtualizarItensInternos();
                }
            }
        }

        private void AoEditarItem(object enviador, EventArgs argumento)
        {
            _formulario.ModoJanela = ModoJanela.Alteracao;

            if (Validar())
            {
                if (_fonteLigacao != null && _fonteLigacao.FonteDados != null)
                {
                    _fonteLigacao.ItemSelecionado.BeginEdit();

                    AtualizarItensInternos();
                }
            }
        }

        private void AoDeletarItem(object enviador, EventArgs argumento)
        {
            _formulario.ModoJanela = ModoJanela.Exclusao;

            if (Validar())
            {
                if (_fonteLigacao != null && _fonteLigacao.FonteDados != null)
                {
                    _fonteLigacao.RemoverItemSelecionado();
                    AtualizarItensInternos();
                }
            }
        }

        private void AoGravar(object enviador, EventArgs argumento)
        {
            if (Validar())
            {
                if (_fonteLigacao != null && _fonteLigacao.FonteDados != null)
                {
                    _fonteLigacao.ItemSelecionado.EndEdit();
                    _formulario.ModoJanela = ModoJanela.Navegacao;

                    AtualizarItensInternos();
                }
            }
        }

        private void AoCancelar(object enviador, EventArgs argumento)
        {
            if (Validar())
            {
                if (_fonteLigacao != null && _fonteLigacao.FonteDados != null)
                {
                    switch (_formulario.ModoJanela)
                    {
                        case ModoJanela.Inclusao:
                        {
                            _linha.CancelEdit();
                            _linha = null;
                            //_fonteLigacao.Remove(_linha);
                            break;
                        }

                        case ModoJanela.Alteracao:
                        {
                            _fonteLigacao.ItemSelecionado.CancelEdit();
                            break;
                        }
                    }

                    _formulario.ModoJanela = ModoJanela.Navegacao;
                    AtualizarItensInternos();
                }
            }
        }

        private void AoClicarBotaoPesquisar(object enviador, EventArgs argumento)
        {

        }

        #endregion Eventos dos Botões

        #region Eventos das Caixas de Textos

        private void AoDigitarCaixaPesquisa(object enviador, KeyEventArgs argumento)
        {
            bool encontrou = false;

            switch (argumento.KeyCode)
            {
                case Keys.Enter:
                {
                    encontrou = Pesquisar();
                    break;
                }

                case Keys.Escape:
                {
                    CaixaPesquisa.TextBox.Text = "0";
                    break;
                }

                default:
                {
                    encontrou = true;
                    break;
                }
            }

            if (!encontrou)
            {
                Mensagem.Avisar("Item não encontrado");
            }
        }

        #endregion Eventos das Caixas de Textos

        #region Eventos Fonte de Ligação

        private void AoMudarEstadoFonteDados(object enviador, EventArgs argumento)
        {
            AtualizarItensInternos();
        }

        private void AoMudarListaFonteDados(object sender, ListChangedEventArgs e)
        {
            AtualizarItensInternos();
        }

        #endregion Eventos das Caixas de Textos

        #endregion Métodos de Eventos

        #region Setar Propriedades

        private void SetarFonteLigacao(ref FonteLigacao antigaFonteLigacao, FonteLigacao novaFonteLigacao)
        {
            if (antigaFonteLigacao != novaFonteLigacao)
            {
                if (antigaFonteLigacao != null)
                {
                    antigaFonteLigacao.PositionChanged -= new EventHandler(AoMudarEstadoFonteDados);
                    antigaFonteLigacao.CurrentChanged -= new EventHandler(AoMudarEstadoFonteDados);
                    antigaFonteLigacao.CurrentItemChanged -= new EventHandler(AoMudarEstadoFonteDados);
                    antigaFonteLigacao.DataSourceChanged -= new EventHandler(AoMudarEstadoFonteDados);
                    antigaFonteLigacao.DataMemberChanged -= new EventHandler(AoMudarEstadoFonteDados);
                    antigaFonteLigacao.ListChanged -= new ListChangedEventHandler(AoMudarListaFonteDados);
                }

                if (novaFonteLigacao != null)
                {
                    novaFonteLigacao.PositionChanged += new EventHandler(AoMudarEstadoFonteDados);
                    novaFonteLigacao.CurrentChanged += new EventHandler(AoMudarEstadoFonteDados);
                    novaFonteLigacao.CurrentItemChanged += new EventHandler(AoMudarEstadoFonteDados);
                    novaFonteLigacao.DataSourceChanged += new EventHandler(AoMudarEstadoFonteDados);
                    novaFonteLigacao.DataMemberChanged += new EventHandler(AoMudarEstadoFonteDados);
                    novaFonteLigacao.ListChanged += new ListChangedEventHandler(AoMudarListaFonteDados);
                }

                antigaFonteLigacao = novaFonteLigacao;
                AtualizarItens();
            }
        }

        private void SetarBotao(ref ToolStripBotao botaoVelho, ToolStripBotao novoBotao, EventHandler clickHandler)
        {
            if (botaoVelho == novoBotao)
            {
                return;
            }

            if (botaoVelho != null)
            {
                botaoVelho.Click -= clickHandler;
            }

            if (novoBotao != null)
            {
                novoBotao.Click -= clickHandler;
            }

            botaoVelho = novoBotao;
            AtualizarItens();
        }

        private void SetarCaixaNumero(ref ToolStripCaixaNumero caixaNumeroVelha, ToolStripCaixaNumero caixaNumeroNova, KeyEventHandler keyUpHandler)
        {
            if (caixaNumeroVelha != caixaNumeroNova)
            {
                caixaNumeroVelha.KeyUp -= keyUpHandler;
                //caixaNumeroVelha.LostFocus -= lostFocusHandler;

                caixaNumeroNova.KeyUp += keyUpHandler;
                //caixaNumeroNova.LostFocus += lostFocusHandler;

                caixaNumeroVelha = caixaNumeroNova;
                AtualizarItens();
            }
        }

        #endregion Setar Propriedades

        #region Verificadores

        private void VerificarValorBotoesItemTool(ToolStripItem valor)
        {
            if (valor.GetType() != typeof(ToolStripBotao) && valor.GetType() != typeof(ToolStripButton))
            {
                throw new ArgumentException(MENSAGEM_EXCECAO_ITENS_PADROES, valor.Name);
            }
        }

        private void VerificarValorCaixaTextoItemTool(ToolStripItem valor)
        {
            if (valor.GetType() != typeof(ToolStripCaixaNumero))
            {
                throw new ArgumentException(MENSAGEM_EXCECAO_ITENS_PADROES, valor.Name);
            }
        }

        #endregion Verificadores

        private bool Pesquisar()
        {
            int codigo = CaixaPesquisa.TextBox.Text.ParaInt();
            int posicao = _fonteLigacao.Encontrar(codigo);

            if (posicao < 0)
            {
                return false;
            }

            _fonteLigacao.Position = posicao;

            return true;
        }

        private void AoAtualizarItens()
        {
            AtualizarItensInternos();

            if (_aoAtualizarItens != null)
            {
                _aoAtualizarItens(this, EventArgs.Empty);
            }
        }

        private void AtualizarItens()
        {
            if (_inicializando)
            {
                return;
            }

            AoAtualizarItens();
        }

        private void AtualizarItensInternos()
        {
            bool permitirAdicionarNovo;
            bool permitirEditar;
            bool permitirExcluir;
            bool permitirGravar;
            bool permitirCancelar;

            EventHandler habilitado = null;
            EventHandler clicado = null;

            if (_fonteLigacao == null)
            {
                permitirAdicionarNovo = false;
                permitirEditar = false;
                permitirExcluir = false;
                permitirGravar = false;
                permitirCancelar = false;
            }
            else
            {
                permitirAdicionarNovo = (_fonteLigacao as IBindingList).AllowNew;
                permitirEditar = (_fonteLigacao as IBindingList).AllowEdit;
                permitirExcluir = (_fonteLigacao as IBindingList).AllowRemove;
                permitirGravar = ((_fonteLigacao as IBindingList).AllowNew || (_fonteLigacao as IBindingList).AllowEdit);
                permitirCancelar = (permitirGravar && (_fonteLigacao as IBindingList).AllowNew || (_fonteLigacao as IBindingList).AllowEdit);
            }

            if (!DesignMode)
            {
                if (AdicionarNovoItem != null)
                {
                    habilitado = new EventHandler(AoMudarEstadoHabilitadoAdicionarNovoItem);
                    clicado = new EventHandler(AoAdicionarNovoItem);

                    _adicionarNovoItem.Click -= clicado;
                    _adicionarNovoItem.Click += clicado;

                    _adicionarNovoItem.EnabledChanged -= habilitado;
                    _adicionarNovoItem.Enabled = (_permitidoAdicionarNovoItem && permitirAdicionarNovo) && _formulario.ModoJanela == ModoJanela.Navegacao;
                    _adicionarNovoItem.EnabledChanged += habilitado;
                }

                if (EditarItem != null)
                {
                    habilitado = new EventHandler(AoMudarEstadoHabilitadoEditarItem);
                    clicado = new EventHandler(AoEditarItem);

                    _editarItem.Click -= clicado;
                    _editarItem.Click += clicado;

                    _editarItem.EnabledChanged -= habilitado;
                    _editarItem.Enabled = (_permitidoEditarItem && permitirEditar) && _formulario.ModoJanela == ModoJanela.Navegacao;
                    _editarItem.EnabledChanged += habilitado;
                }

                if (ExcluirItem != null)
                {
                    habilitado = new EventHandler(AoMudarEstadoHabilitadoDeletarItem);
                    clicado = new EventHandler(AoDeletarItem);

                    _excluirItem.Click -= clicado;
                    _excluirItem.Click += clicado;

                    _excluirItem.EnabledChanged -= habilitado;
                    _excluirItem.Enabled = (_permitidoExcluirItem && permitirExcluir) && _formulario.ModoJanela == ModoJanela.Navegacao;
                    _excluirItem.EnabledChanged += habilitado;
                }

                if (Gravar != null)
                {
                    habilitado = new EventHandler(AoMudarEstadoHabilitadoGravar);
                    clicado = new EventHandler(AoGravar);

                    _gravar.Click -= clicado;
                    _gravar.Click += clicado;

                    _gravar.EnabledChanged -= habilitado;
                    _gravar.Enabled = (_permitidoGravarAlteracao && permitirGravar) && (_formulario.ModoJanela == ModoJanela.Alteracao || _formulario.ModoJanela == ModoJanela.Inclusao);
                    _gravar.EnabledChanged += habilitado;
                }

                if (Cancelar != null)
                {
                    habilitado = new EventHandler(AoMudarEstadoHabilitadoCancelar);
                    clicado = new EventHandler(AoCancelar);

                    _cancelar.Click -= clicado;
                    _cancelar.Click += clicado;

                    _cancelar.EnabledChanged -= habilitado;
                    _cancelar.Enabled = (_permitidoCancelarAlteracao && permitirCancelar) && (_formulario.ModoJanela == ModoJanela.Alteracao || _formulario.ModoJanela == ModoJanela.Inclusao);
                    _cancelar.EnabledChanged += habilitado;
                }

                if (PesquisarItem != null)
                {
                    habilitado = new EventHandler(AoMudarEstadoHabilitadoPesquisarItem);
                    clicado = new EventHandler(AoClicarBotaoPesquisar);

                    _pesquisarItem.Click -= clicado;
                    _pesquisarItem.Click += clicado;

                    _pesquisarItem.EnabledChanged -= habilitado;
                    _pesquisarItem.Enabled = (_permitidoPesquisarItem && permitirExcluir) && _formulario.ModoJanela == ModoJanela.Navegacao && _fonteLigacao.Count > 1;
                    _pesquisarItem.EnabledChanged += habilitado;
                }

                if (AoPrimeiroItem != null)
                {
                    _aoPrimeiroItem.Enabled = _formulario.ModoJanela == ModoJanela.Navegacao && _aoPrimeiroItem.Enabled && _fonteLigacao.Count > 0;
                }

                if (Anterior != null)
                {
                    _itemAnterior.Enabled = _formulario.ModoJanela == ModoJanela.Navegacao && _itemAnterior.Enabled && _fonteLigacao.Count > 0;
                }

                if (Proximo != null)
                {
                    _proximoItem.Enabled = _formulario.ModoJanela == ModoJanela.Navegacao && _proximoItem.Enabled && _fonteLigacao.Count > 1;
                }

                if (AoUltimoItem != null)
                {
                    _aoUltimoItem.Enabled = _formulario.ModoJanela == ModoJanela.Navegacao && _aoUltimoItem.Enabled && _fonteLigacao.Count > 1;
                }

                if (CaixaPesquisa != null)
                {
                    KeyEventHandler teclaPressionada = new KeyEventHandler(AoDigitarCaixaPesquisa);

                    _caixaPesquisa.KeyUp -= teclaPressionada;
                    _caixaPesquisa.KeyUp += teclaPressionada;

                    _caixaPesquisa.Enabled = _formulario.ModoJanela == ModoJanela.Navegacao && _aoUltimoItem.Enabled && _fonteLigacao.Count > 1;
                }
            }
        }

        private void ComecarInicializacao()
        {
            _inicializando = true;
        }

        private void EncerrarInicializacao()
        {
            _inicializando = false;
            AtualizarItens();
        }

        #endregion Métodos Privados

        #region Métodos Sobreescritos

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                FonteLigacao = null;
            }

            base.Dispose(disposing);
        }

        #endregion Métodos Sobreescritos

        #region Métodos Públicos

        public void BeginInit()
        {
            ComecarInicializacao();
        }

        public void EndInit()
        {
            EncerrarInicializacao();
        }

        public void AdicionarItensPadroes()
        {
            AoPrimeiroItem = new ToolStripBotao();
            Anterior = new ToolStripBotao();
            Proximo = new ToolStripBotao();
            AoUltimoItem = new ToolStripBotao();

            CaixaPesquisa = new ToolStripCaixaNumero();

            PesquisarItem = new ToolStripBotao();

            AdicionarNovoItem = new ToolStripBotao();
            EditarItem = new ToolStripBotao();
            ExcluirItem = new ToolStripBotao();

            Gravar = new ToolStripBotao();
            Cancelar = new ToolStripBotao();

            ToolStripSeparator separator1 = new ToolStripSeparator();
            ToolStripSeparator separator2 = new ToolStripSeparator();
            ToolStripSeparator separator3 = new ToolStripSeparator();
            ToolStripSeparator separator4 = new ToolStripSeparator();

            //
            // Setar nomes
            //
            AoPrimeiroItem.Name = "btnPrimeiroItem";
            Anterior.Name = "btnItemAnterior";
            Proximo.Name = "btnProximoItem";
            AoUltimoItem.Name = "btnUltimoItem";

            CaixaPesquisa.Name = "cxnCodigoPesquisa";

            PesquisarItem.Name = "btnPesquisarItem";
            AdicionarNovoItem.Name = "btnAdicionarItem";
            EditarItem.Name = "btnEditarItem";
            ExcluirItem.Name = "btnDeletarItem";

            Gravar.Name = "btnGravar";
            Cancelar.Name = "btnCancelar";

            separator1.Name = "indingNavigatorSeparator";
            separator2.Name = "indingNavigatorSeparator";
            separator3.Name = "indingNavigatorSeparator";
            separator3.Name = "indingNavigatorSeparator";

            //
            // Setar textos
            //
            AoPrimeiroItem.Text =
            Anterior.Text =
            Proximo.Text =
            AoUltimoItem.Text =
            AdicionarNovoItem.Text =
            EditarItem.Text =
            ExcluirItem.Text =
            PesquisarItem.Text =
            Gravar.Text =
            Cancelar.Text = TEXTO_ITEN;

            CaixaPesquisa.Text = TEXTO_ITEN;

            //
            // Setar dicas
            //
            AoPrimeiroItem.ToolTipText = "Para o primeiro";
            Anterior.ToolTipText = "Para o anterior";
            Proximo.ToolTipText = "Para o próximo";
            AoUltimoItem.ToolTipText = "Para o último";

            AdicionarNovoItem.ToolTipText = "Adicionar novo item";
            EditarItem.ToolTipText = "Editar item existente";
            ExcluirItem.ToolTipText = "Excluir item";
            PesquisarItem.ToolTipText = "Pesquisar item";

            Gravar.ToolTipText = "Gravar alterações";
            Cancelar.ToolTipText = "Cancelar alterações";

            CaixaPesquisa.ToolTipText = "Pesquisar item pelo código";

            //
            // Setar as imagens
            //
            Bitmap moveFirstImage = new Bitmap(typeof(System.Windows.Forms.BindingNavigator), "BindingNavigator.MoveFirst.bmp");
            Bitmap movePreviousImage = new Bitmap(typeof(System.Windows.Forms.BindingNavigator), "BindingNavigator.MovePrevious.bmp");
            Bitmap moveNextImage = new Bitmap(typeof(System.Windows.Forms.BindingNavigator), "BindingNavigator.MoveNext.bmp");
            Bitmap moveLastImage = new Bitmap(typeof(System.Windows.Forms.BindingNavigator), "BindingNavigator.MoveLast.bmp");

            Bitmap addNewImage = Properties.Resources.Novo_24px;
            Bitmap editarItem = Properties.Resources.Editar_24px;
            Bitmap deleteImage = Properties.Resources.Deletar_24px;

            Bitmap pesquisarItem = Properties.Resources.Buscar;

            Bitmap gravar = Properties.Resources.Salvar;
            Bitmap cancelar = Properties.Resources.Cancelar_20x20;

            moveFirstImage.MakeTransparent(Color.Magenta);
            movePreviousImage.MakeTransparent(Color.Magenta);
            moveNextImage.MakeTransparent(Color.Magenta);
            moveLastImage.MakeTransparent(Color.Magenta);

            addNewImage.MakeTransparent(Color.Magenta);
            editarItem.MakeTransparent(Color.Magenta);
            deleteImage.MakeTransparent(Color.Magenta);

            pesquisarItem.MakeTransparent(Color.Magenta);

            gravar.MakeTransparent(Color.Magenta);
            cancelar.MakeTransparent(Color.Magenta);

            AoPrimeiroItem.Image = moveFirstImage;
            Anterior.Image = movePreviousImage;
            Proximo.Image = moveNextImage;
            AoUltimoItem.Image = moveLastImage;

            AdicionarNovoItem.Image = addNewImage;
            EditarItem.Image = editarItem;
            ExcluirItem.Image = deleteImage;

            PesquisarItem.Image = pesquisarItem;

            Gravar.Image = gravar;
            Cancelar.Image = cancelar;

            AoPrimeiroItem.RightToLeftAutoMirrorImage = true;
            Anterior.RightToLeftAutoMirrorImage = true;
            Proximo.RightToLeftAutoMirrorImage = true;
            AoUltimoItem.RightToLeftAutoMirrorImage = true;

            AdicionarNovoItem.RightToLeftAutoMirrorImage = true;
            EditarItem.RightToLeftAutoMirrorImage = true;
            ExcluirItem.RightToLeftAutoMirrorImage = true;

            PesquisarItem.RightToLeftAutoMirrorImage = true;

            Gravar.RightToLeftAutoMirrorImage = true;
            Cancelar.RightToLeftAutoMirrorImage = true;

            AoPrimeiroItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            Anterior.DisplayStyle = ToolStripItemDisplayStyle.Image;
            Proximo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            AoUltimoItem.DisplayStyle = ToolStripItemDisplayStyle.Image;

            AdicionarNovoItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            EditarItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ExcluirItem.DisplayStyle = ToolStripItemDisplayStyle.Image;

            PesquisarItem.DisplayStyle = ToolStripItemDisplayStyle.Image;

            Gravar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            Cancelar.DisplayStyle = ToolStripItemDisplayStyle.Image;

            //
            // Setar outras propriedades
            //
            CaixaPesquisa.AutoSize = false;
            CaixaPesquisa.Width = 50;

            Gravar.Resposta = Resposta.Ok;
            PesquisarItem.Resposta = Resposta.Nenhuma;
            Cancelar.Resposta = Resposta.Cancelar;

            //
            // Adicionar os itens na coleção
            //
            Items.AddRange(new ToolStripItem[] {
                                AdicionarNovoItem,
                                EditarItem,
                                ExcluirItem,
                                separator1,
                                AoPrimeiroItem,
                                Anterior,
                                separator2,
                                CaixaPesquisa,
                                PesquisarItem,
                                separator3,
                                Proximo,
                                AoUltimoItem,
                                separator4,
                                Gravar,
                                Cancelar,
                            });
        }

        public bool Validar()
        {
            bool validatedControlAllowsFocusChange = true;

            return validatedControlAllowsFocusChange;
        }

        #endregion Métodos Públicos
    }
}