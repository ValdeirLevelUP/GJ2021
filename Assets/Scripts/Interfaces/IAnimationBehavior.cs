using UnityEngine;
/// <summary>
/// Interface para controle de animacao do personagem.
/// </summary>
public interface IAnimationBehavior
{
    /// <summary>
    /// Método para atualizar animacoes.
    /// </summary>
    /// <param name="velocity"></param>
    void Animar(Vector2Int velocity);
}
