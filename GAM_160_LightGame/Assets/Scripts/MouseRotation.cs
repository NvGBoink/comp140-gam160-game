using UnityEngine;
using System.Collections;

public class MouseRotation : MonoBehaviour {

    public GameObject cam;
    public float sensitivity;

    [HideInInspector]
    public bool canMove = true;

    float x;
    float y;

    float newCameraX = 0;

    public void ReciveInput(float hor, float ver)
    {
        x = hor * sensitivity;
        y = -ver * sensitivity;
    }

    void Update()
    {
        if (canMove)
        {
            transform.Rotate(new Vector3(0, x, 0));

            if (cam != null)
            {
                newCameraX += y;
                newCameraX = Mathf.Clamp(newCameraX, -90, 90);
                cam.transform.localRotation = Quaternion.Euler(new Vector3(newCameraX, 0, 0));
            }
        }
    }
}
