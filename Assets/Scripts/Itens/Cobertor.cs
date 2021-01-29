using UnityEngine;

public class Cobertor : MonoBehaviour, IIten
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

    public void Usar()
    {
        Debug.Log("Cobertor");
    }
}
