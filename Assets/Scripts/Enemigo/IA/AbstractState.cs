using System.Collections;  

/// <summary>
/// Script base para comportamentos
/// </summary>
public abstract class AbstractState  
{
    protected StateMachine _stateMachine;

    public AbstractState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    /// <summary>
    /// Método executado ao iniciar um novo comportamento
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerator Enter()
    {
        yield return null;
    }
    /// <summary>
    /// Méotodo executado a cada frame.
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerator Executar()
    {
        yield return null;
    }
    /// <summary>
    /// Método executado por ultimo ao trocar de comportamento
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerator Exit()
    {
        yield return null;
    }
}
