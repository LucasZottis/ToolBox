namespace MyGears.Interfaces;

public interface IControl
{
    /// <summary>
    /// Define ou obtém se deve bloquear o componente.
    /// </summary>
    bool DisableControl { get; set; }

    /// <summary>
    /// Define se o componente está bloqueado.
    /// </summary>
    bool Disabled { set; }

    Point GetCenterPoint();
}