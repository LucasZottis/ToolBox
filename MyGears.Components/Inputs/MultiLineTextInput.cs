namespace MyGears.Components.Inputs
{
    [DesignerCategory( "Caixa de Texto" ), ToolboxItem( true )]
    public class MultiLineTextInput
        : TextInput
    {
        #region Atributos

        private int _previousLines = 1;

        #endregion Atributos

        #region Propriedades

        [Browsable( true )]
        public new ScrollBars ScrollBars
        {
            get
            {
                return base.ScrollBars;
            }

            set
            {
                base.ScrollBars = value;
            }
        }

        #endregion Propriedades

        #region Construtores

        public MultiLineTextInput( IContainer container ) : base( container )
        {
            Multiline = true;
            ScrollBars = ScrollBars.Both;
        }

        #endregion Construtores

        #region Métodos

        #region Protegidos

        protected override void OnTextChanged( EventArgs e )
        {
            base.OnTextChanged( e );

            //int size = Font.Height;
            //int lineas = Lines.Length;
            //int newlines = 0;

            //if ( Text.Contains( Environment.NewLine ) )
            //{
            //    newlines = Text.Split( new string[] { Environment.NewLine }, StringSplitOptions.None ).Length - 1;
            //    lineas += newlines - ( Lines.Length - 1 );
            //}

            //for ( int line_num = 0; line_num < Lines.Length; line_num++ )
            //{
            //    if ( Lines[ line_num ].Length > 1 )
            //    {
            //        int pos1 = GetFirstCharIndexFromLine( line_num );
            //        int pos2 = pos1 + Lines[ line_num ].Length - 1;
            //        int y1 = GetPositionFromCharIndex( pos1 ).Y;
            //        int y2 = GetPositionFromCharIndex( pos2 ).Y;

            //        if ( y1 != y2 )
            //        {
            //            int aux = y2 + size;
            //            lineas = ( aux / size );

            //            if ( y1 != 1 )
            //            {
            //                lineas++;
            //            }

            //            lineas += newlines - ( Lines.Length - 1 );
            //        }
            //    }
            //}

            //if ( lineas > _previousLines )
            //{
            //    _previousLines++;
            //    Height = Height + size;
            //}
            //else if ( lineas < _previousLines )
            //{
            //    _previousLines--;
            //    Height = Height - size;
            //}
        }

        #endregion Protegidos

        #region Internos

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Internos

        #endregion Métodos
    }
}