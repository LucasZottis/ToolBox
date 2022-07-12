using BibliotecaPublica.Classes;
using BibliotecaPublica.Classes.Config;
using BibliotecaPublica.Classes.Servicos.Conversores;
using BibliotecaPublica.Classes.Servicos.Gerenciadores;
using BibliotecaPublica.Classes.Verificadores;
using BibliotecaPublica.Estruturas;
using MaterialSkin.Controls;
using System;
using System.IO;
using System.Windows.Forms;
using ToolBox.ToolBoxFramework.Componentes;

namespace ToolBox.ToolBoxFramework.Formularios.BancoDados
{
    public partial class frmConfiguracaoBancoDados : MaterialForm 
    {
        #region Constantes

        private const string TEXTO_PADRAO = "Informações: ";

        #endregion Constantes

        #region Atributos

        private readonly string _nomeCadeiaConexao = string.Empty;

        private bool _conexaoFuncionando = false;
        private bool _usarCredenciaisPersonalizadas = false;

        private string _nomeBancoDadosSemExtensao = string.Empty;
        private string _caminhoAplicativoExterno = "debug";

        private string _caminhoArquivo = string.Empty;
        private string _nomeBancoDados = string.Empty;
        private string _servidor = string.Empty;
        private string _usuario = string.Empty;
        private string _senha = string.Empty;

        GerenciadorServicosWindows _sqlServer;
        GerenciadorServicosWindows _sqlServerLaunchPad;

        ArquivoConfiguracao _arquivo;

        #endregion Atributos

        #region Propriedades

        public bool ConexaoFuncionando
        {
            get
            {
                return _conexaoFuncionando;
            }
        }

        public bool AcessoInterno { private get; set; }

        #endregion Propriedades

        #region Construtores

        public frmConfiguracaoBancoDados()
        {
            InitializeComponent();

            _sqlServer = new GerenciadorServicosWindows("MSSQL$SQLEXPRESS", ValoresPadroes.TempoLimiteServico);
            _sqlServerLaunchPad = new GerenciadorServicosWindows("MSSQLLaunchpad$SQLEXPRESS", ValoresPadroes.TempoLimiteServico);

            BuscarConfiguracaoLocal();
        }

        public frmConfiguracaoBancoDados(string caminhoAplicativoExterno, string nomeCadeiaConexao)
        {
            InitializeComponent();

            _sqlServer = new GerenciadorServicosWindows("MSSQL$SQLEXPRESS", ValoresPadroes.TempoLimiteServico);
            _sqlServerLaunchPad = new GerenciadorServicosWindows("MSSQLLaunchpad$SQLEXPRESS", ValoresPadroes.TempoLimiteServico);
            _caminhoAplicativoExterno = caminhoAplicativoExterno;
            _nomeCadeiaConexao = nomeCadeiaConexao;

            BuscarConfiguracaoTerceiro();
        }

        #endregion Construtores

        #region Métodos

        private void Salvar()
        {
            try
            {
                _arquivo.AlterarConfiguracao("CaminhoBancoDados", _caminhoArquivo);
                _arquivo.AlterarConfiguracao("NomeBancoDados", _nomeBancoDados);
                _arquivo.AlterarConfiguracao("NomeServidor", _servidor);
                _arquivo.AlterarConfiguracao("UsarCredenciaisPersonalizadas", _usarCredenciaisPersonalizadas.ToString());

                _arquivo.AlterarCadeiaConexao(_nomeCadeiaConexao, SistemaOld.CadeiaConexao);

                _arquivo.SalvarArquivoAlterado();

                Mensagem.Informar("Salvou!");
            }
            catch (Exception ex)
            {
                SetarMensagem(ex.Message);
            }
        }

        private void SetarMensagem(string texto)
        {
            lblResultadoTesteConexao.Text = string.Empty;
            lblResultadoTesteConexao.Text = texto;
            ssmBarraInformacao.Refresh();
        }

        private void PararServicos()
        {
            SetarMensagem("Parando serviços");

            if (_sqlServer.VerificarServicoIniciado())
            {
                _sqlServer.PararServico();
            }

            if (_sqlServerLaunchPad.VerificarServicoIniciado())
            {
                _sqlServerLaunchPad.PararServico();
            }

            SetarMensagem("Serviços parados");
        }

        private void IniciarServicos()
        {
            SetarMensagem("Iniciando serviços");

            if (_sqlServer.VerificarServicoParado())
            {
                _sqlServer.IniciarServico();
            }

            if (_sqlServerLaunchPad.VerificarServicoParado())
            {
                _sqlServerLaunchPad.IniciarServico();
            }

            SetarMensagem("Serviços iniciados");
        }

        private bool VerificarCampos()
        {
            if (_caminhoArquivo.EstaVazio())
            {
                return false;
            }

            if (_nomeBancoDados.EstaVazio())
            {
                return false;
            }

            if (_servidor.EstaVazio())
            {
                return false;
            }

            if (_usarCredenciaisPersonalizadas)
            {
                if (_usuario.EstaVazio())
                {
                    return false;
                }

                if (_senha.EstaVazio())
                {
                    return false;
                }
            }

            return true;
        }

        private void BuscarConfiguracaoLocal()
        {
            _caminhoArquivo = Configuracao.BuscarConfiguracao("CaminhoBancoDados");
            _servidor = Configuracao.BuscarConfiguracao("NomeServidor");
            _nomeBancoDados = Configuracao.BuscarConfiguracao("NomeBancoDados");
            _usarCredenciaisPersonalizadas = Configuracao.BuscarConfiguracao<bool>("UsarCredenciaisPersonalizadas");
            _usuario = Configuracao.BuscarConfiguracao("Usuario");
            _senha = Configuracao.BuscarConfiguracao("Senha");
        }

        private string ObterNomeBancoDados(string nomeArquivoBancoDados)
        {
            return $"DB_{Path.GetFileNameWithoutExtension(nomeArquivoBancoDados)}".ToUpper();
        }

        private void BuscarConfiguracaoTerceiro()
        {
            if (_arquivo == null)
            {
                _arquivo = new ArquivoConfiguracao(_caminhoAplicativoExterno);
            }

            _caminhoArquivo = _arquivo.BuscarConfiguracao("CaminhoBancoDados");
            _servidor = _arquivo.BuscarConfiguracao("NomeServidor");
            _nomeBancoDados = _arquivo.BuscarConfiguracao("NomeBancoDados");
            _usarCredenciaisPersonalizadas = _arquivo.BuscarConfiguracao("UsarCredenciaisPersonalizadas").ParaBoolean();
            _usuario = _arquivo.BuscarConfiguracao("Usuario");
            _senha = _arquivo.BuscarConfiguracao("Senha");

            if (_nomeBancoDados.TemConteudo())
            {
                _nomeBancoDadosSemExtensao = ObterNomeBancoDados(_nomeBancoDados);
            }
        }

        private void GravarAlteracoes()
        {
            _caminhoArquivo = txtCaminhoArquivo.Text;
            _nomeBancoDados = txtNomeBancoDados.Text;
            _servidor = txtServidor.Text;
            _usuario = txtUsuario.Text;
            _senha = txtSenha.Text;
            _usarCredenciaisPersonalizadas = rtnCredenciaisPersonalizadas.Checked;
        }

        //public void ExecutarTesteConexao()
        //{
        //    if (VerificarCampos())
        //    {
        //        try
        //        {
        //            if (SistemaOld.CadeiaConexao.EstaVazio())
        //            {
        //                SistemaOld.CadeiaConexao = AcessoBancoDadosOld.MontarCadeiaConexao(_servidor, _nomeBancoDadosSemExtensao, _usarCredenciaisPersonalizadas, _usuario, _senha);
        //            }

        //            AcessoBancoDadosOld.Iniciar();
        //            AcessoBancoDadosOld.IniciarConexao();

        //            if (AcessoBancoDadosOld.TestarConexao())
        //            {
        //                _conexaoFuncionando = true;
        //            }

        //            SetarMensagem("Conexão realizada com sucesso.");
        //        }
        //        catch (Exception ex)
        //        {
        //            Mensagem.MostrarErro(ex);
        //            SetarMensagem(ex.Message);
        //        }
        //        finally
        //        {
        //            AcessoBancoDadosOld.EncerrarConexao();
        //            AcessoBancoDadosOld.EncerrarAcesso();
        //        }
        //    }
        //    else
        //    {
        //        if (AcessoInterno)
        //        {
        //            Mensagem.Avisar("Está faltando algumas informações no .config.");
        //        }
        //        else
        //        {
        //            SetarMensagem("Está faltando algumas informações.");
        //        }
        //    }
        //}

        #endregion Métodos

        private void btnBuscarArquivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                bool abrirDialogo = true;

                try
                {
                    PararServicos();
                }
                catch (Exception ex)
                {
                    Mensagem.Avisar("Não foi possível parar algum dos serviços necessários e será necessários pará-los manualmente. Para fazer isso, consulte o manual de instrução que está na pasta desse programa.");
                    SetarMensagem(ex.Message);
                    abrirDialogo = false;
                }

                if (abrirDialogo && dialogo.ShowDialog() == DialogResult.OK)
                {
                    txtCaminhoArquivo.Text = dialogo.FileName;
                    txtNomeBancoDados.Text = Path.GetFileName(dialogo.FileName);
                    _nomeBancoDadosSemExtensao = ObterNomeBancoDados(txtNomeBancoDados.Text);
                }
            }
        }

        private void rtnCredenciaisWindows_CheckedChanged(object sender, EventArgs e)
        {
            gbxSeguranca.Enabled = !rtnCredenciaisWindows.Checked;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool salvar = true;

            if (!VerificarCampos())
            {
                SetarMensagem("Está faltando algumas informações.");
                return;
            }
            else if (!_conexaoFuncionando)
            {
                salvar = Mensagem.Perguntar("O teste de conexão com o banco de dados não obteve sucesso ou não foi realizado. Deseja continuar salvando mesmo assim?") == DialogResult.Yes;
            }

            if (salvar)
            {
                Salvar();
                Close();
            }
            else
            {
                SetarMensagem("Teste de conexão sem sucesso ou não foi realizado.");
            }
        }

        private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            bool executarTeste = true;

            GravarAlteracoes();

            try
            {
                IniciarServicos();
            }
            catch (Exception ex)
            {
                Mensagem.Avisar("Não foi possível iniciar algum dos serviços necessários e será preciso inicia-los manualmente. Para fazer isso, consulte o manual de instrução que está na pasta desse programa.");
                SetarMensagem(ex.Message);
                executarTeste = false;
            }

            if (executarTeste)
            {
                //ExecutarTesteConexao();
            }
        }

        private void frmConfiguracaoBancoDados_Load(object sender, EventArgs e)
        {
            try
            {
                if (_arquivo == null)
                {
                    _arquivo = new ArquivoConfiguracao(_caminhoAplicativoExterno);
                }
            }
            catch (ArgumentNullException ex)
            {
                Mensagem.MostrarErro(ex);
            }
            catch (Exception ex)
            {
                Mensagem.MostrarErro(ex);
            }

            txtCaminhoArquivo.Text = _caminhoArquivo;
            txtNomeBancoDados.Text = _nomeBancoDados;
            txtServidor.Text = _servidor;
            rtnCredenciaisPersonalizadas.Checked = _usarCredenciaisPersonalizadas;
            txtUsuario.Text = _usuario;
            txtSenha.Text = _senha;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmConfiguracaoBancoDados_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sqlServer.FecharServico();
            _sqlServer.Dispose();
            _sqlServer = null;

            _sqlServerLaunchPad.FecharServico();
            _sqlServerLaunchPad.Dispose();
            _sqlServerLaunchPad = null;
        }
    }
}