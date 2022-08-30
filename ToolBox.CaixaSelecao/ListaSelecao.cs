namespace ToolBox.ListaSelecao
{
    public class ListaSelecao : ListaSelecaoBase
    {
        #region Construtores

        public ListaSelecao( IContainer container ) : base( container )
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            FlatStyle = FlatStyle.System;
        }

        #endregion Construtores
    }
}