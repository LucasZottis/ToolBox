using BibliotecaPublica.Classes.Servicos.Conversores;
using BibliotecaPublica.Classes.Verificadores;
using BibliotecaPublica.Enums;
using BibliotecaPublica.Estruturas;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ToolBox.ToolBoxFramework.Componentes.Bases;
using ToolBox.ToolBoxFramework.Interfaces;

namespace ToolBox.ToolBoxFramework.Componentes.CaixaTexto
{
    [DesignerCategory( "Caixa de Texto" ), ToolboxItem( true )]
    public class CaixaNumero : CaixaTextoBase, ICaixaNumero
    {
        #region Atributos

        private long _valorMaximo = long.MaxValue;
        private long _valorMinimo = long.MinValue;

        private TipoDado _tipoValor = TipoDado.Int;

        #endregion Atributos

        #region Propriedades

        #region Propriedades Sobreescritas

        [Browsable( false )]
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

        #endregion Propriedades Sobreescritas

        #region Propriedades de Interface

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

        #endregion Propriedades de Interface

        #endregion Propriedades

        #region Construtores

        public CaixaNumero( IContainer container ) : base( container )
        {
            MaxLength = 120000;
            TextAlign = HorizontalAlignment.Center;
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

        #endregion Métodos Privados

        #region Métodos Sobrescritos

        protected override void OnKeyPress( KeyPressEventArgs e )
        {
            if ( Text.Length == 0 )
            {
                if ( VerificarCaractereNumero( e.KeyChar ) || e.KeyChar == 45 )
                {
                    base.OnKeyPress( e );
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                if ( VerificarCaractereNumero( e.KeyChar ) )
                {
                    base.OnKeyPress( e );
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        #endregion Métodos Sobrescritos

        #region Protegidos

        protected virtual void AoAlterarValor()
        {

        }

        #endregion Protegidos
    }
}