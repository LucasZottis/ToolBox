using System.Drawing;

namespace MyGears.Helpers;

/// <summary>
/// Contém métodos de auxilio de calculo de posição de componentes.
/// </summary>
public static class PointHelper
{
    /// <summary>
    /// Obtém o ponto central de um componente a partir do seu tamanho.
    /// </summary>
    /// <param name="componentSize">Tamanho do componente.</param>
    /// <returns>Retorno um novo point com o ponto central do componente.</returns>
    public static Point GetCenterPoint( Size componentSize )
        => new Point( componentSize.Width / 2, componentSize.Height / 2 );
}