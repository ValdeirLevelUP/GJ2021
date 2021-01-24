 using TMPro;
using UnityEngine;

/// <summary>
/// Script que agrupa efeitos de texto para o component TextMeshProGUI
/// </summary>
public static class EfeitoTexto
{
    #region OWN METHODS

    /// <summary>
    /// Esse método faz o texto piscar a cada 1 segundo.
    /// </summary>
    /// <param name="texto">Deve receber como paramentro um componente TextMeshProGUI para aplicar o efeito.</param>
    public static void Piscar(TextMeshProUGUI texto)
    {
        texto.color = Color.Lerp(Color.white,
                                 new Color(texto.color.r, texto.color.g, texto.color.b, 0.4f), 
                                 Mathf.PingPong(Time.time, 1));
    }
    #endregion
}
