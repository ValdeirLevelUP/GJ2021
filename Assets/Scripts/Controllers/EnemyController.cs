using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform _enemyInGame;
    [SerializeField] private AbstractEnemy _inimigo;

    [SerializeField] private RespawnPoint[] _pontosDeRespawn;

    private void OnEnable()
    {
        MedoController.respawn += ColocarInimigoEmCena;
    }

    private void OnDisable()
    {
        MedoController.respawn -= ColocarInimigoEmCena;
    }

    private void ColocarInimigoEmCena(string regiao, float medo)
    {
        float r = Random.Range(0, 30);
        if(r < medo)
        {
            Node pos = PosicionarInimigo(regiao);
            if(pos != null && _enemyInGame == null)
            { 
                AbstractEnemy inimigo = Instantiate(_inimigo);

                inimigo.SetNodeCurrentNode(pos,regiao);

                _enemyInGame = inimigo.transform;

                inimigo.transform.position = pos.PosWorld;
            } 
        }
        Debug.Log(r);
    }

    private Node PosicionarInimigo(string regiao)
    {
        foreach (RespawnPoint point in _pontosDeRespawn)
        {
            if(point.Regiao == regiao)
            {
                return point.nodesIniciais[(int)Random.Range(0, point.nodesIniciais.Length)].gameObject.GetComponent<Node>();
            }
        }
        return null;
    }
}

[System.Serializable]
public class RespawnPoint
{
    public string Regiao;
    public Transform[] nodesIniciais;
}
