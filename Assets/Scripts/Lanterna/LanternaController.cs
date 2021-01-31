using UnityEngine;

/// <summary>
/// Script responsavel por controlar lanterna.
/// </summary>
public class LanternaController : MonoBehaviour 
{
    #region PRIVATE VARIABLES

    private SpriteMask _iluminacao;

    private Transform _transform;

    private Vector3 _tamanho;

    private float _time;
    #endregion

    #region PROPERTIES

    public float Raio { get => _transform.localScale.x; }
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        _iluminacao = GetComponent<SpriteMask>();
        _transform = transform;
        _tamanho = _iluminacao.transform.localScale;
    }
    private void Update()
    {
        BilhoDaLanterna();
        GastarPilha();
    } 
    #endregion

    #region OWN METHODS
    /// <summary>
    /// Método para alterar tamanho da luz.
    /// </summary>
    /// <param name="raio"></param>
    public void RaioDeIluminacao(float raio)
    {
        _tamanho = new Vector3(raio,raio,0);
    }


    /// <summary>
    /// Método responsavel por consumir carga da pilha
    /// </summary>
    private void GastarPilha()
    {
        if (_tamanho.x > 10)
        {
            _time += Time.deltaTime;
            if (_time > 60)
            {
                RaioDeIluminacao(10);
                _time = 0;
            }
        }
    } 
    /// <summary>
    /// Método para simular bilho da lanterna.
    /// </summary>
    private void BilhoDaLanterna()
    {
        ///Jogar intensidade do brilho para o script gameManager.
        _iluminacao.transform.localScale = _tamanho * (1 - Mathf.PingPong(Time.time / 10, 0.1f));
    }
    #endregion
}
