using ToolBox.Datas.Base;

namespace ToolBox.Datas.DataGrid.DataGridStyles.Alternatives
{
    public class DataGridAlternativeYellowStyle : DataGridStyleBase
    {
        #region Construtores

        public DataGridAlternativeYellowStyle() : base(Color.FromArgb(239, 227, 148), Color.Black, Color.FromArgb(255, 252, 132), Color.Black)
        {
            CorFundoGradeDados = Color.PaleGoldenrod;
        }

        #endregion Construtores
    }
}