using UnityEngine;

public class AnimacaoPadrao : MonoBehaviour,IAnimationBehavior
{
    #region PRIVATE VARIABLE
    private Personagem _personagem; 
    private Animator _animator; 
    private SpriteRenderer _spritePersonagem;
    #endregion

    #region UNITY METHODS

    public void Awake()
    {
        _personagem = GetComponent<Personagem>();

        _animator = _personagem.GetComponent<Animator>();

        _spritePersonagem = _personagem.GetComponent<SpriteRenderer>();
    }
    #endregion

    #region OWN METHODS

    public void Animar(Vector2Int velocity)
    {
        
        if(velocity.x > 0 && !_spritePersonagem.flipX)
        {
            _spritePersonagem.flipX = true; 
        }
        else if(velocity.x < 0 && _spritePersonagem.flipX)
        {
            _spritePersonagem.flipX = false;
        }
        _animator.SetInteger("x",Mathf.Abs(velocity.x));

        _animator.SetInteger("y", velocity.y);
         
    }
    #endregion
}
