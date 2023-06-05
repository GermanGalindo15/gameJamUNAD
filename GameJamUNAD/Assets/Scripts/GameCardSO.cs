using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameCardType
{
    fuego,
    hielo,
    radiacion,
    acido,
    normal
}

[CreateAssetMenu(fileName = "New Game Card", menuName = "Scriptable Objects/Game Card")]
public class GameCardSO : ScriptableObject
{
    [Header("Information")]
    public string Nombre;
    public string Tipo;

    [TextArea] public string descripcion;

    [Header("Card")]
    public Texture texture;
    public Color color;
    public bool isHolographic;

    [Header("Stats")]
    public string diametroKm;
    public string periodoRotacionHrs;
    public string temperaturaMaxima;
    public string gravedad;
}
