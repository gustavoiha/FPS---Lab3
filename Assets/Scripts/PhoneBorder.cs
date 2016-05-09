using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PhoneBorder : MonoBehaviour {

    public GUISkin phoneSkin;

    //Distance top left
    public int xOffset = -30;
    public int yOffset = 0;
    //Distance bot right
    public int xExtend = 80;
    public int yExtend = 20;

	void OnGUI() {
        if (phoneSkin)
            GUI.skin = phoneSkin;
        Camera cam = transform.GetComponent<Camera>();

        //Creates a box for our camera
        GUI.Box(new Rect(cam.pixelRect.x + xOffset, (Screen.height - cam.pixelRect.yMax) + yOffset, cam.pixelWidth + xExtend, cam.pixelHeight + yExtend), "");
    }
}
