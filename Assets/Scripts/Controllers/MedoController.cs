using UnityEngine;


public delegate void GameOver();
public delegate void MudarFace(float quantidade);
public delegate void Respawn(string regiao, float medo);
/// <summary>
/// Script responsavel por controlar medo no game.
/// </summary>
public class MedoController : MonoBehaviour
{
    #region PRIVATE VARIABLE

    public float _timeElapsed; 
    [SerializeField] private float _medo;
    #endregion

    #region PROPERTIES
    public float TotalMedo { get => _medo; }
    #endregion

    #region EVENTS

    public static event GameOver gameOver; 
    public static event MudarFace mudarFace;
    public static event Respawn respawn;
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
    /// Método que verifica condicao de gameOver
    /// </summary>
    private void MarcadorDeGameOver()
    {
        if (_medo >= FindObjectOfType<GameManager>().Data.MedoMaximo)
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
           float r = Random.Range(1, FindObjectOfType<GameManager>().Data.QuantidadeDeMedoPorMinuto);
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

        mudarFace?.Invoke(_medo);

        respawn?.Invoke(FindObjectOfType<Personagem>().Regiao, _medo);
    }  
    #endregion
}
