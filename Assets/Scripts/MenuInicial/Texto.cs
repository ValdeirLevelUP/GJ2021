using UnityEngine;
using TMPro; 

public delegate void Effect(TextMeshProUGUI text);
/// <summary>
/// Script que aplica os efeitos ao texto.
/// </summary>
public  class Texto : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public event Effect efeito;
    #endregion

    #region PRIVATE VARIABLES
    private TextMeshProUGUI _text;
    [SerializeField] private Efeitos[] _efeitos;
    #endregion 

    #region UNITY METHODS
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        for (int i = 0; i < _efeitos.Length; i++)
        {
            efeito += AddEffect(_efeitos[i]);
        }
    } 
    private void Update()
    {
        efeito?.Invoke(_text);
    }
    #endregion 

    #region OWN METHODS
    /// <summary>
    /// Método que seleciona e adiciona efeitos a esse texto
    /// </summary>
    /// <param name="efeitos"> enumerador selecionado inspetor</param>
    /// <returns></returns>
    private Effect AddEffect(Efeitos efeitos)
    {
        switch (efeitos)
        {
            case Efeitos.Piscar:
                return EfeitoTexto.Piscar;

            default:
                return null;
        } 
    }
    #endregion

}
