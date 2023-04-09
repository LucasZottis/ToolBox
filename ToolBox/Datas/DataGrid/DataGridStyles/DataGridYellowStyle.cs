using ToolBox.Datas.Base;

namespace ToolBox.Datas.DataGrid.DataGridStyles
{
    public class DataGridYellowStyle
        : DataGridStyleBase
    {
        #region Construtores

        public DataGridYellowStyle() : base(Color.FromArgb(245, 238, 188), Color.Black, Color.FromArgb(255, 252, 132), Color.Black)
        {
            CorFundoGradeDados = Color.PaleGoldenrod;
        }

        #endregion Construtores
    }
}