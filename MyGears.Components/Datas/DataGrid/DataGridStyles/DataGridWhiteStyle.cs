using MyGears.Components.Datas.Base;

namespace MyGears.Components.Datas.DataGrid.DataGridStyles
{
    public class DataGridWhiteStyle : DataGridStyleBase
    {
        #region Construtores

        public DataGridWhiteStyle() : base( Color.White, Color.Black, SystemColors.Highlight, SystemColors.HighlightText )
        {
            CorFundoGradeDados = Color.White;
        }

        #endregion Construtores
    }
}