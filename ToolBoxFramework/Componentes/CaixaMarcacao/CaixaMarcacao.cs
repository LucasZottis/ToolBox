using BibliotecaPublica.Estruturas;
using BibliotecaPublica.Interfaces;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace BibliotecaPublica.CaixaFerramenta.Componentes.CaixaMarcacao
{
    public class CaixaMarcacao : CheckBox, IComponente
    {
        #region Atributos

        

        #endregion Atributos

        #region Propriedades

        [
            Browsable( true ),
            Category( TextosPadroes.ValidacaoCategoria ),
            Description( TextosPadroes.FazerValidacaoDescricao ),
            DisplayName( TextosPadroes.FazerValidacao ),
            DefaultValue( false )
        ]
        public bool FazerValidacao
        {
            get; set;
        }

        [
            Browsable( true ),
            Category( TextosPadroes.ComportamentoCategoria ),
            Description( TextosPadroes.BloquearComponenteDescricao ),
            DisplayName( TextosPadroes.BloquearComponente ),
            DefaultValue( false )
        ]
        public bool BloquearComponente
        {
            get; set;
        }

        [
            Browsable( false ),
            Category( TextosPadroes.ComportamentoCategoria ),
            Description( TextosPadroes.BloqueadoDescricao ),
            DisplayName( TextosPadroes.Bloqueado ),
            DefaultValue( false )
        ]
        public bool Bloqueado
        {
            set
            {
                Enabled = !value;
            }
        }

        #endregion Propriedades

        #region Construtores

        public CaixaMarcacao(IContainer container)
        {
            if (container != null)
            {
                container.Add( this );
            }
        }

        #endregion Construtores

        #region Métodos

        #region Privados

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Privados

        #region Protegidos

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Protegidos

        #region Internos

        #region Sobreescritos



        #endregion Sobreescritos



        #endregion Internos

        #region Públicos

        public bool Validar()
        {
            throw new NotImplementedException();
        }

        #endregion Públicos

        #endregion Métodos
    }
}