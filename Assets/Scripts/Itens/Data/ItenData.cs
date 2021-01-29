using UnityEngine; 
/// <summary>
/// Script responsavel armazenar dados dos itens
/// </summary>
[CreateAssetMenu(menuName ="Prototipo/Itens/Novo Item")]
public class ItenData : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _nome;
    [TextArea(2,5)]
    [SerializeField] private string _descricao;

    public Sprite Icon { get => _icon; }
    public string Nome { get => _nome; } 
    public string Descricao { get => _descricao; }
}
