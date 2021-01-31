using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ursinho : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        FindObjectOfType<GameManager>().Vitoria();
    }
}
