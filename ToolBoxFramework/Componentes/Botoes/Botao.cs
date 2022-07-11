using BibliotecaPublica.Enums;
using BibliotecaPublica.Estruturas;
using BibliotecaPublica.Interfaces;
using CaixaFerramenta.Formularios.Bases;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using BibliotecaPublica;

namespace CaixaFerramenta.Componentes
{
    [DesignerCategory( "Botões" )]
    public class Botao : Button, IBotao, IComponente
    {
        #region Atributos

        private string _texto;
        private string _teclaAtalho;

        private Resposta _resposta = Resposta.Nenhuma;
        private Keys _atalho = Keys.None;

        private EventoClicar _clicar;
        private EventHandler _click;
        #endregion Atributos

        #region Propriedades

        #region Sobreescritas

        [
            Browsable( false )
        ]
        public new string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }

        #endregion Sobreescritas

        [
            Browsable( true ),
            Category( TextosPadroes.AtalhosCategoria ),
            DisplayName( TextosPadroes.TeclaAtalho ),
            Description( TextosPadroes.TeclaAtalhoDescricao ),
            DefaultValue( Keys.None )
        ]
        public Keys TeclaAtalho
        {
            get
            {
                return _atalho;
            }

            set
            {
                _atalho = value;
                AoMudarTeclaAtalho();
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.AparenciaCategoria ),
            DisplayName( TextosPadroes.Texto ),
            Description( TextosPadroes.TextoDescricao ),
            DefaultValue( ValoresPadroes.TextoPadrao )
        ]

        public string Texto
        {
            get
            {
                return _texto;
            }

            set
            {
                _texto = value;
                AoMudarTexto();
            }
        }


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


        [Browsable( true ), Category( TextosPadroes.ValidacaoCategoria ), Description( TextosPadroes.FazerValidacaoDescricao ), DisplayName( TextosPadroes.FazerValidacao ), DefaultValue( false )]
        public bool FazerValidacao { get; set; } = false;

        [Browsable( true ), Category( TextosPadroes.ComportamentoCategoria ), Description( TextosPadroes.BloquearComponenteDescricao ), DisplayName( TextosPadroes.BloquearComponente ), DefaultValue( false )]
        public bool BloquearComponente { get; set; } = false;

        [Browsable( false )]
        public bool Bloqueado
        {
            set
            {
                base.Enabled = !value;
            }
        }

        #endregion Propriedades

        #region Eventos

        #region Ocultados

        //[Browsable ( false )]
        public new event EventHandler Click
        {
            add
            {
                _click += value;
            }

            remove
            {
                _click -= value;
            }
        }

        #endregion Ocultados

        [Browsable( true ), DisplayName( TextosPadroes.EventoClicar ), Description( TextosPadroes.EventoClicarDescricao ), Category( TextosPadroes.AcaoCategoria )]
        public event EventoClicar Clicar
        {
            add
            {
                _clicar += value;
            }
            remove
            {
                _clicar -= value;
            }
        }

        #endregion Eventos

        public Botao( IContainer container )
        {
            container?.Add( this );
        }

        private void AoMudarTeclaAtalho()
        {
            CriarTextoBotao();
        }

        private void AoMudarTexto()
        {
            CriarTextoBotao();
        }

        private void CriarTextoBotao()
        {
            string teclaAtalho = string.Empty;
            Text = string.Empty;

            if ( _atalho != Keys.None )
            {
                switch ( _atalho )
                {
                    case Keys.OemMinus:
                    {
                        teclaAtalho = $" (-)";
                        break;
                    }

                    case Keys.Oemplus:
                    {
                        teclaAtalho = $" (+)";
                        break;
                    }

                    case Keys.Delete:
                    {
                        teclaAtalho = $" (Del)";
                        break;
                    }

                    default:
                    {
                        teclaAtalho = $" ({_atalho})";
                        break;
                    }
                }
            }

            Text = $"{_texto}{teclaAtalho}";
        }

        public Resposta ExecutarCliqueBotao()
        {
            PerformClick();

            return Resposta;
        }

        public void Focar()
        {
            Focus();
        }

        public bool Validar()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnClick( EventArgs e )
        {
            Control controle = this;

            while ( controle != null && !( controle is FormularioBase ) )
            {
                controle = controle.Parent;
            }

            FormularioBase formulario = ( FormularioBase ) controle;

            formulario.DialogResult = DialogResult;

            if ( _clicar != null )
            {
                _clicar();
            }
        }
    }
}