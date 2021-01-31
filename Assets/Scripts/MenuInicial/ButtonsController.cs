using UnityEngine;
using UnityEngine.UI;

public delegate void OnClickButtons();
/// <summary>
/// Script responsavem por setar funcoes de cada botao do menu inicial
/// </summary>
public class ButtonsController : MonoBehaviour
{
    #region PRIVATE VARIABLES
    [SerializeField] private Button _iniciar;
    [SerializeField] private Button _creditos;
    [SerializeField] private Button _sairJogo;
    [SerializeField] private Button _sairCreditos;
    [SerializeField] private AudioSource _audioMenu;
    #endregion

    #region EVENTS VARIABLES
    public static event OnClickButtons creditos;
    public static event OnClickButtons sairCredito;
    public static event OnClickButtons iniciar;
    #endregion

    #region UNITY METHODS 
    private void Awake()
    {
        SetButtonEvents();
    }
    #endregion

    #region OWN METHODS
    private void SetButtonEvents()
    {
        _iniciar.onClick.AddListener(GetIniciar);
        _creditos.onClick.AddListener(GetCreditos);
        _sairJogo.onClick.AddListener(GetSairDoJogo);
        _sairCreditos.onClick.AddListener(GetSairCreditos);
    }

    private void GetSairCreditos()
    {
        _audioMenu.Play(); 
        sairCredito?.Invoke();
    }

    private void GetSairDoJogo()
    { 
        _audioMenu.Play();
        Application.Quit();
    }

    private void GetCreditos()
    { 
        _audioMenu.Play();
        creditos?.Invoke();
    }

    private void GetIniciar()
    {
        _audioMenu.Play();
        iniciar.Invoke();
    }
    #endregion
}
