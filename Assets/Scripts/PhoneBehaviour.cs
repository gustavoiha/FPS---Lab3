using UnityEngine;
using System.Collections;
using System;

public class PhoneBehaviour : MonoBehaviour {

    private PhoneBorder border;

    public GameObject cameraFlash;
    //bool shotStarted = false;

	// Use this for initialization
	void Start () {
        border = GetComponent<PhoneBorder>();
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetMouseButton(1) /*|| Input.GetAxis("360 Left Trigger") > 0*/) && (Input.GetMouseButtonDown(0) /*|| (Input.GetAxis("360 Right Trigger") > 0 && !shotStarted)*/))
        {
            //shotStarted = true;
            StartCoroutine(CameraFlash());

            GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemyList)
            {
                if (enemy.GetComponent<Renderer>().isVisible)
                    enemy.GetComponent<EnemyBehaviour>().TakeDamage();                
            }
        }
        /*else if (Input.GetAxis("360 Right Trigger") == 0)
            shotStarted = false;*/
        if (Input.GetMouseButton(1) /*|| Input.GetAxis("360 Left Trigger") > 0*/) {
            this.GetComponent<Camera>().enabled = true;
            border.enabled = true;
        } else {
            this.GetComponent<Camera>().enabled = false;
            border.enabled = false;
        }
	}

    IEnumerator Fade(float start, float end, float length, GameObject currentObject) { 
        if (currentObject.GetComponent<GUITexture>().color.a == start) {
            Color curColor;
            for (float i = 0.0f; i < 1.0f; i += Time.deltaTime * (1 / length))  {
                //Copies the colour
                curColor = currentObject.GetComponent<GUITexture>().color;

                //Linear interpolation from beginning to final transparency
                curColor.a = Mathf.Lerp(start, end, i);

                //Copies back to the original object
                currentObject.GetComponent<GUITexture>().color = curColor;

                yield return null;
            }
            curColor = currentObject.GetComponent<GUITexture>().color;

            //Holds the final interpolation
            curColor.a = end;
            currentObject.GetComponent<GUITexture>().color = curColor;
        }
    }

    IEnumerator CameraFlash() {
        yield return StartCoroutine(Fade(0.0f, 0.5f, 0.2f, cameraFlash));
        yield return StartCoroutine(Fade(0.5f, 0.0f, 0.2f, cameraFlash));
        StopCoroutine("CameraFlash");
    }
}
