using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SearchState : AbstractState
{
    private Vector2Int _alvo;

    public SearchState(StateMachine stateMachine):base(stateMachine)
    {  
    }

    #region OWN METHODS
    public override IEnumerator Enter()
    {
        Debug.Log("Aonde está você?");
        yield return new WaitForSeconds(1);  
        _alvo = new Vector2Int(-1, -5); 
        base.Enter();
    }
    public override IEnumerator Executar()
    {
        while (true)
        { 
            if(_stateMachine.Enemy.CurrentPosition.PosWorld == GameObject.FindObjectOfType<MapaSala>().Mapa[_alvo].PosWorld)
            { 
                break;
            }
            _stateMachine.Enemy.Mover(_alvo);
            yield return null;
        } 
        base.Executar();
    }
    public override IEnumerator Exit()
    {
        Debug.Log("Ele ñ está aqui");
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
