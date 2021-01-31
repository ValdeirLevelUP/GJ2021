using UnityEngine;

public delegate void PlayMusic(Audio audio);
/// <summary>
/// Script para controle do audio do game.
/// </summary>
public class AudioController : MonoBehaviour
{
    #region PRIVATE VARIABLES

    private static AudioController _instance;

    private AudioSource _audioSource;

    [SerializeField] private AudioClip _audioMenu;

    [SerializeField] private AudioClip _audioGamePlay;
    #endregion

    #region PROPERTIES
     
    public static AudioController Instance
    {
        get => _instance;
    }
    #endregion 

    #region UNITY METHODS
    void Awake()
    { 
        if(_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        } 

        _audioSource = GetComponent<AudioSource>(); 
    }
    private void OnEnable()
    {
        GameManager.playMusic += AudioPlay;
        MenuInicial.play += AudioPlay;
    }
    private void Start()
    {
        AudioPlay(Audio.MENU);
    }
    private void OnDisable()
    {
        GameManager.playMusic -= AudioPlay; 
        MenuInicial.play -= AudioPlay;
    }
    #endregion

    #region OWN METHODS

    /// <summary>
    /// Método que seleciona audio a ser executado.
    /// </summary>
    /// <param name="audio"> Enumerador que seleciona o audio</param>
    private void AudioPlay(Audio audio)
    {
        switch (audio)
        {
            case Audio.MENU:
                _audioSource.clip = _audioMenu;
                _audioSource.Play();
                break;
            case Audio.GAMEPLAY:
                _audioSource.clip = _audioGamePlay;
                _audioSource.volume = 0.25f;
                _audioSource.Play();
                break;
        }
    } 
}
#endregion
public enum Audio
{
    MENU,
    GAMEPLAY
}
