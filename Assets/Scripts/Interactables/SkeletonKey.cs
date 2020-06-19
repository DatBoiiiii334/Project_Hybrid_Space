using UnityEngine;

public class SkeletonKey : Item {

	[SerializeField] private AudioClip keyCling;
	[SerializeField] private AudioClip keyTurnSound;


	private void OnEnable () {
		SoundManager.instance.PlaySoundEffect (keyCling, 1f, this.transform.position);
	}

	public override void OnCollisionEnter (Collision collision) {
		base.OnCollisionEnter (collision);

		if (interactedItem == null)
			return;

		if (interactedItem is Chest) {
			interactedItem.OnInteract ();
		} else {
			return;
		}

		UseItem ();
	}


	public override void UseItem () {
		base.UseItem ();

		SoundManager.instance.PlaySoundEffect (keyTurnSound, 1, this.transform.position);

		// Animations
		// Je neus

	}

}