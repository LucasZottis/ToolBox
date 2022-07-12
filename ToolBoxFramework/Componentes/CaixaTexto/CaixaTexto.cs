using System.ComponentModel;
using ToolBox.ToolBoxFramework.Componentes.Bases;

namespace ToolBox.ToolBoxFramework.Componentes.CaixaTexto
{
    [DesignerCategory( "Caixa de Texto" ), ToolboxItem( true )]
    public class CaixaTexto : CaixaTextoBase
    {
        public CaixaTexto( IContainer container ) : base( container )
        {

        }
    }
}
