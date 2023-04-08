namespace ToolBox.Enums;

/// <summary>
/// Contém tipos de máscaras de data.
/// </summary>
public enum DateTimeMask : byte
{
    /// <summary>
    /// Define uma data curta. (MM/YYYY)
    /// </summary>
    [Description( "Curto (MM/YYYY)" )]
    Short,

    /// <summary>
    /// Define uma data normal. (DD/MM/YYYY)
    /// </summary>
    [Description( "Normal (DD/MM/YYYY)" )]
    Normal,

    /// <summary>
    /// Define uma data normal. (DD/MM/YYYY HH:MM:SS)
    /// </summary>
    [Description( "Longo (DD/MM/YYYY HH:MM:SS)" )]
    Long
}