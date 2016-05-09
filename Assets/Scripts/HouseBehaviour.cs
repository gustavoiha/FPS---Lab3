using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HouseBehaviour : MonoBehaviour {

	void OnTriggerEnter (Collider collider){
		if (collider.gameObject.CompareTag ("Player") && GameController.collectiblesCollected >= GameController.collectiblesTotal)
			SceneManager.LoadScene ("level2");
		else
			gameObject.GetComponent<AudioSource> ().Play ();


	}

}
