namespace ToolBox.Buttons;

/// <summary>
/// Botão flat.
/// </summary>
[DesignerCategory( "Botão Flat" ), ToolboxItem( true )]
public class FlatButton
    : ButtonBase
{
    private Theme _theme = Theme.White;
    private FlatButtonStyle _flatButtonStyle = FlatButtonStyle.Default;

    private readonly Font _stylishFont = new Font( ToolBoxEnvironment.GeneralFont, FontStyle.Bold );

    /// <summary>
    /// Determina o estilo flat.
    /// </summary>
    [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Visible )]
    public new FlatStyle FlatStyle
    {
        get { return base.FlatStyle; }
        set { base.FlatStyle = value; }
    }

    /// <summary>
    /// Mostra a estilização do botão flat.
    /// </summary>
    [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Visible )]
    public new FlatButtonAppearance FlatAppearance => base.FlatAppearance;

    /// <summary>
    /// Estilos para o botão.
    /// </summary>
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

    /// <summary>
    /// Texto do botão.
    /// </summary>
    public new string Text
    {
        get => base.Text;
        set
        {
            if ( DesignMode && _flatButtonStyle != FlatButtonStyle.Default )
                throw new InvalidOperationException( "Não é possível alterar o texto do botão pois tem um estilo selecionado para esse botão." );

            base.Text = value;
        }
    }

    [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Visible )]
    public Theme Theme
    {
        get => _theme;
        internal set
        {
            _theme = value;
        }
    }

    /// <summary>
    /// Construtor padrão que recebe um container.
    /// </summary>
    /// <param name="container">Container do formulário.</param>
    public FlatButton( IContainer container )
        : base( container )
    {
        FlatStyle = FlatStyle.Flat;
    }

    private void SetWhiteThemeStyle()
    {
        ForeColor = Color.Black;
        BackColor = Color.White;

        FlatAppearance.BorderColor = Color.Black;
        FlatAppearance.BorderSize = 2;
        FlatAppearance.MouseDownBackColor = Color.GhostWhite;
        FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
    }

    private void SetThemeStyle()
    {
        switch ( _theme )
        {
            case Theme.White:
                SetWhiteThemeStyle();
                break;
        }
    }

    private void SetConfirmStyle()
    {
        ForeColor = Color.WhiteSmoke;
        BackColor = Color.LimeGreen;

        FlatAppearance.BorderColor = BackColor;
        FlatAppearance.BorderSize = 2;
        FlatAppearance.MouseDownBackColor = Color.ForestGreen;
        FlatAppearance.MouseOverBackColor = Color.LightGreen;

        base.Text = "Confirmar";
        DialogResult = DialogResult.OK;
    }

    private void SetCancelStyle()
    {
        BackColor = Color.Firebrick;

        FlatAppearance.BorderColor = BackColor;
        FlatAppearance.BorderSize = 2;
        FlatAppearance.MouseDownBackColor = Color.DarkRed;
        FlatAppearance.MouseOverBackColor = Color.Red;

        base.Text = "Cancelar";
        DialogResult = DialogResult.Cancel;
    }

    private void OnSetFlatButtonStyle()
    {
        try
        {            
            var appearance = FlatAppearance;

            switch ( _flatButtonStyle )
            {
                case FlatButtonStyle.Confirm:
                    SetConfirmStyle();
                    break;
                case FlatButtonStyle.Cancel:
                    SetCancelStyle();
                    break;
                case FlatButtonStyle.Default:
                    SetThemeStyle();
                    break;
            }
        }
        catch ( Exception ex )
        {
            Mensagem.MostrarErro( ex );
        }
    }

    /// <summary>
    /// Método executado ao clicar no controle.
    /// </summary>
    /// <param name="e">Argumento de evento.</param>
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

    /// <summary>
    /// Método executado ao alterar a fonte do controle.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnFontChanged( EventArgs e )
    {
        if ( FlatButtonStyle == FlatButtonStyle.Default )
            Font = ToolBoxEnvironment.GeneralFont;
        else
            Font = _stylishFont;

        base.OnFontChanged( e );
    }
}