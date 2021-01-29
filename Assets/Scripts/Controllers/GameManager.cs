using UnityEngine;

/// <summary>
/// Script principal que executa o gameplay.
/// </summary>
 public class GameManager : MonoBehaviour
{
    #region PRIVATE VARIABLES 
    [SerializeField] private GameData _data;
    #endregion

    #region EVENTS
    public static event PlayMusic playMusic;
    #endregion

    #region PROPERTIES

    public GameData Data { get => _data; }
    #endregion

    #region UNITY METHODS  
    private void OnEnable()
    {
        MedoController.gameOver += GameOver; 
    }
    private void Start()
    {
        playMusic.Invoke(Audio.GAMEPLAY);
    }
    private void OnDisable()
    {
        MedoController.gameOver -= GameOver;  
    }
    #endregion

    #region OWN METHODS
    public void GameOver()
    {
        Debug.Log("GameOver");
    }
    #endregion

}
