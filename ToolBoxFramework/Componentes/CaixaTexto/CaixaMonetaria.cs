using BibliotecaPublica.CaixaFerramenta.Componentes;
using BibliotecaPublica.Classes.Servicos.Conversores;
using BibliotecaPublica.Classes.Verificadores;
using BibliotecaPublica.Estruturas;
using BibliotecaPublica.Interfaces;
using CaixaFerramenta.Componentes.Bases;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CaixaFerramenta.Componentes.CaixaTexto
{
    [DesignerCategory( "Caixa de Texto" ), ToolboxItem( true )]
    public class CaixaMonetaria : CaixaTextoBase, ICaixaMonetaria
    {
        #region Atributos

        private bool _virgulaDigitada = false;
        private bool _atingiuMaximoCasasDecimais = false;
        private uint _casasDecimais = 0;

        private decimal _valorMaximo = ValoresPadroes.ValorMaximoMonetario;
        private decimal _valorMinimo = ValoresPadroes.ValorMinimoMonetario;
        private decimal _valor = ValoresPadroes.ValorPadraoMonetario;

        #endregion Atributos

        #region Propriedades

        #region Sobreescritas

        [Browsable( false )]
        public new string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                //if (!Focused)
                //{
                //    value = AplicarRegrasValorMonetario(value);
                //}

                base.Text = value;
            }
        }

        [Browsable( false )]
        public new HorizontalAlignment TextAlign
        {
            get
            {
                return base.TextAlign;
            }

            set
            {
                base.TextAlign = value;
            }
        }

        //[Browsable(false)]
        //public new uint QuantidadeMinima
        //{
        //    get
        //    {
        //        return base.QuantidadeMinima;
        //    }

        //    set
        //    {
        //        base.QuantidadeMinima = value;
        //    }
        //}

        [Browsable( false )]
        public new int MaxLength
        {
            get
            {
                return base.MaxLength;
            }

            set
            {
                base.MaxLength = value;
            }
        }

        #endregion Sobreescritas

        [
            Browsable( true ),
            Category( TextosPadroes.DadosCateogria ),
            DisplayName( TextosPadroes.ValorMaximo ),
            Description( TextosPadroes.ValorMaximoDescricao ),
            DefaultValue( ( double ) ValoresPadroes.ValorMaximoMonetario )
        ]
        public decimal ValorMaximo
        {
            get
            {
                return _valorMaximo;
            }

            set
            {
                if ( value < _valorMinimo )
                {
                    _valorMaximo = long.MaxValue;

                    throw new ArgumentException( "Valor máximo não pode ser menor que o valor mínimo definido." );
                }
                else if ( value > long.MaxValue )
                {
                    _valorMaximo = long.MaxValue;
                }
                else
                {
                    _valorMaximo = value;
                }
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.DadosCateogria ),
            DisplayName( TextosPadroes.ValorMinimo ),
            Description( TextosPadroes.ValorMinimoDescricao ),
            DefaultValue( ( double ) ValoresPadroes.ValorMinimoMonetario )
        ]
        public decimal ValorMinimo
        {
            get
            {
                return _valorMinimo;
            }

            set
            {
                if ( value > _valorMaximo )
                {
                    _valorMinimo = long.MinValue;

                    throw new ArgumentException( "Valor mínimo não pode ser maior que o valor máximo definido." );
                }
                else if ( value < long.MinValue )
                {
                    _valorMinimo = long.MinValue;
                }
                else
                {
                    _valorMinimo = value;
                }
            }
        }

        [
            Browsable( false ),
            Category( TextosPadroes.DadosCateogria ),
            DisplayName( TextosPadroes.Valor ),
            Description( TextosPadroes.ValorDescricao ),
            DefaultValue( ( double ) ValoresPadroes.ValorPadraoMonetario )
        ]
        public decimal Valor
        {
            get
            {
                return Text.ParaDecimal();
            }

            set
            {
                Text = _valor.ToString( "N2" );
            }
        }

        #endregion Propriedades

        #region Construtores

        public CaixaMonetaria( IContainer container ) : base( container )
        {
            TextAlign = HorizontalAlignment.Right;
        }

        #endregion Construtores

        #region Métodos Privados

        private int ObterQuantidadeCasasDecimais()
        {
            int indiceVirgula = Text.IndexOf( ',' );

            if ( indiceVirgula.Igual( -1 ) )
            {
                return 0;
            }

            return ( Text.Length - indiceVirgula ) - 2;
        }

        private bool CursorEstaDepoisVirgula()
        {
            int indiceVirgula = Text.IndexOf( ',' );

            if ( indiceVirgula.Igual( -1 ) )
            {
                return false;
            }

            return indiceVirgula < SelectionStart;
        }

        private bool CursorEstaAposVirgula()
        {
            int indiceVirgula = Text.IndexOf( ',' );

            if ( indiceVirgula.Igual( -1 ) )
            {
                return false;
            }

            return ( indiceVirgula + 1 ) == SelectionStart;
        }

        private bool CursorEstaAtrasVirgula()
        {
            int indiceVirgula = Text.IndexOf( ',' );

            if ( indiceVirgula.Igual( -1 ) )
            {
                return true;
            }

            if ( SelectionStart.Igual( 0 ) )
            {
                return true;
            }

            return ( SelectionStart - 1 ) < indiceVirgula;
        }

        private void AoAlterarValorMaximo()
        {

        }

        #endregion Métodos Privados

        #region Métodos Sobrescritos

        protected override void OnKeyPress( KeyPressEventArgs e )
        {
            base.OnKeyPress( e );
            e.Handled = !ValidarValorDigitado( e.KeyChar );
        }

        protected override void OnGotFocus( EventArgs e )
        {
            base.OnGotFocus( e );
            SelectAll();
        }

        protected override void OnLostFocus( EventArgs e )
        {
            base.OnLostFocus( e );
            Text = AplicarRegrasValorMonetario( Text );
        }

        #endregion Métodos Sobrescritos

        #region Métodos Públicos

        #region Interface

        #region ICaixaMonetaria

        /// <summary>
        /// Verifica se um caractere é um número, um sinal de negativo ( - ), umas vírgula ou um backspace.
        /// </summary>
        /// <param name="caractere">Caractere que será verificado.</param>
        /// <returns>Retorna true se for algum valor válido.</returns>
        public bool ValidarValorDigitado( char caractere )
        {
            bool permitirEntrada = true;

            if ( !( caractere.Numero() || caractere.Igual( ',' ) || caractere.Igual( '\b' ) ) )
            {
                return false;
            }
            else
            {
                if ( caractere.Igual( ',' ) )
                {
                    //Mensagem.Informar(_virgulaDigitada.ToString());

                    permitirEntrada = !_virgulaDigitada;
                    _virgulaDigitada = true;
                }
                else
                {
                    bool textoTodoSelecionado = SelectionLength == Text.Length;
                    bool temEspacoDecimal = ObterQuantidadeCasasDecimais().ValorMenor( 2 ) && _casasDecimais < 2;

                    bool apagando = caractere.Igual( TeclasEspeciais.Apagar );

                    bool apagandoNumeroInteiro = CursorEstaAtrasVirgula();
                    bool apagandoVirgula = _virgulaDigitada && CursorEstaAposVirgula();
                    bool apagandoNumeroDecimal = _virgulaDigitada && CursorEstaDepoisVirgula();

                    if ( apagando )
                    {
                        if ( textoTodoSelecionado ) // Se estiver apagando todo o texto.
                        {
                            _virgulaDigitada = false;
                            _casasDecimais = 0;
                        }
                        else if ( apagandoNumeroInteiro ) // Se estiver apagando números inteiros.
                        {
                            permitirEntrada = true;
                        }
                        else if ( apagandoVirgula ) // Se estiver apagando a vírgula.
                        {
                            _virgulaDigitada = false;
                            _casasDecimais = 0;
                        }
                        else if ( apagandoNumeroDecimal ) // Se estiver números decimais.
                        {
                            _casasDecimais--;
                        }
                    }
                    else if ( CursorEstaAtrasVirgula() ) // Se estiver digitando um número atrás da virgula.
                    {
                        permitirEntrada = true;
                    }
                    else if ( _virgulaDigitada && temEspacoDecimal ) // Se estiver digitando um número após a vírgula.
                    {
                        _casasDecimais++;
                    }
                    else if ( !temEspacoDecimal ) // Se não houver mais espaço para casas decimais.
                    {
                        permitirEntrada = false;
                    }
                }

                return permitirEntrada;
            }
        }

        public string AplicarRegrasValorMonetario( string valorSemRegras )
        {
            string valor = valorSemRegras;

            if ( !TemTexto() ) // Se não tiver texto no campo.
            {
                valor = "0,00";
                _casasDecimais = 2;
                _virgulaDigitada = true;
            }
            else
            {
                if ( Text.TamanhoIgual( 1 ) && Text.Contem( ',' ) ) // Se tiver apenas a vírgula no campo.
                {
                    valor = "0,00";
                    _casasDecimais = 2;
                    _virgulaDigitada = true;
                }
                else if ( !Text.Contem( ',' ) ) // Se tiver apenas número inteiros no campo.
                {
                    valor += ",00";
                    _casasDecimais = 2;
                    _virgulaDigitada = true;
                }
                else if ( Text.TamanhoMaior( 1 ) ) // Se tiver número inteiros e vírgula, porém sem números decimais.
                {
                    if ( Text[ 0 ].Igual( ',' ) )
                    {
                        valor = valor.Insert( 0, "0" );

                        if ( _casasDecimais == 1 )
                        {
                            valor += "0";
                            _casasDecimais = 2;
                        }
                    }
                    else
                    {
                        switch ( _casasDecimais )
                        {
                            case 0:
                            {
                                valor += "00";
                                break;
                            }

                            case 1:
                            {
                                valor += "0";
                                break;
                            }
                        }

                        _casasDecimais = 2;
                    }
                }
            }

            valorSemRegras = valor;

            return valorSemRegras;
        }

        #endregion ICaixaMonetaria

        #endregion Interface

        #endregion Métodos Públicos
    }
}