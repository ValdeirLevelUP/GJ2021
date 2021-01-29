 using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script responsavel por controlar os itens do game.
/// </summary>
public class ItensController : MonoBehaviour
{
    #region PRIVATE VARIABLES

    private IIten _itemColetado;

    [SerializeField] private Image _hudIcone;
    #endregion

    #region OWN METHODS
    /// <summary>
    /// Método para coletar itens.
    /// </summary>
    /// <param name="iten"> item coletado</param>
    public void ColetarItem(IIten iten)
    {
        if (iten == null) return;

        _itemColetado = iten;

        _hudIcone.sprite = iten.Data.Icon;
    }
    /// <summary>
    /// Método para executar funçao do item.
    /// </summary>
    public void UsarItem()
    {
        if (_itemColetado == null) return;

        _itemColetado.Usar();
    }
    #endregion
}
