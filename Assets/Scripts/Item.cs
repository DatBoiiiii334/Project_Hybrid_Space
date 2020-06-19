using UnityEngine;

public class Item : MonoBehaviour, IPickupable {

	protected IInteractable interactedItem = null;
	protected bool isBeingHeld = true;


	public virtual void OnCollisionEnter (Collision collision) {
		//Debug.Log ("On Collision enter, from " + this.gameObject.name + " to " + collision.gameObject.name);
		if (isBeingHeld && collision.collider.GetComponent<IInteractable> () != null) {
			interactedItem = collision.collider.GetComponent<IInteractable> ();
		} else {
			interactedItem = null;
			return;
		}
	}

    public virtual void OnTriggerEnter(Collider trigger)
    {
        //Debug.Log("On Trigger enter, from " + this.gameObject.name + " to " + trigger.gameObject.name);
        if (isBeingHeld && trigger.GetComponent<IInteractable>() != null) {
            interactedItem = trigger.GetComponent<IInteractable>();
        }
        else {
            interactedItem = null;
            return;
        }
    }

    public virtual void UseItem () {
		//Debug.Log ("I feel used. :( " + gameObject.name);
	}
	
}
