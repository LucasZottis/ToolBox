﻿namespace ToolBox.ToolBoxWinForms.Net6.Interfaces
{
    public interface ICaixaTexto
    {
        public bool PermitirNumeros { get; set; }
        public bool PermitirLetras { get; set; }
        public bool PermitirSimbolos { get; set; }

        bool TemTexto();
    }
}