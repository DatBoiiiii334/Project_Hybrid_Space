using UnityEngine;

public class Ash : Item {

	public override void OnCollisionEnter (Collision collision) {
		base.OnCollisionEnter (collision);

		if (interactedItem == null)
			return;

		if (interactedItem is Wound) {
			//Doe iets
		} else {
			return;
		}

		UseItem ();
	}


	public override void UseItem () {
		base.UseItem ();

		// Animations
		// Je neus

	}

}