using System.Data;

namespace ToolBox.Dados.LigacaoDados
{
    [ToolboxItem( true ), DesignerCategory( "Dados" )]
    public class VinculoFonteDados : LigacaoFonteDadosBase
    {
        #region Atributos



        #endregion Atributos

        #region Propriedades



        #endregion Propriedades

        #region Construtores

        public VinculoFonteDados()
        {
        }

        public VinculoFonteDados( IContainer container ) : base( container )
        {
        }

        public VinculoFonteDados( object dataSource, string dataMember ) : base( dataSource, dataMember )
        {
        }

        #endregion Construtores

        #region Métodos

        #region Privados

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Privados

        #region Protegidos

        protected override void OnDataSourceChanged( EventArgs e )
        {
            base.OnDataSourceChanged( e );

            if ( DataSource is DataTable )
            {
                if ( ( ( DataTable ) DataSource ).PrimaryKey.Length > 0 )
                {
                    _valorChave = ( ( DataTable ) DataSource ).PrimaryKey[ 0 ].ColumnName;
                }
            }
        }

        #endregion Protegidos

        #region Internos

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Internos

        #endregion Métodos
    }
}