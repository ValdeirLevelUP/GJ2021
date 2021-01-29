using System.Collections; 
using UnityEngine;
/// <summary>
/// Script responsavel por controlar acoes do hud.
/// </summary>
public class HudController : MonoBehaviour
{
    #region PRIVATE VARIABLES
    [SerializeField] private CanvasGroup _panelTexto;
    #endregion

    #region UNITY METHODS
    private void OnEnable()
    {
        TextoController.ExibirTexto += ExibirTexto;
    }
    private void OnDisable()
    {
        TextoController.ExibirTexto -= ExibirTexto;
    }
    #endregion

    #region OWN METHODS

    /// <summary>
    /// Método chamado para alterar visibilidade do texto.
    /// </summary>
    private void ExibirTexto()
    {
        AlterarVisivilidade(_panelTexto);
    }
    /// <summary>
    /// Método que exibi o panel atraves de coroutine,
    /// </summary>
    /// <param name="panel">recebe uma canvas</param>
    private void AlterarVisivilidade(CanvasGroup panel)
    {
        if(panel.alpha == 1)
        {
            StartCoroutine(_esconder(panel));
        }
        else
        {
            StartCoroutine(_mostrar(panel));
        }
    }
    #endregion

    #region COROUTINES
    private IEnumerator _esconder(CanvasGroup panel)
    {
        float timeElapsed = 0;

        float alpha = 1;

        while (panel.alpha > 0.1f)
        {
            alpha = Mathf.Lerp(panel.alpha, 0, timeElapsed/FindObjectOfType<GameManager>().Data.TransicaoTexto);

            panel.alpha = alpha;

            timeElapsed += Time.deltaTime;

            yield return null;
        }
        panel.alpha = 0;
    }
    private IEnumerator _mostrar(CanvasGroup panel)
    {
        float timeElapsed = 0;

        float alpha = 0;

        while (panel.alpha < 0.9f)
        {
            alpha = Mathf.Lerp(panel.alpha, 1, timeElapsed / FindObjectOfType<GameManager>().Data.TransicaoTexto);

            panel.alpha = alpha;

            timeElapsed += Time.deltaTime;

            yield return null;
        }
        panel.alpha = 1;
    }
    #endregion
}
