using UnityEngine;
using System.Collections;

public class BobbingAnimation : MonoBehaviour {

    private float elapsedTime;

    private float startingY;
    private CharacterController controller;

    public float magnitude = 0.2f;
    public float frequency = 10;

    public bool alwaysBob = false;

	// Use this for initialization
	void Start () {
        startingY = transform.localPosition.y;
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (alwaysBob)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            if ((Input.GetAxis("Horizontal") != 0.0f) || (Input.GetAxis("Vertical") != 0.0f))
                elapsedTime += Time.deltaTime;
        }
        float yOffset = Mathf.Sin(elapsedTime * frequency) * magnitude;

        if (controller && !controller.isGrounded)
            return;
        Vector3 pos = transform.position;
        pos.y = transform.parent.transform.position.y + startingY + yOffset;
        transform.position = pos;
	}
}
