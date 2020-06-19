using UnityEngine;

public class Leech : Item {

	private bool isFilled;

	public override void OnCollisionEnter (Collision collision) {
		base.OnCollisionEnter (collision);

		if (interactedItem == null)
			return;

		if (interactedItem is Patient) {
			isFilled = true;
			// Iets van Animatie/Sound/Feedback
		}
		else if (interactedItem is Altar) {
			if (!isFilled)
				return;
			GameManager.instance.currentPatient.TurnZombie ();
			Destroy (this.gameObject);
		}
		else {
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