namespace ToolBox.Geral.Interfaces
{
    public interface ILimpeza
    {
        /// <summary>
        /// Define ou obtém se deve fazer a limpeza de resíduo do componente.
        /// </summary>
        bool FazerLimpeza { get; set; }

        /// <summary>
        /// Executa a limpeza de resíduo do componente.
        /// </summary>
        void Limpar();
    }
}