namespace ToolBox.Botao
{
    [DesignerCategory( "Botão Flat" ), ToolboxItem( true )]
    public class BotaoFlat : BotaoBase
    {
        #region Atributos

        private Tema _tema = Tema.Branco;

        #endregion Atributos

        #region Propriedades

        #region Ocultadas

        [Browsable( false )]
        public new FlatStyle FlatStyle
        {
            get { return base.FlatStyle; }
            set { base.FlatStyle = value; }
        }

        #endregion Ocultadas

        #region Aparência

        //internal Tema Tema
        //{
        //    get
        //    {
        //        return _tema;
        //    }

        //    set
        //    {
        //        re
        //    }
        //}

        #endregion Aparência

        #endregion Propriedades

        #region Construtores

        public BotaoFlat( IContainer container ) : base( container )
        {
            FlatStyle = FlatStyle.Flat;
        }

        #endregion Construtores

        #region Métodos

        #region Privados

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Privados

        #region Protegidos

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Protegidos

        #region Internos

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Internos

        #endregion Métodos
    }
}