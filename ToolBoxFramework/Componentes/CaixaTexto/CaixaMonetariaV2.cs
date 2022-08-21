using BibliotecaPublica.BibliotecaPublicaFramework.Estruturas;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ToolBox.ToolBoxWinForms.Framework.Interfaces;

namespace ToolBox.ToolBoxWinForms.Framework.Componentes.CaixaTexto
{
    [ToolboxItem( true ), DesignerCategory( "Caixa de texto" )]
    public class CaixaMonetariaV2 : NumericUpDown, IComponente, ICaixaTexto
    {
        #region Atributos

        private bool _fazerValidacao = false;
        private bool _bloquearComponente = true;
        private bool _limparComponente = true;

        #endregion Atributos

        #region Propriedades

        [
            Browsable( true ),
            Category( TextosPadroes.ValidacaoCategoria ),
            DisplayName( TextosPadroes.FazerValidacao ),
            Description( TextosPadroes.FazerValidacaoDescricao ),
            DefaultValue( ValoresPadroes.FazerValidacao )
        ]
        public bool FazerValidacao
        {
            get
            {
                return _fazerValidacao;
            }

            set
            {
                _fazerValidacao = value;
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DisplayName( TextosPadroes.BloquearComponente ),
            Description( TextosPadroes.BloquearComponenteDescricao ),
            DefaultValue( ValoresPadroes.BloquearComponente )
        ]
        public bool BloquearComponente
        {
            get
            {
                return _bloquearComponente;
            }

            set
            {
                _bloquearComponente = value;
            }
        }

        [
            Browsable( false ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DisplayName( TextosPadroes.Bloqueado ),
            Description( TextosPadroes.BloqueadoDescricao ),
            DefaultValue( ValoresPadroes.Bloqueado )
        ]
        public bool Bloqueado
        {
            set
            {
                Enabled = !value;
            }
        }

        [Browsable( false )]
        public uint QuantidadeMaxima { get; set; }

        [Browsable( false )]
        public uint QuantidadeMinima { get; set; }

        [
            Browsable( true ),
            Category( TextosPadroes.DiversosCategoria ),
            DisplayName( TextosPadroes.LimparComponente ),
            Description( TextosPadroes.LimparComponenteDescricao ),
            DefaultValue( ValoresPadroes.LimparComponente )
        ]
        public bool LimparComponente
        {
            get
            {
                return _limparComponente;
            }

            set
            {
                _limparComponente = value;
            }
        }

        [
            Browsable( true ),
            Bindable( BindableSupport.Yes )
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

        #region ILimpeza

        [Browsable( true ), Category( TextosPadroes.DadosCateogria ), Description( TextosPadroes.FazerLimpezaDescricao ), DisplayName( TextosPadroes.FazerLimpeza ), DefaultValue( false )]
        public bool FazerLimpeza { get; set; } = false;
        public bool PermitirNumeros { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool PermitirLetras { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool PermitirSimbolos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion ILimpeza

        #endregion Propriedades

        public CaixaMonetariaV2( IContainer container ) : base()
        {
            if ( container != null )
            {
                container.Add( this );
            }

            TextAlign = HorizontalAlignment.Right;
            UpDownAlign = LeftRightAlignment.Left;
            DecimalPlaces = 2;
            Maximum = ValoresPadroes.ValorMaximoMonetario;
            Minimum = ValoresPadroes.ValorMinimoMonetario;
        }

        public bool Validar()
        {
            throw new NotImplementedException();
        }

        public bool TemTexto()
        {
            throw new NotImplementedException();
        }

        public void Limpar()
        {
            Value = 0.00m;
        }
    }
}