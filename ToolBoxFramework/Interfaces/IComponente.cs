namespace ToolBox.ToolBoxFramework.Interfaces
{
    /// <summary>
    /// Interface de componente.
    /// </summary>
    public interface IComponente
    {
        /// <summary>
        /// Define ou obtém se deve bloquear o componente.
        /// </summary>
        bool BloquearComponente { get; set;}

        /// <summary>
        /// Define se o componente está bloqueado.
        /// </summary>
        bool Bloqueado { set; }
    }
}