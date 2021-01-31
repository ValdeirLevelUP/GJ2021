using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script base para o bicho papao
/// </summary>
public class BichoPapao : AbstractEnemy
{
    Vector2Int _posfinal;
    #region UNITY METHODS

    private void Awake()
    { 
        _stateMachine = GetComponent<StateMachine>();

        SetarComportamentos();

        _transform = transform;  
    }  
    #endregion

    #region OWN METHODS
    public override void Mover(Vector2Int posFinal,MapaSala mapa)
    { 
        
        if(_percurso == null || _percurso.Count == 0 || _posfinal != posFinal )
        { 
            _percurso = new Queue<Node>(FindObjectOfType<Pathfinding>().MenorCaminho(CurrentNode.PosMatrix, posFinal, mapa));

            _posfinal = posFinal; 
        } 

        float distancia = Vector3.Distance(_transform.position, _currentPosition.PosWorld);

        if(distancia > 0.1f)
        {

            Vector3 direcao = _currentPosition.PosWorld - transform.position;

            direcao = direcao.normalized;

            direcao.z = 0;

            _transform.position += direcao * Time.deltaTime * 2;

        }else if (_percurso.Count > 0)
        {
            _currentPosition = _percurso.Dequeue();

            if(_percurso.Count == 0)
            {
                foreach (Node node in mapa.Mapa.Values)
                {
                    node.transform.GetComponent<SpriteRenderer>().color = Color.white;
                } 
            }
        } 
    } 
    public override void SetarComportamentos()
    {
        _listOfBehaviour = new Dictionary<Acoes, AbstractState>();

        _listOfBehaviour.Add(Acoes.BUSCAR, new SearchState(_stateMachine));

        _listOfBehaviour.Add(Acoes.PERSERGUIR, new ChaseState(_stateMachine));
    }
    #endregion
}
