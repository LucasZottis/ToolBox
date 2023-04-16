namespace MyGears.Components.Inputs;

[ToolboxItem( true )]
public class DateTimeInput
    : InputBase
{
    private bool _ignorarTecla = false;
    private DateTimeMask _mask = DateTimeMask.Normal;
    private ErrorProvider _errorProvider;

    [Browsable( true ), DisplayName( "Máscara" ), Description( "Define ou obtém a máscara utilizada pelo componente." ), Category( "Comportamento" ), DefaultValue( DateTimeMask.Normal )]
    public DateTimeMask Mask
    {
        get => _mask;
        set
        {
            _mask = value;
            Configure();
        }
    }

    [Browsable( false )]
    public DateTime? Value { get; set; }

    [Browsable( false )]
    public new bool PermitirLetras
    {
        get => AllowLetters;
        set => AllowLetters = value;
    }

    [Browsable( false )]
    public new bool PermitirSimbolos
    {
        get => AllowSymbols;
        set => AllowSymbols = value;
    }

    [Browsable( false )]
    public new int MaxLength
    {
        get => base.MaxLength;
        set => base.MaxLength = value;
    }

    [Browsable( false )]
    public new HorizontalAlignment TextAlign
    {
        get => base.TextAlign;
        set => base.TextAlign = value;
    }

    public DateTimeInput( IContainer container )
        : base( container )
    {
        _errorProvider = new ErrorProvider();
        Configure();
    }

    private void Configure()
    {
        base.TextAlign = HorizontalAlignment.Center;
        AllowLetters = false;
        AllowSymbols = false;

        SetMaxLength();
        SetPlaceHolder();
    }

    private void SetMaxLength()
    {
        switch ( Mask )
        {
            case DateTimeMask.Short:
                base.MaxLength = 7;
                break;
            case DateTimeMask.Normal:
                base.MaxLength = 10;
                break;
            case DateTimeMask.Long:
                base.MaxLength = 19;
                break;
        }
    }

    private void SetPlaceHolder()
    {
        if ( PlaceholderText.TemConteudo() )
            return;

        switch ( Mask )
        {
            case DateTimeMask.Short:
                PlaceholderText = "MM/YYYY";
                break;
            case DateTimeMask.Normal:
                PlaceholderText = "DD/MM/YYYY";
                break;
            case DateTimeMask.Long:
                PlaceholderText = "DD/MM/YYYY HH:MM:SS";
                break;
        }
    }

    private int GetLengthWithoutMask()
        => Text.Replace( "/", "" ).Replace( ":", "" ).Length;

    private bool IsValidMonthDigit( Keys key )
    {
        var firstPosition = 0;
        var lastPosition = 1;
        var option = 3;

        if ( Mask == DateTimeMask.Normal || Mask == DateTimeMask.Long )
        {
            firstPosition = 2;
            lastPosition = 4;
        }

        if ( SelectionStart == firstPosition || SelectionStart == option )
            return key == Keys.NumPad0
                || key == Keys.NumPad1
                || key == Keys.D0
                || key == Keys.D1;

        if ( SelectionStart == lastPosition )
            return key == Keys.NumPad0
                || key == Keys.NumPad1
                || key == Keys.NumPad2
                || key == Keys.NumPad3
                || key == Keys.NumPad4
                || key == Keys.NumPad5
                || key == Keys.NumPad6
                || key == Keys.NumPad7
                || key == Keys.NumPad8
                || key == Keys.NumPad9
                || key == Keys.D0
                || key == Keys.D1
                || key == Keys.D2
                || key == Keys.D3
                || key == Keys.D4
                || key == Keys.D5
                || key == Keys.D6
                || key == Keys.D7
                || key == Keys.D8
                || key == Keys.D9;

        return true;
    }

    private bool IsValidDayDigit( Keys key )
    {
        if ( SelectionStart == 0 )
            return key == Keys.NumPad0
                || key == Keys.NumPad1
                || key == Keys.NumPad2
                || key == Keys.NumPad3
                || key == Keys.D0
                || key == Keys.D1
                || key == Keys.D2
                || key == Keys.D3;

        if ( SelectionStart == 1 )
            return key == Keys.NumPad0
                || key == Keys.NumPad1
                || key == Keys.NumPad2
                || key == Keys.NumPad3
                || key == Keys.NumPad4
                || key == Keys.NumPad5
                || key == Keys.NumPad6
                || key == Keys.NumPad7
                || key == Keys.NumPad8
                || key == Keys.NumPad9
                || key == Keys.D0
                || key == Keys.D1
                || key == Keys.D2
                || key == Keys.D3
                || key == Keys.D4
                || key == Keys.D5
                || key == Keys.D6
                || key == Keys.D7
                || key == Keys.D8
                || key == Keys.D9;

        return true;
    }

    private bool IsValidHourDigit( Keys key )
    {
        if ( SelectionStart == 11 )
            return key == Keys.NumPad0
                || key == Keys.NumPad1
                || key == Keys.NumPad2
                || key == Keys.D0
                || key == Keys.D1
                || key == Keys.D2;

        if ( SelectionStart == 12 )
            return key == Keys.NumPad0
                || key == Keys.NumPad1
                || key == Keys.NumPad2
                || key == Keys.NumPad3
                || key == Keys.NumPad4
                || key == Keys.NumPad5
                || key == Keys.NumPad6
                || key == Keys.NumPad7
                || key == Keys.NumPad8
                || key == Keys.NumPad9
                || key == Keys.D0
                || key == Keys.D1
                || key == Keys.D2
                || key == Keys.D3
                || key == Keys.D4
                || key == Keys.D5
                || key == Keys.D6
                || key == Keys.D7
                || key == Keys.D8
                || key == Keys.D9;

        return true;
    }

    private bool IsValidMinuteAndSecondDigit( Keys key )
    {
        if ( SelectionStart == 13 || SelectionStart == 14 )
            return key == Keys.NumPad0
                || key == Keys.NumPad1
                || key == Keys.NumPad2
                || key == Keys.NumPad3
                || key == Keys.NumPad4
                || key == Keys.NumPad5
                || key == Keys.NumPad6
                || key == Keys.D0
                || key == Keys.D1
                || key == Keys.D2
                || key == Keys.D3
                || key == Keys.D4
                || key == Keys.D5
                || key == Keys.D6;

        if ( SelectionStart == 15 )
            return key == Keys.NumPad0
                || key == Keys.NumPad1
                || key == Keys.NumPad2
                || key == Keys.NumPad3
                || key == Keys.NumPad4
                || key == Keys.NumPad5
                || key == Keys.NumPad6
                || key == Keys.NumPad7
                || key == Keys.NumPad8
                || key == Keys.NumPad9
                || key == Keys.D0
                || key == Keys.D1
                || key == Keys.D2
                || key == Keys.D3
                || key == Keys.D4
                || key == Keys.D5
                || key == Keys.D6
                || key == Keys.D7
                || key == Keys.D8
                || key == Keys.D9;

        return true;
    }

    private void SetShortDateMask( Keys key )
    {
        if ( !IsValidMonthDigit( key ) )
            InvalidateInput();

        if ( _ignorarTecla )
            return;

        if ( GetLengthWithoutMask() == 2 && Text.Length == 2 )
            AppendText( "/" );
    }

    private void SetNormalDateMask( Keys key )
    {
        if ( !IsValidDayDigit( key ) )
            InvalidateInput();
        else if ( !IsValidMonthDigit( key ) )
            InvalidateInput();

        if ( _ignorarTecla )
            return;

        if ( GetLengthWithoutMask() == 2 && Text.Length == 2 )
            AppendText( "/" );
        else if ( GetLengthWithoutMask() == 4 && Text.Length == 5 )
            AppendText( "/" );
    }

    private void SetLongDateMask( Keys key )
    {
        if ( !IsValidDayDigit( key ) )
            InvalidateInput();
        else if ( !IsValidMonthDigit( key ) )
            InvalidateInput();
        else if ( !IsValidHourDigit( key ) )
            InvalidateInput();
        else if ( !IsValidMinuteAndSecondDigit( key ) )
            InvalidateInput();

        if ( _ignorarTecla )
            return;

        if ( GetLengthWithoutMask() == 2 && Text.Length == 2 )
            AppendText( "/" );
        else if ( GetLengthWithoutMask() == 4 && Text.Length == 5 )
            AppendText( "/" );
        else if ( GetLengthWithoutMask() == 8 && Text.Length == 10 )
            AppendText( " " );
        else if ( GetLengthWithoutMask() == 11 && Text.Length == 13 || GetLengthWithoutMask() == 13 && Text.Length == 16 )
            AppendText( ":" );
    }

    private void InvalidateInput()
    {
        _errorProvider.SetError( this, "Dígito inserido inválido!" );
        _ignorarTecla = true;
    }

    private void IsDateTimeValid()
    {
        if ( !HasText() )
            return;

        if ( DateTime.TryParse( Text, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime ) )
        {
            Value = dateTime;
            return;
        }

        CleanUp();
        _errorProvider.SetError( this, "Data inválida!" );
    }

    protected override void OnLeave( EventArgs e )
    {
        IsDateTimeValid();
        base.OnLeave( e );
    }

    protected override void OnKeyDown( KeyEventArgs e )
    {
        if ( e.KeyCode == Keys.Back )
            _ignorarTecla = false;
        else
        {
            switch ( Mask )
            {
                case DateTimeMask.Short:
                    SetShortDateMask( e.KeyCode );
                    break;
                case DateTimeMask.Normal:
                    SetNormalDateMask( e.KeyCode );
                    break;
                case DateTimeMask.Long:
                    SetLongDateMask( e.KeyCode );
                    break;
            }
        }

        base.OnKeyDown( e );
    }

    protected override void OnKeyPress( KeyPressEventArgs e )
    {
        e.Handled = _ignorarTecla;
        base.OnKeyPress( e );
        _ignorarTecla = false;
    }
}