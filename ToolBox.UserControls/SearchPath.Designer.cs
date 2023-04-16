using MyGears.Components.Buttons;
using MyGears.Components.Containers;
using MyGears.Components.Inputs;

namespace MyGears.UserControls;

partial class SearchPath
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
        components = new System.ComponentModel.Container();
        cgpCaminho = new MyGears.Components.Containers.ContainerGroup( components );
        btfSearch = new MyGears.Components.Buttons.FlatButton( components );
        txtPath = new MyGears.Components.Inputs.TextInput( components );
        cgpCaminho.SuspendLayout();
        SuspendLayout();
        // 
        // cgpCaminho
        // 
        cgpCaminho.Controls.Add( txtPath );
        cgpCaminho.Controls.Add( btfSearch );
        cgpCaminho.Dock = DockStyle.Fill;
        cgpCaminho.Location = new Point( 0, 0 );
        cgpCaminho.Name = "cgpCaminho";
        cgpCaminho.Size = new Size( 505, 45 );
        cgpCaminho.TabIndex = 0;
        cgpCaminho.TabStop = false;
        // 
        // btfSearch
        // 
        btfSearch.Dock = DockStyle.Right;
        btfSearch.FlatStyle = FlatStyle.Flat;
        btfSearch.ForeColor = Color.Black;
        btfSearch.Image = Properties.Resources.icons8_pasta_24;
        btfSearch.Location = new Point( 450, 19 );
        btfSearch.Name = "btfSearch";
        btfSearch.Size = new Size( 52, 23 );
        btfSearch.TabIndex = 0;
        btfSearch.UseVisualStyleBackColor = true;
        btfSearch.Click += OnClick;
        // 
        // txtPath
        // 
        txtPath.Dock = DockStyle.Fill;
        txtPath.Location = new Point( 3, 19 );
        txtPath.Margin = new Padding( 10, 5, 10, 5 );
        txtPath.Name = "txtPath";
        txtPath.PasswordChar = '\0';
        txtPath.PlaceholderText = "";
        txtPath.Size = new Size( 447, 23 );
        txtPath.TabIndex = 1;
        txtPath.Text = "";
        txtPath.WordWrap = true;
        // 
        // SearchPath
        // 
        AutoScaleDimensions = new SizeF( 7F, 15F );
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Transparent;
        Controls.Add( cgpCaminho );
        Name = "SearchPath";
        Size = new Size( 505, 45 );
        cgpCaminho.ResumeLayout( false );
        cgpCaminho.PerformLayout();
        ResumeLayout( false );
    }

    #endregion

    private ContainerGroup cgpCaminho;
    private FlatButton btfSearch;
    private TextInput txtPath;
}