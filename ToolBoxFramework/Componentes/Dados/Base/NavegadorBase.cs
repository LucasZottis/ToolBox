using BibliotecaPublica;
using BibliotecaPublica.Classes.Servicos.Conversores;
using BibliotecaPublica.Classes.Verificadores;
using BibliotecaPublica.Enums;
using BibliotecaPublica.Estruturas;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ToolBox.ToolBoxFramework.Componentes.ToolStripComponentes;
using ToolBox.ToolBoxFramework.Interfaces;
using ToolBox.ToolBoxFramework.Properties;

namespace ToolBox.ToolBoxFramework.Componentes.Dados.Base
{
    [DesignerCategory( "Dados" ), ToolboxItem( false )]
    public class NavegadorBase : BindingNavigator, ISupportInitialize
    {
        #region Constantes

        private const string MENSAGEM_EXCECAO_ITENS_PADROES = "Não é permitido esse tipo de item tool strip.";
        private const string TEXTO_ITEN = "";

        #endregion Constantes

        #region Delegados

        private EventoCrudNavegador _aoGravar;
        private EventoCrudNavegador _aoCancelar;
        private EventoCrudNavegador _aoIncluirItem;
        private EventoCrudNavegador _aoEditarItem;
        private EventoExcluirItemNavegador _aoDeletarItem;
        private EventoValidacao _aoValidar;

        #endregion Delegados

        #region Atributos

        private bool _permitidoAdicionarNovoItem = true;
        private bool _permitidoEditarItem = true;
        private bool _permitidoGravarAlteracao = true;
        private bool _permitidoCancelarAlteracao = true;
        private bool _permitidoPesquisarItem = true;

        private DataRowView _linha = null;
        private BindingSourceBase _fonte = null;

        private ToolStripBotao _inclurNovoItem;
        private ToolStripBotao _editarItem;
        private ToolStripBotao _excluirItem;
        private ToolStripBotao _moverParaPrimeiroItem;
        private ToolStripBotao _moverParaItemAnterior;
        private ToolStripBotao _moverParaProximoItem;
        private ToolStripBotao _moverParaUltimoItem;
        private ToolStripBotao _gravar;
        private ToolStripBotao _cancelar;
        private ToolStripBotao _pesquisarItem;

        private ToolStripCaixaNumero _caixaPesquisa;

        private IFormulario _formularioInterface;

        #endregion Atributos

        #region Propriedades

        #region Públicas

        #region Ocultados

        #region Itens

        [Browsable( false )]
        public new ToolStripItem AddNewItem
        {
            get
            {
                return null;
            }

            set
            {

            }
        }

        [Browsable( false )]
        public new ToolStripItem DeleteItem
        {
            get
            {
                return null;
            }

            set
            {

            }
        }

        [Browsable( false )]
        public new ToolStripItem MoveFirstItem
        {
            get
            {
                return null;
            }

            set
            {

            }
        }

        [Browsable( false )]
        public new ToolStripItem MovePreviousItem
        {
            get
            {
                return null;
            }

            set
            {

            }
        }

        [Browsable( false )]
        public new ToolStripItem MoveNextItem
        {
            get
            {
                return null;
            }

            set
            {

            }
        }

        [Browsable( false )]
        public new ToolStripItem MoveLastItem
        {
            get
            {
                return null;
            }

            set
            {

            }
        }

        [Browsable( false )]
        public new ToolStripItem PositionItem
        {
            get
            {
                return null;
            }

            set
            {

            }
        }

        [Browsable( false )]
        public new ToolStripItem CountItem
        {
            get
            {
                return null;
            }

            set
            {

            }
        }

        #endregion Itens

        #region Dados

        [Browsable( false )]
        public new BindingSource BindingSource
        {
            get
            {
                return null;
            }

            set
            {

            }
        }

        #endregion Dados

        #endregion Ocultados

        #region Botões

        [
            Browsable( true ),
            Category( TextosPadroes.BotoesCategoria ),
            Description( "O ToolStripItem no navegador de registros que gera a ação incluir um novo item." ),
            DisplayName( "Botão de incluir" ),
            TypeConverter( typeof( ReferenceConverter ) )
        ]
        public ToolStripBotao IncluirNovoItem
        {
            get
            {
                if ( _inclurNovoItem != null && _inclurNovoItem.IsDisposed )
                {
                    _inclurNovoItem = null;
                }

                return _inclurNovoItem;
            }

            set
            {
                VerificarValorBotoesItemTool( value );

                if ( _inclurNovoItem != null && value != null )
                {
                    value.EnabledChanged += new EventHandler( AoMudarEstadoHabilitadoAdicionarNovoItem );
                    _permitidoAdicionarNovoItem = value.Enabled;
                }

                SetarBotao( ref _inclurNovoItem, value, new EventHandler( AoClicarIncluirItem ) );
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.BotoesCategoria ),
            Description( "O ToolStripItem no navegador de registros que gera a ação editar um item existente." ),
            DisplayName( "Botão de editar" ),
            TypeConverter( typeof( ReferenceConverter ) )
        ]
        public ToolStripBotao EditarItem
        {
            get
            {
                if ( _editarItem != null && _editarItem.IsDisposed )
                {
                    _editarItem = null;
                }

                return _editarItem;
            }

            set
            {
                VerificarValorBotoesItemTool( value );

                if ( _editarItem != null && value != null )
                {
                    value.EnabledChanged += new EventHandler( AoMudarEstadoHabilitadoEditarItem );
                    _permitidoEditarItem = value.Enabled;
                }

                SetarBotao( ref _editarItem, value, new EventHandler( AoClicarEditarItem ) );
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.BotoesCategoria ),
            Description( "O ToolStripItem no navegador de registros que gera a ação excluir um item." ),
            DisplayName( "Botão de excluir" ),
            TypeConverter( typeof( ReferenceConverter ) )
        ]
        public ToolStripBotao ExcluirItem
        {
            get
            {
                if ( _excluirItem != null && _excluirItem.IsDisposed )
                {
                    _excluirItem = null;
                }

                return _excluirItem;
            }

            set
            {
                VerificarValorBotoesItemTool( value );

                if ( _excluirItem != null && value != null )
                {
                    value.EnabledChanged += new EventHandler( AoMudarEstadoHabilitadoDeletarItem );
                }

                SetarBotao( ref _excluirItem, value, new EventHandler( AoClicarDeletarItem ) );
            }
        }

        [
             Browsable( true ),
            Category( TextosPadroes.BotoesCategoria ),
             Description( "O ToolStripItem no navegador de registros que gera a ação voltar para o primeiro item existente." ),
             DisplayName( "Botão para voltar ao primeiro" ),
             TypeConverter( typeof( ReferenceConverter ) )
         ]
        public ToolStripBotao MoverParaPrimeiroItem
        {
            get
            {
                if ( _moverParaPrimeiroItem != null && _moverParaPrimeiroItem.IsDisposed )
                {
                    _moverParaPrimeiroItem = null;
                }

                return _moverParaPrimeiroItem;
            }

            set
            {
                VerificarValorBotoesItemTool( value );

                if ( _excluirItem != null && value != null )
                {
                    value.EnabledChanged += new EventHandler( AoMudarEstadoHabilitadoDeletarItem );
                }

                SetarBotao( ref _moverParaPrimeiroItem, value, new EventHandler( AoVoltarParaPrimeiroItem ) );
            }
        }
        [
            Browsable( true ),
            Category( TextosPadroes.BotoesCategoria ),
            Description( "O ToolStripItem no navegador de registros que gera a ação voltar para o item existente." ),
            DisplayName( "Botão de voltar" ),
            TypeConverter( typeof( ReferenceConverter ) )
        ]
        public ToolStripBotao MoverParaItemAnterior
        {
            get
            {
                if ( _moverParaItemAnterior != null && _moverParaItemAnterior.IsDisposed )
                {
                    _moverParaItemAnterior = null;
                }

                return _moverParaItemAnterior;
            }

            set
            {
                VerificarValorBotoesItemTool( value );

                SetarBotao( ref _moverParaItemAnterior, value, new EventHandler( AoVoltar ) );
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.BotoesCategoria ),
            Description( "O ToolStripItem no navegador de registros que gera a ação avançar para o item existente." ),
            DisplayName( "Botão de avançar" ),
            TypeConverter( typeof( ReferenceConverter ) )
        ]
        public ToolStripBotao MoverParaProximoItem
        {
            get
            {
                if ( _moverParaProximoItem != null && _moverParaProximoItem.IsDisposed )
                {
                    _moverParaProximoItem = null;
                }

                return _moverParaProximoItem;
            }

            set
            {
                VerificarValorBotoesItemTool( value );

                SetarBotao( ref _moverParaProximoItem, value, new EventHandler( AoAvancar ) );
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.BotoesCategoria ),
            Description( "O ToolStripItem no navegador de registros que gera a ação avançar para o último item existente." ),
            DisplayName( "Botão para avançar ao último" ),
            TypeConverter( typeof( ReferenceConverter ) )
        ]
        public ToolStripBotao MoverParaUltimoItem
        {
            get
            {
                if ( _moverParaUltimoItem != null && _moverParaUltimoItem.IsDisposed )
                {
                    _moverParaUltimoItem = null;
                }

                return _moverParaUltimoItem;
            }

            set
            {
                VerificarValorBotoesItemTool( value );

                SetarBotao( ref _moverParaUltimoItem, value, new EventHandler( AoAvancarParaUltimoItem ) );
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.BotoesCategoria ),
            Description( "O ToolStripItem no navegador de registros que gera a ação de abrir uma janela de pesquisa itens." ),
            DisplayName( "Botão de pesquisar" ),
            TypeConverter( typeof( ReferenceConverter ) )
        ]
        public ToolStripBotao PesquisarItem
        {
            get
            {
                if ( _pesquisarItem != null && _pesquisarItem.IsDisposed )
                {
                    _pesquisarItem = null;
                }

                return _pesquisarItem;
            }

            set
            {
                VerificarValorBotoesItemTool( value );

                if ( _pesquisarItem != null && value != null )
                {
                    value.EnabledChanged += new EventHandler( AoMudarEstadoHabilitadoPesquisarItem );
                    _permitidoPesquisarItem = value.Enabled;
                }

                SetarBotao( ref _pesquisarItem, value, new EventHandler( AoClicarBotaoPesquisar ) );
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.BotoesCategoria ),
            Description( "O ToolStripItem no navegador de registros que gera a ação de gravar um novo item ou um item em edição." ),
            DisplayName( "Botão de gravar" ),
            TypeConverter( typeof( ReferenceConverter ) )
        ]
        public ToolStripBotao Gravar
        {
            get
            {
                if ( _gravar != null && _gravar.IsDisposed )
                {
                    _gravar = null;
                }

                return _gravar;
            }

            set
            {
                VerificarValorBotoesItemTool( value );

                if ( _gravar != null && value != null )
                {
                    value.EnabledChanged += new EventHandler( AoMudarEstadoHabilitadoGravar );
                    _permitidoGravarAlteracao = value.Enabled;
                }

                SetarBotao( ref _gravar, value, new EventHandler( AoClicarGravar ) );
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.BotoesCategoria ),
            Description( "O ToolStripItem no navegador de registros que gera a ação de cancelar um novo item ou um item em edição." ),
            DisplayName( "Botão de cancelar" ),
            TypeConverter( typeof( ReferenceConverter ) )
        ]
        public ToolStripBotao Cancelar
        {
            get
            {
                if ( _cancelar != null && _cancelar.IsDisposed )
                {
                    _cancelar = null;
                }

                return _cancelar;
            }

            set
            {
                VerificarValorBotoesItemTool( value );

                if ( _cancelar != null && value != null )
                {
                    value.EnabledChanged += new EventHandler( AoMudarEstadoHabilitadoCancelar );
                    _permitidoCancelarAlteracao = value.Enabled;
                }

                SetarBotao( ref _cancelar, value, new EventHandler( AoClicarCancelar ) );
            }
        }

        #endregion Botões

        #region Caixas de Texto

        [
            Browsable( true ),
            Category( TextosPadroes.CaixaTextoCategoria ),
            DisplayName( "Caixa de pesquisa por código" ),
            Description( "O ToolStripItem no navegador de registros que gera a ação editar um item existente." ),
            TypeConverter( typeof( ReferenceConverter ) )
        ]
        public ToolStripCaixaNumero CaixaPesquisa
        {
            get
            {
                if ( _caixaPesquisa != null && _caixaPesquisa.IsDisposed )
                {
                    _caixaPesquisa = null;
                }

                return _caixaPesquisa;
            }

            set
            {
                VerificarValorCaixaTextoItemTool( value );
                SetarCaixaNumero( ref _caixaPesquisa, value, new KeyEventHandler( AoDigitarCaixaPesquisa ), new EventHandler( AoPerderFoco ) );
            }
        }

        #endregion Caixas de Texto

        #region Dados

        [Browsable( true ), Category( "Dados" ), Description( "Fonte de ligação navegado pelo navegador." ), DisplayName( "Fonte de dados" )]
        public BindingSourceBase FonteDados
        {
            get
            {
                return _fonte;
            }

            set
            {
                _fonte = value;
                SetarFonteLigacao( ref _fonte, value );
            }
        }

        #endregion Dados

        /// <summary>
        /// Método que define ou obtém de deve executar a função AoGravar quando clicar para excluir um item.
        /// </summary>
        [
            Browsable( true ),
            Category( TextosPadroes.ComportamentoCategoria ),
            Description( @"Define ou obtém se o evento ""AoGravar"" é acionado quando clicar para excluir um item." ),
            DisplayName( "Executar o gravar ao excluir" ),
            DefaultValue( false )
        ]
        public bool ExecutarGravarAoExcluir
        {
            get; set;
        }

        #endregion Públicas

        #region Protegidas

        protected bool Inicializando { get; set; } = false;

        protected bool Pesquisando { get; set; } = false;

        #endregion Protegidas

        #endregion Propriedades

        #region Construtores

        [EditorBrowsable( EditorBrowsableState.Never )]
        public NavegadorBase() : this( false )
        {

        }

        public NavegadorBase( BindingSourceBase fontaDados ) : this( true )
        {
            FonteDados = fontaDados;
        }

        [EditorBrowsable( EditorBrowsableState.Never )]
        public NavegadorBase( IContainer container ) : this( false )
        {
            if ( container == null )
            {
                throw new ArgumentNullException( "container" );
            }

            container.Add( this );
        }

        public NavegadorBase( bool adicionarItensPadroes )
        {
            if ( adicionarItensPadroes )
            {
                AddStandardItems();
            }
        }

        #endregion Construtores

        #region Eventos

        [
            Browsable( true ),
            Category( TextosPadroes.DadosCateogria ),
            Description( "Evento gerado ao clicar no botão gravar." )
        ]
        public event EventoCrudNavegador AoGravar
        {
            add
            {
                _aoGravar += value;
            }

            remove
            {
                _aoGravar -= value;
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.DadosCateogria ),
            Description( "Evento gerado ao clicar no botão gravar." )
        ]
        public event EventoCrudNavegador AoCancelar
        {
            add
            {
                _aoCancelar += value;
            }

            remove
            {
                _aoCancelar -= value;
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.DadosCateogria ),
            Description( "Evento gerado ao clicar no botão gravar." )
        ]
        public event EventoCrudNavegador AoIncluir
        {
            add
            {
                _aoIncluirItem += value;
            }

            remove
            {
                _aoIncluirItem -= value;
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.DadosCateogria ),
            Description( "Evento gerado ao clicar no botão gravar." )
        ]
        public event EventoCrudNavegador AoEditar
        {
            add
            {
                _aoEditarItem += value;
            }

            remove
            {
                _aoEditarItem -= value;
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.DadosCateogria ),
            Description( "Evento gerado ao clicar no botão gravar." )
        ]
        public event EventoExcluirItemNavegador AoExcluir
        {
            add
            {
                _aoDeletarItem += value;
            }

            remove
            {
                _aoDeletarItem -= value;
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.DadosCateogria ),
            Description( "Evento gerado ao fazer a validação antes de gravar." )
        ]
        public event EventoValidacao AoValidar
        {
            add
            {
                _aoValidar += value;
            }

            remove
            {
                _aoValidar -= value;
            }
        }

        #endregion Eventos

        #region Métodos

        #region Privados

        #region Eventos de Estado

        private void AoMudarEstadoHabilitadoAdicionarNovoItem( object enviador, EventArgs argumento )
        {
            if ( IncluirNovoItem != null )
            {
                _permitidoAdicionarNovoItem = IncluirNovoItem.Enabled;
            }
        }

        private void AoMudarEstadoHabilitadoEditarItem( object enviador, EventArgs argumento )
        {
            if ( EditarItem != null )
            {
                _permitidoEditarItem = _editarItem.Enabled;
            }
        }

        private void AoMudarEstadoHabilitadoDeletarItem( object enviador, EventArgs argumento )
        {

        }

        private void AoMudarEstadoHabilitadoGravar( object enviador, EventArgs argumento )
        {
            if ( _gravar != null )
            {
                _permitidoGravarAlteracao = _gravar.Enabled;
            }
        }

        private void AoMudarEstadoHabilitadoCancelar( object enviador, EventArgs argumento )
        {
            if ( _cancelar != null )
            {
                _permitidoCancelarAlteracao = _cancelar.Enabled;
            }
        }

        private void AoMudarEstadoHabilitadoPesquisarItem( object enviador, EventArgs argumento )
        {
            if ( _pesquisarItem != null )
            {
                _permitidoPesquisarItem = _pesquisarItem.Enabled;
            }
        }

        #endregion Eventos de Estado

        #region Eventos dos Botões

        private void AoVoltarParaPrimeiroItem( object enviador, EventArgs argumento )
        {
            if ( Validate() )
            {
                if ( _fonte != null && _fonte.DataSource != null )
                {
                    _fonte.MoveFirst();
                    RefreshItemsCore();
                }
            }
        }

        private void AoVoltar( object enviador, EventArgs argumento )
        {
            if ( Validate() )
            {
                if ( _fonte != null && _fonte.DataSource != null )
                {
                    _fonte.MovePrevious();
                    RefreshItemsCore();
                }
            }
        }

        private void AoAvancar( object enviador, EventArgs argumento )
        {
            if ( Validate() )
            {
                if ( _fonte != null && _fonte.DataSource != null )
                {
                    _fonte.MoveNext();
                    RefreshItemsCore();
                }
            }
        }

        private void AoAvancarParaUltimoItem( object enviador, EventArgs argumento )
        {
            if ( Validate() )
            {
                if ( _fonte != null && _fonte.DataSource != null )
                {
                    _fonte.MoveLast();
                    RefreshItemsCore();
                }
            }
        }

        private void AoClicarIncluirItem( object enviador, EventArgs argumento )
        {
            if ( _fonte == null && _fonte.DataSource == null )
            {
                return;
            }

            if ( !Validate() )
            {
                return;
            }

            if ( _aoIncluirItem != null )
            {
                _aoIncluirItem();
            }
            else
            {
                _fonte.AdicionarNovo();
            }

            _fonte.MoveLast();

            _linha = _fonte.ItemSelecionado;
            _linha?.BeginEdit();

            _formularioInterface.ModoJanela = ModoJanela.Inclusao;
            RefreshItemsCore();
        }

        private void AoClicarEditarItem( object enviador, EventArgs argumento )
        {
            _formularioInterface.ModoJanela = ModoJanela.Alteracao;

            if ( _fonte == null && _fonte.DataSource == null )
            {
                return;
            }

            if ( !_fonte.TemRegistro )
            {
                Mensagem.Avisar( "Não há registros para ser alterado." );
                return;
            }

            if ( !Validate() )
            {
                return;
            }

            _linha = _fonte.ItemSelecionado;
            _linha.BeginEdit();

            RefreshItemsCore();

            if ( _aoEditarItem != null )
            {
                _aoEditarItem();
            }
        }

        private void AoClicarDeletarItem( object enviador, EventArgs argumento )
        {
            _formularioInterface.ModoJanela = ModoJanela.Exclusao;

            if ( _fonte == null && _fonte.DataSource == null )
            {
                return;
            }

            if ( !_fonte.TemRegistro )
            {
                Mensagem.Avisar( "Não há registros." );
                return;
            }

            if ( _fonte.ItemSelecionado == null )
            {
                Mensagem.Avisar( "Nenhum item selecionado." );
                return;
            }

            if ( !Validate() )
            {
                return;
            }

            DialogResult resposta = Mensagem.Perguntar( "Deseja excluir esse item?" );

            if ( resposta == DialogResult.No || resposta == DialogResult.Cancel )
            {
                _formularioInterface.ModoJanela = ModoJanela.Navegacao;
                return;
            }

            if ( _aoDeletarItem != null )
            {
                try
                {
                    _aoDeletarItem( _fonte.ItemSelecionado[ _fonte.NomeValorChave ].ParaInt() );
                }
                catch ( ArgumentNullException ex )
                {
                    throw new ArgumentNullException( "Nome do valor chave da fonte de dados.", ex );
                }
            }

            if ( ExecutarGravarAoExcluir && _aoGravar != null )
            {
                _aoGravar();
            }

            _formularioInterface.ModoJanela = ModoJanela.Navegacao;

            RefreshItemsCore();
        }

        private void AoClicarGravar( object enviador, EventArgs argumento )
        {
            bool gravar = true;

            try
            {
                if ( _fonte == null && _fonte.DataSource == null )
                {
                    return;
                }

                if ( !Validate() )
                {
                    _fonte.ItemSelecionado.CancelEdit();
                    return;
                }

                if ( _linha != null )
                {
                    _linha.EndEdit();
                }
                else
                {
                    _fonte.ItemSelecionado.EndEdit();
                }

                if ( _aoValidar != null && !_aoValidar() )
                {
                    gravar = false;
                    _linha.BeginEdit();
                    return;
                }

                if ( gravar )
                {
                    if ( _aoGravar != null )
                    {
                        _aoGravar();
                    }

                    _linha = null;
                }

                _formularioInterface.ModoJanela = ModoJanela.Navegacao;
                RefreshItemsCore();
            }
            catch ( DataException ex )
            {
                Mensagem.MostrarErro( ex );
            }
            catch ( Exception ex )
            {
                Mensagem.MostrarErro( ex );
            }
        }

        private void AoClicarCancelar( object enviador, EventArgs argumento )
        {
            if ( _fonte == null && _fonte.DataSource == null )
            {
                return;
            }

            if ( !Validate() )
            {
                return;
            }

            CancelarAcao();

            _formularioInterface.ModoJanela = ModoJanela.Navegacao;
            RefreshItemsCore();

            if ( _aoCancelar != null )
            {
                _aoCancelar();
            }
        }

        private void AoClicarBotaoPesquisar( object enviador, EventArgs argumento )
        {

        }

        #endregion Eventos dos Botões

        #region Eventos das Caixas de Textos

        private void AoDigitarCaixaPesquisa( object enviador, KeyEventArgs argumento )
        {
            bool encontrou = true;

            switch ( argumento.KeyCode )
            {
                case Keys.Enter:
                {
                    Pesquisando = true;
                    encontrou = Pesquisar();

                    break;
                }

                case Keys.Escape:
                {
                    AposPesquisar( true );

                    break;
                }

                default:
                {
                    encontrou = true;
                    AposPesquisar( false );

                    break;
                }
            }

            if ( !encontrou )
            {
                Mensagem.Avisar( "Item não encontrado" );
            }
        }

        private void AoPerderFoco( object enviador, EventArgs argumento )
        {
            bool encontrou = true;

            if ( _caixaPesquisa.TemTexto() )
            {
                Pesquisando = true;
                encontrou = Pesquisar();
            }

            if ( !encontrou )
            {
                Mensagem.Avisar( "Item não encontrado" );
            }
        }

        #endregion Eventos das Caixas de Textos

        #region Setar Propriedades

        private void SetarFonteLigacao( ref BindingSourceBase antigaFonteLigacao, BindingSourceBase novaFonteLigacao )
        {
            if ( antigaFonteLigacao != novaFonteLigacao )
            {
                if ( antigaFonteLigacao != null )
                {
                    antigaFonteLigacao.PositionChanged -= new EventHandler( AoMudarEstadoFonteDados );
                    antigaFonteLigacao.CurrentChanged -= new EventHandler( AoMudarEstadoFonteDados );
                    antigaFonteLigacao.CurrentItemChanged -= new EventHandler( AoMudarEstadoFonteDados );
                    antigaFonteLigacao.DataSourceChanged -= new EventHandler( AoMudarEstadoFonteDados );
                    antigaFonteLigacao.DataMemberChanged -= new EventHandler( AoMudarEstadoFonteDados );
                    antigaFonteLigacao.ListChanged -= new ListChangedEventHandler( AoMudarListaFonteDados );
                }

                if ( novaFonteLigacao != null )
                {
                    novaFonteLigacao.PositionChanged += new EventHandler( AoMudarEstadoFonteDados );
                    novaFonteLigacao.CurrentChanged += new EventHandler( AoMudarEstadoFonteDados );
                    novaFonteLigacao.CurrentItemChanged += new EventHandler( AoMudarEstadoFonteDados );
                    novaFonteLigacao.DataSourceChanged += new EventHandler( AoMudarEstadoFonteDados );
                    novaFonteLigacao.DataMemberChanged += new EventHandler( AoMudarEstadoFonteDados );
                    novaFonteLigacao.ListChanged += new ListChangedEventHandler( AoMudarListaFonteDados );
                }

                antigaFonteLigacao = novaFonteLigacao;
                AtualizarItens();
            }
        }

        private void SetarBotao( ref ToolStripBotao botaoVelho, ToolStripBotao novoBotao, EventHandler clickHandler )
        {
            if ( botaoVelho == novoBotao )
            {
                return;
            }

            if ( botaoVelho != null )
            {
                botaoVelho.Click -= clickHandler;
            }

            if ( novoBotao != null )
            {
                novoBotao.Click -= clickHandler;
            }

            botaoVelho = novoBotao;
            AtualizarItens();
        }

        private void SetarCaixaNumero( ref ToolStripCaixaNumero caixaNumeroVelha, ToolStripCaixaNumero caixaNumeroNova, KeyEventHandler aoSoltarTeclaEvento, EventHandler aoPerderFocoEvento )
        {
            if ( caixaNumeroVelha != caixaNumeroNova )
            {
                if ( caixaNumeroVelha != null )
                {
                    caixaNumeroVelha.KeyUp -= aoSoltarTeclaEvento;
                    caixaNumeroVelha.LostFocus -= aoPerderFocoEvento;
                }

                caixaNumeroNova.KeyUp += aoSoltarTeclaEvento;
                caixaNumeroNova.LostFocus += aoPerderFocoEvento;
            }

            caixaNumeroVelha = caixaNumeroNova;
            AtualizarItens();
        }

        #endregion Setar Propriedades

        #region Eventos Fonte de Ligação

        private void AoMudarEstadoFonteDados( object enviador, EventArgs argumento )
        {
            RefreshItemsCore();
        }

        private void AoMudarListaFonteDados( object sender, ListChangedEventArgs e )
        {
            RefreshItemsCore();
        }

        #endregion Eventos Fonte de Ligação

        #region Verificadores

        private void VerificarValorBotoesItemTool( ToolStripItem valor )
        {
            if ( valor.GetType() != typeof( ToolStripBotao ) && valor.GetType() != typeof( ToolStripButton ) )
            {
                throw new ArgumentException( MENSAGEM_EXCECAO_ITENS_PADROES, valor.Name );
            }
        }

        private void VerificarValorCaixaTextoItemTool( ToolStripItem valor )
        {
            if ( valor.GetType() != typeof( ToolStripCaixaNumero ) )
            {
                throw new ArgumentException( MENSAGEM_EXCECAO_ITENS_PADROES, valor.Name );
            }
        }

        #endregion Verificadores

        private void CancelarAcao()
        {
            switch ( _formularioInterface.ModoJanela )
            {
                case ModoJanela.Inclusao:
                {
                    CancelarAdicao();
                    break;
                }

                case ModoJanela.Alteracao:
                {
                    CancelarEdicao();
                    break;
                }
            }
        }

        private void CancelarAdicao()
        {
            if ( _linha != null )
            {
                if ( _linha.Row.RowState == DataRowState.Detached )
                {
                    _linha.CancelEdit();
                }
                else
                {
                    _linha.Row.RejectChanges();
                }

                _linha.CancelEdit();
                _linha = null;

                return;
            }
        }

        private void CancelarEdicao()
        {
            if ( _linha.Row.RowState == DataRowState.Detached )
            {
                _linha.CancelEdit();
            }
            else
            {
                _linha.Row.RejectChanges();
            }

            _linha.CancelEdit();
            _linha = null;
        }

        private void ExecutarAtalhos( Keys tecla )
        {
            switch ( tecla )
            {
                case Keys.F3:
                {
                    if ( _caixaPesquisa.Focused )
                    {
                        _pesquisarItem.ExecutarCliqueBotao();
                        break;
                    }

                    _caixaPesquisa.Focus();
                    break;
                }
                case Keys.F8:
                {
                    _inclurNovoItem.ExecutarCliqueBotao();
                    break;
                }

                case Keys.F9:
                {
                    _editarItem.ExecutarCliqueBotao();
                    break;
                }

                case Keys.F10:
                {
                    _excluirItem.ExecutarCliqueBotao();
                    break;
                }
            }
        }

        private bool Pesquisar()
        {
            int codigo = 0;
            int posicao = -1;

            if ( Pesquisando && !( Disposing || IsDisposed ) )
            {
                if ( CaixaPesquisa != null )
                {
                    codigo = CaixaPesquisa.TextBox.Text.ParaInt();
                }

                if ( _fonte != null && codigo.Diferente( 0 ) )
                {
                    posicao = _fonte.Encontrar( codigo );
                }

                if ( posicao < 0 )
                {
                    AposPesquisar( true );
                    return false;
                }
            }

            _fonte.Position = posicao;
            AposPesquisar( true );

            return true;
        }

        private void AposPesquisar( bool apagarCampo )
        {
            if ( apagarCampo )
            {
                CaixaPesquisa.TextBox.Clear();
                Pesquisando = false;
            }
        }

        #endregion Privados

        #region Protegidos

        protected virtual void ComecarInicializacao()
        {
            Inicializando = true;
        }

        protected virtual void EncerrarInicializacao()
        {
            Inicializando = false;
        }

        protected override void RefreshItemsCore()
        {
            if ( _formularioInterface == null )
            {
                _formularioInterface = TopLevelControl as IFormulario;
            }

            bool permitirIncluirNovoItem = false;
            bool permitirEditar = false;
            bool permitirExcluir = false;
            bool permitirGravar = false;
            bool permitirCancelar = false;
            bool permitirPesquisar = false;
            bool permitirNavegar = false;

            EventHandler habilitado = null;
            EventHandler clicado = null;

            PositionItem = null;
            CountItem = null;
            CountItemFormat = null;

            if ( !DesignMode )
            {
                if ( _fonte == null )
                {
                    permitirIncluirNovoItem = false;
                    permitirEditar = false;
                    permitirExcluir = false;
                    permitirGravar = false;
                    permitirCancelar = false;
                    permitirPesquisar = false;
                    permitirNavegar = false;
                }
                else
                {
                    permitirIncluirNovoItem = ( _fonte as IBindingList ).AllowNew;
                    permitirEditar = ( _fonte as IBindingList ).AllowEdit;
                    permitirExcluir = ( _fonte as IBindingList ).AllowRemove;
                    permitirGravar = ( ( _fonte as IBindingList ).AllowNew || ( _fonte as IBindingList ).AllowEdit );
                    permitirCancelar = ( permitirGravar && ( _fonte as IBindingList ).AllowNew || ( _fonte as IBindingList ).AllowEdit );
                    permitirPesquisar = _formularioInterface.ModoJanela == ModoJanela.Navegacao && _fonte.Count > 1;
                    permitirNavegar = _formularioInterface.ModoJanela == ModoJanela.Navegacao && _fonte.Count > 1;
                }
            }

            if ( !DesignMode )
            {
                if ( IncluirNovoItem != null )
                {
                    habilitado = new EventHandler( AoMudarEstadoHabilitadoAdicionarNovoItem );
                    clicado = new EventHandler( AoClicarIncluirItem );

                    _inclurNovoItem.Click -= clicado;
                    _inclurNovoItem.Click += clicado;

                    _inclurNovoItem.EnabledChanged -= habilitado;
                    _inclurNovoItem.Enabled = ( _permitidoAdicionarNovoItem && permitirIncluirNovoItem ) && _formularioInterface.ModoJanela == ModoJanela.Navegacao;
                    _inclurNovoItem.EnabledChanged += habilitado;
                }

                if ( EditarItem != null )
                {
                    habilitado = new EventHandler( AoMudarEstadoHabilitadoEditarItem );
                    clicado = new EventHandler( AoClicarEditarItem );

                    _editarItem.Click -= clicado;
                    _editarItem.Click += clicado;

                    _editarItem.EnabledChanged -= habilitado;
                    _editarItem.Enabled = ( _permitidoEditarItem && permitirEditar ) && _formularioInterface.ModoJanela == ModoJanela.Navegacao;
                    _editarItem.EnabledChanged += habilitado;
                }

                if ( ExcluirItem != null )
                {
                    habilitado = new EventHandler( AoMudarEstadoHabilitadoDeletarItem );
                    clicado = new EventHandler( AoClicarDeletarItem );

                    _excluirItem.Click -= clicado;
                    _excluirItem.Click += clicado;

                    _excluirItem.EnabledChanged -= habilitado;
                    _excluirItem.Enabled = permitirExcluir && _formularioInterface.ModoJanela == ModoJanela.Navegacao;
                    _excluirItem.EnabledChanged += habilitado;
                }

                if ( Gravar != null )
                {
                    habilitado = new EventHandler( AoMudarEstadoHabilitadoGravar );
                    clicado = new EventHandler( AoClicarGravar );

                    _gravar.Click -= clicado;
                    _gravar.Click += clicado;

                    _gravar.EnabledChanged -= habilitado;
                    _gravar.Enabled = ( _permitidoGravarAlteracao && permitirGravar ) && ( _formularioInterface.ModoJanela == ModoJanela.Alteracao || _formularioInterface.ModoJanela == ModoJanela.Inclusao );
                    _gravar.EnabledChanged += habilitado;
                }

                if ( Cancelar != null )
                {
                    habilitado = new EventHandler( AoMudarEstadoHabilitadoCancelar );
                    clicado = new EventHandler( AoClicarCancelar );

                    _cancelar.Click -= clicado;
                    _cancelar.Click += clicado;

                    _cancelar.EnabledChanged -= habilitado;
                    _cancelar.Enabled = ( _permitidoCancelarAlteracao && permitirCancelar ) && ( _formularioInterface.ModoJanela == ModoJanela.Alteracao || _formularioInterface.ModoJanela == ModoJanela.Inclusao );
                    _cancelar.EnabledChanged += habilitado;
                }

                if ( PesquisarItem != null )
                {
                    habilitado = new EventHandler( AoMudarEstadoHabilitadoPesquisarItem );
                    clicado = new EventHandler( AoClicarBotaoPesquisar );

                    _pesquisarItem.Click -= clicado;
                    _pesquisarItem.Click += clicado;

                    _pesquisarItem.EnabledChanged -= habilitado;
                    _pesquisarItem.Enabled = ( _permitidoPesquisarItem && permitirPesquisar ) && _formularioInterface.ModoJanela == ModoJanela.Navegacao;
                    _pesquisarItem.EnabledChanged += habilitado;
                }

                if ( MoverParaPrimeiroItem != null )
                {
                    clicado = new EventHandler( AoVoltarParaPrimeiroItem );

                    _moverParaPrimeiroItem.Click -= clicado;
                    _moverParaPrimeiroItem.Click += clicado;

                    _moverParaPrimeiroItem.Enabled = permitirNavegar;
                }

                if ( MoverParaItemAnterior != null )
                {
                    clicado = new EventHandler( AoVoltar );

                    _moverParaItemAnterior.Click -= clicado;
                    _moverParaItemAnterior.Click += clicado;

                    _moverParaItemAnterior.Enabled = permitirNavegar;
                }

                if ( MoverParaProximoItem != null )
                {
                    clicado = new EventHandler( AoAvancar );

                    _moverParaProximoItem.Click -= clicado;
                    _moverParaProximoItem.Click += clicado;

                    _moverParaProximoItem.Enabled = permitirNavegar;
                }

                if ( MoverParaUltimoItem != null )
                {
                    clicado = new EventHandler( AoAvancarParaUltimoItem );

                    _moverParaUltimoItem.Click -= clicado;
                    _moverParaUltimoItem.Click += clicado;

                    _moverParaUltimoItem.Enabled = permitirNavegar;
                }

                if ( CaixaPesquisa != null )
                {
                    KeyEventHandler teclaPressionada = new KeyEventHandler( AoDigitarCaixaPesquisa );

                    _caixaPesquisa.KeyUp -= teclaPressionada;
                    _caixaPesquisa.KeyUp += teclaPressionada;

                    _caixaPesquisa.Enabled = permitirPesquisar;
                }
            }
        }

        protected override void OnKeyDown( KeyEventArgs e )
        {
            base.OnKeyDown( e );
            ExecutarAtalhos( e.KeyData );
        }

        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                _fonte = null;
            }

            base.Dispose( disposing );
        }

        #endregion Protegidos

        #region Internos



        #endregion Internos

        #region Públicos

        public new void BeginInit()
        {
            ComecarInicializacao();
        }

        public new void EndInit()
        {
            EncerrarInicializacao();
        }

        public void AtualizarItens()
        {
            if ( Inicializando )
            {
                return;
            }

            OnRefreshItems();
        }

        public override void AddStandardItems()
        {
            MoverParaPrimeiroItem = new ToolStripBotao();
            MoverParaItemAnterior = new ToolStripBotao();
            MoverParaProximoItem = new ToolStripBotao();
            MoverParaUltimoItem = new ToolStripBotao();

            CaixaPesquisa = new ToolStripCaixaNumero();

            PesquisarItem = new ToolStripBotao();

            IncluirNovoItem = new ToolStripBotao();
            EditarItem = new ToolStripBotao();
            ExcluirItem = new ToolStripBotao();

            Gravar = new ToolStripBotao();
            Cancelar = new ToolStripBotao();

            ToolStripSeparator separador1 = new ToolStripSeparator();
            ToolStripSeparator separador2 = new ToolStripSeparator();
            ToolStripSeparator separador3 = new ToolStripSeparator();
            ToolStripSeparator separador4 = new ToolStripSeparator();

            //
            // Setar nomes
            //
            MoverParaPrimeiroItem.Name = "btnPrimeiroItem";
            MoverParaItemAnterior.Name = "btnItemAnterior";
            MoverParaProximoItem.Name = "btnProximoItem";
            MoverParaUltimoItem.Name = "btnUltimoItem";

            CaixaPesquisa.Name = "cxnPesquisaPorCodigo";

            PesquisarItem.Name = "btnPesquisaCompleta";
            IncluirNovoItem.Name = "btnIncluirItem";
            EditarItem.Name = "btnEditarItem";
            ExcluirItem.Name = "btnExcluirItem";

            Gravar.Name = "btnGravar";
            Cancelar.Name = "btnCancelar";

            separador1.Name = "indingNavigatorSeparator";
            separador2.Name = "indingNavigatorSeparator";
            separador3.Name = "indingNavigatorSeparator";
            separador3.Name = "indingNavigatorSeparator";

            //
            // Setar textos
            //
            MoverParaPrimeiroItem.Text =
            MoverParaItemAnterior.Text =
            MoverParaProximoItem.Text =
            MoverParaUltimoItem.Text =
            IncluirNovoItem.Text =
            EditarItem.Text =
            ExcluirItem.Text =
            PesquisarItem.Text =
            Gravar.Text =
            Cancelar.Text = TEXTO_ITEN;

            CaixaPesquisa.Text = TEXTO_ITEN;

            //
            // Setar dicas
            //
            MoverParaPrimeiroItem.ToolTipText = "Para o primeiro";
            MoverParaItemAnterior.ToolTipText = "Para o anterior";
            MoverParaProximoItem.ToolTipText = "Para o próximo";
            MoverParaUltimoItem.ToolTipText = "Para o último";

            IncluirNovoItem.ToolTipText = "Adicionar novo item";
            EditarItem.ToolTipText = "Editar item existente";
            ExcluirItem.ToolTipText = "Excluir item";
            PesquisarItem.ToolTipText = "Pesquisar item";

            Gravar.ToolTipText = "Gravar alterações";
            Cancelar.ToolTipText = "Cancelar alterações";

            CaixaPesquisa.ToolTipText = "Pesquisar item pelo código";

            //
            // Setar as imagens
            //
            Bitmap movarParaPrimeiroItemImagem = Resources.Inicio;
            Bitmap voltarItemImagem = Resources.Anterior;
            Bitmap AvançarItemImagem = Resources.Proximo;
            Bitmap MoverParaUltimoItemImagem = Resources.Fim;

            Bitmap adicionarNovoItemImagem = Resources.Adicionar;
            Bitmap editarItemImagem = Resources.Editar;
            Bitmap excluirItemImagem = Resources.Excluir;

            Bitmap pesquisarItem = Resources.Pesquisar;

            Bitmap gravar = Resources.Salvar;
            Bitmap cancelar = Resources.Cancelar;

            movarParaPrimeiroItemImagem.MakeTransparent( Color.Magenta );
            voltarItemImagem.MakeTransparent( Color.Magenta );
            AvançarItemImagem.MakeTransparent( Color.Magenta );
            MoverParaUltimoItemImagem.MakeTransparent( Color.Magenta );

            adicionarNovoItemImagem.MakeTransparent( Color.Magenta );
            editarItemImagem.MakeTransparent( Color.Magenta );
            excluirItemImagem.MakeTransparent( Color.Magenta );

            pesquisarItem.MakeTransparent( Color.Magenta );

            gravar.MakeTransparent( Color.Magenta );
            cancelar.MakeTransparent( Color.Magenta );

            MoverParaPrimeiroItem.Image = movarParaPrimeiroItemImagem;
            MoverParaItemAnterior.Image = voltarItemImagem;
            MoverParaProximoItem.Image = AvançarItemImagem;
            MoverParaUltimoItem.Image = MoverParaUltimoItemImagem;

            IncluirNovoItem.Image = adicionarNovoItemImagem;
            EditarItem.Image = editarItemImagem;
            ExcluirItem.Image = excluirItemImagem;

            PesquisarItem.Image = pesquisarItem;

            Gravar.Image = gravar;
            Cancelar.Image = cancelar;

            MoverParaPrimeiroItem.RightToLeftAutoMirrorImage = true;
            MoverParaItemAnterior.RightToLeftAutoMirrorImage = true;
            MoverParaProximoItem.RightToLeftAutoMirrorImage = true;
            MoverParaUltimoItem.RightToLeftAutoMirrorImage = true;

            IncluirNovoItem.RightToLeftAutoMirrorImage = true;
            EditarItem.RightToLeftAutoMirrorImage = true;
            ExcluirItem.RightToLeftAutoMirrorImage = true;

            PesquisarItem.RightToLeftAutoMirrorImage = true;

            Gravar.RightToLeftAutoMirrorImage = true;
            Cancelar.RightToLeftAutoMirrorImage = true;

            MoverParaPrimeiroItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            MoverParaItemAnterior.DisplayStyle = ToolStripItemDisplayStyle.Image;
            MoverParaProximoItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            MoverParaUltimoItem.DisplayStyle = ToolStripItemDisplayStyle.Image;

            IncluirNovoItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
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

            Dock = DockStyle.Bottom;
            GripStyle = ToolStripGripStyle.Hidden;

            //
            // Adicionar os itens na coleção
            //
            Items.AddRange( new ToolStripItem[] {
                                IncluirNovoItem,
                                EditarItem,
                                ExcluirItem,
                                separador1,
                                MoverParaPrimeiroItem,
                                MoverParaItemAnterior,
                                separador2,
                                CaixaPesquisa,
                                PesquisarItem,
                                separador3,
                                MoverParaProximoItem,
                                MoverParaUltimoItem,
                                separador4,
                                Gravar,
                                Cancelar,
                            } );
        }

        #endregion

        #endregion Métodos
    }
}