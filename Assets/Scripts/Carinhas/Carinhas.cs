using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carinhas : MonoBehaviour
{
    public Sprite carinhaNormal; //carinha normal
    public Sprite carinhaMedoMedio; // carinha de assutada
    public Sprite carinhaMedoAlto;  // carinha de panico absoluto
    public Sprite carinhaCaixa; // carinha dentro da caixa
    private SpriteRenderer spriteRenderer;
    public float panic;
    private Medo medo;


    private void OnEnable()
    {
        MedoController.mudarFace += ChangeTheDamnSprite;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //Acessando o SpriteRenderer que está anexado ao Gameobject
        if (spriteRenderer.sprite == null) // se o sprite em spriteRenderer for nulo, então
            spriteRenderer.sprite = carinhaNormal; // seta o sprite como carinha normal
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CarinhaCaixa();
        }
    }

    private void OnDisable()
    {
        MedoController.mudarFace -= ChangeTheDamnSprite;
    }

    void ChangeTheDamnSprite(float qtdMedo)
    {
        if (qtdMedo > 25 && medo != Medo.NACAIXA)
        {
            medo = Medo.NORMAL;
            spriteRenderer.sprite = carinhaNormal;

        }
        else if (qtdMedo > 20 && qtdMedo < 25 && medo != Medo.NACAIXA)
        {
            medo = Medo.MEDOLEVE;
            spriteRenderer.sprite = carinhaMedoMedio;

        }
        else if (qtdMedo < 20 && medo != Medo.NACAIXA)
        {
            medo = Medo.MEDOALTO;
            spriteRenderer.sprite = carinhaMedoAlto;
        }

    }

    void CarinhaCaixa()
    {
        spriteRenderer.sprite = carinhaCaixa;
    }
}
public enum Medo { NORMAL, MEDOLEVE, MEDOALTO, NACAIXA }
