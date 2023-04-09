namespace ToolBox.Interfaces;

public interface ITextInput
{
    public bool AllowNumbers { get; set; }
    public bool AllowLetters { get; set; }
    public bool AllowSymbols { get; set; }

    bool HasText();
}