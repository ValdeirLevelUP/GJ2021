using UnityEngine;

public class Pilha : MonoBehaviour, IIten
{
     private LanternaController _lanterna;
    [SerializeField] private ItenData _data;


    private void Awake()
    {
        _lanterna = FindObjectOfType<LanternaController>();
    }
    public ItenData Data
    {
        get => _data;
    }

    public Sprite GetIcon()
    {
        return _data.Icon;
    }

    public void Usar()
    {
         if(_lanterna.Raio == 30)
        {
            _lanterna.RaioDeIluminacao(10);
        }
        else
        {
            _lanterna.RaioDeIluminacao(30);
        }
    }

    public void Ocultar()
    {
        gameObject.SetActive(false);
    }
}
