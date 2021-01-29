using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Animator))]
public class Personagem : MonoBehaviour
{
    #region PRIVATE VARIABLES 

    private Vector2 _direction;

    private IMovimentBehavior _movimento;

    private IAnimationBehavior _animation;

    private ItensController _itensControle; 

    private Rigidbody2D _rigidBody;

    private string _regiao;

    [SerializeField] private Vector2Int _currentPosition;

    [SerializeField] private LayerMask _camada; 

    [SerializeField] private DataPersonagem _data;
    #endregion
    
    #region PROPERTIES
    public DataPersonagem Data { get => _data;} 
    public Rigidbody2D RigidBody { get => _rigidBody; }

    public Vector2Int CurrentPosition { get => _currentPosition; set => _currentPosition = value; }

    public string Regiao { get => _regiao; set => _regiao = value; }
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

        _animation = GetComponent<AnimacaoPadrao>();

        _movimento = GetComponent<IMovimentBehavior>();

        _itensControle = FindObjectOfType<ItensController>();
    }
    private void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(FindObjectOfType<GameManager>().Data.UsarItem))
        {
            _itensControle.UsarItem();
        }
        if (Input.GetKeyDown(FindObjectOfType<GameManager>().Data.ColetarItens))
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, 1, Vector2.zero,1, ~_camada);
            if(hit.collider != null)
            {
                IIten item = hit.collider.GetComponent<IIten>();

                _itensControle.ColetarItem(item);

                item.Ocultar();

                FindObjectOfType<TextoController>().MostrarTexto(string.Format("Você encontrou um {0}",item.Data.Nome));
            }
        }
    }
    private void FixedUpdate()
    {
        Movimentar(true);
    }
    #endregion 
    #region OWN METHODS
    private void Movimentar(bool ativo)
    {
        _movimento.Mover(_direction);

        _animation.Animar(Vector2Int.FloorToInt(_rigidBody.velocity));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }
    #endregion
}
