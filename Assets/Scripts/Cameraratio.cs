using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraratio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera camera2 = GetComponent<Camera>();
        Rect rect2 = camera2.rect;
        float scaleheight2 = ((float)Screen.width / Screen.height) / ((float)9 / 16); // (가로 / 세로)
        float scalewidth2 = 1f / scaleheight2;
        if (scaleheight2 < 1)
        {
            rect2.height = scaleheight2;
            rect2.y = (1f - scaleheight2) / 2f;
        }
        else
        {
            rect2.width = scalewidth2;
            rect2.x = (1f - scalewidth2) / 2f;
        }
        camera2.rect = rect2;
    }

    void OnPreCull() => GL.Clear(true, true, Color.black);


}
