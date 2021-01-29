using UnityEngine;

/// <summary>
/// Interface base para script de movimento
/// </summary>
public interface IMovimentBehavior  
{ 
    /// <summary>
    /// Método para executar o movimento.
    /// </summary>
    /// <param name="direction"> direcao do movimento</param>
    void Mover(Vector2 direction);
}
