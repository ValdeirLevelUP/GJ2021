using UnityEngine;

/// <summary>
/// Script principal que executa o gameplay.
/// </summary>
 public class GameManager : MonoBehaviour
{
    #region PRIVATE VARIABLES 
    private Personagem _personagem;
    private bool _movimento = true;
    [SerializeField] private GameData _data;
    [SerializeField] private MapaSala[] _regioes;
    #endregion

    #region EVENTS
    public static event PlayMusic playMusic;
    #endregion

    #region PROPERTIES
    public bool Movimento { get => _movimento; }
    public GameData Data { get => _data; }
    public MapaSala[] Mapas { get => _regioes; }

    public Personagem Personagem { get => _personagem; }
    #endregion

    #region UNITY METHODS  
    private void OnEnable()
    {
        MedoController.gameOver += GameOver;
        FadeController.modificarMovimento += MudarMovimentacao;
    }
    private void Start()
    {
        playMusic.Invoke(Audio.GAMEPLAY);

        _personagem = FindObjectOfType<Personagem>();
    }
    private void OnDisable()
    {
        MedoController.gameOver -= GameOver;
        FadeController.modificarMovimento -= MudarMovimentacao;

    }
    #endregion

    #region OWN METHODS
    public void GameOver()
    {
        Debug.Log("GameOver");
    }
    private void MudarMovimentacao()
    {
        _movimento = !_movimento;
        PauseDesPause();
    }
    private void PauseDesPause()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    #endregion

}
