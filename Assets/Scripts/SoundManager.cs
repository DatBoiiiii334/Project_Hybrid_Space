using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance = null; 

	[SerializeField] private float masterVolume = 1f;

	private void Awake () {
		//Singleton of the SoundManager
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

	///<summary>
	/// PlaySound plays am Audioclip at a specific location.
	///</summary>
	public void PlaySoundEffect (AudioClip clip, float volume, Vector3 pos) {
		if (clip != null) {
			AudioSource.PlayClipAtPoint (clip, pos, masterVolume * volume);
		}
	}

}
