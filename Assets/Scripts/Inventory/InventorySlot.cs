using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image itemIcon;
    public Button removeButton;

    public void AddItem(Item newItem)
    {
        item = newItem;
        itemIcon.sprite = item.icon;
        itemIcon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        itemIcon.sprite = null;
        itemIcon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            switch (item.itemtype)
            {
                case Item.ItemType.Health:
                    if(PlayerManager.instance.currentHealth <= 90)
                    {
                        PlayerManager.instance.IncreasePlayerHealth(20);
                        item.RemoveFromInventory();
                    }
                    break;
                case Item.ItemType.EXP:
                    PlayerManager.instance.IncreasePlayerEXP(10);
                    item.RemoveFromInventory();
                    break;
                case Item.ItemType.Gun:
                    PlayerManager.instance.canShoot = true;
                    PlayerManager.instance.UseGun();
                    item.RemoveFromInventory();
                    break;
            }
        }
    }
}
