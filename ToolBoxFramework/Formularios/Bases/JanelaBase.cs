using System;
using System.ComponentModel;

namespace ToolBox.ToolBoxFramework.Formularios.Bases
{
    [Serializable()]
    public partial class JanelaBase : FormularioBase
    {
        public JanelaBase()
        {
            InitializeComponent();
            ConfiguracoesCaixaFerramenta.FormulariosAbertos.Add( this );
        }

        #region Métodos Sobreescritos

        protected override void OnClosing( CancelEventArgs e )
        {
            base.OnClosing( e );
            ConfiguracoesCaixaFerramenta.FormulariosAbertos.Remove( this );
        }

        #endregion Métodos Sobreescritos
    }
}