namespace ToolBox.Buttons;

[DesignerCategory( "Botão Flat" ), ToolboxItem( true )]
public class FlatButton
    : ButtonBase
{
    private Theme _theme = Theme.White;
    private FlatButtonStyle _flatButtonStyle = FlatButtonStyle.Default;

    [Browsable( false )]
    public new FlatStyle FlatStyle
    {
        get { return base.FlatStyle; }
        set { base.FlatStyle = value; }
    }

    [Browsable( true ), DisplayName( "Estilo" ), Description( "Define ou obtém o estilo do botão. Esse estilo sobrepõe o tema definido." ), Category( TextosPadroes.AparenciaCategoria ), DefaultValue( FlatButtonStyle.Default )]
    public FlatButtonStyle FlatButtonStyle
    {
        get => _flatButtonStyle;
        set
        {
            _flatButtonStyle = value;
            OnSetFlatButtonStyle();
        }
    }

    public new string Text
    {
        get => base.Text;
        set
        {
            if ( _flatButtonStyle != FlatButtonStyle.Default )
                throw new InvalidOperationException( "Não é possível alterar o texto do botão pois tem um estilo para esse botão." );

            base.Text = value;
        }
    }

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

    public FlatButton( IContainer container )
        : base( container )
    {
        FlatStyle = FlatStyle.Flat;
    }

    private void SetConfirmStyle( FlatButtonAppearance appearance )
    {
        BackColor = Color.Green;

        appearance.BorderColor = BackColor;
        appearance.BorderSize = 2;
        appearance.MouseDownBackColor = Color.DarkGreen;
        appearance.MouseOverBackColor = Color.LimeGreen;

        base.Text = "Confirmar";
    }

    private void SetCancelStyle( FlatButtonAppearance appearance )
    {
        BackColor = Color.Firebrick;

        appearance.BorderColor = BackColor;
        appearance.BorderSize = 2;
        appearance.MouseDownBackColor = Color.DarkRed;
        appearance.MouseOverBackColor = Color.Red;

        base.Text = "Cancelar";
    }

    private void OnSetFlatButtonStyle()
    {
        try
        {
            var appearance = FlatAppearance;

            switch ( _flatButtonStyle )
            {
                case FlatButtonStyle.Confirm:
                    SetConfirmStyle( appearance );
                    break;
                case FlatButtonStyle.Cancel:
                    SetCancelStyle( appearance );
                    break;
            }
        }
        catch ( Exception ex )
        {
            Mensagem.MostrarErro( ex );
        }
    }

    protected override void OnClick( EventArgs e )
    {
        try
        {
            base.OnClick( e );
        }
        catch ( Exception ex )
        {
            Mensagem.MostrarErro( ex );
        }
    }
}