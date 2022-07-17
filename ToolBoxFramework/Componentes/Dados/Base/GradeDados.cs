using BibliotecaPublica.BibliotecaPublicaFramework.Classes.Verificadores;
using BibliotecaPublica.BibliotecaPublicaFramework.Estruturas;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ToolBox.ToolBoxFramework.Componentes.Dados.Base
{
    [ToolboxItem( false ), DesignerCategory( "Dados" )]
    public class GradeDadosBase : DataGridView
    {
        #region Atributos

        private bool _gerarColunasAutomaticamente = true;
        private FonteDados _fonteDados;

        #endregion Atributos

        #region Propriedades

        [Browsable( false )]
        //[Category( TextosPadroes.ComportamentoCategoria )]
        //[Description( "Define ou obtém se será gerado as colunas automaticamente." )]
        //[DisplayName( "Gerar colunas automaticamente" )]
        //[DefaultValue( true )]
        public new bool AutoGenerateColumns
        {
            get
            {
                return false;
            }

            set
            {
                base.AutoGenerateColumns = false;
            }
        }

        [Browsable( true )]
        [Category( TextosPadroes.ComportamentoCategoria )]
        [Description( "Define ou obtém se será gerado as colunas automaticamente." )]
        [DisplayName( "Gerar colunas automaticamente" )]
        //[DefaultValue( true )]
        public bool GerarColunasAutomaticamento
        {
            get
            {
                return _gerarColunasAutomaticamente;
            }

            set
            {
                _gerarColunasAutomaticamente = value;
                GerarColunas();
            }
        }

        #endregion Propriedades

        #region Construtores

        public GradeDadosBase()
        {

        }

        #endregion Construtores

        #region Métodos

        #region Privados

        private void GerarColunas()
        {
            if ( !_gerarColunasAutomaticamente )
            {
                return;
            }

            if ( DataSource == null )
            {
                return;
            }

            switch ( DataSource )
            {
                case FonteDados fonteDados:
                {
                    _fonteDados = DataSource as FonteDados;

                    if ( _fonteDados.DataSource is DataSet )
                    {
                        if ( !_fonteDados.DataMember.TemConteudo() )
                        {
                            return;
                        }

                        DataSet fonte = _fonteDados.DataSource as DataSet;
                        DataColumnCollection colecaoColunas = fonte.Tables[ fonteDados.DataMember ].Columns;

                        DataGridViewColumn coluna = null;

                        foreach ( DataColumn colunaTabela in colecaoColunas )
                        {
                            coluna = new DataGridViewColumn();

                            coluna.Name = colunaTabela.ColumnName;
                            coluna.DataPropertyName = colunaTabela.ColumnName;

                            Columns.Add( coluna );
                        }
                    }
                    else if ( _fonteDados.DataSource is DataTable )
                    {
                        DataTable tabela = _fonteDados.DataSource as DataTable;
                        DataColumnCollection colecaoColunas = tabela.Columns;

                        DataGridViewColumn coluna = null;

                        foreach ( DataColumn colunaTabela in colecaoColunas )
                        {
                            coluna = new DataGridViewColumn();

                            coluna.Name = colunaTabela.ColumnName;
                            coluna.DataPropertyName = colunaTabela.ColumnName;

                            Columns.Add( coluna );
                        }
                    }

                    break;
                }

                case FonteLigacao fonteLigacao:
                {
                    if ( fonteLigacao.DataSource is DataSet )
                    {
                        if ( !fonteLigacao.DataMember.TemConteudo() )
                        {
                            return;
                        }

                        DataSet fonte = fonteLigacao.DataSource as DataSet;
                        DataColumnCollection colecaoColunas = fonte.Tables[ fonteLigacao.DataMember ].Columns;

                        DataGridViewColumn coluna = null;

                        foreach ( DataColumn colunaTabela in colecaoColunas )
                        {
                            coluna = new DataGridViewColumn();

                            coluna.Name = colunaTabela.ColumnName;
                            coluna.DataPropertyName = colunaTabela.ColumnName;

                            Columns.Add( coluna );
                        }
                    }

                    break;
                }

                case BindingSourceBase bindingSourceBase:
                {
                    if ( bindingSourceBase.DataSource is DataSet )
                    {
                        if ( !bindingSourceBase.DataMember.TemConteudo() )
                        {
                            return;
                        }

                        DataSet fonte = bindingSourceBase.DataSource as DataSet;
                        DataColumnCollection colecaoColunas = fonte.Tables[ bindingSourceBase.DataMember ].Columns;

                        DataGridViewColumn coluna = null;

                        foreach ( DataColumn colunaTabela in colecaoColunas )
                        {
                            coluna = new DataGridViewColumn();

                            coluna.Name = colunaTabela.ColumnName;
                            coluna.DataPropertyName = colunaTabela.ColumnName;

                            Columns.Add( coluna );
                        }
                    }

                    break;
                }

                case BindingSource bindingSource:
                {
                    if ( bindingSource.DataSource is DataSet )
                    {
                        if ( !bindingSource.DataMember.TemConteudo() )
                        {
                            return;
                        }

                        DataSet fonte = bindingSource.DataSource as DataSet;
                        DataColumnCollection colecaoColunas = fonte.Tables[ bindingSource.DataMember ].Columns;

                        DataGridViewColumn coluna = null;

                        foreach ( DataColumn colunaTabela in colecaoColunas )
                        {
                            coluna = new DataGridViewColumn();

                            coluna.Name = colunaTabela.ColumnName;
                            coluna.DataPropertyName = colunaTabela.ColumnName;

                            Columns.Add( coluna );
                        }
                    }

                    break;
                }

                case DataSet conjuntoTabelas:
                {
                    if ( !DataMember.TemConteudo() )
                    {
                        return;
                    }

                    DataSet fonte = DataSource as DataSet;
                    DataColumnCollection colecaoColunas = ObterColunasDataSet( fonte );

                    DataGridViewColumn coluna = null;

                    foreach ( DataColumn colunaTabela in colecaoColunas )
                    {
                        coluna = new DataGridViewColumn();

                        coluna.Name = colunaTabela.ColumnName;
                        coluna.DataPropertyName = colunaTabela.ColumnName;

                        Columns.Add( coluna );
                    }

                    break;
                }

                case DataTable tabela:
                {
                    break;
                }
            }
        }

        private DataColumnCollection ObterColunasDataSet( DataSet conjuntoTabelas )
        {
            return conjuntoTabelas.Tables[ DataMember ].Columns;
        }

        private DataColumnCollection ObterColunasDataSet( DataTable tabela )
        {
            return tabela.Columns;
        }

        private void RenomearCabecalhos( DataColumnCollection colecaoColunas, DataGridViewColumn colunaGrade )
        {
            if ( colecaoColunas[ colunaGrade.Index ].Caption.TemConteudo() )
            {
                colunaGrade.HeaderText = colecaoColunas[ colunaGrade.Index ].Caption;
            }
        }

        #endregion Privados

        #region Protegidos

        #region Sobreescritos

        //protected override void OnAutoGenerateColumnsChanged( EventArgs e )
        //{
        //    //base.OnAutoGenerateColumnsChanged( e );

        //    if ( AutoGenerateColumns )
        //    {
        //        GerarColunas();
        //    }
        //}

        protected override void OnColumnAdded( DataGridViewColumnEventArgs e )
        {
            base.OnColumnAdded( e );

            switch ( DataSource )
            {
                case DataSet dataSet:
                {
                    RenomearCabecalhos( ObterColunasDataSet( dataSet ), e.Column );
                    break;
                }

                case DataTable tabela:
                {
                    RenomearCabecalhos( ObterColunasDataSet( tabela ), e.Column );
                    break;
                }

                case FonteDados fonteDados:
                {
                    switch ( fonteDados.DataSource )
                    {
                        case DataSet dataSet:
                        {
                            RenomearCabecalhos( ObterColunasDataSet( dataSet ), e.Column );
                            break;
                        }

                        case DataTable tabela:
                        {
                            RenomearCabecalhos( ObterColunasDataSet( tabela ), e.Column );
                            break;
                        }
                    }

                    break;
                }
            }
        }

        protected override void OnDataSourceChanged( EventArgs e )
        {
            base.OnDataSourceChanged( e );

            GerarColunas();
        }

        #endregion Sobreescritos



        #endregion Protegidos

        #region Internos

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Internos

        #endregion Métodos
    }
}