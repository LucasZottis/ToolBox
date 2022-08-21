using System;
using System.ComponentModel;

namespace ToolBox.ToolBoxWinForms.Framework.Formularios.Bases
{
    [Serializable()]
    public partial class JanelaBase : FormularioBase
    {
        public JanelaBase()
        {
            InitializeComponent();
            ToolBoxConfig.FormulariosAbertos.Add( this );
        }

        #region Métodos Sobreescritos

        protected override void OnClosing( CancelEventArgs e )
        {
            base.OnClosing( e );
            ToolBoxConfig.FormulariosAbertos.Remove( this );
        }

        #endregion Métodos Sobreescritos
    }
}