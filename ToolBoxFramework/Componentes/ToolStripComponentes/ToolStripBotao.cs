using BibliotecaPublica.Enums;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ToolBox.ToolBoxFramework.Interfaces;

namespace ToolBox.ToolBoxFramework.Componentes.ToolStripComponentes
{
    [ToolStripItemDesignerAvailability( ToolStripItemDesignerAvailability.ToolStrip ), ToolboxItem( false ), DesignerCategory( "Menus" )]
    public class ToolStripBotao : ToolStripButton, IBotao
    {
        #region Atributos

        private Resposta _resposta = Resposta.Nenhuma;

        #endregion Atributos

        [Browsable( true ), Category( "Diversos" )]
        public Resposta Resposta
        {
            private get
            {
                return _resposta;
            }

            set
            {
                _resposta = value;
            }
        }

        [Browsable( false )]
        public Keys TeclaAtalho { get; set; }

        [Browsable( false )]
        public new event EventHandler Click
        {
            add
            {
                base.Click += value;
            }

            remove
            {
                base.Click -= value;
            }
        }

        public Resposta ExecutarCliqueBotao()
        {
            if ( Enabled )
            {
                PerformClick();

                return Resposta;
            }

            return Resposta.Nenhuma;
        }

        public void Focar()
        {

        }
    }
}