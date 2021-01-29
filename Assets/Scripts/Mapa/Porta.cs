
using UnityEngine;
using Cinemachine;
using System.Collections;

/// <summary>
/// Script responsavel pelas portas.
/// </summary>
public class Porta : MonoBehaviour
{ 
    [SerializeField] private Transform _saida;
    [SerializeField] private bool _trancada; 

    public static event FadeSystem fade;
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Personagem personagem = collision.GetComponent<Personagem>();

        if(personagem != null)
        {
            fade?.Invoke(Teleporte(personagem));
        }
    }
    private IEnumerator Teleporte(Personagem personagem)
    { 
          
        personagem.transform.position = _saida.position;

        yield return new WaitForSeconds(2);
    }
}
