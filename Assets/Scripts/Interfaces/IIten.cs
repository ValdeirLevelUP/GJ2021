
using UnityEngine;
/// <summary>
/// Interface base para criacao de itens.
/// </summary>
public interface IIten 
{
    /// <summary>
    /// Método que retorna dados do item.
    /// </summary>
    ItenData Data { get; }
    /// <summary>
    /// Método que executa item.
    /// </summary>
    void Usar();
    /// <summary>
    /// Método que retorna imagem para a interface.
    /// </summary>
    /// <returns></returns>
    Sprite GetIcon();

    /// <summary>
    /// Método que oculta item no cenário.
    /// </summary>
    void Ocultar();
}
