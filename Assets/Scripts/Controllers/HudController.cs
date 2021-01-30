using System.Collections; 
using UnityEngine;
using UnityEngine.UI;

public delegate void MudarFace(FaceMedo face);
/// <summary>
/// Script responsavel por controlar acoes do hud.
/// </summary>
public class HudController : MonoBehaviour
{
    #region PRIVATE VARIABLES

    [SerializeField] private Image _facePersonagem;
    [SerializeField] private CanvasGroup _panelTexto;
    [SerializeField] private Sprite _spriteSemMedo;
    [SerializeField] private Sprite _spriteUmPoucoDeMedo;
    [SerializeField] private Sprite _spriteComMedo;
    [SerializeField] private Sprite _spriteDentroDaCaixa;
    #endregion

    #region UNITY METHODS
    private void OnEnable()
    {
        TextoController.ExibirTexto += ExibirTexto;
        MedoController.mudarFace += AlterarHudMedo;
    } 
    private void OnDisable()
    {
        TextoController.ExibirTexto -= ExibirTexto;
        MedoController.mudarFace -= AlterarHudMedo;
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

    /// <summary>
    /// Método que trocar sprites da face do personagem;
    /// </summary>
    /// <param name="face"></param>
    private void AlterarHudMedo(FaceMedo face)
    {
        switch (face)
        {
            case FaceMedo.SEM_MEDO:
                _facePersonagem.sprite = _spriteSemMedo;
                break;
            case FaceMedo.UM_POUCO_DE_MEDO:
                _facePersonagem.sprite = _spriteUmPoucoDeMedo;
                break;
            case FaceMedo.COM_MEDO:
                _facePersonagem.sprite = _spriteComMedo;
                break;
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
public enum FaceMedo
{
    SEM_MEDO,
    UM_POUCO_DE_MEDO,
    COM_MEDO,
    ESCONDIDA
}
