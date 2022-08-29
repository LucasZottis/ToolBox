namespace ToolBox.Geral.Estilos
{
    public class EstiloGradeDadosBrancoAlternativo : EstiloGradeDadosBase
    {
        #region Construtores

        public EstiloGradeDadosBrancoAlternativo() : base( Color.Snow, Color.Black, SystemColors.Highlight, SystemColors.HighlightText )
        {
            CorFundoGradeDados = Color.White;
        }

        #endregion Construtores
    }
}