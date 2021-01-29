using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script responsavel por gerar mapa de nodes.
/// </summary>
public class MapaSala : MonoBehaviour
{
    #region PRIVATE VARIABLES

    private Dictionary<Vector2Int,Node> _map;

    [SerializeField] private bool _mostrarNumeracao;

    [SerializeField] private GameObject _marcador; 

    [SerializeField] private string regiao;
    #endregion

    #region PROPERTIES
    public Dictionary<Vector2Int, Node> Mapa { get => _map; }
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        GerarMapa();
    }
    #endregion

    #region OWN METHODS
    /// <summary>
    /// Método para gerar nodes.
    /// </summary>
    private void GerarMapa()
    {
        _map = new Dictionary<Vector2Int, Node>();

        foreach (Transform pos in GetComponentInChildren<Transform>())
        { 
            Node newNode = pos.gameObject.AddComponent<Node>();
             
            newNode.SetNode(pos,regiao);

            if (_mostrarNumeracao)
            {
                Transform marcador = Instantiate(_marcador).transform;

                marcador.transform.position = newNode.PosWorld;

                marcador.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = newNode.PosMatrix.ToString();
            }

            _map.Add(newNode.PosMatrix, newNode);
        } 
    }
    #endregion
}
