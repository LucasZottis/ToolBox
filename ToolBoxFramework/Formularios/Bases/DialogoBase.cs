using BibliotecaPublica.Estruturas;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ToolBox.ToolBoxFramework.Interfaces;

namespace ToolBox.ToolBoxFramework.Formularios.Bases
{
    [Serializable()]
    public partial class DialogoBase : FormularioBase
    {
        #region Propriedades Sobreescritas

        [Browsable( false )]
        public new FormBorderStyle FormBorderStyle
        {
            get
            {
                return base.FormBorderStyle;
            }

            set
            {
                base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            }
        }

        [Browsable( false )]
        public new Icon Icone
        {
            get
            {
                return base.Icone;
            }

            set
            {
                base.Icone = value;
            }
        }

        [Browsable( false )]
        public new bool HabilitarBotaoAjuda
        {
            get
            {
                return base.HabilitarBotaoAjuda;
            }

            set
            {
                base.HabilitarBotaoAjuda = value;
            }
        }

        [Browsable( false )]
        public new bool MaximizeBox
        {
            get
            {
                return base.MaximizeBox;
            }

            set
            {
                base.MaximizeBox = value;
            }
        }

        [Browsable( false )]
        public new bool MinimizeBox
        {
            get
            {
                return base.MinimizeBox;
            }

            set
            {
                base.MinimizeBox = value;
            }
        }

        [Browsable( false )]
        public new IBotao AtalhoPesquisa
        {
            get
            {
                return base.AtalhoPesquisa;
            }

            set
            {
                base.AtalhoPesquisa = value;
            }
        }

        [Browsable( false )]
        public new MenuStrip BarraMenu
        {
            get
            {
                return base.BarraMenu;
            }

            set
            {
                base.BarraMenu = value;
            }
        }

        [Browsable( false )]
        public new FormWindowState EstadoInicialJanela
        {
            get
            {
                return base.EstadoInicialJanela;
            }

            set
            {
                base.EstadoInicialJanela = value;
            }
        }

        /// <summary>
        /// Indica se as barras de rolagem são exibidas automaticamente quando o conteúdo do controle é maior qua a área visivel.
        /// </summary>
        [
            Browsable( true ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DisplayName( "Habilitar barras de rolagem" ),
            DefaultValue( false )
        ]
        public new bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }

            set
            {
                base.AutoScroll = value;
            }
        }

        [
            Browsable( false ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DisplayName( "Margem das barras de rolagem" )
        ]
        public new Size AutoScrollMargin
        {
            get
            {
                return base.AutoScrollMargin;
            }

            set
            {
                base.AutoScrollMargin = value;
            }
        }

        [Browsable( false )]
        public new Size AutoScrollMinSize
        {
            get
            {
                return base.AutoScrollMinSize;
            }

            set
            {
                base.AutoScrollMinSize = value;
            }
        }

        #endregion Propriedades Sobreescritas

        #region Construtores

        public DialogoBase()
        {
            InitializeComponent();
        }

        #endregion Construtores
    }
}