using System.Data;

namespace ToolBox.Dados.LigacaoDados
{
    [ToolboxItem( true ), DesignerCategory( "Dados" )]
    public class VinculoFonteDados 
        : LigacaoFonteDadosBase
    {
        public VinculoFonteDados()
        {
        }

        public VinculoFonteDados( IContainer container ) : base( container )
        {
        }

        public VinculoFonteDados( object dataSource, string dataMember ) : base( dataSource, dataMember )
        {
        }

        protected override void OnDataSourceChanged( EventArgs e )
        {
            base.OnDataSourceChanged( e );

            if ( DataSource is DataTable && ( ( DataTable ) DataSource ).PrimaryKey.Length > 0 )
                _valorChave = ( ( DataTable ) DataSource ).PrimaryKey[ 0 ].ColumnName;
        }
    }
}