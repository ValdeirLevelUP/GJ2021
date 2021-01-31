using System.Collections; 
using UnityEngine;

/// <summary>
/// Script responsavel por executar comportamentos do inimigo.
/// </summary>
public class StateMachine: MonoBehaviour
{
    #region PRIVATE VARIABLES

    private AbstractState _currentState;

    private IEnumerator _coroutineMudar;

    private AbstractEnemy _enemy;

    #endregion

    #region PUBLIC VARIABLES
    public AbstractEnemy Enemy { get => _enemy; }
    #endregion

    #region UNITY METHODS

    public void Awake()
    {
        _enemy = GetComponent<AbstractEnemy>(); 
    }
    #endregion

    #region OWN METHODS
    /// <summary>
    /// Método para mudar comportamento do inimigo.
    /// </summary>
    /// <param name="acao">comportamento a ser executado</param>
    public void MudarStatus(Acoes acao)
    { 
        _coroutineMudar = _mudarState(acao); 

        StartCoroutine(_coroutineMudar);
    }

    /// <summary>
    /// Método responsavel por atualizar comportamento.
    /// </summary>
    private void Atualizar()
    {
        StartCoroutine(_currentState.Executar());
    }
    #endregion

    #region COROTINA
    /// <summary>
    /// Corotina que atualiza comportamento.
    /// </summary>
    /// <param name="acao">novo comportamento</param>
    /// <returns></returns>
    private IEnumerator _mudarState(Acoes acao)
    {
        if (_currentState != null)
        {
            yield return StartCoroutine(_currentState.Exit());
        }
        if (_enemy.ListOfBehaviour.ContainsKey(acao))
        {
            _currentState = _enemy.ListOfBehaviour[acao];

            yield return StartCoroutine(_currentState.Enter());
        }
        Atualizar();
    }
    #endregion
}
