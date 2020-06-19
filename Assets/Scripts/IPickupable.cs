using UnityEngine;

public interface IPickupable {

	void UseItem ();

	void OnCollisionEnter (Collision collision);

}
