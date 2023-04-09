using ToolBox.Containers.Base;

namespace ToolBox.Containers
{
    [ToolboxItem( true ), DesignerCategory( "Paineis" )]
    public class ContainerGroup : ContainerGroupBase
    {
        #region Construtores

        public ContainerGroup( IContainer container ) : base( container )
        {

        }

        #endregion Construtores
    }
}