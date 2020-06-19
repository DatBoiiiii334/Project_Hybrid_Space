using UnityEngine;

public class Maggot : Item {

	[SerializeField] private AudioClip maggotRustle;

	public override void OnCollisionEnter (Collision collision) {
		base.OnCollisionEnter (collision);

		if (interactedItem == null)
			return;

		if (interactedItem is Wound) {
			GameManager.instance.currentPatient.MaggotWound ((Wound) interactedItem);
		}

		else if (interactedItem is Patient) {
			GameManager.instance.currentPatient.EatenByMaggots ();
		}
		else {
			return;
		}

		UseItem ();
	}

	public override void UseItem () {
		base.UseItem ();

		SoundManager.instance.PlaySoundEffect (maggotRustle, 1, this.transform.position);

		// Animations
		// Je neus

	}

}
