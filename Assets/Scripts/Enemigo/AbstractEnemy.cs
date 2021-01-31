using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script responsavel pela base do do inimigo.
/// </summary>
public abstract class AbstractEnemy : MonoBehaviour
{
    #region PROTECTED VARIABLES

    protected Dictionary<Acoes,AbstractState> _listOfBehaviour;

    protected Node _currentPosition;

    protected Queue<Node> _percurso;

    protected Transform _transform;

    protected StateMachine _stateMachine;

    #endregion

    public string _regiaoAtual;

    #region PROPERTIES
    public Node CurrentNode { get => _currentPosition; set => _currentPosition = value; } 

    public Dictionary<Acoes,AbstractState> ListOfBehaviour { get => _listOfBehaviour;}
    #endregion

    #region OWN METHODS

    /// <summary>
    /// Método que controla a movimentacao do inimigo.
    /// </summary>
    /// <param name="posFinal">posicao final do inimigo</param>
    public abstract void Mover(Vector2Int posFinal, MapaSala mapa); 

    /// <summary>
    /// Método responsavel por configurar comportamentos do inimigo.
    /// </summary>
    public abstract void SetarComportamentos();

    public void SetNodeCurrentNode(Node node, string regiao)
    {
        _currentPosition = node;
        _regiaoAtual = regiao;
        _stateMachine.MudarStatus(Acoes.BUSCAR);
    }

    #endregion

} 
