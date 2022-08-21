using BibliotecaPublica.BibliotecaPublicaFramework.Classes.Verificadores;
using BibliotecaPublica.BibliotecaPublicaFramework.Estruturas;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ToolBox.ToolBoxWinForms.Framework.Interfaces;

namespace ToolBox.ToolBoxWinForms.Framework.Componentes.CaixaSelecao.Base
{
    [ToolboxItem( false ), DesignerCategory( "Comuns" )]
    public class CaixaSelecaoBase : ComboBox, IComponente, ILimpeza
    {
        #region Atributos

        private IBindingListView _listaVinculada;
        private DataTable _tabela;

        #endregion Atributos

        #region Propriedades

        #region Sobreescritos

        [
            Category( TextosPadroes.AparenciaCategoria ),
            DisplayName( TextosPadroes.CorFundo )
        ]
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

        [
            Category( TextosPadroes.AparenciaCategoria ),
            DisplayName( TextosPadroes.NomeAcessibilidade )
        ]
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

        [
            Category( TextosPadroes.AparenciaCategoria ),
            DisplayName( TextosPadroes.FuncaoAcessibilidade )
        ]
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

        [
            Category( TextosPadroes.AparenciaCategoria ),
            DisplayName( TextosPadroes.CorFundo )
        ]
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

        [
            Category( TextosPadroes.AparenciaCategoria ),
            DisplayName( "Estilo da caixa de seleção" )
        ]
        public new ComboBoxStyle DropDownStyle
        {
            get
            {
                return base.DropDownStyle;
            }

            set
            {
                base.DropDownStyle = value;
            }
        }

        [
            Category( TextosPadroes.AparenciaCategoria ),
            DisplayName( TextosPadroes.EstiloFlatComponente )
        ]
        public new FlatStyle FlatStyle
        {
            get
            {
                return base.FlatStyle;
            }

            set
            {
                base.FlatStyle = value;
            }
        }

        #endregion Sobreescritos

        #region IComponente

        [Browsable( true ), Category( TextosPadroes.ValidacaoCategoria ), Description( TextosPadroes.FazerValidacaoDescricao ), DisplayName( TextosPadroes.FazerValidacao ), DefaultValue( false )]
        public bool FazerValidacao { get; set; } = false;

        [Browsable( true ), Category( TextosPadroes.ComportamentoCategoria ), Description( TextosPadroes.BloquearComponenteDescricao ), DisplayName( TextosPadroes.BloquearComponente ), DefaultValue( false )]
        public bool BloquearComponente { get; set; } = false;

        [Browsable( false )]
        public bool Bloqueado
        {
            set
            {
                base.Enabled = !value;
            }
        }

        #endregion IComponente

        #region ILimpeza

        [Browsable( true ), Category( TextosPadroes.DadosCateogria ), Description( TextosPadroes.FazerLimpezaDescricao ), DisplayName( TextosPadroes.FazerLimpeza ), DefaultValue( false )]
        public bool FazerLimpeza { get; set; } = false;

        #endregion ILimpeza

        #endregion Propriedades

        #region Construtores

        public CaixaSelecaoBase( IContainer container )
        {
            container?.Add( this );
        }

        #endregion Construtores

        #region Métodos

        #region Privados

        private void FiltrarItens()
        {
            if ( _listaVinculada == null )
            {
                return;
            }

            if ( Text.TemConteudo() )
            {
                _listaVinculada.Filter = $"{DisplayMember} LIKE '%{Text}%'";
            }

            DroppedDown = true;
        }

        #endregion Privados

        #region Protegidos

        #region Sobreescritos

        protected override void OnKeyDown( KeyEventArgs e )
        {
            base.OnKeyDown( e );

            if ( e.KeyData == Keys.F3 )
            {
                FiltrarItens();
            }

            if ( Text.EstaVazio() )
            {
                _listaVinculada?.RemoveFilter();
            }
        }

        protected override void OnDataSourceChanged( EventArgs e )
        {
            base.OnDataSourceChanged( e );

            if ( DataSource == null )
            {
                return;
            }

            switch ( DataSource )
            {
                case IBindingListView _:
                {
                    _listaVinculada = DataSource as IBindingListView;
                    break;
                }

                case DataTable _:
                {
                    _tabela = DataSource as DataTable;
                    break;
                }
            }
        }

        #endregion Sobreescritos



        #endregion Protegidos

        #region Internos

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Internos

        #region Públicos

        public void SelecionarItem( object valorSelecionado )
        {
            SelectedValue = valorSelecionado;
        }

        #endregion Públicos

        #region IComponente

        public bool Validar()
        {
            throw new NotImplementedException();
        }

        #endregion IComponente

        #region ILimpeza

        public void Limpar()
        {
            if ( _listaVinculada == null )
            {
                return;
            }

            _listaVinculada.RemoveFilter();
            SelectedIndex = -1;
        }

        #endregion ILimpeza

        #endregion Métodos
    }
}