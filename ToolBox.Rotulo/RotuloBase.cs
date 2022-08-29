using ToolBox.Geral.Interfaces;

namespace ToolBox.Geral.Componentes.Rotulos.Base
{
    [DesignerCategory( "Rotulos" ), ToolboxItem( false )]
    public class RotuloBase : Label, IComponente
    {
        #region Atributos



        #endregion Atributos

        #region Propriedades

        [Browsable( true ), DisplayName( TextosPadroes.BloquearComponente ), Description( TextosPadroes.BloquearComponenteDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
        public bool BloquearComponente { get; set; } = false;

        [Browsable( true ), DisplayName( TextosPadroes.Bloqueado ), Description( TextosPadroes.BloqueadoDescricao ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( true )]
        public bool Bloqueado
        {
            set
            {
                Enabled = !value;
            }
        }

        #endregion Propriedades

        #region Construtores

        public RotuloBase( IContainer container )
        {
            if ( container != null )
            {
                container.Add( this );
            }
        }

        #endregion Construtores

        #region Métodos

        #region Privados



        #endregion Privados

        #region Protegidos



        #endregion Protegidos

        #region Internos



        #endregion Internos

        #region Públicos

        public Point ObterPontoCentral()
        {
            throw new NotImplementedException();
        }

        #endregion Públicos

        #endregion Métodos
    }
}