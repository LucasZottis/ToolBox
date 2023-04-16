using MyGears.Components.Datas.Base;

namespace MyGears.Components.Datas.DataGrid.DataGridStyles.Alternatives
{
    public class DataGridAlternativeWhiteStyle : DataGridStyleBase
    {
        #region Construtores

        public DataGridAlternativeWhiteStyle() : base( Color.Snow, Color.Black, SystemColors.Highlight, SystemColors.HighlightText )
        {
            CorFundoGradeDados = Color.White;
        }

        #endregion Construtores
    }
}