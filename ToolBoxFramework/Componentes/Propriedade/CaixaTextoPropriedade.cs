using BibliotecaPublica.CaixaFerramenta.Interfaces;
using BibliotecaPublica.Estruturas;
using CaixaFerramenta.Componentes.Bases;
using System;
using System.ComponentModel;

namespace BibliotecaPublica.CaixaFerramenta.Componentes.Propriedade
{
    [DesignerCategory( "Propriedades" ), ToolboxItem( true )]
    public class CaixaTextoPropriedade : CaixaTextoBase, IPropriedade
    {
        #region Propriedades

        #region Públicas

        #region Sobreescritas

        public new string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
                AlterarValorPropriedade();
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
                return Text;
            }
            set
            {
                Text = value;
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

        public CaixaTextoPropriedade( IContainer container ) : base( container )
        {
            if ( container != null )
            {
                container.Add( this );
            }
        }

        protected override void OnTextChanged( EventArgs e )
        {
            base.OnTextChanged( e );

            if ( !DesignMode )
            {
                AlterarValorPropriedade();
            }
        }

        public void AlterarValorPropriedade()
        {
            AoAlterarPropriedade( Codigo, ValorPropriedade );
        }
    }
}