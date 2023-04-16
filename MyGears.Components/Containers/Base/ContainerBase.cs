﻿namespace MyGears.Components.Containers.Base
{
    [ToolboxItem( false ), DesignerCategory( "Paineis" )]
    public class ContainerBase : Panel, IControl
    {
        #region Propriedades

        #region IComponente

        [Browsable( true ), DisplayName( TextosPadroes.BloquearComponente ), Description( TextosPadroes.BloquearComponenteDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
        public bool DisableControl { get; set; } = false;

        [Browsable( false )]
        public bool Disabled { set => Enabled = !value; }

        #endregion IComponente

        #endregion Propriedades

        #region Construtores

        public ContainerBase( IContainer container ) : base()
        {
            if ( container != null )
            {
                container.Add( this );
            }
        }

        #endregion Construtores

        #region Métodos

        #region Públicos

        #region IComponente

        public Point GetCenterPoint()
        {
            return new Point( Size.Width / 2, Size.Height / 2 );
        }

        #endregion IComponente

        #endregion Públicos

        #endregion Métodos
    }
}