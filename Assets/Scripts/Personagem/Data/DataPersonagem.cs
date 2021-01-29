
using UnityEngine;
/// <summary>
/// Script que armazena dados relacionados ao personagem.
/// </summary>
[CreateAssetMenu(menuName ="Prototipo/Personagem/Data")]
public class DataPersonagem : ScriptableObject
{
    #region PRIVATE VARIABLES
    [SerializeField] private float _velocidade;
    [SerializeField] private float _medoMaximo;
    #endregion

    #region PROPERTIES
    public float Velocidade { get => _velocidade; }
    public float Medo { get => _medoMaximo; }
    #endregion
}
