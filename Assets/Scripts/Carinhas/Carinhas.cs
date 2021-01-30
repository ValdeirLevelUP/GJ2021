using UnityEngine;
using UnityEngine.UI;

public class Carinhas : MonoBehaviour
{
    public Sprite carinhaNormal; //carinha normal
    public Sprite carinhaMedoMedio; // carinha de assutada
    public Sprite carinhaMedoAlto;  // carinha de panico absoluto
    public Sprite carinhaCaixa; // carinha dentro da caixa 
    private Medo medo; 
    [SerializeField] private Image _carinhaHUD;

    public Medo NivelMedo { get => medo; }


    private void OnEnable()
    {
        MedoController.mudarFace += ChangeTheDamnSprite;
    }  

    private void OnDisable()
    {
        MedoController.mudarFace -= ChangeTheDamnSprite;
    }

    void ChangeTheDamnSprite(float qtdMedo)
    {
        if (qtdMedo > 25 && medo != Medo.NACAIXA)
        {
            medo = Medo.MEDOALTO;
            _carinhaHUD.sprite = carinhaMedoAlto;

        }
        else if (qtdMedo > 20 && qtdMedo < 25 && medo != Medo.NACAIXA)
        {
            medo = Medo.MEDOLEVE;
            _carinhaHUD.sprite = carinhaMedoMedio;

        }
        else if (qtdMedo < 15 && medo != Medo.NACAIXA)
        {
            medo = Medo.NORMAL;
            _carinhaHUD.sprite = carinhaNormal;
        }

    }

    public void EntrarNaCaixa()
    {
        _carinhaHUD.sprite = carinhaCaixa;
        medo = Medo.NACAIXA;
    }
    public void SairDaCaixa()
    {
        medo = Medo.NORMAL;
        ChangeTheDamnSprite(FindObjectOfType<MedoController>().TotalMedo);
    }
}
public enum Medo { NORMAL, MEDOLEVE, MEDOALTO, NACAIXA }
