using System.Collections; 
using UnityEngine;
using UnityEngine.UI;

public delegate void ModificarMovimentacao();
/// <summary>
/// Script responsavel pelo fade do game.
/// </summary>
public class FadeController : MonoBehaviour
{
    #region PRIVATE VARIABLES

    [SerializeField] private Image _fade;

    #endregion

    #region EVENTS
    public static event ModificarMovimentacao modificarMovimento;
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
        modificarMovimento?.Invoke();

        yield return StartCoroutine(hidden());

        yield return StartCoroutine(action);

        yield return StartCoroutine(show());

        modificarMovimento?.Invoke();
    }
    private IEnumerator hidden()
    { 
        for (float i = 0; i < 0.5f; i += Time.unscaledDeltaTime)
        {
            Color cor = _fade.color;
            cor = Color.Lerp(_fade.color, new Color(_fade.color.r, _fade.color.g, _fade.color.b, 1), i/0.5f);
            _fade.color = cor;
            yield return null;
        }
        _fade.color = Color.black; 
        yield break;
    }
    private IEnumerator show()
    {
        for (float i = 0; i < 1f; i += Time.unscaledDeltaTime)
        {
            Color cor = _fade.color;
            cor = Color.Lerp(_fade.color, new Color(_fade.color.r, _fade.color.g, _fade.color.b, 0), i);
            _fade.color = cor;
            yield return null;
        }
        _fade.color = new Color(0, 0, 0, 0); 
        yield break;
    }
    #endregion
}
