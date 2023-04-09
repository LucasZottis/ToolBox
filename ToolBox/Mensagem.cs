using System.Text;

namespace ToolBox
{
    /// <summary>
    /// Classe para mostrar notificações para o usuário.
    /// </summary>
    public static class Mensagem
    {
        #region Atributos

        private static readonly string _novalinha = "\n";
        private static string _titulo = ToolBoxConfig.AppName;

        #endregion Atributos

        #region Métodos Privados

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

        #endregion Métodos Privados

        #region Informar

        public static void Informar( string mensagem )
        {
            MessageBox.Show( mensagem, _titulo, MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        public static void Informar( StringBuilder mensagem )
        {
            MessageBox.Show( mensagem.ToString(), _titulo, MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        #endregion Informar

        #region Perguntar

        public static DialogResult Perguntar( string mensagem )
        {
            return MessageBox.Show( mensagem, _titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question );
        }

        public static DialogResult Perguntar( StringBuilder mensagem )
        {
            return MessageBox.Show( mensagem.ToString(), _titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question );
        }

        #endregion Perguntar

        #region Avisar

        public static void Avisar( string mensagem )
        {
            MessageBox.Show( mensagem, _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning );
        }

        public static void Avisar( StringBuilder mensagem )
        {
            MessageBox.Show( mensagem.ToString(), _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning );
        }

        #endregion Avisar

        #region MostrarErro

        /// <summary>
        /// Método para mostrar mensagens originadas de exceção.
        /// </summary>
        /// <param name="ex">Exceção que deve ser mostrada.</param>
        public static void MostrarErro( Exception ex )
        {
            MessageBox.Show( MontarMensagemExcecao( ex ), _titulo, MessageBoxButtons.OK, MessageBoxIcon.Error );
        }

        #endregion MostrarErro
    }
}