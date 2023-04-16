using MyGears.Components.Datas.Base;

namespace MyGears.Components.Datas.DataGrid.DataGridStyles.Alternatives
{
    public class DataGridAlternativeGrayStyle : DataGridStyleBase
    {
        #region Construtores

        public DataGridAlternativeGrayStyle() : base( Color.FromArgb( 200, 200, 200 ), Color.Black, Color.Gray, Color.White )
        {
            CorFundoGradeDados = Color.Silver;
        }

        #endregion Construtores
    }
}