using BibliotecaPublica.CaixaFerramenta.Componentes.Dados.Base;
using BibliotecaPublica.Classes.Verificadores;
using System;
using System.ComponentModel;
using System.Data;

namespace CaixaFerramenta.Componentes.Dados
{
    [DesignerCategory( "Dados" ), ToolboxItem( true )]
    public class FonteLigacao : BindingSourceBase
    {
        #region Atributos

        private string _nomeTabela = string.Empty;

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

        [Browsable( false )]
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

        [Browsable( false )]
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

        [DefaultValue( null ), RefreshProperties( RefreshProperties.Repaint ), AttributeProvider( typeof( IListSource ) ), Browsable( true ), Category( "Dados" ), Description( "Obtém ou define a fonte de dados." ), DisplayName( "Fonte de dados" )]
        public DataSet FonteDados
        {
            get
            {
                return ( DataSet ) DataSource;
            }

            set
            {
                DataSource = value;
                OnDataSourceChanged( null );
            }
        }

        [RefreshProperties( RefreshProperties.Repaint ), DefaultValue( "" ), Browsable( true ), Category( "Dados" ), Description( "Obtém ou define qual a tabela da fonte de dados será utilizada." ), DisplayName( "Tabela ativa" )]
        public DataTable Tabela
        {
            get
            {
                if ( FonteDados == null )
                {
                    return null;
                }

                if ( DataMember.TemConteudo() )
                {
                    return FonteDados.Tables[ DataMember ];
                }

                return null;
            }

            set
            {
                _nomeTabela = string.Empty;

                if ( value != null )
                {
                    _nomeTabela = value.TableName;
                }

                DataMember = _nomeTabela;

                OnDataMemberChanged( EventArgs.Empty );
                ObterNomeValorChave();
            }
        }

        #endregion Propriedades

        #region Construtores

        public FonteLigacao( IContainer container ) : base( container )
        {
            if ( container != null )
            {
                container.Add( this );
            }
        }

        #endregion Construtores

        #region Métodos

        #region Privados

        private void ObterNomeValorChave()
        {
            _valorChave = Tabela.PrimaryKey[ 0 ].ColumnName;
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



        #endregion Sobreescritos



        #endregion Públicos

        #endregion Métodos
    }
}