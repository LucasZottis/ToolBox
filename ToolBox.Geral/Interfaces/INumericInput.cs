namespace ToolBox.Interfaces;

public interface INumericInput
{
    long Value { get; }

    long MaxValue { get; set; }

    long MinValue { get; set; }
}