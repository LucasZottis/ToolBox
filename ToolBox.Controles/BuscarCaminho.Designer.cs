namespace ToolBox.Controles
{
    partial class BuscarCaminho
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cgpCaminho = new ToolBox.Painel.CaixaGrupo(this.components);
            this.cxtCaminho = new ToolBox.CaixaTexto.CaixaTexto(this.components);
            this.btfBuscar = new ToolBox.Botao.BotaoFlat(this.components);
            this.cgpCaminho.SuspendLayout();
            this.SuspendLayout();
            // 
            // cgpCaminho
            // 
            this.cgpCaminho.Controls.Add(this.cxtCaminho);
            this.cgpCaminho.Controls.Add(this.btfBuscar);
            this.cgpCaminho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgpCaminho.Location = new System.Drawing.Point(0, 0);
            this.cgpCaminho.Name = "cgpCaminho";
            this.cgpCaminho.Size = new System.Drawing.Size(505, 45);
            this.cgpCaminho.TabIndex = 0;
            this.cgpCaminho.TabStop = false;
            // 
            // cxtCaminho
            // 
            this.cxtCaminho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cxtCaminho.Location = new System.Drawing.Point(3, 19);
            this.cxtCaminho.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.cxtCaminho.Name = "cxtCaminho";
            this.cxtCaminho.PasswordChar = '\0';
            this.cxtCaminho.PlaceholderText = "";
            this.cxtCaminho.Size = new System.Drawing.Size(447, 23);
            this.cxtCaminho.TabIndex = 1;
            this.cxtCaminho.Text = "";
            this.cxtCaminho.WordWrap = true;
            // 
            // btfBuscar
            // 
            this.btfBuscar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btfBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btfBuscar.ForeColor = System.Drawing.Color.Black;
            this.btfBuscar.Image = global::ToolBox.Controles.Properties.Resources.icons8_pasta_24;
            this.btfBuscar.Location = new System.Drawing.Point(450, 19);
            this.btfBuscar.Name = "btfBuscar";
            this.btfBuscar.Size = new System.Drawing.Size(52, 23);
            this.btfBuscar.TabIndex = 0;
            this.btfBuscar.UseVisualStyleBackColor = true;
            this.btfBuscar.Click += new System.EventHandler(this.Buscar);
            // 
            // BuscarCaminho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cgpCaminho);
            this.Name = "BuscarCaminho";
            this.Size = new System.Drawing.Size(505, 45);
            this.cgpCaminho.ResumeLayout(false);
            this.cgpCaminho.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Painel.CaixaGrupo cgpCaminho;
        private Botao.BotaoFlat btfBuscar;
        private CaixaTexto.CaixaTexto cxtCaminho;
    }
}