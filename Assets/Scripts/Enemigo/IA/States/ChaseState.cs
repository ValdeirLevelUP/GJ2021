using System.Collections; 
using UnityEngine;

public class ChaseState : AbstractState
{
    private Vector2Int _alvo;
    private MapaSala _mapa; 
    public ChaseState(StateMachine stateMachine):base(stateMachine)
    {
         
    }
    public override IEnumerator Enter()
    { 
        yield return new WaitForSeconds(0.1f);

        MapaSala[] todosMapas = GameObject.FindObjectOfType<GameManager>().Mapas;

        foreach (MapaSala mapa in todosMapas)
        {
            if (mapa.Regiao == _stateMachine.Enemy._regiaoAtual)
            {
                _mapa = mapa;
                _alvo = GameObject.FindObjectOfType<GameManager>().Personagem.CurrentPosition;
                break;
            }
        } 

        base.Enter();
    }

    public override IEnumerator Executar()
    {
        while (true)
        { 
            _stateMachine.Enemy.Mover(_alvo,_mapa);

            float distancia = Vector3.Distance(_stateMachine.Enemy.transform.position, GameObject.FindObjectOfType<GameManager>().Personagem.transform.position);

            if(distancia > 8)
            {
                _stateMachine.MudarStatus(Acoes.BUSCAR);
                break;
            }
            else
            {
                _alvo = GameObject.FindObjectOfType<GameManager>().Personagem.CurrentPosition;
            }
            
            yield return null;
        }
        base.Executar();
    }

    public override IEnumerator Exit()
    {
        return base.Exit();
    }
}
