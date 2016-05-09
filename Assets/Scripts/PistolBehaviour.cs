using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PistolBehaviour : MonoBehaviour {

    public GameObject gun;
    public GameObject textObj;

    void OnTriggerEnter() {
		gun.SetActive(true);
		textObj.SetActive(true);

		Text text = textObj.GetComponent<Text> ();

		text.text = "You will need this weapon for what will come.";
		text.CrossFadeAlpha(1, 0, false);
		text.CrossFadeAlpha(0, 10, false);
		Destroy(gameObject);
    }

}
