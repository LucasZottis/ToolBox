using System.ComponentModel;
using ToolBox.ToolBoxFramework.Componentes.Dados.Base;

namespace ToolBox.ToolBoxFramework.Componentes.Dados
{
    [DesignerCategory( "Dados" )]
    public class NavegadorDados : NavegadorBase
    {
        #region Atributos

        private FonteDados _fonteDados;

        #endregion Atributos

        #region Propriedades



        #endregion Propriedades

        #region Construtores



        #endregion Construtores

        #region Privados



        #endregion Privados

        #region Protegidos

        protected override void EncerrarInicializacao()
        {
            base.EncerrarInicializacao();
            _fonteDados.ListChanged += new ListChangedEventHandler( ( object acionador, ListChangedEventArgs argumentos ) => { RefreshItemsCore(); } );

            AtualizarItens();
        }

        #endregion Protegidos

        #region Públicos



        #endregion Públicos
    }
}