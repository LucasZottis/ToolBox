namespace ToolBox.ToolBoxWinForms.Net6.Interfaces
{
    public interface IComponente
    {
        /// <summary>
        /// Define ou obtém se deve bloquear o componente.
        /// </summary>
        bool BloquearComponente { get; set; }

        /// <summary>
        /// Define se o componente está bloqueado.
        /// </summary>
        bool Bloqueado { set; }

        Point ObterPontoCentral();
    }
}