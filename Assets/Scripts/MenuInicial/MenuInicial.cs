using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

 public delegate void FadeSystem(IEnumerator action);
public class MenuInicial : MonoBehaviour
{
    #region PRIVATE VARIABLES
    [Tooltip("Primeira tela deve ser a tela de inicio do game")]
    [SerializeField] private CanvasGroup[] _screenOfMenuInicial;
    #endregion

    #region EVENTS 
    public static event FadeSystem fade;
    #endregion

    #region UNITY METHODS
    private void Start()
    {
        StartScreenSystem();
    }
    private void OnEnable()
    {
        ButtonsController.iniciar += StartGame;
        ButtonsController.creditos += OpenCreditos;
        ButtonsController.sairCredito += SairCreditos;
    }
    private void Update()
    {
        StartMenuInicial(); 
    }
    private void OnDisable()
    {
        ButtonsController.iniciar -= StartGame;
        ButtonsController.creditos -= OpenCreditos;
        ButtonsController.sairCredito += SairCreditos; 
    }
    #endregion

    #region OWN METHODS

    /// <summary>
    /// Método que exibe menu inicial do game.
    /// </summary>
    void StartMenuInicial()
    {
        if (Input.anyKeyDown && _screenOfMenuInicial[0].alpha == 1)
        {
            _screenOfMenuInicial[0].alpha = 0; 
            _screenOfMenuInicial[0].blocksRaycasts = false;
            _screenOfMenuInicial[1].alpha = 1;
            _screenOfMenuInicial[1].blocksRaycasts = true; 
        } 
    }

    /// <summary>
    /// Método que garante que apenas a primeira tela seja visivel no inicio do game.
    /// </summary>
    private void StartScreenSystem()
    {
        for (int i = 0; i < _screenOfMenuInicial.Length; i++)
        {
            if(i == 0)
            {
                _screenOfMenuInicial[i].alpha = 1;
                _screenOfMenuInicial[i].blocksRaycasts = true;
            }
            else
            {
                _screenOfMenuInicial[i].alpha = 0;
                _screenOfMenuInicial[i].blocksRaycasts = false;
            } 
        }
    }
    /// <summary>
    /// Método que inicia o gamePlay.
    /// </summary>
    private void StartGame()
    {
        SceneManager.LoadScene(1); 
    }
    /// <summary>
    /// Método que exibi creditos.
    /// </summary>
    private void OpenCreditos()
    {
        OpenCanvas(2);
    }
    /// <summary>
    /// Método que oculta tela de creditos.
    /// </summary>
    private void SairCreditos()
    {
        OpenCanvas(1);
    }
    /// <summary>
    /// Método responsavel exibir uma determinada tela e fechar todas as outras do menu inicial.
    /// </summary>
    /// <param name="v"> indica que tela deve ser aberta</param>
    private void OpenCanvas(int v)
    {
        for (int i = 0; i < _screenOfMenuInicial.Length; i++)
        {
            if(i == v)
            {
                _screenOfMenuInicial[i].alpha = 1;
                _screenOfMenuInicial[i].blocksRaycasts = true;
            }
            else{
                _screenOfMenuInicial[i].alpha = 0;
                _screenOfMenuInicial[i].blocksRaycasts = false;
            }
        }
    }
    #endregion
}
