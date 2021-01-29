using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script base para o bicho papao
/// </summary>
public class BichoPapao : AbstractEnemy
{
    #region UNITY METHODS

    private void Awake()
    { 
        _stateMachine = GetComponent<StateMachine>();

        SetarComportamentos();

        _transform = transform;  
    } 

    private void Start()
    {
        _currentPosition = FindObjectOfType<MapaSala>().Mapa[new Vector2Int(0, 0)]; 

        _stateMachine.MudarStatus(Acoes.PERSERGUIR);
    }
    #endregion

    #region OWN METHODS
    public override void Mover(Vector2Int posFinal)
    {
        if(_percurso == null)
        {
            _percurso = new Queue<Node>(FindObjectOfType<Pathfinding>().MenorCaminho(CurrentPosition.PosMatrix, posFinal, FindObjectOfType<MapaSala>()));
        }

        float distancia = Vector2.Distance(_transform.position, _currentPosition.PosWorld); 

        if(distancia > 0.05f)
        {
            Vector3 direcao = _currentPosition.PosWorld - transform.position; 

            direcao = direcao.normalized;

            direcao.z = 0;

            _transform.position += direcao * Time.deltaTime;
        }
        else if(_percurso.Count > 0)
        {
            _currentPosition = _percurso.Dequeue();
        }
        else
        {
            _percurso = null;
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
