using System.ComponentModel;
using System.Windows.Forms;

namespace ToolBox.ToolBoxFramework.Componentes.Rotulo.Base
{
    [ToolboxItem( false ), DesignerCategory( "Comuns" )]
    public class RotuloBase : Label
    {
        #region Atributos



        #endregion Atributos

        #region Propriedades



        #endregion Propriedades

        #region Construtores

        public RotuloBase( IContainer container ) : base()
        {
            container.Add( this );
        }

        #endregion Construtores

        #region Métodos

        #region Privados



        #endregion Privados

        #region Protegidos



        #endregion Protegidos

        #region Internos



        #endregion Internos

        #endregion Métodos
    }
}