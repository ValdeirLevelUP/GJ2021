using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public delegate void ExibirTexto();
/// <summary>
/// Script para gerenciar os textos do game.
/// </summary>
public class TextoController : MonoBehaviour
{
    #region PRIVATE VARIABLES

    private IEnumerator _exibirTexto;

    [SerializeField] private TextMeshProUGUI _panelTexto;
    #endregion

    #region EVENTS

    public static event ExibirTexto ExibirTexto;
    #endregion

    #region OWN METHODS

    /// <summary>
    /// Método que oculta panel de texto.
    /// </summary>
    public void OcultarTexto()
    {
        ExibirTexto?.Invoke();

        _panelTexto.text = "";

        _exibirTexto = null;
    }

    /// <summary>
    /// Método para exibir texto no panel.
    /// </summary>
    /// <param name="texto"> texto a ser exibido</param>
    public void MostrarTexto(string texto)
    {
        if(_exibirTexto != null)
        { 
            StopCoroutine(_exibirTexto);
        } 
        _exibirTexto = _mostrarTexto(texto);

        StartCoroutine(_exibirTexto);
    }
    #endregion

    #region COROUTINE
    private IEnumerator _mostrarTexto(string texto)
    {
        _panelTexto.text = "";

        ExibirTexto?.Invoke();

        float tempoElapsed = 0;

        Queue<char> textoCompleto = new Queue<char>();

        foreach (char letra in texto)
        {
            textoCompleto.Enqueue(letra);
        }

        yield return new WaitForSeconds(FindObjectOfType<GameManager>().Data.TransicaoTexto);

        while (textoCompleto.Count > 0)
        {
            tempoElapsed += Time.deltaTime;

            if (tempoElapsed > FindObjectOfType<GameManager>().Data.TempoDeExibicaoDeTexto)
            {
                _panelTexto.text += textoCompleto.Dequeue();

                tempoElapsed = 0;
            }

            yield return null;
        }

        yield return new WaitForSeconds(0.8f);

        ExibirTexto?.Invoke();
        _exibirTexto = null;
    }
    #endregion
}
