using MyGears.Components.Datas.Base;

namespace MyGears.Components.Datas.DataGrid.DataGridStyles
{
    public class DataGridGrayStyle : DataGridStyleBase
    {
        #region Construtores

        public DataGridGrayStyle() : base( Color.Gainsboro, Color.Black, Color.Gray, Color.White )
        {
            CorFundoGradeDados = Color.Silver;
        }

        #endregion Construtores
    }
}