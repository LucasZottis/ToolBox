namespace ToolBox.CaixaSelecao
{
    public class CaixaSelecao : CaixaSelecaoBase
    {
        #region Construtores

        public CaixaSelecao( IContainer container ) : base( container )
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            FlatStyle = FlatStyle.System;
        }

        #endregion Construtores
    }
}