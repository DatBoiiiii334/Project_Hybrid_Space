using UnityEngine;

public class Mushroom : Item {
	
	public override void OnCollisionEnter (Collision collision) {
		base.OnCollisionEnter (collision);

		if (interactedItem == null)
			return;

		if (interactedItem is Wound) {
			GameManager.instance.currentPatient.MaggotWound ((Wound) interactedItem);
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