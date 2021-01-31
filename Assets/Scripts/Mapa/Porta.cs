
using UnityEngine; 
using System.Collections;
using System;

/// <summary>
/// Script responsavel pelas portas.
/// </summary>
public class Porta : MonoBehaviour
{
    #region PRIVATE VARIABLES

    [SerializeField] private Transform _saida;
    [SerializeField] private bool _trancada; 
    #endregion

    #region EVENTS

    public static event FadeSystem fade;
    #endregion

    #region UNITY METHODS
    private void Start()
    {
        if (_trancada)
        {
            gameObject.layer = 0;
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else
        {
            gameObject.layer = 8;
            GetComponent<BoxCollider2D>().isTrigger = true;

        }
    } 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Personagem personagem = collision.GetComponent<Personagem>();

        if(personagem != null)
        {
            fade?.Invoke(Teleporte(personagem));
        }
    } 
    private void OnCollisionEnter2D()
    {
        FindObjectOfType<TextoController>().MostrarTexto("Porta fechada, procure por uma chave ou entrada alternativa.");
    }
    #endregion

    #region OWN METHODS

    /// <summary>
    /// Método usado para destrancar porta.
    /// </summary>
    public void Destrancar()
    {
        _trancada = true;

        gameObject.layer = 8;

        GetComponent<BoxCollider2D>().isTrigger = true; 
    }
    #endregion

    #region COROUTINE

    /// <summary>
    /// Coroutine que muda o personagem de regiao.
    /// </summary>
    /// <param name="personagem">Personagem a ser transferido de lugar</param>
    /// <returns></returns>
    private IEnumerator Teleporte(Personagem personagem)
    { 
          
        personagem.transform.position = _saida.position;
        yield break;
    }
    #endregion
}
