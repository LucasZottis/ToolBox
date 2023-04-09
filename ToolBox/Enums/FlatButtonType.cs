namespace ToolBox.Enums;

/// <summary>
/// Define o estilo do botão flat.
/// </summary>
public enum FlatButtonStyle
    : byte
{
    /// <summary>
    /// Será utilizado o estilo definido pelo tema.
    /// </summary>
    [Description( "Padrão" )]
    Default,

    /// <summary>
    /// Estilo de botão confirmar.
    /// </summary>
    [Description( "Confirmar" )]
    Confirm,

    /// <summary>
    /// Estilo de botão cancelar.
    /// </summary>
    [Description( "Cancelar" )]
    Cancel,
}