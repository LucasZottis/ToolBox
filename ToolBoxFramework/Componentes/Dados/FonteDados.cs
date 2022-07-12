using System;
using System.ComponentModel;
using System.Data;
using ToolBox.ToolBoxFramework.Componentes.Dados.Base;

namespace ToolBox.ToolBoxFramework.Componentes.Dados
{
    [DesignerCategory( "Dados" ), ToolboxItem( true )]
    public class FonteDados : BindingSourceBase
    {
        public FonteDados( IContainer container ) : base( container ) { }

        protected override void OnDataSourceChanged( EventArgs e )
        {
            base.OnDataSourceChanged( e );

            if ( DataSource is DataTable && ( ( DataTable ) DataSource ).PrimaryKey.Length > 0 )
            {
                _valorChave = ( ( DataTable ) DataSource ).PrimaryKey[ 0 ].ColumnName;
            }
        }
    }
}