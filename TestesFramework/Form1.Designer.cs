namespace TestesFramework
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.caixaTextoMonetaria1 = new ToolBox.ToolBoxFramework.Componentes.CaixaTexto.CaixaTextoMonetaria(this.components);
            this.SuspendLayout();
            // 
            // caixaTextoMonetaria1
            // 
            this.caixaTextoMonetaria1.Location = new System.Drawing.Point(508, 138);
            this.caixaTextoMonetaria1.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.caixaTextoMonetaria1.MaxLength = 120000;
            this.caixaTextoMonetaria1.Name = "caixaTextoMonetaria1";
            this.caixaTextoMonetaria1.PasswordChar = '\0';
            this.caixaTextoMonetaria1.PermitirLetras = false;
            this.caixaTextoMonetaria1.PermitirSimbolos = false;
            this.caixaTextoMonetaria1.Size = new System.Drawing.Size(100, 20);
            this.caixaTextoMonetaria1.TabIndex = 0;
            this.caixaTextoMonetaria1.Text = "";
            this.caixaTextoMonetaria1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.caixaTextoMonetaria1.Valor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.caixaTextoMonetaria1.WordWrap = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.caixaTextoMonetaria1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolBox.ToolBoxFramework.Componentes.CaixaTexto.CaixaTextoMonetaria caixaTextoMonetaria1;
    }
}

