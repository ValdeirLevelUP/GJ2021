using UnityEngine;

/// <summary>
/// Script responsavel pelos nodes.
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class Node: MonoBehaviour
{
    #region PRIVATE VARIABLES

    private Vector3 _posWorld;

    private Vector2Int _posMatrix;

    private Node _nodeAnterior;

    private string _regiao;

    private float _f;

    private float _g;

    private float _h;
    #endregion

    #region PROPERTIES
    public Node Anterior { get => _nodeAnterior; set => _nodeAnterior = value; }
    public float F { get => _g + _h; }
    public float G { set => _g = value; get => _g; }
    public float H { set => _h = value; get => _h;}

    public Vector3 PosWorld { get => _posWorld;}

    public Vector2Int PosMatrix { get => _posMatrix;}
    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    #endregion

    #region OWN METHODS

    /// <summary>
    /// Método responsavel por configurar node.
    /// </summary>
    /// <param name="node">transform do node que atribuirar posicao na matrix</param>
    /// <param name="regiao">regiao onde o node esta sendo criado</param>
    public void SetNode(Transform node, string regiao)
    {
        _posWorld = node.position;

        _regiao = regiao;

        _posMatrix = Vector2Int.RoundToInt(node.localPosition);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        Personagem personagem = collision.gameObject.GetComponent<Personagem>();
        if (personagem != null)
        {
            if(personagem.Regiao != _regiao)
            {
                personagem.Regiao = _regiao;
                FindObjectOfType<TextoController>().MostrarTexto(string.Format(personagem.Regiao));
            }
            personagem.CurrentPosition = _posMatrix;
        }
    }
    #endregion
}
