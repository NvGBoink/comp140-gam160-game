using UnityEngine;
using System.Collections;

public class CharacterInput : MonoBehaviour {

    public KeyCode sneakKey = KeyCode.LeftShift;
    public KeyCode flashLightKey = KeyCode.Mouse0;

    CharacterMotor charMotor;
    MouseRotation mouseRotation;
    FlashLight flashLight;

    void Awake()
    {
        charMotor = GetComponent<CharacterMotor>();
        mouseRotation = GetComponent<MouseRotation>();
        flashLight = GetComponent<FlashLight>();
    }

	void Update()
    {
        if (charMotor != null)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            bool isSneaking = Input.GetKey(sneakKey);

            charMotor.ReciveInput(hor, ver, isSneaking);
        }

        if (mouseRotation != null)
        {
            float hor = Input.GetAxis("Mouse X");
            float ver = Input.GetAxis("Mouse Y");

            mouseRotation.ReciveInput(hor, ver);
        }

        if (flashLight != null)
        {
            float chargeInput = Input.GetAxis("Mouse ScrollWheel");
            bool toggleLight = Input.GetKeyDown(flashLightKey);

            flashLight.ReciveInput(chargeInput, toggleLight);
        }
    }

}
