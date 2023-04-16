using MyGears.Components.Containers.Base;

namespace MyGears.Components.Containers
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