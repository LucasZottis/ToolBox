namespace MyGears.Components;

public static class ToolBoxEnvironment
{
    #region Temas

    #region Branco padrão

    /*
     * Tema amarelado
     * Fundo: White
     * 
     * Padrão grade de dados
     *
     * Fundo linha: White
     * Fonte linha: Preto
     * Fundo Seleção: Highlight
     * Fonte Seleção: HighlightText
     *
     * Padrão grade de dados alternativo
     * 
     * Fundo linha: snow
     * Fonte linha: Preto
     * Fundo Seleção: Highlight
     * Fonte Seleção: HighlightText
    */

    #endregion Branco padrão

    #region Cinza

    /*
     * Tema Cinza
     * Fundo: Silver
     * 
     * Padrão grade de dados
     *
     * Fundo linha: Gainsboro
     * Fonte linha: Black
     * Fundo Seleção: Gray
     * Fonte Seleção: White
     *
     * Padrão grade de dados alternativo
     * 
     * Fundo linha: LightGray
     * Fonte linha: Black
     * Fundo Seleção: Gray
     * Fonte Seleção: White
    */

    #endregion Cinza

    #region Vermelho

    /*
    * Tema Vermelho
    * Fundo: R:255; G:204; B:204
    * 
    * Padrão grade de dados
    *
    * Fundo linha: R:255; G:180; B:180
    * Fonte linha: Black
    * Fundo Seleção: Red
    * Fonte Seleção: White
    *
    * Padrão grade de dados alternativo
    * 
    * Fundo linha: R:255; G:140; B:140
    * Fonte linha: Black
    * Fundo Seleção: Red
    * Fonte Seleção: White
    */

    #endregion Vermelho

    #region Amarelo

    /*
     * Tema amarelado
     * Fundo: PaleGoldenRod
     * 
     * Padrão grade de dados
     *
     * Fundo linha: Beige
     * Fonte linha: Black
     * Fundo Seleção: R:213; G:213; B:106
     * Fonte Seleção: Black
     * 
     * Padrão grade de dados alternativo
     * 
     * Fundo linha: PaleGoldenRod
     * Fundo linha: Beige
     * Fundo Seleção: R:213; G:213; B:106
     * Fonte Seleção: Black
    */

    #endregion

    #region Azul

    /*
    * Tema Azul
    * Fundo: LightBlue
    * 
    * Padrão grade de dados
    *
    * Fundo linha: R:160; G:210; B:226
    * Fonte linha: Black
    * Fundo Seleção: Blue
    * Fonte Seleção: White
    *
    * Padrão grade de dados alternativo
    * 
    * Fundo linha: B:145; B:202; B:221
    * Fonte linha: Black
    * Fundo Seleção: Blue
    * Fonte Seleção: White
    */

    #endregion Azul

    #endregion Temas

    /// <summary>
    /// Nome do aplicativo.
    /// É usado para mostrar nos títulos das janelas.
    /// O padrão é a informação é <see cref="Application.ProductName"/>
    /// </summary>
    public static string AppName { get; set; } = Application.ProductName;

    /// <summary>
    /// Define o tema para a aplicação.
    /// </summary>
    public static Theme Theme { get; set; } = Theme.White;

    /// <summary>
    /// Fonte padrão utilizada para todos os componentes.
    /// </summary>
    public static Font GeneralFont { get; set; } = new Font( new FontFamily( "Roboto" ), 12F );

    public static Color BackgroundColor { get; set; }

    public static Color DataGridBackgroundColor
        => GetDataGridBackgroundColor();

    //public static Color CorFundoDaGradeDaGradeDeDados
    //    => ObterCorDaGradeDeGradeDeDados();

    public static DataGridStyleBase DataGridStyle
        => ObterEstiloDeGradeDeDados();

    public static DataGridStyleBase DataGridAlternativeStyle
        => ObterEstiloDeGradeDeDadosAlternativo();

    private static Color GetDataGridBackgroundColor()
    {
        switch ( Theme )
        {
            default:
            case Theme.White:
                return Color.White;
            case Theme.Gray:
                return Color.Silver;
            case Theme.Red:
                return Color.FromArgb( 255, 204, 204 );
            case Theme.Yellow:
                return Color.PaleGoldenrod;
            case Theme.Blue:
                return Color.LightBlue;
        }
    }

    //private static Color ObterCorDaGradeDeGradeDeDados()
    //{
    //    switch ( Theme )
    //    {
    //        default:
    //        case Tema.Branco:
    //            return Color.DarkGray;
    //        case Tema.Cinza:
    //            return SystemColors.ControlDark;
    //        case Tema.Vermelho:
    //            return Color.IndianRed;
    //        case Tema.Amarelo:
    //            return Color.Goldenrod;
    //        case Tema.Azul:
    //            return Color.MidnightBlue;
    //    }
    //}

    private static DataGridStyleBase ObterEstiloDeGradeDeDados()
    {
        switch ( Theme )
        {
            default:
            case Theme.White:
                return new DataGridWhiteStyle();

            case Theme.Gray:
                return new DataGridGrayStyle();

            case Theme.Red:
                return new DataGridRedStyle();

            case Theme.Yellow:
                return new DataGridYellowStyle();

            case Theme.Blue:
                return new DataGridBlueStyle();
        }
    }

    private static DataGridStyleBase ObterEstiloDeGradeDeDadosAlternativo()
    {
        switch ( Theme )
        {
            default:
            case Theme.White:
                return new DataGridAlternativeWhiteStyle();
            case Theme.Gray:
                return new DataGridAlternativeGrayStyle();
            case Theme.Red:
                return new DataGridAlternativeRedStyle();
            case Theme.Yellow:
                return new DataGridAlternativeYellowStyle();
            case Theme.Blue:
                return new DataGridAlternativeBlueStyle();
        }
    }
}