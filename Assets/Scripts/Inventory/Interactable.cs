using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform player;
    public Transform interactionTransform;

    public virtual void Interact()
    {    
    }
    private void Update()
    {
        float distance = Vector3.Distance(player.position, interactionTransform.position);
        {
            if (distance <= radius)
            {
                Interact();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
        if(interactionTransform == null)
        {
            interactionTransform = transform;
        }
    }
}
