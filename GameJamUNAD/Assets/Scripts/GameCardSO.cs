using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameCardType
{

}

[CreateAssetMenu(fileName = "New Game Card", menuName = "Scriptable Objects/ Game Card")]
public class GameCardSO : ScriptableObject
{
    [Header("Information")]
    public string title;
    [Range(0, 12)] public int level;
    public GameCardType[] types;
    [TextArea] public string description;

    [Header("Card")]
    public Texture texture;
    public Color color;
    public bool isHolographic;

    [Header("Stats")]
    public int statAttack;
    public int statDefence;
}
