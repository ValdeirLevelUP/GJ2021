
using UnityEngine;
/// <summary>
/// Interface base para criacao de itens.
/// </summary>
public interface IIten 
{
    /// <summary>
    /// Variavel que retorna dados do item.
    /// </summary>
    ItenData Data { get; }
    /// <summary>
    /// Método que executa item.
    /// </summary>
    bool Usar();
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
