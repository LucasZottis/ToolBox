namespace ToolBox.Geral.Componentes.Dados.GradeDados.Estilos
{
    public class EstiloGradeDadosAmarelo : EstiloGradeDadosBase
    {
        #region Construtores

        public EstiloGradeDadosAmarelo() : base( Color.FromArgb( 245, 238, 188 ), Color.Black, Color.FromArgb( 255, 252, 132 ), Color.Black )
        {
            CorFundoGradeDados = Color.PaleGoldenrod;
        }

        #endregion Construtores
    }
}