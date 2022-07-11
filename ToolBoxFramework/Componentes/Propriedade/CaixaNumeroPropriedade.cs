using BibliotecaPublica.CaixaFerramenta.Interfaces;
using BibliotecaPublica.Classes.Servicos.Conversores;
using BibliotecaPublica.Estruturas;
using CaixaFerramenta.Componentes.CaixaTexto;
using System;
using System.ComponentModel;

namespace BibliotecaPublica.CaixaFerramenta.Componentes.Propriedade
{
    public class CaixaNumeroPropriedade : CaixaNumero, IPropriedade
    {
        #region Atributos



        #endregion Atributos

        #region Propriedades

        #region Públicas

        #region Sobreescritas

        public new int Valor
        {
            get
            {
                return base.Valor;
            }

            set
            {
                base.Valor = value;

                AoAlterarValor();
            }
        }

        #endregion Sobreescritas

        #region IPropriedade

        [Browsable( false )]
        public int Codigo
        {
            get;
            set;
        }

        [
            Browsable( true ),
            Category( TextosPadroes.PropriedadeCategoria ),
            Description( TextosPadroes.NomePropriedade ),
            DisplayName( TextosPadroes.NomePropriedadeDescricao ),
            DefaultValue( "" )
        ]
        public string NomePropriedade
        {
            get;
            set;
        }

        [
            Browsable( true ),
            Category( TextosPadroes.PropriedadeCategoria ),
            Description( TextosPadroes.DescricaoPropriedadeDescricao ),
            DisplayName( TextosPadroes.DescricaoPropriedade ),
            DefaultValue( "" )
        ]
        public string DescricaoPropriedade
        {
            get;
            set;
        }

        [
            Browsable( true ),
            Category( TextosPadroes.PropriedadeCategoria ),
            Description( TextosPadroes.TipoPropriedadeDescricao ),
            DisplayName( TextosPadroes.TipoPropriedade ),
            DefaultValue( "" )
        ]
        public string TipoPropriedade
        {
            get;
            set;
        }

        [Browsable( false )]
        public string ValorPropriedade
        {
            get
            {
                return Valor.ToString();
            }

            set
            {
                Valor = value.ParaInt();
            }
        }

        [Browsable( false )]
        public Action<int, string> AoAlterarPropriedade
        {
            get; set;
        }

        #endregion IPropriedade

        #endregion Públicas

        #endregion Propriedades

        #region Construtores

        public CaixaNumeroPropriedade( IContainer container ) : base( container )
        {

        }

        #endregion Construtores

        #region Métodos

        #region Privados

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Privados

        #region Protegidos

        #region Sobreescritos

        protected override void AoAlterarValor()
        {
            AlterarValorPropriedade();
        }

        #endregion Sobreescritos



        #endregion Protegidos

        #region Internos

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Internos

        #region Públicos

        #region IPropriedade

        public void AlterarValorPropriedade()
        {
            if ( AoAlterarPropriedade != null )
            {
                AoAlterarPropriedade( Codigo, ValorPropriedade );
            }
        }

        #endregion IPropriedade

        #endregion Públicos

        #endregion Métodos
    }
}