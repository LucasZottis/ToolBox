using BibliotecaPublica.Classes.Servicos.Conversores;
using BibliotecaPublica.Classes.Verificadores;
using BibliotecaPublica.Enums;
using BibliotecaPublica.Estruturas;
using BibliotecaPublica.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CaixaFerramenta.Componentes.ToolStripComponentes
{
    [ToolStripItemDesignerAvailability( ToolStripItemDesignerAvailability.MenuStrip | ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.ContextMenuStrip )]
    public class ToolStripCaixaNumero : ToolStripTextBox, IComponente, ICaixaTexto, ICaixaNumero
    {
        #region Atributos

        private bool _fazerValidacao = false;
        private bool _bloquearComponente = false;
        private bool _limparComponente = true;

        private uint _quantidadeMinima = ValoresPadroes.QuantidadeMinima;

        private long _valorMinimo = 0;
        private long _valorMaximo = long.MaxValue;

        private TipoDado _tipoValor = TipoDado.Int;

        #endregion Atributos

        #region Propriedades

        #region Propriedades de Interface

        #region IComponente

        [
            Browsable( true ),
            Category( TextosPadroes.ValidacaoCategoria ),
            DisplayName( TextosPadroes.FazerValidacao ),
            Description( TextosPadroes.FazerValidacaoDescricao ),
            DefaultValue( false )
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
            DefaultValue( false )
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
            DefaultValue( false )
        ]
        public bool Bloqueado
        {
            set
            {
                Enabled = !value;
            }
        }

        #endregion IComponente

        #region ICaixaNumero

        [
            Browsable( true ),
            Category( TextosPadroes.ValidacaoCategoria ),
            DisplayName( TextosPadroes.ValorMaximo ),
            Description( TextosPadroes.ValorMaximoDescricao ),
            DefaultValue( long.MaxValue )
        ]
        public long ValorMaximo
        {
            get
            {
                return _valorMaximo;
            }

            set
            {
                if ( value < long.MinValue || value > long.MaxValue )
                {
                    throw new ArgumentOutOfRangeException( TextosPadroes.ValorLimiteTipoLong );
                }

                if ( value <= ValorMinimo )
                {
                    throw new ArgumentException( TextosPadroes.ValorMaximoMenorValorMinimo );
                }

                _valorMaximo = value;
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.ValidacaoCategoria ),
            DisplayName( TextosPadroes.ValorMinimo ),
            Description( TextosPadroes.ValorMinimoDescricao ),
            DefaultValue( long.MinValue )
        ]
        public long ValorMinimo
        {
            get
            {
                return _valorMinimo;
            }

            set
            {
                if ( value < long.MinValue || value > long.MaxValue )
                {
                    throw new ArgumentOutOfRangeException( TextosPadroes.ValorLimiteTipoLong );
                }

                if ( value >= ValorMaximo )
                {
                    throw new ArgumentException( TextosPadroes.ValorMinimoMaiorValorMaximo );
                }

                _valorMinimo = value;
            }
        }

        [
            Browsable( false ),
            Category( TextosPadroes.DadosCateogria ),
            DisplayName( TextosPadroes.Valor ),
            Description( TextosPadroes.ValorDescricao ),
        ]
        public int Valor
        {
            get
            {
                return Text.ParaInt();
            }

            set
            {
                Text = value.ToString();
            }
        }

        #endregion ICaixaNumero

        #region ICaixaTexto

        [
            Browsable( true ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DisplayName( TextosPadroes.QuantidadeMaxima ),
            Description( TextosPadroes.QuantidadeMaximaDescricao ),
            DefaultValue( ValoresPadroes.QuantidadeMaxima )
        ]
        public uint QuantidadeMaxima
        {
            get
            {
                return ( uint ) MaxLength;
            }

            set
            {
                if ( value < _quantidadeMinima )
                {
                    MaxLength = ValoresPadroes.QuantidadeMaxima.ParaInt();
                    throw new ArgumentException( TextosPadroes.QuantidadeMaximaMenorQuantidadeMinima, $"Classe : {this.ToString()} - Parâmetro: {TextosPadroes.QuantidadeMaxima}" );
                }

                MaxLength = value.ParaInt();
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.ValidacaoCategoria ),
            DisplayName( TextosPadroes.QuantidadeMinima ),
            Description( TextosPadroes.QuantidadeMinimaDescricao ),
            DefaultValue( ValoresPadroes.QuantidadeMinima )
        ]
        public uint QuantidadeMinima
        {
            get
            {
                return _quantidadeMinima;
            }

            set
            {
                if ( value < 0 )
                {
                    _quantidadeMinima = 0;
                    throw new ArgumentException( TextosPadroes.QuantidadeMinimaMenorZero, $"Classe : {this.ToString()} - Parâmetro: {TextosPadroes.QuantidadeMinima}" );
                }

                if ( value > MaxLength )
                {
                    _quantidadeMinima = 0;
                    throw new ArgumentException( TextosPadroes.QuantidadeMinimaMaiorMaxLenght, $"Classe : {this.ToString()} - Parâmetro: {TextosPadroes.QuantidadeMinima}" );
                }

                _quantidadeMinima = value;
            }
        }

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

        #endregion ICaixaTexto

        #region ILimpeza

        [Browsable( true ), Category( TextosPadroes.DadosCateogria ), Description( TextosPadroes.FazerLimpezaDescricao ), DisplayName( TextosPadroes.FazerLimpeza ), DefaultValue( false )]
        public bool FazerLimpeza { get; set; } = false;

        #endregion ILimpeza

        #endregion Propriedades de Interface

        #endregion Propriedades

        #region Construtores

        public ToolStripCaixaNumero() : base()
        {
            TextBoxTextAlign = HorizontalAlignment.Center;
        }

        public ToolStripCaixaNumero( string name ) : base( name )
        {
        }

        public ToolStripCaixaNumero( Control c ) : base( c )
        {
        }

        #endregion Construtores

        #region Métodos Privados

        /// <summary>
        /// Verifica se um caractere é um número ou um sinal de negativo ( - ).
        /// </summary>
        /// <param name="caractere">Caractere que será verificado.</param>
        /// <returns>Retorna true se for número ou um sinal de negativo.</returns>
        private bool VerificarCaractereNumero( char caractere )
        {
            return caractere.Numero() || caractere == 8 || caractere == '\b';
        }

        /// <summary>
        /// Verifica se um string contem apenas números ou sinal de negativo ( - ).
        /// </summary>
        /// <param name="valor">Caractere que será verificado.</param>
        /// <returns>Retorna true se for número ou um sinal de negativo.</returns>
        private bool VerificarEntradaValorPadrao( string valor )
        {
            bool apenasValoresPermitidos = true;

            for ( int i = 0; i < valor.Length; i++ )
            {
                if ( i == 0 )
                {
                    if ( !( VerificarCaractereNumero( valor[ i ] ) || ( valor[ i ] == 45 ) ) )
                    {
                        apenasValoresPermitidos = false;
                        break;
                    }
                }
                else
                {
                    if ( !VerificarCaractereNumero( valor[ i ] ) )
                    {
                        apenasValoresPermitidos = false;
                        break;
                    }
                }
            }

            return apenasValoresPermitidos;
        }

        private bool ValidarValor()
        {
            return Valor >= ValorMinimo && Valor <= ValorMaximo;
        }

        #endregion Métodos Privados

        #region Métodos Públicos

        #region Métodos de Interface

        #region ICompnente

        public bool Validar()
        {
            return ValidarValor();
        }

        #endregion ICompnente

        #region ICaixaTexto

        public bool TemTexto()
        {
            return TextBox.Text.TemConteudo();
        }

        public void Limpar()
        {
            Clear();
        }

        #endregion ICaixaTexto

        #endregion Métodos de Interface

        #endregion Métodos Públicos
    }
}