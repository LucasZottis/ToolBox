using System;

namespace ToolBox.ToolBoxWinForms.Framework.Interfaces
{
    public interface IPropriedade
    {
        int Codigo
        {
            get; set;
        }

        string NomePropriedade
        {
            get; set;
        }

        string DescricaoPropriedade
        {
            get; set;
        }

        string TipoPropriedade
        {
            get; set;
        }

        string ValorPropriedade
        {
            get; set;
        }

        Action<int, string> AoAlterarPropriedade
        {
            get; set;
        }

        void AlterarValorPropriedade();
    }
}