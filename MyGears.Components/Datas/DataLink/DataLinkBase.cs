using System.Data;

namespace MyGears.Components.Datas.DataLink
{
    [DesignerCategory( "Caixa de Texto" ), ToolboxItem( false )]
    public class DataLinkBase : BindingSource, ISupportInitialize
    {
        protected bool _inicializando;
        protected string _filtroPadrao;
        protected string _valorChave;

        [Browsable( true )]
        [Category( "Dados" )]
        [Description( "Obtém ou define o filtro utilizado nos registros." )]
        [DisplayName( "Filtro" )]
        public new string Filter
        {
            get => base.Filter;
            set
            {
                base.Filter = value;

                if ( _inicializando )
                    _filtroPadrao = value;
            }
        }

        [Browsable( true )]
        [Category( "Dados" )]
        [Description( "Obtém ou define a fonte de dados." )]
        [DisplayName( "Fonte de dados" )]
        public new object DataSource
        {
            get => base.DataSource;
            set => base.DataSource = value;
        }

        [Browsable( true )]
        [Category( "Dados" )]
        [Description( "Obtém ou define a subfonte de dados que será vinculada." )]
        [DisplayName( "Sub fonte de dados" )]
        public new string DataMember
        {
            get => base.DataMember;
            set => base.DataMember = value;
        }

        //[Browsable( false )]
        //public DataRowView ItemSelecionado
        //{
        //    get
        //    {
        //        return ( DataRowView ) Current;
        //    }
        //}

        [Browsable( false )]
        public bool TemRegistro
            => Count > 0;

        [
            Browsable( true ),
            Category( "Dados" ),
            Description( "Obtém o valor chave da fonte de dados." ),
            DefaultValue( null ),
            DisplayName( "Nome de valor chave" )
        ]
        public virtual string NomeValorChave
            => _valorChave;

        public DataLinkBase()
        {
        }

        public DataLinkBase( IContainer container ) : base( container )
        {
        }

        public DataLinkBase( object dataSource, string dataMember ) : base( dataSource, dataMember )
        {
        }

        public override void RemoveFilter()
        {
            base.RemoveFilter();

            Filter = _filtroPadrao;
        }

        public void BeginInit()
        {
            _inicializando = true;
        }

        public void EndInit()
        {
            _inicializando = false;
        }

        public T AdicionarNovo<T>()
        {
            return ( T ) AddNew();
        }

        public void RemoverItemSelecionado()
        {
            if ( !( this as IBindingList ).AllowRemove )
                throw new InvalidOperationException( "Não é permitido remover itens." );

            if ( Position < 0 || Position >= Count )
                throw new InvalidOperationException( "Não existe o item na posição indicada." );

            RemoveAt( Position );
        }

        public TItem ObterItemSelecionado<TItem>()
            => ( TItem ) Current;

        //public int Encontrar( int codigo )
        //{
        //    return Find( NomeValorChave, codigo );
        //}

        //public int Encontrar( string nomeValor, DataRowView linha )
        //{
        //    return Find( nomeValor, linha[ nomeValor ] );
        //}

    }
}