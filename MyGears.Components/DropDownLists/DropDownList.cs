namespace MyGears.Components.DropDownLists;

/// <summary>
/// Mostra uma lista de itens.
/// </summary>
[ToolboxItem( true )]
public class DropDownList
    : DropDownListBase
{
    /// <summary>
    /// Construtor padrão com injeção de IContainer.
    /// </summary>
    /// <param name="container">Um container que irá guardar o componente.</param>
    public DropDownList( IContainer container )
        : base( container )
    {
        DropDownStyle = ComboBoxStyle.DropDownList;
        FlatStyle = FlatStyle.System;
    }

    /// <summary>
    /// Obtém o valor tipado da propriedade Selectedvalue.
    /// </summary>
    /// <typeparam name="TReturn">Tipo de retorno.</typeparam>
    /// <returns>Item selecionado.</returns>
    public TReturn? GetSelectedValue<TReturn>()
        => ( TReturn ) SelectedValue ?? default;
}