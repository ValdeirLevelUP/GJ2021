using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : MonoBehaviour, IIten
{
    [SerializeField] private ItenData _itenData;
    public ItenData Data
    {
        get => _itenData;
    }

    public Sprite GetIcon()
    {
        return _itenData.Icon;
    }

    public void Ocultar()
    {
        gameObject.SetActive(false);
    }

    public bool Usar()
    {
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
