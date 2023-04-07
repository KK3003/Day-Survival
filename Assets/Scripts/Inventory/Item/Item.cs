using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public int value;
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public ItemType itemtype;
   
    public virtual void Use()
    {
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

    public enum ItemType
    {
        Health,
        Gun,
        EXP
    }
}
