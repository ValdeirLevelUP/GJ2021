using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : MonoBehaviour, IIten
{
    [SerializeField] private ItenData _data;
    public ItenData Data
    {
        get => _data;
    }

    public Sprite GetIcon()
    {
        return _data.Icon;
    }

    public void Ocultar()
    {
        gameObject.SetActive(false);
    }

    public bool Usar()
    {
        ///Criar um singleton para o gameManager
        Collider2D[] objetos = Physics2D.OverlapCircleAll(FindObjectOfType<GameManager>().Personagem.transform.position, 1);
        foreach (Collider2D objeto in objetos)
        {
            Porta porta = objeto.GetComponent<Porta>();
            if(porta != null)
            {
                porta.Destrancar();
                return true;
            }
        }
        return false;
    }
}
