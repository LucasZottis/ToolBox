namespace ToolBox.ToolBoxWinForms.Framework.Formularios.BancoDados
{
    partial class frmConfiguracaoBancoDados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracaoBancoDados));
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtServidor = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtNomeBancoDados = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtCaminhoArquivo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.gbxSeguranca = new System.Windows.Forms.GroupBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtUsuario = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtSenha = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.rtnCredenciaisWindows = new MaterialSkin.Controls.MaterialRadioButton();
            this.rtnCredenciaisPersonalizadas = new MaterialSkin.Controls.MaterialRadioButton();
            this.ssmBarraInformacao = new System.Windows.Forms.StatusStrip();
            this.lblResultadoTesteConexao = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSalvar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnTestarConexao = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnSair = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnBuscaArquivo = new System.Windows.Forms.Button();
            this.gbxSeguranca.SuspendLayout();
            this.ssmBarraInformacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 175);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(64, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Servidor";
            // 
            // txtServidor
            // 
            this.txtServidor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServidor.Depth = 0;
            this.txtServidor.Hint = "Caminho para o servidor do banco de dados.";
            this.txtServidor.Location = new System.Drawing.Point(12, 197);
            this.txtServidor.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.PasswordChar = '\0';
            this.txtServidor.SelectedText = "";
            this.txtServidor.SelectionLength = 0;
            this.txtServidor.SelectionStart = 0;
            this.txtServidor.Size = new System.Drawing.Size(628, 23);
            this.txtServidor.TabIndex = 2;
            this.txtServidor.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(12, 127);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(116, 19);
            this.materialLabel2.TabIndex = 0;
            this.materialLabel2.Text = "Banco de dados";
            // 
            // txtNomeBancoDados
            // 
            this.txtNomeBancoDados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeBancoDados.Depth = 0;
            this.txtNomeBancoDados.Enabled = false;
            this.txtNomeBancoDados.Hint = "Nome do arquivo MDF (Banco de dados).";
            this.txtNomeBancoDados.Location = new System.Drawing.Point(12, 149);
            this.txtNomeBancoDados.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNomeBancoDados.Name = "txtNomeBancoDados";
            this.txtNomeBancoDados.PasswordChar = '\0';
            this.txtNomeBancoDados.SelectedText = "";
            this.txtNomeBancoDados.SelectionLength = 0;
            this.txtNomeBancoDados.SelectionStart = 0;
            this.txtNomeBancoDados.Size = new System.Drawing.Size(628, 23);
            this.txtNomeBancoDados.TabIndex = 1;
            this.txtNomeBancoDados.UseSystemPasswordChar = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(12, 78);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(69, 19);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "Caminho";
            // 
            // txtCaminhoArquivo
            // 
            this.txtCaminhoArquivo.Depth = 0;
            this.txtCaminhoArquivo.Enabled = false;
            this.txtCaminhoArquivo.Hint = "Caminho para o arquivo MDF (Banco de dados).";
            this.txtCaminhoArquivo.Location = new System.Drawing.Point(12, 100);
            this.txtCaminhoArquivo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCaminhoArquivo.Name = "txtCaminhoArquivo";
            this.txtCaminhoArquivo.PasswordChar = '\0';
            this.txtCaminhoArquivo.SelectedText = "";
            this.txtCaminhoArquivo.SelectionLength = 0;
            this.txtCaminhoArquivo.SelectionStart = 0;
            this.txtCaminhoArquivo.Size = new System.Drawing.Size(574, 23);
            this.txtCaminhoArquivo.TabIndex = 1;
            this.txtCaminhoArquivo.UseSystemPasswordChar = false;
            // 
            // gbxSeguranca
            // 
            this.gbxSeguranca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxSeguranca.BackColor = System.Drawing.Color.White;
            this.gbxSeguranca.Controls.Add(this.materialLabel4);
            this.gbxSeguranca.Controls.Add(this.txtUsuario);
            this.gbxSeguranca.Controls.Add(this.txtSenha);
            this.gbxSeguranca.Controls.Add(this.materialLabel5);
            this.gbxSeguranca.Enabled = false;
            this.gbxSeguranca.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSeguranca.Location = new System.Drawing.Point(13, 265);
            this.gbxSeguranca.Name = "gbxSeguranca";
            this.gbxSeguranca.Size = new System.Drawing.Size(627, 123);
            this.gbxSeguranca.TabIndex = 5;
            this.gbxSeguranca.TabStop = false;
            this.gbxSeguranca.Text = "Segurança";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.BackColor = System.Drawing.SystemColors.Control;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(6, 21);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(61, 19);
            this.materialLabel4.TabIndex = 6;
            this.materialLabel4.Text = "Usuário";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsuario.Depth = 0;
            this.txtUsuario.Hint = "Usuário para acesso ao banco de dados.";
            this.txtUsuario.Location = new System.Drawing.Point(6, 43);
            this.txtUsuario.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PasswordChar = '\0';
            this.txtUsuario.SelectedText = "";
            this.txtUsuario.SelectionLength = 0;
            this.txtUsuario.SelectionStart = 0;
            this.txtUsuario.Size = new System.Drawing.Size(615, 23);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.UseSystemPasswordChar = false;
            // 
            // txtSenha
            // 
            this.txtSenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSenha.BackColor = System.Drawing.SystemColors.Control;
            this.txtSenha.Depth = 0;
            this.txtSenha.Hint = "Senha de acesso ao banco de dados.";
            this.txtSenha.Location = new System.Drawing.Point(6, 92);
            this.txtSenha.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '#';
            this.txtSenha.SelectedText = "";
            this.txtSenha.SelectionLength = 0;
            this.txtSenha.SelectionStart = 0;
            this.txtSenha.Size = new System.Drawing.Size(615, 23);
            this.txtSenha.TabIndex = 2;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.SystemColors.Control;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(6, 70);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(50, 19);
            this.materialLabel5.TabIndex = 3;
            this.materialLabel5.Text = "Senha";
            // 
            // rtnCredenciaisWindows
            // 
            this.rtnCredenciaisWindows.AutoSize = true;
            this.rtnCredenciaisWindows.Checked = true;
            this.rtnCredenciaisWindows.Depth = 0;
            this.rtnCredenciaisWindows.Font = new System.Drawing.Font("Roboto", 10F);
            this.rtnCredenciaisWindows.Location = new System.Drawing.Point(16, 227);
            this.rtnCredenciaisWindows.Margin = new System.Windows.Forms.Padding(0);
            this.rtnCredenciaisWindows.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rtnCredenciaisWindows.MouseState = MaterialSkin.MouseState.HOVER;
            this.rtnCredenciaisWindows.Name = "rtnCredenciaisWindows";
            this.rtnCredenciaisWindows.Ripple = true;
            this.rtnCredenciaisWindows.Size = new System.Drawing.Size(180, 30);
            this.rtnCredenciaisWindows.TabIndex = 3;
            this.rtnCredenciaisWindows.TabStop = true;
            this.rtnCredenciaisWindows.Text = "Credênciais do Windows";
            this.rtnCredenciaisWindows.UseVisualStyleBackColor = true;
            this.rtnCredenciaisWindows.CheckedChanged += new System.EventHandler(this.rtnCredenciaisWindows_CheckedChanged);
            // 
            // rtnCredenciaisPersonalizadas
            // 
            this.rtnCredenciaisPersonalizadas.AutoSize = true;
            this.rtnCredenciaisPersonalizadas.Depth = 0;
            this.rtnCredenciaisPersonalizadas.Font = new System.Drawing.Font("Roboto", 10F);
            this.rtnCredenciaisPersonalizadas.Location = new System.Drawing.Point(206, 227);
            this.rtnCredenciaisPersonalizadas.Margin = new System.Windows.Forms.Padding(0);
            this.rtnCredenciaisPersonalizadas.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rtnCredenciaisPersonalizadas.MouseState = MaterialSkin.MouseState.HOVER;
            this.rtnCredenciaisPersonalizadas.Name = "rtnCredenciaisPersonalizadas";
            this.rtnCredenciaisPersonalizadas.Ripple = true;
            this.rtnCredenciaisPersonalizadas.Size = new System.Drawing.Size(200, 30);
            this.rtnCredenciaisPersonalizadas.TabIndex = 4;
            this.rtnCredenciaisPersonalizadas.Text = "Credênciais Personalizadas";
            this.rtnCredenciaisPersonalizadas.UseVisualStyleBackColor = true;
            // 
            // ssmBarraInformacao
            // 
            this.ssmBarraInformacao.BackColor = System.Drawing.SystemColors.Control;
            this.ssmBarraInformacao.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssmBarraInformacao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblResultadoTesteConexao});
            this.ssmBarraInformacao.Location = new System.Drawing.Point(0, 434);
            this.ssmBarraInformacao.Name = "ssmBarraInformacao";
            this.ssmBarraInformacao.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ssmBarraInformacao.Size = new System.Drawing.Size(652, 22);
            this.ssmBarraInformacao.SizingGrip = false;
            this.ssmBarraInformacao.TabIndex = 8;
            // 
            // lblResultadoTesteConexao
            // 
            this.lblResultadoTesteConexao.BackColor = System.Drawing.Color.Transparent;
            this.lblResultadoTesteConexao.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.lblResultadoTesteConexao.Name = "lblResultadoTesteConexao";
            this.lblResultadoTesteConexao.Size = new System.Drawing.Size(0, 17);
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSalvar.Depth = 0;
            this.btnSalvar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvar.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(508, 394);
            this.btnSalvar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Primary = true;
            this.btnSalvar.Size = new System.Drawing.Size(60, 29);
            this.btnSalvar.TabIndex = 7;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnTestarConexao
            // 
            this.btnTestarConexao.AutoSize = true;
            this.btnTestarConexao.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTestarConexao.Depth = 0;
            this.btnTestarConexao.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestarConexao.Location = new System.Drawing.Point(12, 394);
            this.btnTestarConexao.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTestarConexao.Name = "btnTestarConexao";
            this.btnTestarConexao.Primary = true;
            this.btnTestarConexao.Size = new System.Drawing.Size(125, 29);
            this.btnTestarConexao.TabIndex = 6;
            this.btnTestarConexao.Text = "Testar Conexão";
            this.btnTestarConexao.UseVisualStyleBackColor = true;
            this.btnTestarConexao.Click += new System.EventHandler(this.btnTestarConexao_Click);
            // 
            // btnSair
            // 
            this.btnSair.AutoSize = true;
            this.btnSair.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSair.Depth = 0;
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSair.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(589, 394);
            this.btnSair.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSair.Name = "btnSair";
            this.btnSair.Primary = true;
            this.btnSair.Size = new System.Drawing.Size(45, 29);
            this.btnSair.TabIndex = 8;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnBuscaArquivo
            // 
            this.btnBuscaArquivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(56)))));
            this.btnBuscaArquivo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscaArquivo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(69)))), ((int)(((byte)(91)))));
            this.btnBuscaArquivo.FlatAppearance.BorderSize = 3;
            this.btnBuscaArquivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaArquivo.Image = global::ToolBox.ToolBoxWinForms.Framework.Properties.Resources.ConfiguracaoBancoDados;
            this.btnBuscaArquivo.Location = new System.Drawing.Point(601, 94);
            this.btnBuscaArquivo.Name = "btnBuscaArquivo";
            this.btnBuscaArquivo.Size = new System.Drawing.Size(39, 32);
            this.btnBuscaArquivo.TabIndex = 1;
            this.btnBuscaArquivo.UseVisualStyleBackColor = false;
            this.btnBuscaArquivo.Click += new System.EventHandler(this.btnBuscarArquivo_Click);
            // 
            // frmConfiguracaoBancoDados
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnSair;
            this.ClientSize = new System.Drawing.Size(652, 456);
            this.Controls.Add(this.ssmBarraInformacao);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnTestarConexao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscaArquivo);
            this.Controls.Add(this.rtnCredenciaisPersonalizadas);
            this.Controls.Add(this.rtnCredenciaisWindows);
            this.Controls.Add(this.gbxSeguranca);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.txtCaminhoArquivo);
            this.Controls.Add(this.txtNomeBancoDados);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConfiguracaoBancoDados";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração do Banco de Dados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfiguracaoBancoDados_FormClosing);
            this.Load += new System.EventHandler(this.frmConfiguracaoBancoDados_Load);
            this.gbxSeguranca.ResumeLayout(false);
            this.gbxSeguranca.PerformLayout();
            this.ssmBarraInformacao.ResumeLayout(false);
            this.ssmBarraInformacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtServidor;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNomeBancoDados;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCaminhoArquivo;
        private System.Windows.Forms.GroupBox gbxSeguranca;
        private MaterialSkin.Controls.MaterialRadioButton rtnCredenciaisWindows;
        private MaterialSkin.Controls.MaterialRadioButton rtnCredenciaisPersonalizadas;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtUsuario;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSenha;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.Button btnBuscaArquivo;
        private System.Windows.Forms.StatusStrip ssmBarraInformacao;
        private System.Windows.Forms.ToolStripStatusLabel lblResultadoTesteConexao;
        private MaterialSkin.Controls.MaterialRaisedButton btnSair;
        private MaterialSkin.Controls.MaterialRaisedButton btnSalvar;
        public MaterialSkin.Controls.MaterialRaisedButton btnTestarConexao;
    }
}