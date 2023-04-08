using ToolBox.Datas.Base;

namespace ToolBox.Datas.DataGrid.DataGridStyles
{
    public class DataGridWhiteStyle : DataGridStyleBase
    {
        #region Construtores

        public DataGridWhiteStyle() : base(Color.White, Color.Black, SystemColors.Highlight, SystemColors.HighlightText)
        {
            CorFundoGradeDados = Color.White;
        }

        #endregion Construtores
    }
}