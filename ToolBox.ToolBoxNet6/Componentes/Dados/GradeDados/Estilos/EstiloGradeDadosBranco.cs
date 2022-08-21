namespace ToolBox.ToolBoxWinForms.Net6.Componentes.Dados.GradeDados.Estilos
{
    public class EstiloGradeDadosBranco : EstiloGradeDadosBase
    {
        #region Construtores

        public EstiloGradeDadosBranco() : base( Color.White, Color.Black, SystemColors.Highlight, SystemColors.HighlightText )
        {
            CorFundoGradeDados = Color.White;
        }

        #endregion Construtores
    }
}