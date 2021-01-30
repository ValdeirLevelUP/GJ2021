using UnityEngine;


public delegate void GameOver(); 
/// <summary>
/// Script responsavel por controlar medo no game.
/// </summary>
public class MedoController : MonoBehaviour
{
    #region PRIVATE VARIABLE

    public float _timeElapsed;
    private FaceMedo _nivelDeMedo = FaceMedo.SEM_MEDO;
    [SerializeField] private float _medo;
    #endregion 

    #region EVENTS

    public static event GameOver gameOver; 
    public static event MudarFace mudarFace;
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
           float r = -Random.Range(1, FindObjectOfType<GameManager>().Data.QuantidadeDeMedoPorMinuto);
           AlterarQuantidadeDeMedo(r); 
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
        if(_medo > FindObjectOfType<GameManager>().Data.MedoMaximo * 0.75 && _nivelDeMedo != FaceMedo.ESCONDIDA)
        {
            MudarStatus(FaceMedo.SEM_MEDO);
        }else if(_medo < FindObjectOfType<GameManager>().Data.MedoMaximo * 0.75 && _medo > FindObjectOfType<GameManager>().Data.MedoMaximo * 0.50 && _nivelDeMedo != FaceMedo.ESCONDIDA)
        {
            MudarStatus(FaceMedo.UM_POUCO_DE_MEDO);
        }else if (_medo < FindObjectOfType<GameManager>().Data.MedoMaximo * 0.5  && _nivelDeMedo != FaceMedo.ESCONDIDA)
        {
            MudarStatus(FaceMedo.COM_MEDO);
        }
    }
    private void Escondida()
    {
        _nivelDeMedo = FaceMedo.ESCONDIDA;
        mudarFace?.Invoke(_nivelDeMedo);
    }

    private void MudarStatus(FaceMedo nivel)
    {
        _nivelDeMedo = nivel;
        mudarFace?.Invoke(nivel);
    }
    #endregion
}
