using UnityEngine;

public class Vial : Item {

	private MeshFilter meshFilter;

	[SerializeField] private AudioClip liquidAudio;

	[Header("Liquid Filled Meshes")]
	[SerializeField] private Mesh bloodMesh;
	[SerializeField] private Mesh pusMesh;

	bool isFilled = false;
	bool containsBlood = false;
	bool containsPus = false;

	private void Start () {
		meshFilter = this.gameObject.GetComponent<MeshFilter> ();
	}

	public override void OnCollisionEnter (Collision collision) {
		base.OnCollisionEnter (collision);

		if (interactedItem == null)
			return;

		if (interactedItem is Wound && !isFilled) {
			meshFilter.mesh = bloodMesh;
			containsBlood = true;
			isFilled = true;
		}
		else if (interactedItem is Cyst && !isFilled) {
			meshFilter.mesh = pusMesh;
			containsPus = true;
			isFilled = true;
		}

		else if (interactedItem is Patient) {
			//Doe dingen
		} else {
			return;
		}

		UseItem ();
	}

	public override void UseItem () {
		base.UseItem ();

		SoundManager.instance.PlaySoundEffect (liquidAudio, 1, this.transform.position);

		// Animations
		// Je neus

	}

}
