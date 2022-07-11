using BibliotecaPublica;
using BibliotecaPublica.CaixaFerramenta.Componentes;
using BibliotecaPublica.CaixaFerramenta.Interfaces;
using BibliotecaPublica.Classes.Servicos.Conversores;
using BibliotecaPublica.Classes.Verificadores;
using BibliotecaPublica.Enums;
using BibliotecaPublica.Estruturas;
using CaixaFerramenta.Componentes.ToolStripComponentes;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CaixaFerramenta.Componentes.Dados
{
    [DesignerCategory( "Dados" )]
    public class NavegadorRegistros : BindingNavigator, ISupportInitialize
    {
        #region Delegados

        private EventoCrudNavegador _aoGravar;
        private EventoCrudNavegador _aoCancelar;
        private EventoCrudNavegador _aoIncluirItem;
        private EventoCrudNavegador _aoEditarItem;
        private EventoCrudNavegador _aoDeletarItem;
        private EventoValidacao _aoValidar;

        #endregion Delegados

        #region Constantes

        private const string MENSAGEM_EXCECAO_ITENS_PADROES = "Não é permitido esse tipo de item tool strip.";
        private const string TEXTO_ITEN = "";

        #endregion Constantes

        #region Atributos

        private bool _permitidoAdicionarNovoItem = true;
        private bool _permitidoEditarItem = true;
        private bool _permitidoGravarAlteracao = true;
        private bool _permitidoCancelarAlteracao = true;
        private bool _permitidoPesquisarItem = true;
        private bool _inicializando = false;
        private bool _pesquisando = false;

        private DataRowView _linha = null;
        private DataRow _dataRow = null;

        private FonteLigacao _fonteLigacao;

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

        #region Propriedades Sobreescritas

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

        #endregion Propriedades Sobreescritas

        #region Dados

        [Browsable( true ), Category( "Dados" ), Description( "Fonte de ligação navegado pelo navegador." ), DisplayName( "Fonte de ligação" )]
        public FonteLigacao FonteLigacao
        {
            get
            {
                return _fonteLigacao;
            }

            set
            {
                SetarFonteLigacao( ref _fonteLigacao, value );
            }
        }

        [Browsable( true ), Category( "Dados" ), Description( "Formulário que abriga esse navegador de registros." ), DisplayName( "Formulário" )]
        public IFormulario BaseJanela
        {
            get
            {
                return _formularioInterface;
            }

            set
            {
                _formularioInterface = value;
            }
        }

        #endregion Dados

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

        #endregion Propriedades

        #region Construtores

        [EditorBrowsable( EditorBrowsableState.Never )]
        public NavegadorRegistros() : this( false )
        {
        }

        public NavegadorRegistros( FonteLigacao fonteLigacao ) : this( true )
        {
            FonteLigacao = fonteLigacao;
        }

        [EditorBrowsable( EditorBrowsableState.Never )]
        public NavegadorRegistros( IContainer container ) : this( false )
        {
            if ( container == null )
            {
                throw new ArgumentNullException( "container" );
            }

            container.Add( this );
        }

        public NavegadorRegistros( bool adicionarItensPadroes )
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
        public event EventoCrudNavegador AoExcluir
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

        #region Métodos Privados

        #region Métodos de Eventos

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
            //if (ExcluirItem != null)
            //{
            //    _permitidoExcluirItem = _excluirItem.Enabled;
            //}
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
                if ( _fonteLigacao != null && _fonteLigacao.FonteDados != null )
                {
                    _fonteLigacao.MoveFirst();
                    RefreshItemsCore();
                }
            }
        }

        private void AoVoltar( object enviador, EventArgs argumento )
        {
            if ( Validate() )
            {
                if ( _fonteLigacao != null && _fonteLigacao.FonteDados != null )
                {
                    _fonteLigacao.MovePrevious();
                    RefreshItemsCore();
                }
            }
        }

        private void AoAvancar( object enviador, EventArgs argumento )
        {
            if ( Validate() )
            {
                if ( _fonteLigacao != null && _fonteLigacao.FonteDados != null )
                {
                    _fonteLigacao.MoveNext();
                    RefreshItemsCore();
                }
            }
        }

        private void AoAvancarParaUltimoItem( object enviador, EventArgs argumento )
        {
            if ( Validate() )
            {
                if ( _fonteLigacao != null && _fonteLigacao.FonteDados != null )
                {
                    _fonteLigacao.MoveLast();
                    RefreshItemsCore();
                }
            }
        }

        private void AoClicarIncluirItem( object enviador, EventArgs argumento )
        {
            if ( _fonteLigacao == null && _fonteLigacao.FonteDados == null )
            {
                return;
            }

            if ( !Validate() )
            {
                return;
            }

            _linha = _fonteLigacao.AdicionarNovo();
            _fonteLigacao.MoveLast();
            //int posicao = _fonteLigacao.Encontrar( _linha[ _fonteLigacao.NomeValorChave ].ParaInt() );
            //_fonteLigacao.Position = posicao;
            _linha.BeginEdit();

            if ( _aoIncluirItem != null )
            {
                _aoIncluirItem();
            }

            _formularioInterface.ModoJanela = ModoJanela.Inclusao;
            RefreshItemsCore();
        }

        private void AoClicarEditarItem( object enviador, EventArgs argumento )
        {
            _formularioInterface.ModoJanela = ModoJanela.Alteracao;

            if ( _fonteLigacao == null && _fonteLigacao.FonteDados == null )
            {
                return;
            }

            if ( !_fonteLigacao.TemRegistro )
            {
                Mensagem.Avisar( "Não há registros para ser alterado." );
                return;
            }

            if ( !Validate() )
            {
                return;
            }

            _linha = _fonteLigacao.ItemSelecionado;
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

            if ( _fonteLigacao == null && _fonteLigacao.FonteDados == null )
            {
                return;
            }

            if ( !_fonteLigacao.TemRegistro )
            {
                Mensagem.Avisar( "Não há registros." );
                return;
            }

            if ( _fonteLigacao.ItemSelecionado == null )
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
                _aoDeletarItem();
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
                if ( _fonteLigacao == null && _fonteLigacao.FonteDados == null )
                {
                    return;
                }

                if ( !Validate() )
                {
                    _fonteLigacao.ItemSelecionado.CancelEdit();
                    return;
                }

                _linha.EndEdit();

                if ( _aoValidar != null && !_aoValidar() )
                {
                    gravar = false;
                    _linha.BeginEdit();
                    return;
                }

                if ( gravar && _aoGravar != null )
                {
                    _aoGravar();
                }

                if ( gravar )
                {
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
            if ( _fonteLigacao == null && _fonteLigacao.FonteDados == null )
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
                    _pesquisando = true;
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
                _pesquisando = true;
                encontrou = Pesquisar();
            }

            if ( !encontrou )
            {
                Mensagem.Avisar( "Item não encontrado" );
            }
        }

        #endregion Eventos das Caixas de Textos

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

        #endregion Métodos de Eventos

        #region Setar Propriedades

        private void SetarFonteLigacao( ref FonteLigacao antigaFonteLigacao, FonteLigacao novaFonteLigacao )
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

        private bool Pesquisar()
        {
            int codigo = 0;
            int posicao = -1;

            if ( _pesquisando && !( Disposing || IsDisposed ) )
            {
                if ( CaixaPesquisa != null )
                {
                    codigo = CaixaPesquisa.TextBox.Text.ParaInt();
                }

                if ( _fonteLigacao != null && codigo.Diferente( 0 ) )
                {
                    posicao = _fonteLigacao.Encontrar( codigo );
                }

                if ( posicao < 0 )
                {
                    AposPesquisar( true );
                    return false;
                }
            }

            _fonteLigacao.Position = posicao;
            AposPesquisar( true );

            return true;
        }

        private void AposPesquisar( bool apagarCampo )
        {
            if ( apagarCampo )
            {
                CaixaPesquisa.TextBox.Clear();
                _pesquisando = false;
            }
        }

        private void AtualizarItens()
        {
            if ( _inicializando )
            {
                return;
            }

            OnRefreshItems();
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
            /* 
                * Código comentado pois ao implementar a validação de registro,
                * se clicasse em gravar e invalidasse, o registro ficava salvo na lista.
            */

            //_linha.CancelEdit();
            //_linha = null;

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

        #endregion Métodos Privados

        #region Métodos Sobreescritos

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

            ToolStripSeparator separator1 = new ToolStripSeparator();
            ToolStripSeparator separator2 = new ToolStripSeparator();
            ToolStripSeparator separator3 = new ToolStripSeparator();
            ToolStripSeparator separator4 = new ToolStripSeparator();

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

            separator1.Name = "indingNavigatorSeparator";
            separator2.Name = "indingNavigatorSeparator";
            separator3.Name = "indingNavigatorSeparator";
            separator3.Name = "indingNavigatorSeparator";

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
            Bitmap moveFirstImage = new Bitmap( typeof( System.Windows.Forms.BindingNavigator ), "BindingNavigator.MoveFirst.bmp" );
            Bitmap movePreviousImage = new Bitmap( typeof( System.Windows.Forms.BindingNavigator ), "BindingNavigator.MovePrevious.bmp" );
            Bitmap moveNextImage = new Bitmap( typeof( System.Windows.Forms.BindingNavigator ), "BindingNavigator.MoveNext.bmp" );
            Bitmap moveLastImage = new Bitmap( typeof( System.Windows.Forms.BindingNavigator ), "BindingNavigator.MoveLast.bmp" );

            Bitmap addNewImage = BibliotecaPublica.CaixaFerramenta.Properties.Resources.Novo_24px;
            Bitmap editarItem = BibliotecaPublica.CaixaFerramenta.Properties.Resources.Editar_24px;
            Bitmap deleteImage = BibliotecaPublica.CaixaFerramenta.Properties.Resources.Deletar_24px;

            Bitmap pesquisarItem = BibliotecaPublica.CaixaFerramenta.Properties.Resources.Buscar;

            Bitmap gravar = BibliotecaPublica.CaixaFerramenta.Properties.Resources.Salvar;
            Bitmap cancelar = BibliotecaPublica.CaixaFerramenta.Properties.Resources.Cancelar_20x20;

            moveFirstImage.MakeTransparent( Color.Magenta );
            movePreviousImage.MakeTransparent( Color.Magenta );
            moveNextImage.MakeTransparent( Color.Magenta );
            moveLastImage.MakeTransparent( Color.Magenta );

            addNewImage.MakeTransparent( Color.Magenta );
            editarItem.MakeTransparent( Color.Magenta );
            deleteImage.MakeTransparent( Color.Magenta );

            pesquisarItem.MakeTransparent( Color.Magenta );

            gravar.MakeTransparent( Color.Magenta );
            cancelar.MakeTransparent( Color.Magenta );

            MoverParaPrimeiroItem.Image = moveFirstImage;
            MoverParaItemAnterior.Image = movePreviousImage;
            MoverParaProximoItem.Image = moveNextImage;
            MoverParaUltimoItem.Image = moveLastImage;

            IncluirNovoItem.Image = addNewImage;
            EditarItem.Image = editarItem;
            ExcluirItem.Image = deleteImage;

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
                                separator1,
                                MoverParaPrimeiroItem,
                                MoverParaItemAnterior,
                                separator2,
                                CaixaPesquisa,
                                PesquisarItem,
                                separator3,
                                MoverParaProximoItem,
                                MoverParaUltimoItem,
                                separator4,
                                Gravar,
                                Cancelar,
                            } );
        }

        protected override void RefreshItemsCore()
        {
            bool permitirIncluirNovoItem;
            bool permitirEditar;
            bool permitirExcluir;
            bool permitirGravar;
            bool permitirCancelar;
            bool permitirPesquisar;
            bool permitirNavegar;

            EventHandler habilitado = null;
            EventHandler clicado = null;

            PositionItem = null;
            CountItem = null;
            CountItemFormat = null;

            if ( _fonteLigacao == null )
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
                permitirIncluirNovoItem = ( _fonteLigacao as IBindingList ).AllowNew;
                permitirEditar = ( _fonteLigacao as IBindingList ).AllowEdit;
                permitirExcluir = ( _fonteLigacao as IBindingList ).AllowRemove;
                permitirGravar = ( ( _fonteLigacao as IBindingList ).AllowNew || ( _fonteLigacao as IBindingList ).AllowEdit );
                permitirCancelar = ( permitirGravar && ( _fonteLigacao as IBindingList ).AllowNew || ( _fonteLigacao as IBindingList ).AllowEdit );
                permitirPesquisar = _formularioInterface.ModoJanela == ModoJanela.Navegacao && _fonteLigacao.Count > 1;
                permitirNavegar = _formularioInterface.ModoJanela == ModoJanela.Navegacao && _fonteLigacao.Count > 1;
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
                    //habilitado = new EventHandler(AoMudarEstadoHabilitadoAdicionarNovoItem);
                    clicado = new EventHandler( AoVoltarParaPrimeiroItem );

                    _moverParaPrimeiroItem.Click -= clicado;
                    _moverParaPrimeiroItem.Click += clicado;

                    //_inclurNovoItem.EnabledChanged -= habilitado;
                    //_inclurNovoItem.Enabled = (_permitidoAdicionarNovoItem && permitirIncluirNovoItem) && _formularioInterface.ModoJanela == ModoJanela.Navegacao;
                    //_inclurNovoItem.EnabledChanged += habilitado;

                    _moverParaPrimeiroItem.Enabled = permitirNavegar;
                }

                if ( MoverParaItemAnterior != null )
                {
                    //habilitado = new EventHandler(AoMudarEstadoHabilitadoAdicionarNovoItem);
                    clicado = new EventHandler( AoVoltar );

                    _moverParaItemAnterior.Click -= clicado;
                    _moverParaItemAnterior.Click += clicado;

                    //_inclurNovoItem.EnabledChanged -= habilitado;
                    //_inclurNovoItem.Enabled = (_permitidoAdicionarNovoItem && permitirIncluirNovoItem) && _formularioInterface.ModoJanela == ModoJanela.Navegacao;
                    //_inclurNovoItem.EnabledChanged += habilitado;

                    _moverParaItemAnterior.Enabled = permitirNavegar;
                }

                if ( MoverParaProximoItem != null )
                {
                    //habilitado = new EventHandler(AoMudarEstadoHabilitadoAdicionarNovoItem);
                    clicado = new EventHandler( AoAvancar );

                    _moverParaProximoItem.Click -= clicado;
                    _moverParaProximoItem.Click += clicado;

                    //_inclurNovoItem.EnabledChanged -= habilitado;
                    //_inclurNovoItem.Enabled = (_permitidoAdicionarNovoItem && permitirIncluirNovoItem) && _formularioInterface.ModoJanela == ModoJanela.Navegacao;
                    //_inclurNovoItem.EnabledChanged += habilitado;

                    _moverParaProximoItem.Enabled = permitirNavegar;
                }

                if ( MoverParaUltimoItem != null )
                {
                    //habilitado = new EventHandler(AoMudarEstadoHabilitadoAdicionarNovoItem);
                    clicado = new EventHandler( AoAvancarParaUltimoItem );

                    _moverParaUltimoItem.Click -= clicado;
                    _moverParaUltimoItem.Click += clicado;

                    //_inclurNovoItem.EnabledChanged -= habilitado;
                    //_inclurNovoItem.Enabled = (_permitidoAdicionarNovoItem && permitirIncluirNovoItem) && _formularioInterface.ModoJanela == ModoJanela.Navegacao;
                    //_inclurNovoItem.EnabledChanged += habilitado;

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
                FonteLigacao = null;
            }

            base.Dispose( disposing );
        }

        #endregion Métodos Sobreescritos

        #region Métodos Públicos

        public new void BeginInit()
        {
            ComecarInicializacao();
        }

        public new void EndInit()
        {
            EncerrarInicializacao();
        }

        #endregion Métodos Públicos
    }
}