using BibliotecaPublica.BibliotecaPublicaFramework.Enums;
using BibliotecaPublica.BibliotecaPublicaFramework.Estruturas;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ToolBox.ToolBoxFramework.Interfaces;

namespace ToolBox.ToolBoxFramework.Componentes.CaixaTexto
{
    [DesignerCategory( "Caixa de Texto" ), ToolboxItem( true )]
    public class CaixaTextoMascara : MaskedTextBox, IComponente
    {
        #region Atributos

        private bool _fazerValidacao = true;
        private bool _bloquearComponente = false;
        private TipoMascara _tipoMascara = TipoMascara.Nenhum;

        #endregion Atributos

        #region Propriedades

        #region Propriedades Sobreescritas

        #region Acessibilidade

        [Browsable( false )]
        public new string AccessibleDescription
        {
            get
            {
                return base.AccessibleDescription;
            }

            set
            {
                base.AccessibleDescription = value;
            }
        }

        [Browsable( false )]
        public new string AccessibleName
        {
            get
            {
                return base.AccessibleName;
            }

            set
            {
                base.AccessibleName = value;
            }
        }

        [Browsable( false )]
        public new AccessibleRole AccessibleRole
        {
            get
            {
                return base.AccessibleRole;
            }

            set
            {
                base.AccessibleRole = value;
            }
        }

        #endregion Acessibilidade

        #region Aparência

        [Browsable( false )]
        public new Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
            }
        }

        [Browsable( false )]
        public new BorderStyle BorderStyle
        {
            get
            {
                return base.BorderStyle;
            }

            set
            {
                base.BorderStyle = value;
            }
        }

        [Browsable( false )]
        public new Cursor Cursor
        {
            get
            {
                return base.Cursor;
            }

            set
            {
                base.Cursor = value;
            }
        }

        [Browsable( false )]
        public new Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                base.Font = value;
            }
        }

        [Browsable( false )]
        public new Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                base.ForeColor = value;
            }
        }

        [Browsable( false )]
        public new string[] Lines
        {
            get
            {
                return base.Lines;
            }

            set
            {
                base.Lines = value;
            }
        }

        [Browsable( false )]
        public new RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }

            set
            {
                base.RightToLeft = value;
            }
        }

        [Browsable( false )]
        public new string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }

        [Browsable( false )]
        public new HorizontalAlignment TextAlign
        {
            get
            {
                return base.TextAlign;
            }

            set
            {
                base.TextAlign = value;
            }
        }

        [Browsable( false )]
        public new bool UseWaitCursor
        {
            get
            {
                return base.UseWaitCursor;
            }

            set
            {
                base.UseWaitCursor = value;
            }
        }

        [Browsable( false )]
        private new string Mask
        {
            get { return base.Mask; }
            set { base.Mask = value; }
        }

        #endregion Aparência

        #region Comportamento

        [Browsable( false )]
        public new bool AcceptsTab
        {
            get
            {
                return base.AcceptsTab;
            }

            set
            {
                base.AcceptsTab = value;
            }
        }

        [Browsable( false )]
        public new bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }

            set
            {
                base.AllowDrop = value;
            }
        }

        [Browsable( false )]
        public new ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return base.ContextMenuStrip;
            }

            set
            {
                base.ContextMenuStrip = value;
            }
        }

        [Browsable( false )]
        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }

            set
            {
                base.Enabled = value;
            }
        }

        [Browsable( false )]
        public new bool HideSelection
        {
            get
            {
                return base.HideSelection;
            }

            set
            {
                base.HideSelection = value;
            }
        }

        [Browsable( false )]
        public new ImeMode ImeMode
        {
            get
            {
                return base.ImeMode;
            }

            set
            {
                base.ImeMode = value;
            }
        }

        [Browsable( false )]
        public new int MaxLength
        {
            get
            {
                return base.MaxLength;
            }

            set
            {
                base.MaxLength = value;
            }
        }

        [Browsable( false )]
        public new bool Multiline
        {
            get
            {
                return base.Multiline;
            }

            set
            {
                base.Multiline = value;
            }
        }

        [Browsable( false )]
        public new char PasswordChar
        {
            get
            {
                return base.PasswordChar;
            }

            set
            {
                base.PasswordChar = value;
            }
        }

        [Browsable( false )]
        public new bool ReadOnly
        {
            get
            {
                return base.ReadOnly;
            }

            set
            {
                base.ReadOnly = value;
            }
        }

        [Browsable( false )]
        public new bool ShortcutsEnabled
        {
            get
            {
                return base.ShortcutsEnabled;
            }

            set
            {
                base.ShortcutsEnabled = value;
            }
        }

        [Browsable( false )]
        public new int TabIndex
        {
            get
            {
                return base.TabIndex;
            }

            set
            {
                base.TabIndex = value;
            }
        }

        [Browsable( false )]
        public new bool TabStop
        {
            get
            {
                return base.TabStop;
            }

            set
            {
                base.TabStop = value;
            }
        }

        [Browsable( false )]
        public new bool UseSystemPasswordChar
        {
            get
            {
                return base.UseSystemPasswordChar;
            }

            set
            {
                base.UseSystemPasswordChar = value;
            }
        }

        [Browsable( false )]
        public new bool Visible
        {
            get
            {
                return base.Visible;
            }

            set
            {
                base.Visible = value;
            }
        }

        [Browsable( false )]
        public new bool WordWrap
        {
            get
            {
                return base.WordWrap;
            }

            set
            {
                base.WordWrap = value;
            }
        }

        #endregion Comportamento

        #region Diversos


        #endregion Diversos

        #region Foco

        [Browsable( false )]
        public new bool CausesValidation
        {
            get
            {
                return base.CausesValidation;
            }

            set
            {
                base.CausesValidation = value;
            }
        }

        #endregion Foco

        #region Layout

        [Browsable( false )]
        public new AnchorStyles Anchor
        {
            get
            {
                return base.Anchor;
            }

            set
            {
                base.Anchor = value;
            }
        }

        [Browsable( false )]
        public new DockStyle Dock
        {
            get
            {
                return base.Dock;
            }

            set
            {
                base.Dock = value;
            }
        }

        [Browsable( false )]
        public new Point Location
        {
            get
            {
                return base.Location;
            }

            set
            {
                base.Location = value;
            }
        }

        [Browsable( false )]
        public new Padding Margin
        {
            get
            {
                return base.Margin;
            }

            set
            {
                base.Margin = value;
            }
        }

        [Browsable( false )]
        public new Size MaximumSize
        {
            get
            {
                return base.MaximumSize;
            }

            set
            {
                base.MaximumSize = value;
            }
        }

        [Browsable( false )]
        public new Size MinimumSize
        {
            get
            {
                return base.MinimumSize;
            }

            set
            {
                base.MinimumSize = value;
            }
        }

        [Browsable( false )]
        public new Size Size
        {
            get
            {
                return base.Size;
            }

            set
            {
                base.Size = value;
            }
        }

        #endregion Layout

        #endregion Propriedades Sobreescritas

        #region Propriedades de Interface

        #region IComponentes

        [
            Browsable( true ),
            Category( TextosPadroes.ValidacaoCategoria ),
            DisplayName( TextosPadroes.FazerValidacao ),
            Description( TextosPadroes.FazerValidacaoDescricao ),
            DefaultValue( true )
        ]
        public bool FazerValidacao
        {
            get
            {
                return _fazerValidacao;
            }

            set
            {
                _fazerValidacao = true;
            }
        }

        [
            Browsable( true ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DisplayName( TextosPadroes.BloquearComponente ),
            Description( TextosPadroes.BloquearComponenteDescricao ),
            DefaultValue( false )
        ]
        public bool BloquearComponente
        {
            get
            {
                return _bloquearComponente;
            }

            set
            {
                _bloquearComponente = value;
            }
        }

        [
            Browsable( false ),
            Category( TextosPadroes.ComportamentoCategoria ),
            DisplayName( TextosPadroes.Bloqueado ),
            Description( TextosPadroes.BloqueadoDescricao ),
            DefaultValue( false )
        ]
        public bool Bloqueado
        {
            set
            {
                Enabled = !value;
            }
        }

        #endregion IComponentes


        #endregion Propriedades de Interface

        #region Acessibilidade

        [Browsable( true ), Category( "Acessibilidade" ), Description( "A descrição a ser relatada para os cliente de acessibilidade." ), DisplayName( "Descrição" )]
        public string Descricao
        {
            get
            {
                return AccessibleDescription;
            }

            set
            {
                AccessibleDescription = value;
            }
        }

        [Browsable( true ), Category( "Acessibilidade" ), Description( "O nome a ser relatada para os cliente de acessibilidade." ), DisplayName( "Nome" )]
        public string Nome
        {
            get
            {
                return AccessibleName;
            }

            set
            {
                AccessibleName = value;
            }
        }

        [Browsable( true ), Category( "Acessibilidade" ), Description( "A função a ser relatada para os cliente de acessibilidade." ), DisplayName( "Função" )]
        public AccessibleRole Funcao
        {
            get
            {
                return AccessibleRole;
            }

            set
            {
                AccessibleRole = value;
            }
        }

        #endregion Acessibilidade

        #region Aparência

        [Browsable( true ), Category( "Aparência" ), Description( "Cor de fundo da caixa." ), DisplayName( "Cor de fundo" )]
        public Color CorFundo
        {
            get
            {
                return BackColor;
            }

            set
            {
                BackColor = value;
            }
        }

        [Browsable( true ), Category( "Aparência" ), Description( "Estilo da borda da caixa." ), DisplayName( "Estilo de borda" )]
        public BorderStyle EstiloBorda
        {
            get
            {
                return BorderStyle;
            }

            set
            {
                BorderStyle = value;
            }
        }

        [Browsable( true ), Category( "Aparência" ), Description( "Estilo da fonte que será usado no texto." ), DisplayName( "Estilo da fonte" )]
        public Font Fonte
        {
            get
            {
                return Font;
            }

            set
            {
                Font = value;
            }
        }

        [Browsable( true ), Category( "Aparência" ), Description( "Cor do texto." ), DisplayName( "Cor do texto" )]
        public Color CorFonte
        {
            get
            {
                return ForeColor;
            }

            set
            {
                ForeColor = value;
            }
        }

        [Browsable( true ), Category( "Aparência" ), Description( "Obtém ou define o tamanho da caixa de texto." ), DisplayName( "Tamanho" )]
        public Size Tamanho
        {
            get
            {
                return Size;
            }

            set
            {
                Size = value;
            }
        }

        #endregion Aparência

        #region Comportamento

        [Browsable( true ), Category( "Comportamento" ), Description( "Obtem ou define o alinhamento do texto." ), DisplayName( "Alinhamento de texto" )]
        public HorizontalAlignment AlinhamentoTexto
        {
            get
            {
                return TextAlign;
            }

            set
            {
                TextAlign = value;
            }
        }

        [Browsable( true ), Category( "Comportamento" ), Description( "Obtem ou define o menu ao clicar com o botão direito do mouse." ), DisplayName( "Menu ao clicar botão direito" )]
        public ContextMenuStrip MenuStrip
        {
            get
            {
                return ContextMenuStrip;
            }

            set
            {
                ContextMenuStrip = value;
            }
        }

        [Browsable( true ), Category( "Comportamento" ), Description( "Obtem ou define se a caixa de texto está habilitada." ), DisplayName( "Habilitada" )]
        public bool Habilitado
        {
            get
            {
                return Enabled;
            }

            set
            {
                Enabled = value;
            }
        }

        [Browsable( true ), Category( "Comportamento" ), Description( "Obtem ou define se a caixa de texto será apenas para leitura." ), DisplayName( "Apenas leitura" )]
        public bool ApenasLeitura
        {
            get
            {
                return ReadOnly;
            }

            set
            {
                ReadOnly = value;
            }
        }

        [Browsable( true ), Category( "Comportamento" ), Description( "Obtem ou define o índice da tabulação." ), DisplayName( "Índice de tabulação" )]
        public int PosicaoTabulacao
        {
            get
            {
                return TabIndex;
            }

            set
            {
                TabIndex = value;
            }
        }

        [Browsable( true ), Category( "Comportamento" ), Description( "Obtem ou define se deve parar na caixa de texto." ), DisplayName( "Parar na caixa de texto" )]
        public bool PararNoCaixaTexto
        {
            get
            {
                return TabStop;
            }

            set
            {
                TabStop = value;
            }
        }

        [Browsable( true ), Category( "Comportamento" ), Description( "Obtem ou define se a caixa de texto deve estár invisivel no formulário." ), DisplayName( "Visível" )]
        public bool Visivel
        {
            get
            {
                return Visible;
            }

            set
            {
                Visible = value;
            }
        }

        [Browsable( true ), Category( "Comportamento" ), Description( "Obtem ou define a âncora da caixa de texto." ), DisplayName( "Âncora" )]
        public AnchorStyles Ancora
        {
            get
            {
                return Anchor;
            }

            set
            {
                Anchor = value;
            }
        }

        [Browsable( true ), Category( "Comportamento" ), Description( "Obtem ou define qual parte do formulário a caixa de texto irá ficar fixada." ), DisplayName( "Fixado" )]
        public DockStyle Fixado
        {
            get
            {
                return Dock;
            }

            set
            {
                Dock = value;
            }
        }

        [Browsable( true ), Category( "Comportamento" ), Description( "Obtem ou define o tamanho máximo que a caixa de texto pode ficar." ), DisplayName( "Tamanho máximo" )]
        public Size TamanhoMaximo
        {
            get
            {
                return MaximumSize;
            }

            set
            {
                MaximumSize = value;
            }
        }

        [Browsable( true ), Category( "Comportamento" ), Description( "Obtem ou define o tamanho mínimo que a caixa de texto pode ficar." ), DisplayName( "Tamanho mínimo" )]
        public Size TamanhoMinimo
        {
            get
            {
                return MinimumSize;
            }

            set
            {
                MinimumSize = value;
            }
        }

        #endregion Comportamento

        #region Dados

        [Browsable( true ), Category( "Dados" ), Description( "Texto da caixa." ), DisplayName( "Texto" )]
        public string Texto
        {
            get
            {
                return Text;
            }

            set
            {
                Text = value;
            }
        }

        [Category( "Dados" ), Description( "Define o tipo de máscara que será utilizado no controle." ), DefaultValue( "" ), Browsable( true )]
        public string Mascara
        {
            get
            {
                return Mask;
            }

            set
            {
                Mask = value;
            }
        }

        #endregion Dados

        #region Diversos

        [Browsable( true ), Category( "Diversos" ), Description( "Obtém ou define a localização da caixa de texto em relação ao formulário." ), DisplayName( "Localização" )]
        public Point Localizacao
        {
            get
            {
                return Location;
            }

            set
            {
                Location = value;
            }
        }

        #endregion Diversos

        #endregion Propriedades

        #region Cosntrutores

        public CaixaTextoMascara()
        {
            //DefinirTamanhoMaximo();
            CriarMascara();
        }

        #endregion Cosntrutores

        #region Métodos Privados

        //private void DefinirTamanhoMaximo()
        //{
        //    switch (Mascara)
        //    {
        //        case TipoMascara.Nenhum:
        //        {
        //            MaxLength = 0;
        //            break;
        //        }

        //        case TipoMascara.Telefone:
        //        {
        //            MaxLength = 14;
        //            break;
        //        }

        //        case TipoMascara.Celular:
        //        {
        //            MaxLength = 15;
        //            break;
        //        }

        //        case TipoMascara.Cep:
        //        {
        //            MaxLength = 9;
        //            break;
        //        }

        //        case TipoMascara.Cpf:
        //        {
        //            MaxLength = 14;
        //            break;
        //        }

        //        case TipoMascara.Cnpj:
        //        {
        //            MaxLength = 18;
        //            break;
        //        }

        //        case TipoMascara.NumeroNotaFiscal:
        //        {
        //            MaxLength = 11;
        //            break;
        //        }

        //    }
        //}

        #region Métodos CriarMascara

        private string CriarMascaraTelefone()
        {
            return "(00) 0000-0000";
        }

        private string CriarMascaraCelular()
        {
            return "(00) 0 0000-0000";
        }

        private string CriarMascaraCep()
        {
            return "00000-000";
        }

        private string CriarMascaraCpf()
        {
            return "000.000.000-00";
        }

        private string CriarMascaraCnpj()
        {
            return "00.000.000/0000-00";
        }

        private string CriarMascarNumeroNotaFiscal()
        {
            return "000.000.000";
        }

        private void CriarMascara()
        {
            switch ( _tipoMascara )
            {
                case TipoMascara.Telefone:
                {
                    Mask = CriarMascaraTelefone();
                    break;
                }

                case TipoMascara.Celular:
                {

                    Mask = CriarMascaraCelular();
                    break;
                }

                case TipoMascara.Cep:
                {
                    Mask = CriarMascaraCep();
                    break;
                }

                case TipoMascara.Cpf:
                {
                    Mask = CriarMascaraCpf();
                    break;
                }

                case TipoMascara.Cnpj:
                {
                    Mask = CriarMascaraCnpj();
                    break;
                }

                case TipoMascara.NumeroNotaFiscal:
                {
                    Mask = CriarMascarNumeroNotaFiscal();
                    break;
                }
            }
        }

        #endregion Métodos CriarMascara

        #endregion Métodos Privados

        #region Métodos Internos

        public bool ValidarCampo()
        {
            throw new NotImplementedException();
        }

        public bool Validar()
        {
            throw new NotImplementedException();
        }

        #endregion Métodos Internos

        #region Métodos Sobrescritos



        #endregion Métodos Sobrescritos
    }
}