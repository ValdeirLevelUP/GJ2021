using System.Collections; 
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script responsavel pelo fade do game.
/// </summary>
public class FadeController : MonoBehaviour
{
    #region PRIVATE VARIABLES

    [SerializeField] private Image _fade;

    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        MenuInicial.fade += Fade;
        Porta.fade += Fade;
    }
    private void Start()
    {
        StartCoroutine(show());
    }
    private void OnDisable()
    {
        MenuInicial.fade -= Fade;
        Porta.fade -= Fade;
    }
    #endregion

    #region OWN METHODS

    /// <summary>
    /// Método para executar Fade
    /// </summary>
    /// <param name="action">método a ser executado entre fades</param>
    public void Fade(IEnumerator action)
    {
        StartCoroutine(fadeSystem(action));
    }
    #endregion



    #region COROUTINE
    private IEnumerator fadeSystem(IEnumerator action)
    {
        yield return StartCoroutine(hidden());

        yield return StartCoroutine(action);

        yield return StartCoroutine(show());
    }
    private IEnumerator hidden()
    { 
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            Color cor = _fade.color;
            cor = Color.Lerp(_fade.color, new Color(_fade.color.r, _fade.color.g, _fade.color.b, 1), i/0.5f);
            _fade.color = cor;
            yield return null;
        }
        yield break;
    }
    private IEnumerator show()
    {
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            Color cor = _fade.color;
            cor = Color.Lerp(_fade.color, new Color(_fade.color.r, _fade.color.g, _fade.color.b, 0), i/0.5f);
            _fade.color = cor;
            yield return null;
        }
        yield break;
    }
    #endregion
}
