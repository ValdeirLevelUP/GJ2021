using System.Collections.Generic;
using UnityEngine; 

/// <summary>
/// Script responsavel pelo pathfind
/// </summary>
public class Pathfinding : MonoBehaviour
{
    #region PRIVATE VARIABLES

    private Vector2[] _adjacente = new Vector2[4] { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };  

    private Dictionary<Vector2Int, Node> _percuso;
    #endregion

    #region OWN METHODS

    public Node[] MenorCaminho(Vector2Int inicio, Vector2Int fim, MapaSala mapa)
    {
        _percuso = mapa.Mapa;

        Node inicioNode = _percuso[inicio];

        Node fimNode = _percuso[fim];

        LimparNodes();

        DistanciaHeuristica(fimNode);

        inicioNode.G = 0;

        List<Node> listaAberta = new List<Node>();

        HashSet<Node> listaFechada = new HashSet<Node>();

        listaAberta.Add(inicioNode);

        while(listaAberta.Count > 0)
        {
            Node currentNode = BuscarMenorF(listaAberta);

            listaAberta.Remove(currentNode);

            listaFechada.Add(currentNode);

            if(currentNode.PosMatrix == fimNode.PosMatrix)
            {
                Node[] resultado = new Node[listaFechada.Count];

                listaFechada.CopyTo(resultado);

                return resultado;
            }
            foreach (Node item in BuscarAdjacentes(currentNode))
            {
                if (listaFechada.Contains(item)) continue;

                float novoG = DistanciaEntreDoisNode(currentNode, item);

                if(novoG < item.G)
                {
                    item.G = novoG;

                    item.Anterior = currentNode;

                    if (!listaAberta.Contains(item))
                    {
                        listaAberta.Add(item);
                    }
                }
            }
        }
        return null;
    }

    private float DistanciaEntreDoisNode(Node currentNode, Node item)
    {
        float distancia = Vector2Int.Distance(currentNode.PosMatrix, item.PosMatrix);

        return distancia;
    }
    private void DistanciaHeuristica(Node fim)
    {
        foreach (Node item in _percuso.Values)
        {
            item.H = Vector2Int.Distance(item.PosMatrix, fim.PosMatrix);
        }
    }

    private Node[] BuscarAdjacentes(Node currentNode)
    {
        List<Node> resultado = new List<Node>();

        for (int i = 0; i < _adjacente.Length; i++)
        {
            Vector2Int pos = Vector2Int.FloorToInt(currentNode.PosMatrix + _adjacente[i]);

            if (_percuso.ContainsKey(pos))
            {
                resultado.Add(_percuso[pos]);
            }

        }
        return resultado.ToArray();
    }

    private Node BuscarMenorF(List<Node> listaAberta)
    {
        Node currentNode = listaAberta[0];

        foreach (Node item in listaAberta)
        {
            if(currentNode.F > item.F)
            {
                currentNode = item;
            }
        }
        return currentNode;
    }

    private void LimparNodes()
    {
        foreach (Node item in _percuso.Values)
        {
            item.G = float.MaxValue;

            item.H = 0;
        }
    }

    #endregion
}
