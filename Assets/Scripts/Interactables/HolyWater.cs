using UnityEngine;

public class HolyWater : Item {

	[SerializeField] private AudioClip pouringSound;

	public override void OnCollisionEnter (Collision collision) {
		base.OnCollisionEnter (collision);

		if (interactedItem == null)
			return;

		else if (interactedItem is Patient) {
			GameManager.instance.currentPatient.BurnZombie ();
			// Iets van feedback
		}
		else {
			return;
		}

		UseItem ();
	}


	public override void UseItem () {
		base.UseItem ();

		SoundManager.instance.PlaySoundEffect (pouringSound, 1, this.transform.position);

		// Animations
		// Je neus

	}
}