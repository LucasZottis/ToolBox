namespace MyGears.Forms.Base;

public partial class FloatingForm
    : FormBase
{
    #region Propriedades

    #region Ocultadas

    [Browsable( false )]
    public new FormBorderStyle FormBorderStyle
    {
        get
        {
            return base.FormBorderStyle;
        }

        set
        {
            base.FormBorderStyle = value;
        }
    }

    [Browsable( false )]
    public new Icon Icon
    {
        get { return base.Icon; }
        set { base.Icon = value; }
    }

    [Browsable( false )]
    public new bool HelpButton
    {
        get { return base.HelpButton; }
        set { base.HelpButton = value; }
    }

    [Browsable( false )]
    public new bool MaximizeBox
    {
        get
        {
            return base.MaximizeBox;
        }

        set
        {
            base.MaximizeBox = value;
        }
    }

    [Browsable( false )]
    public new bool MinimizeBox
    {
        get
        {
            return base.MinimizeBox;
        }

        set
        {
            base.MinimizeBox = value;
        }
    }

    [Browsable( false )]
    public new MenuStrip MainMenuStrip
    {
        get { return base.MainMenuStrip; }
        set { base.MainMenuStrip = value; }
    }

    [Browsable( false )]
    public new FormWindowState WindowState
    {
        get => base.WindowState;
        set => base.WindowState = value;
    }

    [Browsable( false )]
    public new Size AutoScrollMargin
    {
        get
        {
            return base.AutoScrollMargin;
        }

        set
        {
            base.AutoScrollMargin = value;
        }
    }

    [Browsable( false )]
    public new Size AutoScrollMinSize
    {
        get
        {
            return base.AutoScrollMinSize;
        }

        set
        {
            base.AutoScrollMinSize = value;
        }
    }

    #endregion Ocultadas

    #region Comportamento

    [Browsable( true ), DisplayName( "Barras de rolagem" ), Category( TextosPadroes.ComportamentoCategoria ), DefaultValue( false )]
    public new bool AutoScroll
    {
        get
        {
            return base.AutoScroll;
        }

        set
        {
            base.AutoScroll = value;
        }
    }

    #endregion Comportamento

    #endregion Propriedades

    public FloatingForm()
    {
        InitializeComponent();
    }
}
