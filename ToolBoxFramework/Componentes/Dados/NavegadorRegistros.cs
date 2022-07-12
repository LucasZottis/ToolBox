using System.ComponentModel;
using System.Data;
using ToolBox.ToolBoxFramework.Componentes.Dados.Base;

namespace ToolBox.ToolBoxFramework.Componentes.Dados
{
    [DesignerCategory( "Dados" )]
    public class NavegadorRegistros : NavegadorBase
    {
        #region Atributos

        private DataRow _dataRow = null;
        private FonteLigacao _fonteLigacao;

        #endregion Atributos

        #region Propriedades



        #endregion Propriedades

        #region Construtores

        public NavegadorRegistros()
        {
        }

        public NavegadorRegistros( BindingSourceBase fontaDados ) : base( fontaDados )
        {
        }

        public NavegadorRegistros( IContainer container ) : base( container )
        {
        }

        public NavegadorRegistros( bool adicionarItensPadroes ) : base( adicionarItensPadroes )
        {
        }

        #endregion Construtores

        #region Privados



        #endregion Privados

        #region Públicos



        #endregion Públicos
    }
}