using UnityEngine;


public delegate void GameOver();
public delegate void HUDMedo(float quantidade);
/// <summary>
/// Script responsavel por controlar medo no game.
/// </summary>
public class MedoController : MonoBehaviour
{
    #region PRIVATE VARIABLE

    private float _timeElapsed;
    [SerializeField] private float _medo;
    #endregion 

    #region EVENTS

    public static event GameOver gameOver;
    public static event HUDMedo hud;
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        _medo = FindObjectOfType<GameManager>().Data.MedoInicial;
    }
    private void Update()
    {
        MarcadorDeGameOver();

        AumentarMedoComOTempo();
    }
    #endregion

    #region OWN METHODS
    /// <summary>
    /// Método responsavel por visualizar medo.
    /// </summary>
    private void AlterarHudPorMedo()
    {

    }
    /// <summary>
    /// Método que verifica condicao de gameOver
    /// </summary>
    private void MarcadorDeGameOver()
    {
        if (_medo <= 0)
        {
            gameOver?.Invoke();
        }
    }
    /// <summary>
    /// Método responsavel por diminuir a quantidade de medo.
    /// </summary>
    /// <param name="quantidade">Quantidade de medo a ser diminuida</param>
    public void DiminuirMedo(float quantidade)
    {
        AlterarQuantidadeDeMedo(quantidade);
    }
    /// <summary>
    /// Método responsavel por aumentar medo com o passar do tempo.
    /// </summary>
    private void AumentarMedoComOTempo()
    {
        _timeElapsed += Time.deltaTime;

        if(_timeElapsed > 60)
        {
            AlterarQuantidadeDeMedo(-Random.Range(1, FindObjectOfType<GameManager>().Data.QuantidadeDeMedoPorMinuto));

            _timeElapsed = 0;
        }
    }
    /// <summary>
    /// Método responsavel por alterar a quantidade de medo.
    /// </summary>
    /// <param name="quantidade"></param>
    private void AlterarQuantidadeDeMedo(float quantidade)
    {
        _medo += quantidade;
    }
    #endregion
}
