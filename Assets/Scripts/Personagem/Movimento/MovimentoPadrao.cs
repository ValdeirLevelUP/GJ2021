using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPadrao : MonoBehaviour, IMovimentBehavior
{
    private Personagem _personagem;
    public float _distanciaDeDeteccao;
    private Vector2 _direcaoObstaculo;
    private Vector2[] _directions = new Vector2[4] { Vector2.left, Vector2.right, Vector2.up, Vector2.down };
    [SerializeField] LayerMask _player;
    public void Awake( )
    { 
        _personagem = GetComponent<Personagem>(); 
    }
    public void Mover(Vector2 direction)
    {
        direction = (direction.SqrMagnitude() > 1) ? direction.normalized - _direcaoObstaculo : direction -_direcaoObstaculo;

        _personagem.RigidBody.velocity = direction * Time.deltaTime * _personagem.Data.Velocidade; 
    }
    private void Update()
    {
       _direcaoObstaculo = DetectarColisao();
    }
    private Vector2 DetectarColisao()
    {
        Vector2 direcaoObstaculo = Vector2.zero; 

        RaycastHit2D hit;

        foreach (Vector2 direction in _directions)
        {
            hit = Physics2D.Raycast(_personagem.transform.position + new Vector3(0, -0.25f, 0), direction, _distanciaDeDeteccao, ~_player);

            if(hit.collider != null)
            {
                direcaoObstaculo += direction;
            } 
        }
        return direcaoObstaculo;
    }

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying) return;

        foreach (Vector2 direction in _directions)
        {
            Gizmos.DrawRay(_personagem.transform.position +  new Vector3(0,-0.25f,0), direction * _distanciaDeDeteccao);
        } 
    }

}
