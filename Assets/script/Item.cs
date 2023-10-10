
using UnityEngine;
[CreateAssetMenu(fileName="Item",menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string Name;
    public string description;
    public Sprite image;
    public int hpGiven;
    public int speedGiven;
    public float speedDuration;
    public bool invincibilityItem = false;
    public float inverseDuration;
    public bool inverse = false;
    public int price;
    public bool isDoublePiece;
}
