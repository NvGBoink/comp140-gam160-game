using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            LockMouse();
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            UnLockMouse();
        }
    }

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnLockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
