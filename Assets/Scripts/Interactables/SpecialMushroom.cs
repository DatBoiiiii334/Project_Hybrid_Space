using UnityEngine;
using System.Collections;

public class SpecialMushroom : Item {

	private Vector3 targetSize;

	private void OnEnable () {
		targetSize = this.transform.localScale;
		this.transform.localScale = new Vector3 (0, 0, 0);
		StartCoroutine (Growth ());
	}

	IEnumerator Growth () {
		Vector3 growthAmount = new Vector3 (0.01f, 0.01f, 0.01f);

		while (this.transform.localScale.x < targetSize.x) {
			this.transform.localScale += growthAmount;
			yield return null;
		}
		this.transform.localScale = targetSize;
	}

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

		// Play sound
		// Animations
		// Je neus

	}

}