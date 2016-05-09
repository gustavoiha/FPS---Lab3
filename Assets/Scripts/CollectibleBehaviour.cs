using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectibleBehaviour : MonoBehaviour {

	public GameObject textObj;

	void OnTriggerEnter (Collider collider){
		if (!collider.gameObject.CompareTag ("Player"))
			return;

		GameController.Collected ();

		Text text = textObj.GetComponent<Text> ();

		textObj.SetActive(true);
		text.text = GameController.collectibleTexts[GameController.collectiblesCollected - 1];
		SetAlpha (text.GetComponent<Text> (), 1);
		text.CrossFadeAlpha(1, 0, false);
		text.CrossFadeAlpha(0, 5, false);
		Destroy(gameObject);
	}

	public void SetAlpha(Text gui, float alpha)
    {
        gui.color = new Color(gui.color.r, gui.color.g, gui.color.b, alpha);
    }


}
