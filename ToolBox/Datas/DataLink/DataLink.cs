using System.Data;

namespace ToolBox.Datas.DataLink
{
    [ToolboxItem( true ), DesignerCategory( "Dados" )]
    public class DataLink
        : DataLinkBase
    {
        public DataLink()
        {
        }

        public DataLink( IContainer container ) : base( container )
        {
        }

        public DataLink( object dataSource, string dataMember ) : base( dataSource, dataMember )
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