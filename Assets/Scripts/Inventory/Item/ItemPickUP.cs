using UnityEngine;

public class ItemPickUP : Interactable
{
    public Item item;
    private bool isPickedUp = false;

    private void OnEnable()
    {
        if (!isPickedUp)
        {
            InputManager.OnPickUp += PickUp;
        }   
    }


    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    public void PickUp()
    {
        bool wasPickedUP = Inventory.instance.Add(item);
        if(wasPickedUP)
        {
            isPickedUp = true;
            gameObject.SetActive(false);
            InputManager.OnPickUp -= PickUp;
        }
    }  
}
