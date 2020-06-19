using UnityEngine;

public class Knife : Item {

	[SerializeField] private AudioClip cutSound;

	public override void OnCollisionEnter (Collision collision) {
		base.OnCollisionEnter (collision);

        //Debug.Log("Kife used; OnCollision" + collision.collider.name);

		if (interactedItem == null)
			return;

		if (interactedItem is Destructable) {
			interactedItem = (Destructable) interactedItem;
			interactedItem.OnInteract ();
		}
		else if (interactedItem is Cyst) {
			interactedItem.OnInteract ();
		}
		else if (interactedItem is Patient) {
			GameManager.instance.currentPatient.CauseWound (collision.contacts[0].point);
		} else {
			return;

		}

		UseItem ();
	}

    public override void OnTriggerEnter(Collider trigger)
    {
        base.OnTriggerEnter(trigger);
        if (interactedItem == null)
            return;

        if (interactedItem is Destructable) {
            interactedItem = (Destructable)interactedItem;
            interactedItem.OnInteract();
        }
        else if (interactedItem is Cyst) {
            interactedItem.OnInteract();
        }else {
            return;
        }
    }


    public override void UseItem () {
		base.UseItem ();

		SoundManager.instance.PlaySoundEffect (cutSound, 1, this.transform.position);
		
		// Animations
		// Je neus

	}

}
