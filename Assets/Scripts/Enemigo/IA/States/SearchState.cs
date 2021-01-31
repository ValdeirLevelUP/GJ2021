using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SearchState : AbstractState
{
    private Node _alvo;
    private MapaSala _mapa;
    private Personagem _personagem;

    public SearchState(StateMachine stateMachine):base(stateMachine)
    {
        _personagem = GameObject.FindObjectOfType<GameManager>().Personagem;
    }

    #region OWN METHODS
    public override IEnumerator Enter()
    {
        Debug.Log("Aonde está você?");

        yield return new WaitForSeconds(1);

        MapaSala[] todosMapas = GameObject.FindObjectOfType<GameManager>().Mapas;

        foreach (MapaSala mapa in todosMapas)
        {
            if(mapa.Regiao == _stateMachine.Enemy._regiaoAtual)
            {
                _mapa = mapa;
                _alvo = mapa.GetRandomNode(); 
            }
        }
        base.Enter();
    }
    public override IEnumerator Executar()
    {
        while (true)
        { 
            if(_stateMachine.Enemy.CurrentNode.PosWorld ==_alvo.PosWorld)
            { 
                _stateMachine.MudarStatus(Acoes.BUSCAR);
                break;
            }
            float distancia = Vector3.Distance(_personagem.transform.position, _stateMachine.Enemy.transform.position); 
            if(distancia < 5)
            { 
                _stateMachine.MudarStatus(Acoes.PERSERGUIR);
                break;
            }

            _stateMachine.Enemy.Mover(_alvo.PosMatrix,_mapa);

            yield return null;
        } 
        base.Executar();
    }
    public override IEnumerator Exit()
    { 

        yield return new WaitForSeconds(1);

        base.Exit();
    }
    #endregion
}

public enum Acoes
{
    BUSCAR,
    PERSERGUIR
}
