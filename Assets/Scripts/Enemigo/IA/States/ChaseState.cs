using System.Collections; 
using UnityEngine;

public class ChaseState : AbstractState
{
    private Vector2Int _alvo;
    private Personagem _personagem;
    public ChaseState(StateMachine stateMachine):base(stateMachine)
    {

    }
    public override IEnumerator Enter()
    {
        Debug.Log("Estou te vendo :)");
        _personagem = GameObject.FindObjectOfType<Personagem>();
        yield return new WaitForSeconds(0.1f);
        base.Enter();
    }

    public override IEnumerator Executar()
    {
        while (true)
        {
            _alvo = _personagem.CurrentPosition;
            _stateMachine.Enemy.Mover(_alvo); 
            yield return null;
        }
        base.Executar();
    }

    public override IEnumerator Exit()
    {
        return base.Exit();
    }
}
