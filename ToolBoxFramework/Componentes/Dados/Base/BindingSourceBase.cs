using BibliotecaPublica.Classes.Servicos.Conversores;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace BibliotecaPublica.CaixaFerramenta.Componentes.Dados.Base
{
    [ToolboxItem( false )]
    public class BindingSourceBase : BindingSource, ISupportInitialize
    {
        #region Atributos

        protected bool _inicializando;
        protected string _filtroPadrao;
        protected string _valorChave;

        #endregion Atributos

        #region Propriedades

        #region Sobreescritas

        [Browsable( true )]
        [Category( "Dados" )]
        [Description( "Obtém ou define o filtro utilizado nos registros." )]
        [DisplayName( "Filtro" )]
        public new string Filter
        {
            get
            {
                return base.Filter;
            }
            set
            {
                base.Filter = value;

                if ( _inicializando )
                {
                    _filtroPadrao = value;
                }
            }
        }

        [Browsable( true )]
        [Category( "Dados" )]
        [Description( "Obtém ou define a fonte de dados." )]
        [DisplayName( "Fonte de dados" )]
        public new object DataSource
        {
            get
            {
                return base.DataSource;
            }

            set
            {
                base.DataSource = value;
            }
        }

        [Browsable( true )]
        [Category( "Dados" )]
        [Description( "Obtém ou define a subfonte de dados que será vinculada." )]
        [DisplayName( "Sub fonte de dados" )]
        public new string DataMember
        {
            get
            {
                return base.DataMember;
            }

            set
            {
                base.DataMember = value;
            }
        }

        #endregion Sobreescritas

        [Browsable( false )]
        public DataRowView ItemSelecionado
        {
            get
            {
                return ( DataRowView ) Current;
            }
        }

        [Browsable( false )]
        public bool TemRegistro
        {
            get
            {
                return Count > 0;
            }
        }

        [Browsable( true ), Category( "Dados" ), Description( "Obtém o valor chave da fonte de dados." ), DefaultValue( null ), DisplayName( "Nome de valor chave" )]
        public virtual string NomeValorChave
        {
            get
            {
                return _valorChave;
            }
        }

        #endregion Propriedades

        #region Construtores

        public BindingSourceBase( IContainer container )
        {
            if ( container != null )
            {
                container.Add( this );
            }
        }

        #endregion Construtores

        #region Métodos

        #region Privados

        #region Sobreescritos



        #endregion Sobreescritos

        private void LocalizarValorChave()
        {

        }

        #endregion Privados

        #region Protegidos

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Protegidos

        #region Internos

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Internos

        #region Públicos

        #region Sobreescritos

        private new int Find( string nomeValor, object valor )
        {
            return base.Find( nomeValor, valor );
        }

        public override void RemoveFilter()
        {
            base.RemoveFilter();

            Filter = _filtroPadrao;
        }

        #endregion Sobreescritos

        #region ISupportInitialize

        public void BeginInit()
        {
            _inicializando = true;
        }

        public void EndInit()
        {
            _inicializando = false;
        }

        #endregion ISupportInitialize

        #region Valor Item Selecionado Para...

        public TipoDado ValorColunaPara<TipoDado>( string nomeValor )
        {
            return ( TipoDado ) ItemSelecionado[ nomeValor ];
        }

        public string ValorColunaParaTexto( string nomeValor )
        {
            return ValorColunaPara<string>( nomeValor );
        }

        public int ValorColunaParaInteiro( string nomeValor )
        {
            if ( ItemSelecionado == null )
            {
                return 0;
            }

            return ItemSelecionado[ nomeValor ].ParaInt();
        }

        public bool ValorColunaParaBooleano( string nomeValor )
        {
            return ValorColunaPara<bool>( nomeValor );
        }

        public decimal ValorColunaParaDecimal( string nomeValor )
        {
            return ValorColunaPara<decimal>( nomeValor );
        }

        #endregion Valor Item Selecionado Para...

        public DataRowView AdicionarNovo()
        {
            if ( DataSource == null )
            {
                throw new ArgumentNullException( "DataSource", "A fonte de dados não foi informada." );
            }

            return ( DataRowView ) AddNew();
        }

        public void RemoverItemSelecionado()
        {
            if ( !( this as IBindingList ).AllowRemove )
            {
                throw new InvalidOperationException( "Não é permitido remover itens." );
            }

            if ( Position < 0 || Position >= Count )
            {
                throw new InvalidOperationException( "Não existe o item na posição indicada." );
            }

            RemoveAt( Position );
        }

        public int Encontrar( int codigo )
        {
            return Find( NomeValorChave, codigo );
        }

        public int Encontrar( string nomeValor, DataRowView linha )
        {
            return Find( nomeValor, linha[ nomeValor ] );
        }

        #endregion Públicos

        #endregion Métodos
    }
}