namespace ToolBox.UserControls
{
    partial class Search
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
            components =  new System.ComponentModel.Container() ;
            cgpCaminho =  new Containers.ContainerGroup( components ) ;
            cxtCaminho =  new TextBoxes.CaixaTexto( components ) ;
            btfBuscar =  new Buttons.FlatButton( components ) ;
            cgpCaminho.SuspendLayout();
            SuspendLayout();
            // 
            // cgpCaminho
            // 
            cgpCaminho.Controls.Add( cxtCaminho );
            cgpCaminho.Controls.Add( btfBuscar );
            cgpCaminho.Dock =  DockStyle.Fill ;
            cgpCaminho.Location =  new Point( 0, 0 ) ;
            cgpCaminho.Name =  "cgpCaminho" ;
            cgpCaminho.Size =  new Size( 505, 45 ) ;
            cgpCaminho.TabIndex =  0 ;
            cgpCaminho.TabStop =  false ;
            // 
            // cxtCaminho
            // 
            cxtCaminho.Dock =  DockStyle.Fill ;
            cxtCaminho.Location =  new Point( 3, 19 ) ;
            cxtCaminho.Margin =  new Padding( 10, 5, 10, 5 ) ;
            cxtCaminho.Name =  "cxtCaminho" ;
            cxtCaminho.PasswordChar =  '\0' ;
            cxtCaminho.PlaceholderText =  "" ;
            cxtCaminho.Size =  new Size( 447, 23 ) ;
            cxtCaminho.TabIndex =  1 ;
            cxtCaminho.Text =  "" ;
            // 
            // btfBuscar
            // 
            btfBuscar.Dock =  DockStyle.Right ;
            btfBuscar.FlatStyle =  FlatStyle.Flat ;
            btfBuscar.ForeColor =  Color.Black ;
            btfBuscar.Image = UserControls.Properties.Resources.icons8_pasta_24 ;
            btfBuscar.Location =  new Point( 450, 19 ) ;
            btfBuscar.Name =  "btfBuscar" ;
            btfBuscar.Size =  new Size( 52, 23 ) ;
            btfBuscar.TabIndex =  0 ;
            btfBuscar.UseVisualStyleBackColor =  true ;
            btfBuscar.Click +=  Buscar ;
            // 
            // BuscarCaminho
            // 
            AutoScaleDimensions =  new SizeF( 7F, 15F ) ;
            AutoScaleMode =  AutoScaleMode.Font ;
            BackColor =  Color.Transparent ;
            Controls.Add( cgpCaminho );
            Name =  "BuscarCaminho" ;
            Size =  new Size( 505, 45 ) ;
            cgpCaminho.ResumeLayout( false );
            cgpCaminho.PerformLayout();
            ResumeLayout( false );
        }

        #endregion

        private Containers.ContainerGroup cgpCaminho;
        private Buttons.FlatButton btfBuscar;
        private TextBoxes.CaixaTexto cxtCaminho;
    }
}