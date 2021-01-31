
using UnityEngine; 
using System.Collections;

/// <summary>
/// Script responsavel pelas portas.
/// </summary>
public class Porta : MonoBehaviour
{ 
    [SerializeField] private Transform _saida;
    [SerializeField] private bool _trancada; 

    public static event FadeSystem fade;

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
    private IEnumerator Teleporte(Personagem personagem)
    { 
          
        personagem.transform.position = _saida.position;
        yield break;
    }
}
