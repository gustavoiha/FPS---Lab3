using UnityEngine;
using System.Collections;

public class WaterBehaviour : MonoBehaviour {

    public Transform startPos;

	void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
            other.transform.position = startPos.position;
    }
}
