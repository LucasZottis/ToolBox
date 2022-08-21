using System.ComponentModel;
using ToolBox.ToolBoxWinForms.Framework.Componentes.Dados.Base;

namespace ToolBox.ToolBoxWinForms.Framework.Componentes.Dados
{
    [DesignerCategory( "Dados" ), ToolboxItem( true )]
    public class NavegadorDados : NavegadorBase
    {
        #region Atributos

        private FonteDados _fonteDados;

        #endregion Atributos

        #region Propriedades



        #endregion Propriedades

        #region Construtores

        public NavegadorDados()
        {
        }

        public NavegadorDados( BindingSourceBase fontaDados ) : base( fontaDados )
        {
        }

        public NavegadorDados( IContainer container ) : base( container )
        {
        }

        public NavegadorDados( bool adicionarItensPadroes ) : base( adicionarItensPadroes )
        {
        }

        #endregion Construtores

        #region Privados



        #endregion Privados

        #region Protegidos

        protected override void EncerrarInicializacao()
        {
            base.EncerrarInicializacao();

            if ( _fonteDados != null )
            {
                _fonteDados.ListChanged += new ListChangedEventHandler( ( object acionador, ListChangedEventArgs argumentos ) => { RefreshItemsCore(); } );
            }

            AtualizarItens();
        }

        #endregion Protegidos

        #region Públicos



        #endregion Públicos
    }
}