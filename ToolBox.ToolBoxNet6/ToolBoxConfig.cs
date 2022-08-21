using ToolBox.ToolBoxWinForms.Net6.Componentes.Dados.GradeDados.Estilos;

namespace ToolBox.ToolBoxWinForms.Net6
{
    public static class ToolBoxConfig
    {
        #region Atributos

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

        #endregion Atributos

        #region Propriedades

        public static string TituloPadrao { get; set; } = string.Empty;

        public static Tema Tema { get; set; } = Tema.Branco;

        public static Font Fonte { get; set; }

        public static Color CorFundoJanela { get; set; }

        public static Color CorFundoGradeDados
        {
            get
            {
                return ObterCorFundoGradeDados();
            }
        }

        public static Color CorFundoDaGradeDaGradeDeDados
        {
            get
            {
                return ObterCorDaGradeDeGradeDeDados();
            }
        }

        public static EstiloGradeDadosBase EstiloGradeDados
        {
            get
            {
                return ObterEstiloDeGradeDeDados();
            }
        }

        public static EstiloGradeDadosBase EstiloGradeDadosAlternativo
        {
            get
            {
                return ObterEstiloDeGradeDeDadosAlternativo();
            }
        }

        #endregion Propriedades

        #region Métodos

        #region Privados

        private static Color ObterCorFundoGradeDados()
        {
            switch ( Tema )
            {
                default:
                case Tema.Branco:
                {
                    return Color.White;
                }

                case Tema.Cinza:
                {
                    return Color.Silver;
                }

                case Tema.Vermelho:
                {
                    return Color.FromArgb( 255, 204, 204 );
                }

                case Tema.Amarelo:
                {
                    return Color.PaleGoldenrod;
                }

                case Tema.Azul:
                {
                    return Color.LightBlue;
                }
            }
        }

        private static Color ObterCorDaGradeDeGradeDeDados()
        {
            switch ( Tema )
            {
                default:
                case Tema.Branco:
                {
                    return Color.DarkGray;
                }

                case Tema.Cinza:
                {
                    return SystemColors.ControlDark;
                }

                case Tema.Vermelho:
                {
                    return Color.IndianRed;
                }

                case Tema.Amarelo:
                {
                    return Color.Goldenrod;
                }

                case Tema.Azul:
                {
                    return Color.MidnightBlue;
                }
            }
        }

        private static EstiloGradeDadosBase ObterEstiloDeGradeDeDados()
        {
            switch ( Tema )
            {
                default:
                case Tema.Branco:
                {
                    return new EstiloGradeDadosBranco();
                }

                case Tema.Cinza:
                {
                    return new EstiloGradeDadosCinza();
                }

                case Tema.Vermelho:
                {
                    return new EstiloGradeDadosVermelho();
                }

                case Tema.Amarelo:
                {
                    return new EstiloGradeDadosAmarelo();
                }

                case Tema.Azul:
                {
                    return new EstiloGradeDadosAzul();
                }
            }
        }

        private static EstiloGradeDadosBase ObterEstiloDeGradeDeDadosAlternativo()
        {
            switch ( Tema )
            {
                default:
                case Tema.Branco:
                {
                    return new EstiloGradeDadosBrancoAlternativo();
                }

                case Tema.Cinza:
                {
                    return new EstiloGradeDadosCinzaAlternativo();
                }

                case Tema.Vermelho:
                {
                    return new EstiloGradeDadosVermelhoAlternativo();
                }

                case Tema.Amarelo:
                {
                    return new EstiloGradeDadosAmareloAlternativo();
                }

                case Tema.Azul:
                {
                    return new EstiloGradeDadosAzulAlternativo();
                }
            }
        }

        #endregion Privados

        #endregion Métodos
    }
}