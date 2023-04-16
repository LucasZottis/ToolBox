using System.Text;

namespace MyGears.Components
{
    /// <summary>
    /// Classe para mostrar notificações para o usuário.
    /// </summary>
    public static class Mensagem
    {
        private static readonly string _novalinha = "\n";

        private static string MontarMensagemExcecao( Exception ex )
        {
            StringBuilder mensagem = new StringBuilder();

            mensagem.AppendLine( "Mensagem:" );
            mensagem.AppendLine( ex.Message );
            mensagem.AppendLine( _novalinha );

            mensagem.AppendLine( $"Pilha de chamadas:" );
            mensagem.AppendLine( ex.StackTrace );
            mensagem.AppendLine( _novalinha );

            if ( ex.InnerException != null )
            {
                mensagem.AppendLine( $"Outras informações: {ex.InnerException.Message}" );
            }

            return mensagem.ToString();
        }

        /// <summary>
        /// Método para mostrar um modal de informação ao usuário.
        /// </summary>
        /// <param name="mensagem">Mensagem que deseja apresentar.</param>
        public static void Informar( string mensagem )
            => MessageBox.Show( mensagem, ToolBoxEnvironment.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information );

        /// <summary>
        /// Método para mostrar um modal de informação ao usuário.
        /// </summary>
        /// <param name="mensagem">Mensagem que deseja apresentar.</param>
        public static void Informar( StringBuilder mensagem )
            => MessageBox.Show( mensagem.ToString(), ToolBoxEnvironment.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information );

        /// <summary>
        /// Método para mostrar um modal de pergunta ao usuário.
        /// </summary>
        /// <param name="mensagem">Mensagem que deseja apresentar.</param>
        public static DialogResult Perguntar( string mensagem )
            => MessageBox.Show( mensagem, ToolBoxEnvironment.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question );

        /// <summary>
        /// Método para mostrar um modal de pergunta ao usuário.
        /// </summary>
        /// <param name="mensagem">Mensagem que deseja apresentar.</param>
        public static DialogResult Perguntar( StringBuilder mensagem )
            => MessageBox.Show( mensagem.ToString(), ToolBoxEnvironment.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question );

        /// <summary>
        /// Método para mostrar um modal de aviso ao usuário.
        /// </summary>
        /// <param name="mensagem">Mensagem que deseja apresentar.</param>
        public static void Avisar( string mensagem )
            => MessageBox.Show( mensagem, ToolBoxEnvironment.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning );

        /// <summary>
        /// Método para mostrar um modal de aviso ao usuário.
        /// </summary>
        /// <param name="mensagem">Mensagem que deseja apresentar.</param>
        public static void Avisar( StringBuilder mensagem )
            => MessageBox.Show( mensagem.ToString(), ToolBoxEnvironment.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning );

        /// <summary>
        /// Método para mostrar mensagens originadas de exceção.
        /// </summary>
        /// <param name="ex">Exceção que deve ser mostrada.</param>
        public static void MostrarErro( Exception ex )
            => MessageBox.Show( MontarMensagemExcecao( ex ), ToolBoxEnvironment.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error );
    }
}