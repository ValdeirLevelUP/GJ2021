using UnityEngine;
/// <summary>
/// Script responsavel por agrupar dados do game.
/// </summary>
[CreateAssetMenu(fileName ="GameData", menuName ="Prototipo/Game Data")]
public class GameData : ScriptableObject
{
    #region PRIVATE VARIABLES

    [SerializeField] private float _medoMaximo;

    [SerializeField] private float _medoInicial;

    [Range(1,10)]
    [SerializeField] private float _quantidadeMedoPorMinuto;

    [SerializeField] private float _tempoTransicaoDoTexto;

    [SerializeField] private float _tempoParaMostrarTodoTexto;

    [SerializeField] private KeyCode _usarItem;

    [SerializeField] private KeyCode _coletarItens;
    #endregion

    #region PROPERTIES
    public KeyCode ColetarItens { get => _coletarItens; } 
    public KeyCode UsarItem { get => _usarItem; } 
    public float MedoInicial { get => _medoInicial; }
    public float MedoMaximo { get => _medoMaximo; }
    public float QuantidadeDeMedoPorMinuto { get => _quantidadeMedoPorMinuto; }

    public float TransicaoTexto { get => _tempoTransicaoDoTexto; }

    public float TempoDeExibicaoDeTexto { get => _tempoParaMostrarTodoTexto; }
    #endregion
}
