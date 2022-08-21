namespace ToolBox.ToolBoxWinForms.Net6.Componentes.Dados.GradeDados.Estilos
{
    public class EstiloGradeDadosCinzaAlternativo : EstiloGradeDadosBase
    {
        #region Construtores

        public EstiloGradeDadosCinzaAlternativo() : base( Color.FromArgb( 200, 200, 200 ), Color.Black, Color.Gray, Color.White )
        {
            CorFundoGradeDados = Color.Silver;
        }

        #endregion Construtores
    }
}