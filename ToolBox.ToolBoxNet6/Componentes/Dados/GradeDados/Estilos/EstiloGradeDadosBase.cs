namespace ToolBox.ToolBoxWinForms.Net6.Componentes.Dados.GradeDados.Estilos
{
    public class EstiloGradeDadosBase : DataGridViewCellStyle
    {
        #region Propriedades

        #region Aparência

        [Browsable( true ), DisplayName( TextosPadroes.CorFundo )]
        public new Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        [Browsable( true ), DisplayName( TextosPadroes.CorFonte )]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        [Browsable( true ), DisplayName( TextosPadroes.CorFundo )]
        public new Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        [Browsable( true ), DisplayName( TextosPadroes.CorFundoSelecao )]
        public new Color SelectionBackColor
        {
            get { return base.SelectionBackColor; }
            set { base.SelectionBackColor = value; }
        }

        [Browsable( true ), DisplayName( TextosPadroes.CorFonteSelecao )]
        public new Color SelectionForeColor
        {
            get { return base.SelectionForeColor; }
            set { base.SelectionForeColor = value; }
        }

        [Browsable( true ), DisplayName( TextosPadroes.ValorNulo )]
        public new string Format
        {
            get { return base.Format; }
            set { base.Format = value; }
        }

        [Browsable( true ), DisplayName( TextosPadroes.CorFundo )]
        public new object NullValue
        {
            get { return base.NullValue; }
            set { base.NullValue = value; }
        }

        [Browsable( true ), DisplayName( TextosPadroes.CorFundo )]
        public new DataGridViewContentAlignment Alignment
        {
            get { return base.Alignment; }
            set { base.Alignment = value; }
        }

        [Browsable( true ), DisplayName( TextosPadroes.Preenchimento )]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }

        [Browsable( false )]
        public new DataGridViewTriState WrapMode
        {
            get { return base.WrapMode; }
            set { base.WrapMode = value; }
        }

        [Browsable( false )]
        public Color CorFundoGradeDados { get; set; }

        #endregion Aparência

        #endregion Propriedades

        #region Construtores

        protected EstiloGradeDadosBase( Color corFundo, Color corFonte, Color corFundoSelecao, Color corFonteSelecao )
        {
            BackColor = corFundo;
            ForeColor = corFonte;

            SelectionBackColor = corFundoSelecao;
            SelectionForeColor = corFonteSelecao;
        }

        public EstiloGradeDadosBase()
        {

        }

        #endregion Construtores
    }
}