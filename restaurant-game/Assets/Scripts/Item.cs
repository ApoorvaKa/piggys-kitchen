using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    public int id;
    public Sprite icon;
    public ItemType itemType;

    public enum ItemType
    {
        Bread,
        Cheese,
        Butter,
        BreadCheese,
        RawSandwich,
        GrilledCheese,
        Tomato,
        TomatoSoup
    }
}
 