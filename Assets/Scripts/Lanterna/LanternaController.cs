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
        _iluminacao.transform.localScale = _tamanho * (1 - Mathf.PingPong(Time.time/10, 0.01f));
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
    #endregion
}
