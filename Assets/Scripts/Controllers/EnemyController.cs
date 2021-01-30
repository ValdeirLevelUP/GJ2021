using UnityEngine;

public class EnemyController : MonoBehaviour
{
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
        float r = Random.Range(0, 31);
        if(r > medo)
        {
            Vector3 pos = PosicionarInimigo(regiao);
            if(pos != Vector3.zero)
            { 
                AbstractEnemy inimigo = Instantiate(_inimigo);
                inimigo.transform.position = pos;
            } 
        }
        Debug.Log(r);
    }

    private Vector3 PosicionarInimigo(string regiao)
    {
        foreach (RespawnPoint point in _pontosDeRespawn)
        {
            if(point.Regiao == regiao)
            {
                return point._points[(int)Random.Range(0, point._points.Length)].position;
            }
        }
        return Vector3.zero;
    }
}

[System.Serializable]
public class RespawnPoint
{
    public string Regiao;
    public Transform[] _points;
}
