using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Renderer))]
public class GameCard : MonoBehaviour
{
    [Header("Card Data")]
    private GameCardSO _data;
     

    [Header("References")]
    [SerializeField] private TextMeshPro _nombreTxt; 
    [SerializeField] private TextMeshPro _descripcionTxt; 
    [SerializeField] private TextMeshPro _diametroTxt; 
    [SerializeField] private TextMeshPro _periodoTxt; 
    [SerializeField] private TextMeshPro _temperaturaTxt; 
    [SerializeField] private TextMeshPro _gravedadTxt;

    [SerializeField] private List<GameCardSO> cardList;

    private MaterialPropertyBlock _propertyBlock;

    private void Start()
    {
        _propertyBlock = new MaterialPropertyBlock();
        InitData();
    }

    [ContextMenu("Update Data")]
    private void InitData()
    {
        int randomIndex = Random.Range(0, cardList.Count);
        _data = cardList[randomIndex];
        _nombreTxt.text = _data.Nombre;
        _descripcionTxt.text = _data.descripcion;
        _diametroTxt.text = _data.diametroKm;
        _periodoTxt.text = _data.periodoRotacionHrs;
        _temperaturaTxt.text = _data.temperaturaMaxima;
        _gravedadTxt.text = _data.gravedad;
        
        //Material
        _propertyBlock.SetColor("_CardColor",_data.color);
        _propertyBlock.SetTexture("_TextureContent",_data.texture);
        _propertyBlock.SetFloat("_IsHolographic",_data.isHolographic ? 1 : 0);

        GetComponent<Renderer>().SetPropertyBlock(_propertyBlock);
    }
}
