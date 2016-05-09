using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PistolBehaviour : MonoBehaviour {

    public GameObject gun;
    public GameObject text;

    void OnTriggerEnter() {
        gun.SetActive(true);
        text.SetActive(true);
        text.GetComponent<Text>().CrossFadeAlpha(0, 10, false);
        Destroy(gameObject);
    }
}
